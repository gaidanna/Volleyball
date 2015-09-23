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
    /// <summary>
    /// Interaction logic for AddPlayerPreciseTeam.xaml
    /// </summary>
    public partial class AddPlayerPreciseTeam : Window
    {
        private AddPlayerControl playerControl;

        public AddPlayerPreciseTeam()
        {
            InitializeComponent();

            AddControl.Children.Clear();

            if (playerControl == null)
            {
                playerControl = new AddPlayerControl();
            }
            AddControl.Children.Add(playerControl);
        }

        public void SetPlayerInfo(Dictionary<string, string> player)
        { 
        playerControl.SetPlayerInfo(player);
        }
    }
}
