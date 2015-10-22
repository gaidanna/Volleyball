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
        private OpenFileDialog openFileDlg;
        private string baseDirectoryPath;
        private string baseDirectoryToCombine;

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
            int[] ageArray;
            client = new VolleyballServiceClient();

            Positions = new string[] { "Middle Blocker", "Outside Hitter", "Right Side Hitter", "Opposite Hitter", "Libero", "Setter" };
            ageArray = Enumerable.Range(14, 60).ToArray();
            amplua.ItemsSource = Positions;
            playerAge.ItemsSource = ageArray;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool succededHeightParse;
            bool succededNumberParse;
            string path;
            bool isCaptain;
            string name;
            string playerAmplua;
            int number;
            bool validated;
            string stringNumber;
            int selectedTeamIndex;
            bool isDuplicated;
            string filepath;
           
            int age;
            int height;
            Player player;

            path = imagePath.Text;
            name = playerName.Text.Trim().ToUpper();
            playerAmplua = amplua.Text;


            stringNumber = playerNumber.Text.Trim();
            isCaptain = captainSign.IsChecked.Value;
            selectedTeamIndex = teamsCombobox.SelectedIndex;
            succededHeightParse = Int32.TryParse(playerHeight.Text, out height);
            succededNumberParse = Int32.TryParse(stringNumber, out number);

            validated = ValidatePlayer(name, stringNumber, playerAmplua, league, path, playerHeight.Text, playerAge.SelectedValue);

            if (validated)
            {
                age = (int)playerAge.SelectedValue;
                Int32.TryParse(playerHeight.Text, out height);
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
                    try
                    {
                        baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
                        baseDirectoryToCombine = baseDirectoryPath.Remove(baseDirectoryPath.Length - 21, 21);
                        string guidToDB = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(openFileDlg.FileName);
                        filepath = baseDirectoryToCombine + "VolleyballMvc\\Content\\Images\\" + guidToDB;
                        File.Copy(System.IO.Path.GetFullPath(path), filepath);
                        player = new Player(name, number, playerAmplua, isCaptain, league, guidToDB, age, height);

                        if (team == null)
                        {
                            var plInTeam = new PlayerInTeam(listOfTeams[teamsCombobox.SelectedIndex], player, DateTime.Now.Year);
                            var playerDict = player.ConvertInstanceToDictionary();
                            var plInTeamDict = plInTeam.ConvertInstanceToDictionary();

                            client.Insert(playerDict, Middleware.VolleyballService.TablesNames.Players);
                            client.Insert(plInTeamDict, Middleware.VolleyballService.TablesNames.PlayerInTeams);
                        }
                        else
                        {
                            playersList.Add(player);
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Unable to save file " + exp.Message);

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
            int selectedTeamIndex;
            List<Player> duplicatesList;
            string path;
            int index;
            int age;
            int height;
            string filepath;

            duplicatesList = new List<Player>();
            name = playerName.Text.Trim().ToUpper();
            playerAmplua = amplua.Text;
            stringNumber = playerNumber.Text.Trim();
            isCaptain = captainSign.IsChecked.Value;
            selectedTeamIndex = teamsCombobox.SelectedIndex;
            path = imagePath.Text;

            validated = ValidatePlayer(name, stringNumber, playerAmplua, league, path, playerHeight.Text, playerAge.SelectedValue);

            if (validated)
            {
                age = (int)playerAge.SelectedValue;
                Int32.TryParse(playerHeight.Text, out height);
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
                    }
                    else
                    {
                        duplicatesList = playersList.Where(pl => pl.Number == number).ToList();
                    }
                }

                if (duplicatesList.Count == 0 || (duplicatesList.Count == 1 && duplicatesList[0].Id == playerToUpdate.Id))
                {
                    baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
                    baseDirectoryToCombine = baseDirectoryPath.Remove(baseDirectoryPath.Length - 21, 21);
                    string guidToDB = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(openFileDlg.FileName);
                    filepath = baseDirectoryToCombine + "VolleyballMvc\\Content\\Images\\" + guidToDB;
                    File.Copy(System.IO.Path.GetFullPath(path), filepath);

                    index = playersList.IndexOf(playerToUpdate);
                    playerToUpdate.Amplua = playerAmplua;
                    playerToUpdate.Captain = isCaptain;
                    playerToUpdate.Name = name;
                    playerToUpdate.Number = number;
                    playerToUpdate.League = league;
                    playerToUpdate.Height = height;
                    playerToUpdate.Age = age;
                    playerToUpdate.ImagePath = guidToDB;

                    if (team == null)
                    {
                        var playerDict = playerToUpdate.ConvertInstanceToDictionary();
                        client.Update(playerDict, Middleware.VolleyballService.TablesNames.Players);
                    }
                    else
                    {
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
        }

        private bool ValidatePlayer(string name, string insertedNumber, string amplua, string league, string path, string insertedHeight, object insertedAge)
        {
            int number;
            int height;
            bool succededHeightParse;
            bool succededNumberParse;
            bool succededAgeParse;
            int age;

            Regex regex = new Regex(@"^[\p{L}\p{M}' \.\-]+$");

            if (insertedAge != null && insertedHeight != "" && insertedNumber != "")
            {
                succededHeightParse = Int32.TryParse(insertedHeight, out height);
                succededNumberParse = Int32.TryParse(insertedNumber, out number);
                succededAgeParse = Int32.TryParse(insertedAge.ToString(), out age);

                if (regex.IsMatch(name) && name.Length <= 50 && name.Length >= 2)
                {
                    if (succededNumberParse && number > 0 && number <= Int32.MaxValue)
                    {
                        if (amplua.Length > 0)
                        {
                            if (league.Length > 0)
                            {
                                if (succededHeightParse && height > 100 && height < 250)
                                {
                                    if (age != 0)
                                    {
                                        if (File.Exists(path))
                                        {
                                            return true;
                                        }
                                        else
                                        { MessageBox.Show("Please check path to image."); }
                                    }
                                    else
                                    { MessageBox.Show("Please specify age."); }
                                }
                                else
                                { MessageBox.Show("Please check inserted height."); }
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
                { MessageBox.Show("Please specify correct name."); }
            }
            else
            { MessageBox.Show("Please fullfill empty lines."); }
            return false;
        }

        private void ClearInputInfo()
        {
            playerName.Clear();
            playerNumber.Clear();
            captainSign.IsChecked = false;
            amplua.SelectedIndex = -1;
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
            teamsCombobox.SelectedIndex = -1;
        }

        private void RadioButtonFemale_Checked(object sender, RoutedEventArgs e)
        {
            league = RadioButtonFemale.Content.ToString();
            teamsCombobox.IsEnabled = true;
            teamsCombobox.SelectedIndex = -1;
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
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

        private void imageButton_Click(object sender, RoutedEventArgs e)
        {
            openFileDlg = new OpenFileDialog();
            openFileDlg.InitialDirectory = "C:\\";
            openFileDlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDlg.ShowDialog() == true)
            {
                imagePath.Text = openFileDlg.FileName;
            }
        }

        private void playerHeight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
