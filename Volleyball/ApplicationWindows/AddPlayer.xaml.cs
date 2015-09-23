using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Volleyball.ApplicationWindows;
using Middleware.VolleyballService;
using System.Text.RegularExpressions;

namespace Volleyball
{
    public partial class AddPlayer : Window
    {
        private string[] comboboxArray = new string[2];
        //private static List<TextBox> playerInfo = new List<TextBox>();
        private AddPlayerControl playerControl;
        private static List<Dictionary<string, string>> allTeamsList;
        VolleyballServiceClient client;
        List<Team> listOfTeams;
        private Dictionary<string, string> playerInfo;
        private string[] Positions = new string[] { "Middle Blocker", "Outside Hitter", "Right Side Hitter", "Opposite Hitter", "Libero", "Setter" };

        public AddPlayer()
        {
            InitializeComponent();
            //AddControl.Children.Clear();

            //if ( playerControl == null )
            //{
            //    playerControl = new AddPlayerControl();
            //}
            //AddControl.Children.Add( playerControl );
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            allTeamsList = new List<Dictionary<string, string>>();
            client = new VolleyballServiceClient();
            listOfTeams = new List<Team>();
            if (allTeamsList.Count == 0)
            {
                allTeamsList = new List<Dictionary<string, string>>(client.ReadAll(Middleware.VolleyballService.TablesNames.Teams, Middleware.VolleyballService.Gender.NotSpecified));
            }
            foreach (var item in allTeamsList)
            {
                listOfTeams.Add(new Team(item));
            }
            teamsCombobox.ItemsSource = listOfTeams;
            //SetTeamsToCombobox(allTeamsList);
            //playerControl.saveButton.IsEnabled = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Player player;
            bool isCaptain;
            string name;
            string playerAmplua;
            int number;
            bool validated;
            string stringNumber;
            int selectedTeamIndex;

            client = new VolleyballServiceClient();
            name = playerName.Text.Trim();
            playerAmplua = amplua.Text;
            stringNumber = playerNumber.Text.Trim();
            isCaptain = captainSign.IsChecked.Value;
            selectedTeamIndex = teamsCombobox.SelectedIndex;
            validated = ValidatePlayer(name, stringNumber, playerAmplua, isCaptain, listOfTeams[selectedTeamIndex].Id);

            if (validated)
            {
                Int32.TryParse(stringNumber, out number);
                var otherplayer = AddTeamWindow.playersList.Find(pl => pl.Number == number);
                if (otherplayer == null)
                {
                    player = new Player(name, number, playerAmplua, isCaptain);

                    var playerDict = player.ConvertInstanceToDictionary();
                    client.Insert(playerDict, Middleware.VolleyballService.TablesNames.Players);
                    AddTeamWindow.playersList.Add(player);
                    //playerInTeam = new PlayerInTeam(new Team, new Player(name, number));
                    //playerInTeam.Save();
                    AddTeamWindow.RefreshListBox();
                    //AddTeamWindow.listBox.ItemsSource = null;
                    //AddTeamWindow.listBox.ItemsSource = AddTeamWindow.playersList;
                    ClearInputInfo();
                    //parentWindow.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Player with this number already exists.");
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            bool isCaptain;
            string name;
            string playerAmplua;
            int number;
            bool validated;
            string stringNumber;
            Player tempPlayer;
            int selectedTeamIndex;

            name = playerName.Text.Trim();
            playerAmplua = amplua.Text;
            stringNumber = playerNumber.Text.Trim();
            isCaptain = captainSign.IsChecked.Value;
            selectedTeamIndex = teamsCombobox.SelectedIndex;
            validated = ValidatePlayer(name, stringNumber, playerAmplua, isCaptain, listOfTeams[selectedTeamIndex].Id);

            validated = ValidatePlayer(name, stringNumber, playerAmplua, isCaptain, listOfTeams[selectedTeamIndex].Id);

            if (validated)
            {
                playerInfo["playerName"] = name;
                playerInfo["Number"] = stringNumber;
                playerInfo["Amplua"] = amplua.SelectedValue.ToString();
                playerInfo["Captain"] = isCaptain.ToString();
                client.Update(playerInfo, Middleware.VolleyballService.TablesNames.Players);

                var player = AddTeamWindow.playersList.Find(pl => pl.Id.ToString() == playerInfo["Id"]);
                Int32.TryParse(stringNumber, out number);
                player.Name = name;
                player.Number = number;
                player.Amplua = playerAmplua;
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
                //parentWindow.Visibility = Visibility.Hidden;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearInputInfo();
            //parentWindow.Visibility = Visibility.Hidden;
        }

        private bool ValidatePlayer(string name, string stringNumber, string amplua, bool captainCheckbox, Guid teamId)
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
                            //if (captainCheckbox)
                            //{
                                var validated = client.ValidatePlayer(number, teamId, captainCheckbox);
                                    //playersList.Find(pl => pl.Captain == true);

                                if (!validated)
                                {
                                    MessageBox.Show("Captain already exists.Please uncheck checkbox and save again");
                                    return false;
                                }
                            //}
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

        private void ClearInputInfo()
        {
            playerName.Clear();
            playerNumber.Clear();
            captainSign.IsChecked = false;
        }

        public void SetPlayerInfo(Dictionary<string, string> player)
        {
            playerName.Text = player["Name"];
            playerNumber.Text = player["Number"];
            amplua.Text = player["Amplua"];

            if (player["Captain"] == "True")
            {
                captainSign.IsChecked = true;
            }
            playerInfo = player;

            saveButton.Visibility = Visibility.Collapsed;
            updateButton.Visibility = Visibility.Visible;
        }




        //private void SetTeamsToCombobox(List<Dictionary<string, string>> selectedList)
        //{
        //    List<string> teamNames;
        //    teamNames = selectedList.Select(team => team["NAME"]).ToList();

        //    teamsCombobox.ItemsSource = teamNames;
        //}
    }
}
