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
using Middleware.VolleyballService;
using System.Collections.ObjectModel;
using Middleware;

namespace Volleyball.ApplicationWindows
{
    public partial class AddGame : Window
    {
        private static List<ListBox> listBoxes = new List<ListBox>();
        private VolleyballServiceClient client;
        private List<Dictionary<string , string>> TeamsList;
        private List<Player> PlayersTeamOne;
        private List<Player> PlayersTeamTwo;
        private AddScore scoreWindow;
        private static List<string> teamNames;
        private string league;
        private Team teamOne;
        private Team teamTwo;

        public AddGame()
        {
            InitializeComponent();
        }

        private void Window_Loaded( object sender , RoutedEventArgs e )
        {
            client = new VolleyballServiceClient();
            score = new ObservableCollection<Tuple<int , int>>();
            TeamsList = new List<Dictionary<string , string>>();
            teamNames = new List<string>();

            listviewScore.ItemsSource = score;
        }

        public static ObservableCollection<Tuple<int , int>> score { get; set; }

        public static List<string> TeamNames
        {
            get
            { return teamNames; }
        }

        private void SaveButton_Click( object sender , RoutedEventArgs e )
        {
            string convertedScore;
            string mainReferee;
            string secondReferee;
            string location;
            DateTime date;
            PlayerInGame plInGame;
            Dictionary<string , string> gameDict;

            convertedScore = null;
            mainReferee = mainJudge.Text;
            secondReferee = secondJudge.Text;
            location = LocationTstBox.Text;
            try
            {
                date = datePicker.SelectedDate.Value;

                if ( mainReferee != null && secondReferee != null && location != null && date != null && league != null && score != null && teamOne != null && teamTwo != null )
                {

                    foreach ( var item in score )
                    {
                        convertedScore += String.Format( "{0};" , item );
                    }
                    Game game = new Game( league , mainReferee , secondReferee , location , date , teamOne , teamTwo , convertedScore );
                    gameDict = game.ConvertInstanceToDictionary();
                    client.Insert( gameDict , Middleware.VolleyballService.TablesNames.Games );
                    SaveplayerInGame( PlayersTeamOne , listviewTeamOne , "chBoxBestPlTeam1" , "chBoxYellowTeam1" , "chBoxRedTeam1" , game );
                    SaveplayerInGame( PlayersTeamTwo , listviewTeamTwo , "chBoxBestPlTeam2" , "chBoxYellowTeam2" , "chBoxRedTeam2" , game );

                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show( "Please check insreted information." );
                }
            }
            catch
            {
                MessageBox.Show("Somethind went wrong. Please try again.");
            }

        }

        private void SaveplayerInGame( List<Player> playersList , ListView listviewTeam , string checkBoxName1 , string checkBoxName2 , string checkBoxName3 , Game game )
        {
            Dictionary<string , string> plInGameDict;
            List<CheckBox> bestPlayer;
            List<CheckBox> yellowCard;
            List<CheckBox> redCard;

            plInGameDict = new Dictionary<string , string>();
            bestPlayer = GetSpecifiedCheckBoxes( listviewTeam , checkBoxName1 );
            yellowCard = GetSpecifiedCheckBoxes( listviewTeam , checkBoxName2 );
            redCard = GetSpecifiedCheckBoxes( listviewTeam , checkBoxName3 );

            for ( int i = 0 ; i < playersList.Count ; i++ )
            {
                var plInGame = new PlayerInGame( playersList[ i ] , bestPlayer[ i ].IsChecked.Value , yellowCard[ i ].IsChecked.Value , redCard[ i ].IsChecked.Value , game );
                plInGameDict = plInGame.ConvertInstanceToDictionary();
                client.Insert( plInGameDict , Middleware.VolleyballService.TablesNames.PlayerInGames );
            }
        }


        private void CancelButton_Click( object sender , RoutedEventArgs e )
        {
            this.Visibility = Visibility.Hidden;
        }

        private void RadioButtonMale_Checked( object sender , RoutedEventArgs e )
        {
            team1Name.IsEnabled = true;
            team2Name.IsEnabled = true;
            TeamsList.Clear();
            league = RadioButtonMale.Content.ToString();
        }

        private void RadioButtonFemale_Checked( object sender , RoutedEventArgs e )
        {
            team1Name.IsEnabled = true;
            team2Name.IsEnabled = true;
            TeamsList.Clear();
            league = RadioButtonFemale.Content.ToString();
        }

        private void SetTeamsToCombobox( List<Dictionary<string , string>> selectedList , ComboBox cmBox )
        {
            List<string> teamNames;
            teamNames = selectedList.Select( team => team[ "Name" ] ).ToList();

            cmBox.ItemsSource = teamNames;
        }

        private void team1Name_SelectionChanged( object sender , SelectionChangedEventArgs e )
        {
            var index = ( sender as ComboBox ).SelectedIndex;
            teamOne = new Team( TeamsList[ index ] );

            PlayersTeamOne = teamOne.Players;
            TeamOneName.Text = teamOne.Name; ;
            listviewTeamOne.ItemsSource = PlayersTeamOne;

            if ( team1Name.SelectedIndex != -1 && team2Name.SelectedIndex != -1 )
            {
                AddScore.IsEnabled = true;
            }
        }

