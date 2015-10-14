using Middleware;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Middleware.VolleyballService;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Data;

namespace Volleyball.ApplicationWindows
{
    public partial class AddTeamWindow : Window
    {
        private string league;
        private VolleyballServiceClient client;
        public static ObservableCollection<Player> playersList;
        //public static List<Player> playersList;
        private DispatcherTimer dispatcherTimer;
        private AddPlayer addPlayerWindow;
        private Team sampleTeam;
        private OpenFileDialog openFileDlg;

        public AddTeamWindow()
        {
            InitializeComponent();
            client = new VolleyballServiceClient();
            playersList = new ObservableCollection<Player>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //int[] yearsArray;

            //yearsArray = Enumerable.Range(2010, 50).ToArray();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            listBoxPlayers.ItemsSource = playersList;
            //participationYearInTeam.ItemsSource = yearsArray;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxPlayers.SelectedIndex != -1)
            {
                AddPlayer.Visibility = Visibility.Collapsed;
                UpdatePlayer.Visibility = Visibility.Visible;
                DeletePlayer.IsEnabled = true;
                dispatcherTimer.Start();
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            AddPlayer.Visibility = Visibility.Visible;
            UpdatePlayer.Visibility = Visibility.Collapsed;
            DeletePlayer.IsEnabled = false;
        }

        private void RadioButtonMale_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            league = radioButton.Content.ToString();
            AddPlayer.IsEnabled = true;
        }

        private void RadioButtonFemale_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            league = radioButton.Content.ToString();
            AddPlayer.IsEnabled = true;
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (sampleTeam == null)
            {
                sampleTeam = new Team(league, team.Text, manager.Text, phone.Text, email.Text, DateTime.Now.Year, imageUrl.Text);
            }
            addPlayerWindow = new AddPlayer(sampleTeam, playersList, league);
            bool? res = addPlayerWindow.ShowDialog();
        }

        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            Player pl;
            Player identifiedplayer;

            pl = (Player)listBoxPlayers.SelectedItem;

            identifiedplayer = playersList.FirstOrDefault(player => player.Id == pl.Id);
            if (identifiedplayer != null)
            {
                playersList.Remove(identifiedplayer);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            bool validated;
            string teamName;
            string managerName;
            string phoneName;
            string emailName;
            string filepath;
            string path;
            Team teamToSave;
            PlayerInTeam plInTeam;
            Dictionary<string, string> teamDict;
            Dictionary<string, string> plDict;
            Dictionary<string, string> plInTeamDict;

            teamName = team.Text;
            managerName = manager.Text;
            phoneName = phone.Text;
            emailName = email.Text;
            path = imageUrl.Text;

            validated = ValidateTeam(teamName, managerName, emailName, league, phoneName, imageUrl.Text);

            if (validated)
            {
                filepath = "D:\\Projects\\Volleyball\\VolleyballMvc\\Content\\Images\\" + Guid.NewGuid().ToString() + System.IO.Path.GetExtension(openFileDlg.FileName);
                File.Copy(Path.GetFullPath(path), filepath);

                teamToSave = new Team(league, teamName, managerName, phoneName, emailName, DateTime.Now.Year, filepath);
                teamDict = teamToSave.ConvertInstanceToDictionary();
                client.Insert(teamDict, Middleware.VolleyballService.TablesNames.Teams);

                foreach (var player in playersList)
                {
                    plInTeam = new PlayerInTeam(teamToSave, player);

                    plDict = player.ConvertInstanceToDictionary();
                    plInTeamDict = plInTeam.ConvertInstanceToDictionary();

                    client.Insert(plDict, Middleware.VolleyballService.TablesNames.Players);
                    client.Insert(plInTeamDict, Middleware.VolleyballService.TablesNames.PlayerInTeams);
                }
                this.Visibility = Visibility.Hidden;
            }
        }

        private bool ValidateTeam(string name, string managerName, string email, string league, string phone, string path)
        {
            Regex regex = new Regex(@"^[\p{L}\p{M}' \.\-]+$");

            if (regex.IsMatch(name) && name.Length <= 50 && name.Length >= 2)
            {
                if (regex.IsMatch(managerName) && managerName.Length <= 50 && managerName.Length >= 2)
                {
                    if (email.Length > 2 && email.Contains("@"))
                    {
                        if (league.Length > 0)
                        {
                            if (phone.Length >= 5 && phone.Length <= 13)
                            {
                                if (File.Exists(path))
                                { return true; }
                                else
                                { MessageBox.Show("Please check path to image."); }
                            }
                            else { MessageBox.Show("Please check phone number."); }
                        }
                        else
                        { MessageBox.Show("Please select league."); }
                    }
                    else
                    { MessageBox.Show("Please check email."); }
                }
                else
                { MessageBox.Show("Please specify correct manager name."); }
            }
            else
            { MessageBox.Show("Please specify correct team name."); }
            return false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void UpdatePlayer_Click(object sender, RoutedEventArgs e)
        {
            Player pl;
            Dictionary<string, string> result;

            pl = (Player)listBoxPlayers.SelectedItem;
            //result = client.Read( pl.Id , Middleware.VolleyballService.TablesNames.Players );
            addPlayerWindow.SetPlayerInfo(pl);
            bool? res = addPlayerWindow.ShowDialog();
        }

        private void phone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            openFileDlg = new OpenFileDialog();
            openFileDlg.InitialDirectory = "C:\\";
            openFileDlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDlg.ShowDialog() == true)
            {
                imageUrl.Text = openFileDlg.FileName;
            }
        }
    }
}
