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

namespace volleyball_stat
{
    public partial class AddPlayerWindowa : Window
    {
        private Team firstTeam;
        private Team secondTeam;
        private TextBox txboxPlayerName;
        private TextBox txboxPlayerNumb;
        private ComboBox teamsCmbbox;
        private string[] comboboxArray = new string[2];
        private static List<TextBox> playerInfo = new List<TextBox>();
        //DataBaseSpy<Base> db = new DataBaseSpy();

        public AddPlayerWindowa()
        {
            InitializeComponent();
            txboxPlayerName = (TextBox)this.FindName("playerName");
            txboxPlayerNumb = (TextBox)this.FindName("playerNumber");
        }

        public static List<TextBox> TextBoxes
        {
            get { return playerInfo; }
        }

        private void Save_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            PlayerInTeam playerInTeam;
            string name;
            int number;
            bool isNumber;
            Team selectedTeam;

            playerInTeam = null;

            if (teamsCmbbox.SelectedIndex != -1)
            {
                
                playerInfo.Add(txboxPlayerName);
                playerInfo.Add(txboxPlayerNumb);

                name = txboxPlayerName.Text;
                isNumber = Int32.TryParse(txboxPlayerNumb.Text, out number);

                if (name.Length > 0 && isNumber)
                {
                    selectedTeam = GetTeamByName(teamsCmbbox.SelectedItem.ToString());
                    playerInTeam = new PlayerInTeam(new Team(selectedTeam.Name), new Player(name, number));
                    //playerInTeam.Save();
                    //Team.SetDataBase(db);
                    //player.Teams.Add(selectedTeam);
                    AddGameWindowa.ListBoxTeams[teamsCmbbox.SelectedIndex].ItemsSource = null;
                    AddGameWindowa.ListBoxTeams[teamsCmbbox.SelectedIndex].ItemsSource = selectedTeam.Players;

                    ClearInputInfo();
                }
                else
                { 
                    MessageBox.Show("Please check all fields.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }

        }

        private void Cancel_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            ClearInputInfo();
            this.Visibility = Visibility.Hidden;
        }

        private void teamsCombobox_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox cmBox = sender as ComboBox;
            RefreshComboBoxTeams(cmBox);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void RefreshComboBoxTeams(ComboBox combobox)
        {
            combobox.SelectedIndex = -1;
            combobox.ItemsSource = null;
            combobox.ItemsSource = comboboxArray;
        }

        private void ClearInputInfo()
        {
            RefreshComboBoxTeams(teamsCmbbox);
            txboxPlayerName.Clear();
            txboxPlayerNumb.Clear();
        }

        private Team GetTeamByName(string teamName)
        {
            return teamName == firstTeam.Name ? firstTeam : secondTeam;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            var textBoxesInfo = AddGameWindowa.TextBox;

            teamsCmbbox = (ComboBox)this.FindName("teamsCombobox");

            teamsCmbbox.SelectedIndex = -1;
            firstTeam = new Team(textBoxesInfo[0].Text);
            secondTeam = new Team(textBoxesInfo[1].Text);

            comboboxArray[0] = firstTeam.Name;
            comboboxArray[1] = secondTeam.Name;
        }
    }
}
