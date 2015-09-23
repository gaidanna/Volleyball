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

namespace Volleyball.ApplicationWindows
{
    public partial class AddScore : Window
    {
        public AddScore()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TeamOneName.Text = AddGame.TeamNames[0];
            TeamTwoName.Text = AddGame.TeamNames[1];
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            bool firstConverted;
            bool secondConverted;
            int scoreOne = 0;
            int scoreTwo = 0;

            firstConverted = Int32.TryParse(ScoreTeamOne.Text, out scoreOne);
            secondConverted = Int32.TryParse(ScoreTeamTwo.Text, out scoreTwo);

            if (firstConverted && secondConverted)
            {
                Tuple<int,int> score = new Tuple<int, int>(scoreOne, scoreTwo);
                AddGame.score.Add(score);
                //AddGame.scoreTeamOne.Add(scoreOne);
                //AddGame.scoreTeamTwo.Add(scoreTwo);
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Please check inserted information.");
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
