using Middleware;
using System;
using System.Collections.Generic;
using System.Windows;
using Volleyball.ApplicationWindows;
using Volleyball.Classes;
using Volleyball.ServiceReference1;

namespace Volleyball
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //TableInform x = new TableInform();
            //var resut = TableInform.Connection;

            //Player player = new Player("Vasya", 1);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.VolleyballServiceClient client = new VolleyballServiceClient();
            ////VolleyballService.VolleyballServiceClient client = new VolleyballService.VolleyballServiceClient();
            //Player p = new Player("zzz", 2, "Setter", true);
            Team t1 = new Team("Male", "m1", "sdsds", "sdsjdksd", "dsskdslk");
            Team t2 = new Team("Male", "m2", "sdsds", "sdsjdksd", "dsskdslk");
            Team t3 = new Team("Female", "f1", "sdsds", "sdsjdksd", "dsskdslk");
            Team t4 = new Team("Female", "f2", "sdsds", "sdsjdksd", "dsskdslk");
            client.Insert(t1.ConvertInstanceToDictionary(), TablesNames.Teams);
            client.Insert(t2.ConvertInstanceToDictionary(), TablesNames.Teams);
            client.Insert(t3.ConvertInstanceToDictionary(), TablesNames.Teams);
            client.Insert(t4.ConvertInstanceToDictionary(), TablesNames.Teams);

            //Team t2 = new Team("zfgdfdfdfd", "sdsds", "sdsds", "sdsjdksd", "dsskdslk");
            //Game g = new Game("female", "zz", "zz", "dsssaa", DateTime.Now, "24, 25; 4, 25", t1, t2);
            //PlayerInGame pg = new PlayerInGame(g, p);
            //PlayerInTeam pt = new PlayerInTeam(t1, p);

            ////var result = pg.ConvertInstanceToDictionary();
            ////var dictrtInstanceToDictionary() = b.Conve;
            //client.Insert(p.ConvertInstanceToDictionary(), TablesNames.Players);
            //client.Insert(t1.ConvertInstanceToDictionary(), TablesNames.Teams);
            //client.Insert(t2.ConvertInstanceToDictionary(), TablesNames.Teams);
            //client.Insert(g.ConvertInstanceToDictionary(), TablesNames.Games);
            //client.Insert(pg.ConvertInstanceToDictionary(), TablesNames.PlayerInGames);
            //client.Insert(pt.ConvertInstanceToDictionary(), TablesNames.PlayerInTeams);

            //List<Team> r1 = p.Teams;
            //var r2 = p.Games;
            //var r3 = t1.Games;
            //var r4 = t1.Players;
            //var r5 = g.Players;
            //var r6 = g.Teams;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddPlayer addPlayerWindow = new AddPlayer();
            bool? res = addPlayerWindow.ShowDialog();
        }

        private void AddTeam_Click(object sender, RoutedEventArgs e)
        {
            AddTeamWindow addTeam = new AddTeamWindow();
            bool? res = addTeam.ShowDialog();
        }

        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            AddGame addGame = new AddGame();
            bool? res = addGame.ShowDialog();

        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Teams_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Referees_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
