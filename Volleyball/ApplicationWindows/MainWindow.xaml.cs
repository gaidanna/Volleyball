using System.Windows;
using Volleyball.ApplicationWindows;


namespace Volleyball
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPlayer_Click( object sender , RoutedEventArgs e )
        {
            AddPlayer addPlayerWindow = new AddPlayer();
            bool? res = addPlayerWindow.ShowDialog();
        }

        private void AddTeam_Click( object sender , RoutedEventArgs e )
        {
            AddTeamWindow addTeam = new AddTeamWindow();
            bool? res = addTeam.ShowDialog();
        }

        private void AddGame_Click( object sender , RoutedEventArgs e )
        {
            AddGame addGame = new AddGame();
            bool? res = addGame.ShowDialog();
        }
    }
}
