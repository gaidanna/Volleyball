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
using Middleware.VolleyballService;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;
using System.Drawing;

namespace Volleyball
{
    public partial class AddPlayer : Window
    {
        VolleyballServiceClient client;
        List<Team> listOfTeams;
        private string league;
        private Player playerToUpdate;
        private Team team;
        private ObservableCollection<Player> playersList;

        private byte[] fileData;
        private string filename;
        private OpenFileDialog openFileDlg;
        //delegate void SavePlayerDelegate(Dictionary<string, string> dictionary, Middleware.VolleyballService.TablesNames tableName);

        public AddPlayer()
        {
            InitializeComponent();
        }

        public AddPlayer(Team team, ObservableCollection<Player> playersList, string selectedleague)
        {
            InitializeComponent();
            this.team = team;
            this.playersList = playersList;
            if (selectedleague == "Male")
            {
                RadioButtonMale.IsChecked = true;
                RadioButtonMale.IsEnabled = false;
                RadioButtonFemale.IsEnabled = false;
            }
            else
            {
                RadioButtonFemale.IsChecked = true;
                RadioButtonMale.IsEnabled = false;
                RadioButtonFemale.IsEnabled = false;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] Positions;
            client = new VolleyballServiceClient();

            Positions = new string[] { "Middle Blocker", "Outside Hitter", "Right Side Hitter", "Opposite Hitter", "Libero", "Setter" };
            amplua.ItemsSource = Positions;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Player player;
            bool isCaptain;
            string name;
            string playerAmplua;
            int number;
            bool validated;
            string stringNumber;
            int selectedTeamIndex;
            //List<Player> otherPlayers;
            bool isDuplicated;

            name = playerName.Text.Trim();
            playerAmplua = amplua.Text;
            stringNumber = playerNumber.Text.Trim();
            isCaptain = captainSign.IsChecked.Value;
            selectedTeamIndex = teamsCombobox.SelectedIndex;
            
            validated = ValidatePlayer(name, stringNumber, playerAmplua, league);
            
            if (validated)
            {
                Int32.TryParse(stringNumber, out number);
                if (team == null)
                {
                    isDuplicated = client.IsIdentifiedDuplicate(number, listOfTeams[selectedTeamIndex].Id, isCaptain);
                }
                else
                {
                    if (isCaptain)
                    {
                        isDuplicated = playersList.Any(pl => pl.Number == number || pl.Captain == true);
                    }
                    else
                    {
                        isDuplicated = playersList.Any(pl => pl.Number == number);
                    }
                }
                if (!isDuplicated)
                {
                    
                    player = new Player(name, number, playerAmplua, isCaptain, league);

                    if (team == null)
                    {
                        var plInTeam = new PlayerInTeam( listOfTeams[teamsCombobox.SelectedIndex], player);
                        var playerDict = player.ConvertInstanceToDictionary();
                        var plInTeamDict = plInTeam.ConvertInstanceToDictionary();

                        client.Insert(playerDict, Middleware.VolleyballService.TablesNames.Players);
                        client.Insert(plInTeamDict, Middleware.VolleyballService.TablesNames.PlayerInTeams);
                        //client.SaveImage(fileData, filename);

                        try
                        {
                            string iName = imageUrl.Text;
                            if (iName.Length > 0)
                            {
                                string filepath = "D:\\Source\\Volleyball\\Middleware\\Images\\" + Guid.NewGuid().ToString() + System.IO.Path.GetExtension(openFileDlg.FileName);

                                File.Copy(System.IO.Path.GetFullPath(iName), filepath);

                                //picProduct.Image = new Bitmap(opFile.OpenFile());
                            }
                        }

                        catch (Exception exp)
                        {

                            MessageBox.Show("Unable to open file " + exp.Message);

                        }
                    }
                    else
                    {
                        playersList.Add(player);
                    }
                    ClearInputInfo();
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Please check inserted information.");
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            bool isCaptain;
            string name;
            string playerAmplua;
            int number;
            bool validated;
            string stringNumber;
            Player tempPlayer;
            int selectedTeamIndex;
            List<Player> duplicatesList;
            bool isDuplicated;
            Player player;

            duplicatesList = new List<Player>();
            name = playerName.Text.Trim();
            playerAmplua = amplua.Text;
            stringNumber = playerNumber.Text.Trim();
            isCaptain = captainSign.IsChecked.Value;
            selectedTeamIndex = teamsCombobox.SelectedIndex;

            validated = ValidatePlayer(name, stringNumber, playerAmplua, league);
            
            if (validated)
            {
                Int32.TryParse(stringNumber, out number);
                if (team == null)
                {
                    var list = client.FindDuplicatedPlayers(number, listOfTeams[selectedTeamIndex].Id, isCaptain);
                    foreach (var item in list)
                    {
                        duplicatesList.Add(new Player(item));
                    }
                }
                else
                {
                    if (isCaptain)
                    {
                        duplicatesList = playersList.Where(pl => pl.Number == number || pl.Captain == true).ToList();

                        //var anotherPlayer = from r in playersList.AsEnumerable()
                        //                 where ((r.Number != number) || (r.Captain != true))
                        //                 select r;
                    }
                    else
                    {
                        duplicatesList = playersList.Where(pl => pl.Number == number).ToList();
                    }
                }

                    if (duplicatesList.Count== 0 || (duplicatesList.Count == 1 && duplicatesList[0].Id == playerToUpdate.Id))
                    {
                    
                    int index = playersList.IndexOf(playerToUpdate);
                    playerToUpdate.Amplua = playerAmplua;
                    playerToUpdate.Captain = isCaptain;
                    playerToUpdate.Name = name;
                    playerToUpdate.Number = number;
                    playerToUpdate.League = league;

                    if (team == null)
                    {
                        var playerDict = playerToUpdate.ConvertInstanceToDictionary();
                        client.Update(playerDict, Middleware.VolleyballService.TablesNames.Players);
                    }
                    else
                    {
                        //playersList.IndexOf(.FirstOrDefault(pl => pl.Id = playerToUpdate.Id);
                        //playersList.Remove(playerToUpdate);
                        playersList.RemoveAt(index);
                        playersList.Add(playerToUpdate);
                    }
                    ClearInputInfo();
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("Please check inserted information.");
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearInputInfo();
            this.Visibility = Visibility.Hidden;
            //parentWindow.Visibility = Visibility.Hidden;
        }

        private bool ValidatePlayer(string name, string stringNumber, string amplua, string league)
        {
            int number;
            bool isNumber;
            Regex regex = new Regex(@"^[\p{L}\p{M}' \.\-]+$");

            isNumber = Int32.TryParse(stringNumber, out number);

            if (regex.IsMatch(name))
            {
                if (name.Length <= 50 && name.Length >= 2)
                {
                    if (isNumber && number > 0 && number <= Int32.MaxValue)
                    {
                        if (amplua.Length > 0)
                        {
                            if (league.Length > 0)
                            {
                                return true;
                            }
                            else
                            { MessageBox.Show("Please select gender."); }
                        }
                        else
                        { MessageBox.Show("Please select volleybal position."); }
                    }
                    else
                    { MessageBox.Show("Please check inserted number."); }
                }
                else
                { MessageBox.Show("Please check inserted name."); }
            }
            else
            { MessageBox.Show("Please specify correct name."); }
            return false;
        }

        private void ClearInputInfo()
        {
            playerName.Clear();
            playerNumber.Clear();
            captainSign.IsChecked = false;
            amplua.SelectedIndex = -1;
            //teamsCombobox.SelectedIndex = -1;
        }

        public void SetPlayerInfo(Player player)
        {
            playerName.Text = player.Name;
            playerNumber.Text = player.Number.ToString();
            amplua.Text = player.Amplua;

            if (player.Captain)
            {
                captainSign.IsChecked = true;
            }
            if (player.League == "female")
            {
                RadioButtonFemale.IsChecked = true;
            }
            else
            {
                RadioButtonMale.IsChecked = true;
            }
            playerToUpdate = player;

            saveButton.Visibility = Visibility.Collapsed;
            updateButton.Visibility = Visibility.Visible;
        }

        private void RadioButtonMale_Checked(object sender, RoutedEventArgs e)
        {
            league = RadioButtonMale.Content.ToString();
            teamsCombobox.IsEnabled = true;
        }

        private void RadioButtonFemale_Checked(object sender, RoutedEventArgs e)
        {
            league = RadioButtonFemale.Content.ToString();
            teamsCombobox.IsEnabled = true;
        }

        private void teamsCombobox_DropDownOpened(object sender, EventArgs e)
        {
            List<Dictionary<string, string>> allTeamsList;

            listOfTeams = new List<Team>();
            allTeamsList = new List<Dictionary<string, string>>();

            var parsedLeague = Enum.Parse(typeof(Middleware.VolleyballService.Gender), league, true);

            if (team == null)
            {
                allTeamsList = new List<Dictionary<string, string>>(client.ReadAll(Middleware.VolleyballService.TablesNames.Teams, (Middleware.VolleyballService.Gender)parsedLeague));
                foreach (var item in allTeamsList)
                {
                    listOfTeams.Add(new Team(item));
                }
                teamsCombobox.ItemsSource = listOfTeams;
            }
            else
            {
                listOfTeams.Add(team);
                teamsCombobox.ItemsSource = listOfTeams;
            }
        }

        private void playerNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            
            openFileDlg = new OpenFileDialog();
            openFileDlg.InitialDirectory = "C:\\";
            openFileDlg.Filter = "Bmp(*.BMP;)|*.BMP;| Jpg(*Jpg)|*.jpg";
            if (openFileDlg.ShowDialog() == true)
            {

                //FileInfo fi = new FileInfo(openFileDlg.FileName);
                //FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                //filename = fi.FullName;
                //BinaryReader rdr = new BinaryReader(fs);
                //fileData = rdr.ReadBytes((int)fs.Length);
                //rdr.Close();
                //fs.Close();
                imageUrl.Text = openFileDlg.FileName;
                
            }
        }
    }
}
