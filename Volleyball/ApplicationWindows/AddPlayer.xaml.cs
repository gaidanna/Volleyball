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
using Volleyball.ServiceReference1;

namespace Volleyball
{
    public partial class AddPlayer : Window
    {
        private Team firstTeam;
        private Team secondTeam;
        private ComboBox teamsCmbbox;
        private string[] comboboxArray = new string[2];
        private static List<TextBox> playerInfo = new List<TextBox>();
        private AddPlayerControl playerControl;
        private static List<Dictionary<string, string>> allTeamsList;
        VolleyballServiceClient client;
        List<Team> listOfTeams;

        public AddPlayer()
        {
            InitializeComponent();
            AddControl.Children.Clear();

            if (playerControl == null)
            {
                playerControl = new AddPlayerControl();
            }
            AddControl.Children.Add(playerControl);
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
                allTeamsList = client.ReadAll(TablesNames.Teams, Gender.NotSpecified);
                foreach (var item in allTeamsList)
                {
                    listOfTeams.Add(new Team(item));
                }

            }
            teamsCombobox.ItemsSource = listOfTeams;
            //SetTeamsToCombobox(allTeamsList);
            //playerControl.saveButton.IsEnabled = false;
            playerControl.saveButton.Visibility = Visibility.Collapsed;
            playerControl.saveButton2.Visibility = Visibility.Visible;
        }


       

        public static List<Dictionary<string, string>> AllTeamsList
        {
            get { return allTeamsList; }
        }

       
        //private void SetTeamsToCombobox(List<Dictionary<string, string>> selectedList)
        //{
        //    List<string> teamNames;
        //    teamNames = selectedList.Select(team => team["NAME"]).ToList();

        //    teamsCombobox.ItemsSource = teamNames;
        //}
    }
}