        private void team2Name_SelectionChanged( object sender , SelectionChangedEventArgs e )
        {
            var index = ( sender as ComboBox ).SelectedIndex;
            teamTwo = new Team( TeamsList[ index ] );

            PlayersTeamTwo = teamTwo.Players;
            TeamTwoName.Text = teamTwo.Name;
            listviewTeamTwo.ItemsSource = PlayersTeamTwo;

            if ( team1Name.SelectedIndex != -1 && team2Name.SelectedIndex != -1 )
            {
                AddScore.IsEnabled = true;
            }
        }

        public List<Dictionary<string , string>> ShowTeamList()
        {
            List<Dictionary<string , string>> result;

            result = new List<Dictionary<string , string>>();

            if ( RadioButtonFemale.IsChecked.Value == true )
            {
                result = new List<Dictionary<string , string>>( client.ReadAll( Middleware.VolleyballService.TablesNames.Teams , Middleware.VolleyballService.Gender.Female ) );
            }
            else
            {
                result = new List<Dictionary<string , string>>( client.ReadAll( Middleware.VolleyballService.TablesNames.Teams , Middleware.VolleyballService.Gender.Male ) );
            }
            return result;
        }

        private void team1Name_DropDownOpened( object sender , EventArgs e )
        {
            if ( TeamsList.Count == 0 )
            {
                TeamsList = ShowTeamList();
            }
            SetTeamsToCombobox( TeamsList , team1Name );
        }

        private void team2Name_DropDownOpened( object sender , EventArgs e )
        {
            if ( TeamsList.Count == 0 )
            {
                TeamsList = ShowTeamList();
            }
            SetTeamsToCombobox( TeamsList , team2Name );
        }

        private void AddScore_Click( object sender , RoutedEventArgs e )
        {
            teamNames.Clear();
            teamNames.Add( team1Name.Text );
            teamNames.Add( team2Name.Text );
            scoreWindow = new AddScore();
            scoreWindow.DataContext = this;
            bool? res = scoreWindow.ShowDialog();
        }

        private void DeleteScore_Click( object sender , RoutedEventArgs e )
        {

        }

        private void Window_Closing( object sender , System.ComponentModel.CancelEventArgs e )
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void chBoxBestPlTeam1_Checked( object sender , RoutedEventArgs e )
        {
            CheckBox ch = sender as CheckBox;

            if ( ch != null && ch.IsChecked == true )
            {
                List<CheckBox> CheckedIteamList = GetSpecifiedCheckBoxes( listviewTeamOne , "chBoxBestPlTeam1" );

                foreach ( var item in CheckedIteamList )
                {
                    if ( item != ch )
                        item.IsEnabled = false;
                }
            }
        }

        private void chBoxBestPlTeam1_Unchecked( object sender , RoutedEventArgs e )
        {
            CheckBox ch = sender as CheckBox;

            if ( ch != null && ch.IsChecked == false )
            {
                List<CheckBox> CheckedIteamList = GetSpecifiedCheckBoxes( listviewTeamOne , "chBoxBestPlTeam1" );
                foreach ( var item in CheckedIteamList )
                {
                    item.IsEnabled = true;
                }
            }
        }

        private void chBoxBestPlTeam2_Checked( object sender , RoutedEventArgs e )
        {
            CheckBox ch = sender as CheckBox;

            if ( ch != null && ch.IsChecked == true )
            {
                List<CheckBox> CheckedIteamList = GetSpecifiedCheckBoxes( listviewTeamTwo , "chBoxBestPlTeam2" );

                foreach ( var item in CheckedIteamList )
                {
                    if ( item != ch )
                        item.IsEnabled = false;
                }
            }
        }

        private void chBoxBestPlTeam2_Unchecked( object sender , RoutedEventArgs e )
        {
            CheckBox ch = sender as CheckBox;

            if ( ch != null && ch.IsChecked == false )
            {
                List<CheckBox> CheckedIteamList = GetSpecifiedCheckBoxes( listviewTeamTwo , "chBoxBestPlTeam2" );
                foreach ( var item in CheckedIteamList )
                {
                    item.IsEnabled = true;
                }
            }
        }

        private List<CheckBox> GetSpecifiedCheckBoxes( ListView listView , string controlName )
        {
            List<CheckBox> resultedList = new List<CheckBox>();
            CheckBox control = null;
            foreach ( var item in listView.Items )
            {
                var container = listView.ItemContainerGenerator.ContainerFromItem( item );
                var children = GetAllChildren( container );
                control = ( CheckBox ) children.First( c => c.Name == controlName );
                resultedList.Add( control );
            }
            return resultedList;
        }

        public List<Control> GetAllChildren( DependencyObject parent )
        {
            var list = new List<Control> { };

            for ( int i = 0 ; i < VisualTreeHelper.GetChildrenCount( parent ) ; i++ )
            {
                var child = VisualTreeHelper.GetChild( parent , i );
                if ( child is Control )
                    list.Add( child as Control );
                list.AddRange( GetAllChildren( child ) );
            }
            return list;
        }
    }
}
