using Middleware;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Middleware.VolleyballService;

namespace Volleyball.ApplicationWindows
{
    public partial class AddTeamWindow : Window
    {
        private string league;
        private static TextBox teamTxtBox;
        private TextBox managerTxtBox;
        private TextBox phoneTxtBox;
        private TextBox emailTxtBox;
        public static ListBox listBox;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private VolleyballServiceClient client;
        public static List<Player> playersList;
        private DispatcherTimer dispatcherTimer;
        private AddPlayerPreciseTeam addPlayerWindow;

        public AddTeamWindow()
        {
            InitializeComponent();
            client = new VolleyballServiceClient();
            playersList = new List<Player>();
            teamTxtBox = (TextBox)this.FindName("team");
            managerTxtBox = (TextBox)this.FindName("manager");
            phoneTxtBox = (TextBox)this.FindName("phone");
            emailTxtBox = (TextBox)this.FindName("email");
            listBox = (ListBox)this.FindName("listBoxPlayers");
            addButton = (Button)this.FindName("AddPlayer");
            updateButton = (Button)this.FindName("UpdatePlayer");
            deleteButton = (Button)this.FindName("DeletePlayer");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
            {
                addButton.Visibility = Visibility.Collapsed;
                updateButton.Visibility = Visibility.Visible;
                deleteButton.IsEnabled = true;
                dispatcherTimer.Start();
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            addButton.Visibility = Visibility.Visible;
            updateButton.Visibility = Visibility.Collapsed;
            deleteButton.IsEnabled = false;
        }

        //private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        //{
        //    ListBoxItem lbi = e.Source as ListBoxItem;

        //    if (lbi != null)
        //    {
        //        MessageBox.Show(lbi.Content.ToString() + " is selected.");
        //    }
        //}

        private void RadioButtonMale_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            league = radioButton.Content.ToString();
        }

        private void RadioButtonFemale_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            league = radioButton.Content.ToString();
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            addPlayerWindow = new AddPlayerPreciseTeam();
            bool? res = addPlayerWindow.ShowDialog();
        }

        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            Player pl;
            Player identifiedplayer;
            Dictionary<string,string> playerDict;

            pl = (Player)listBox.SelectedItem;
            playerDict = pl.ConvertInstanceToDictionary();
            client.Delete( playerDict , Middleware.VolleyballService.TablesNames.Players );

            identifiedplayer = playersList.Find(player => player.Id == pl.Id);
            playersList.Remove(identifiedplayer);
            //Player.Items.Remove(pl.Id);

            RefreshListBox();
        }

        public static void RefreshListBox()
        {
            listBox.ItemsSource = null;
            listBox.ItemsSource = playersList;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string teamName;
            string managerName;
            string phoneName;
            string emailName;
            Team team;
            PlayerInTeam plInTeam;
            Dictionary<string, string> teamDict;
            Dictionary<string, string> plInTeamDict;

            teamName = teamTxtBox.Text;
            managerName = managerTxtBox.Text;
            phoneName = phoneTxtBox.Text;
            emailName = emailTxtBox.Text;

            if (teamName != null && managerName != null && emailName != null && league != null && phoneName != null)
            {
                team = new Team(league, teamName, managerName, phoneName, emailName);
                teamDict = team.ConvertInstanceToDictionary();
                client.Insert( teamDict , Middleware.VolleyballService.TablesNames.Teams );

                foreach (var player in playersList)
                { 
                    plInTeam = new PlayerInTeam(team, player);
                    plInTeamDict = plInTeam.ConvertInstanceToDictionary();
                    client.Insert( plInTeamDict , Middleware.VolleyballService.TablesNames.PlayerInTeams );
                }
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Please check insreted information.");
            }   
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void UpdatePlayer_Click(object sender, RoutedEventArgs e)
        {
            Player pl;
            Dictionary<string, string> result;

            pl = (Player)listBox.SelectedItem;
            result = client.Read( pl.Id , Middleware.VolleyballService.TablesNames.Players );

            addPlayerWindow.SetPlayerInfo(result);
            bool? res = addPlayerWindow.ShowDialog();
        }
    }
}
