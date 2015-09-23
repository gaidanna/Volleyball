using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Middleware.VolleyballService;

namespace Volleyball.ApplicationWindows
{
    public partial class AddPlayerControl : UserControl
    {
        private Team firstTeam;
        private Team secondTeam;
        private Button saveBtn;
        private Button updateBtn;
        private TextBox txboxPlayerName;
        private TextBox txboxPlayerNumb;
        private ComboBox comboboxAmplua;
        private CheckBox checkboxCaptain;
        private Window parentWindow;
        VolleyballServiceClient client;
        private Dictionary<string, string> playerInfo;
        private string[] comboboxArray = new string[2];
        private string[] Positions = new string[] { "Middle Blocker", "Outside Hitter", "Right Side Hitter", "Opposite Hitter", "Libero", "Setter" };

        public AddPlayerControl()
        {
            InitializeComponent();
            txboxPlayerName = (TextBox)this.FindName("playerName");
            txboxPlayerNumb = (TextBox)this.FindName("playerNumber");
            comboboxAmplua = (ComboBox)this.FindName("amplua");
            checkboxCaptain = (CheckBox)this.FindName("captainSign");
            saveBtn = (Button)this.FindName("saveButton");
            updateBtn = (Button)this.FindName("updateButton");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            parentWindow = Window.GetWindow(this);
            comboboxAmplua.ItemsSource = Positions;
            comboboxAmplua.SelectedIndex = -1;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Player player;
            bool isCaptain;
            string name;
            string amplua;
            int number;
            bool validated;
            string stringNumber;

            client = new VolleyballServiceClient();
            name = txboxPlayerName.Text.Trim();
            amplua = comboboxAmplua.Text;
            stringNumber = txboxPlayerNumb.Text.Trim();
            isCaptain = checkboxCaptain.IsChecked.Value;

            validated = ValidatePlayer(name, stringNumber, amplua, isCaptain, AddTeamWindow.playersList);

            if (validated)
            {
                Int32.TryParse(stringNumber, out number);
                var otherplayer = AddTeamWindow.playersList.Find(pl => pl.Number == number);
                if (otherplayer == null)
                {
                    player = new Player(name, number, amplua, isCaptain);

                    var playerDict = player.ConvertInstanceToDictionary();
                    client.Insert( playerDict , Middleware.VolleyballService.TablesNames.Players );
                    AddTeamWindow.playersList.Add(player);
                    //playerInTeam = new PlayerInTeam(new Team, new Player(name, number));
                    //playerInTeam.Save();
                    AddTeamWindow.RefreshListBox();
                    //AddTeamWindow.listBox.ItemsSource = null;
                    //AddTeamWindow.listBox.ItemsSource = AddTeamWindow.playersList;
                    ClearInputInfo();
                    parentWindow.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Player with this number already exists.");
                }
            }
        }

        private bool ValidatePlayer(string name, string stringNumber, string amplua, bool captainCheckbox, List<Player> playersList)
        {
            int number;
            bool isNumber;
            Regex regex = new Regex(@"^[\p{L}\p{M}' \.\-]+$");

            isNumber = Int32.TryParse(stringNumber, out number);

            if (regex.IsMatch(name))
            {
                if (name.Length <= 50)
                {
                    if (isNumber && number > 0 && number <= Int32.MaxValue)
                    {
                        if (amplua.Length > 0)
                        {
                            if (captainCheckbox)
                            {
                                var foundPlayer = playersList.Find(pl => pl.Captain == true);

                                if (foundPlayer != null)
                                {
                                    MessageBox.Show("Captain already exists.Please uncheck checkbox and save again");
                                    return false;
                                }
                            }
                            return true;
                        }
                        else
                        { MessageBox.Show("Please select volleybal position."); }
                    }
                    else
                    { MessageBox.Show("Please check inserted number."); }
                }
                else
                { MessageBox.Show("Please shorten inserted name."); }
            }
            else
            { MessageBox.Show("Please specify correct name."); }
            return false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ClearInputInfo();
            parentWindow.Visibility = Visibility.Hidden;
        }

        private void ClearInputInfo()
        {
            txboxPlayerName.Clear();
            txboxPlayerNumb.Clear();
            checkboxCaptain.IsChecked = false;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            bool isCaptain;
            string name;
            string amplua;
            int number;
            bool validated;
            string stringNumber;
            Player tempPlayer;

            name = txboxPlayerName.Text.Trim();
            amplua = comboboxAmplua.Text;
            stringNumber = txboxPlayerNumb.Text.Trim();
            isCaptain = checkboxCaptain.IsChecked.Value;

            validated = ValidatePlayer(name, stringNumber, amplua, isCaptain, AddTeamWindow.playersList);

            if (validated)
            {
                playerInfo["Name"] = name;
                playerInfo["Number"] = stringNumber;
                playerInfo["Amplua"] = amplua;
                playerInfo["Captain"] = isCaptain.ToString();
                client.Update( playerInfo , Middleware.VolleyballService.TablesNames.Players );

                var player = AddTeamWindow.playersList.Find(pl => pl.Id.ToString() == playerInfo["Id"]);
                Int32.TryParse(stringNumber, out number);
                player.Name = name;
                player.Number = number;
                player.Amplua = amplua;
                player.Captain = isCaptain;

                //if (Player.Items.ContainsKey(player.Id))
                //{
                //    Player.Items[player.Id] = player;
                //}
                //else
                //{
                //    Player.Items.Add(player.Id, player);
                //}

                AddTeamWindow.RefreshListBox();//.listBox.ItemsSource = null;
                //AddTeamWindow.listBox.ItemsSource = AddTeamWindow.playersList;
                ClearInputInfo();
                parentWindow.Visibility = Visibility.Hidden;
            }
        }

        public void SetPlayerInfo(Dictionary<string, string> player)
        {
            txboxPlayerName.Text = player["Name"];
            txboxPlayerNumb.Text = player["Number"];
            comboboxAmplua.Text = player["Amplua"];

            if (player["Captain"] == "True")
            {
                checkboxCaptain.IsChecked = true;
            }
            playerInfo = player;

            saveBtn.Visibility = Visibility.Collapsed;
            updateBtn.Visibility = Visibility.Visible;
        }
    }
}
