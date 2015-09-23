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
using System.Collections.ObjectModel;
using CustomAttributes;
using System.Reflection;
using System.IO;

namespace volleyball_stat
{

    public partial class AddWindow : Window
    {
        private string[] comboboxArray = new string[2];
        //private Game game;
        private Team firstTeam;
        private Team secondTeam;
        private static List<ListBox> listBoxes = new List<ListBox>();
        private TextBox txboxPlayerName;
        private TextBox txboxPlayerNumb;
        private TextBox teamName1;
        private TextBox teamName2;
        private ComboBox teamsCmbbox;
        private Button deleteButton;
        private Player selectedPlayer;
        private string league;
        private AddPlayer addplayerWindow;
        private static List<TextBox> teams = new List<TextBox>();

        public AddWindow()
        {
            ListBox listboxTeam1;
            ListBox listboxTeam2;

            InitializeComponent();

            listBoxes = new List<ListBox>();
            addplayerWindow = new AddPlayer();
            listboxTeam1 = (ListBox)this.FindName("listBoxTeam1");
            listboxTeam2 = (ListBox)this.FindName("listBoxTeam2");
            deleteButton = (Button)this.FindName("Delete_AddWindow");
            teamName1 = (TextBox)this.FindName("team1Name");
            teamName2 = (TextBox)this.FindName("team2Name");

            listBoxes.Add(listboxTeam1);
            listBoxes.Add(listboxTeam2);
            deleteButton.IsEnabled = false;
        }

        public static List<TextBox> TextBox
        {
            get { return teams; }
        }

        public static List<ListBox> ListBoxTeams
        {
            get { return listBoxes; }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void Save_AddWindow_Click(object sender, RoutedEventArgs e)
        {
            string mainJudge;
            string secondJudge;
            string location;
            Game gameInfo;
            Team team1;
            Team team2;
            TextBox txboxMainJudge;
            TextBox txboxSecondJudge;
            TextBox txtBoxLocation;
            //Serialization serialization;

            txboxMainJudge = (TextBox)this.FindName("mainJudge");
            txboxSecondJudge = (TextBox)this.FindName("secondJudge");
            txtBoxLocation = (TextBox)this.FindName("LocationTstBox");

            mainJudge = txboxMainJudge.Text;
            secondJudge = txboxSecondJudge.Text;
            location = txtBoxLocation.Text;

            gameInfo = new Game("male", mainJudge, secondJudge, location);
            team1 = new Team(teamName1.Text);
            team2 = new Team(teamName2.Text);
            gameInfo.Teams = new List<Team>() { team1, team2 };
            //serialization = new Serialization(); 
            //Serialization.WriteXML(gameInfo);

            //new ExternalDataBase().CreateGame(gameInfo);
            Serialization.Save();
            DialogResult = true;
            ////Close();
        }

        private void Cancel_AddWindow_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            //Close();
        }

        private void teamsCombobox_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox cmBox = sender as ComboBox;
            RefreshComboBoxTeams(cmBox);
        }

        private void Add_AddWindow_Click(object sender, RoutedEventArgs e)
        {
            teams.Clear();
            teams.Add(teamName1);
            teams.Add(teamName2);

            TextBlock team1Representation = (TextBlock)this.FindName("firstTeamName");
            TextBlock team2Representation = (TextBlock)this.FindName("secondTeamName");
            team1Representation.Text = teamName1.Text;
            team2Representation.Text = teamName2.Text;

            bool? res = addplayerWindow.ShowDialog();
        }

        private void Delete_AddWindow_Click(object sender, RoutedEventArgs e)
        {
            Team selectedTeam;

            selectedTeam = GetTeamByName(teamsCmbbox.SelectedItem.ToString());
            selectedPlayer.Teams.Clear();
            ListBoxRefresh(selectedTeam);
            //ClearInputInfo();
            //RefreshComboBoxTeams(teamsCmbbox);
            deleteButton.IsEnabled = false;
        }

        private void listBoxTeam1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deleteButton.IsEnabled = true;
            //ListBox lbi = (sender as ListBox);
            //selectedPlayer = lbi.SelectedItem as Player;

            //if (selectedPlayer != null)
            //{
            //    //ShowSelectedPlayer(selectedPlayer);
            //    teamsCmbbox.SelectedIndex = 0;
            //}
        }

        private void listBoxTeam2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deleteButton.IsEnabled = true;

            //ListBox lbi = (sender as ListBox);
            // selectedPlayer = lbi.SelectedItem as Player;

            // if (selectedPlayer != null)
            // {
            //     //ShowSelectedPlayer(selectedPlayer);
            //     teamsCmbbox.SelectedIndex = 1;
            // }
        }

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

        private void RefreshComboBoxTeams(ComboBox combobox)
        {
            combobox.SelectedIndex = -1;
            combobox.ItemsSource = null;
            combobox.ItemsSource = comboboxArray;
        }

        private Team GetTeamByName(string teamName)
        {
            return teamName == firstTeam.Name ? firstTeam : secondTeam;
        }

        private void ShowSelectedPlayer(Player player)
        {
            txboxPlayerName.Text = player.Name;
            txboxPlayerNumb.Text = player.Number.ToString();
        }

        private void ListBoxRefresh(Team selectedTeam)
        {
            string nameTeam = selectedTeam.Name;
            int indexOfTeam = teamsCmbbox.Items.IndexOf(nameTeam);

            listBoxes[indexOfTeam].ItemsSource = selectedTeam.Players;
        }

        private void ClearInputInfo()
        {
            RefreshComboBoxTeams(teamsCmbbox);
            txboxPlayerName.Clear();
            txboxPlayerNumb.Clear();
        }

        private static List<MethodInfo> AreTestedMembers()
        {
            List<MethodInfo> MethodsList = new List<MethodInfo>();

            string[] fileNames = Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach (var fn in fileNames)
            {
                if (!fn.EndsWith(".exe"))
                {
                    continue;
                }
                Assembly a = Assembly.LoadFrom(fn);

                foreach (var m in a.GetModules())
                {
                    foreach (var t in m.GetTypes())
                    {
                        foreach (var method in t.GetMethods())
                        {
                            if (method.GetCustomAttributes(typeof(IsTestedAttribute), (false)).Length > 0)
                            {
                                IsTestedAttribute[] attrs = (IsTestedAttribute[])method.GetCustomAttributes(typeof(IsTestedAttribute), false);

                                if (attrs.Length > 0)
                                {
                                    MethodsList.Add(method);
                                }
                            }
                        }
                    }
                }
            }
            return MethodsList;
        }

        //private void listBoxTeam1_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //listBoxes[0].ItemsSource = AreTestedMembers();
        //}
    }
}
