using System;
using System.Collections.Generic;
using System.Windows;
using Volleyball.ApplicationWindows;
using Middleware.VolleyballService;
using Middleware;

namespace Volleyball
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded( object sender , RoutedEventArgs e )
        {
            //VolleyballServiceClient client = new VolleyballServiceClient();
            //client.TryCreateTable("Players", Player.GetRowNames);
            //client.TryCreateTable("Teams", Team.GetRowNames);
            //client.TryCreateTable("Games", Game.GetRowNames);
            //client.TryCreateTable("PlayerInGames", PlayerInGame.GetRowNames);
            //client.TryCreateTable("PlayerInTeams", PlayerInTeam.GetRowNames);
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
