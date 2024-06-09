using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace SAE_201_MARATHON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private ObservableCollection<Coureur> LesCoureurs { get; set; }
        private bool isAddingNewCoureur = false;
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            

        }
        private void LoadData()
        {
            try
            {
                Coureur coureur = new Coureur();
                LesCoureurs = new ObservableCollection<Coureur>(coureur.ListCoureurs());
                dgCoureurs.ItemsSource = LesCoureurs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading coureurs: " + ex.Message);
            }
        }

        /*    --------------------    BUTTONS      -------------------      */

        public void ButtonConnexion(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = pswrdBox.Password;

            string connectionString = $"Server=localhost;" +
                                      "port=5432;" +
                                      "Database=base;" +
                                      "Search Path=public;" +
                                      $"uid={login};" +
                                      $"password={password};";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // If connection is successful, change the stack panel visibility
                    stackPanelConnexion.Visibility = Visibility.Hidden;
                    RechercheCourse.Visibility = Visibility.Visible;
                    gridCourse.Visibility = Visibility.Visible;

                    lbConnexion.Visibility = Visibility.Visible;
                    labelRechercheCourse.Visibility = Visibility.Visible;
                    labelRechercheCoureurs.Visibility = Visibility.Visible;
                    labelSelectionneCoureurs.Visibility = Visibility.Visible;
                    labelbMontantTotal.Visibility = Visibility.Visible;

                    lbConnexion.Background = Brushes.LawnGreen;
                    lbConnexion.TextDecorations = null;
                    labelRechercheCoureurs.Background = Brushes.LawnGreen;
                    labelRechercheCoureurs.TextDecorations = null;

                    labelRechercheCourse.Background = Brushes.GreenYellow;
                    labelRechercheCourse.TextDecorations = TextDecorations.Underline;
                }
                catch (Exception ex)
                {
                    // Log the exception message for debugging
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    MessageBox.Show("Identifiant ou mot de passe incorrect", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }



        private void Button_Suivant_1(object sender, RoutedEventArgs e)
        {
            RechercheCourse.Visibility = Visibility.Hidden;
            RechercheCoureurs.Visibility = Visibility.Visible;
            ListeRechercheCoureurs.Visibility = Visibility.Visible;

            gridCourse.Visibility = Visibility.Hidden;

            labelRechercheCoureurs.Background = Brushes.GreenYellow;
            labelRechercheCoureurs.TextDecorations = TextDecorations.Underline;

            lbConnexion.Background = Brushes.LawnGreen;
            lbConnexion.TextDecorations = null;

            labelRechercheCourse.TextDecorations = null;
            labelRechercheCourse.Background = Brushes.LawnGreen;

            labelSelectionneCoureurs.TextDecorations = null;
            labelSelectionneCoureurs.Background = Brushes.LawnGreen;
        }

        private void Button_Suivant_2(object sender, RoutedEventArgs e)
        {
            RechercheCoureurs.Visibility = Visibility.Hidden;
            ListeRechercheCoureurs.Visibility = Visibility.Hidden;
            SelectionCoureurs.Visibility = Visibility.Visible;

            labelSelectionneCoureurs.Background = Brushes.GreenYellow;
            labelSelectionneCoureurs.TextDecorations = TextDecorations.Underline;

            lbConnexion.Background = Brushes.LawnGreen;
            lbConnexion.TextDecorations = null;

            labelRechercheCourse.TextDecorations = null;
            labelRechercheCourse.Background = Brushes.LawnGreen;

            labelRechercheCoureurs.TextDecorations = null;
            labelRechercheCoureurs.Background = Brushes.LawnGreen;
        }

        private void Button_Precedent_1(object sender, RoutedEventArgs e)
        {
            RechercheCourse.Visibility = Visibility.Visible;
            RechercheCoureurs.Visibility = Visibility.Hidden;
            ListeRechercheCoureurs.Visibility = Visibility.Hidden;
            gridCourse.Visibility = Visibility.Visible;

            labelRechercheCourse.Background = Brushes.GreenYellow;
            labelRechercheCourse.TextDecorations = TextDecorations.Underline;

            lbConnexion.Background = Brushes.LawnGreen;
            lbConnexion.TextDecorations = null;

            labelRechercheCoureurs.TextDecorations = null;
            labelRechercheCoureurs.Background = Brushes.GreenYellow;

            labelbMontantTotal.Background = Brushes.LawnGreen;
            labelbMontantTotal.TextDecorations = null;

            labelSelectionneCoureurs.Background = Brushes.LawnGreen;
            labelSelectionneCoureurs.TextDecorations = null;
        }

        private void Button_Precedent_2(object sender, RoutedEventArgs e)
        {
            RechercheCoureurs.Visibility = Visibility.Visible;
            ListeRechercheCoureurs.Visibility = Visibility.Visible;
            SelectionCoureurs.Visibility = Visibility.Hidden;

            labelRechercheCoureurs.Background = Brushes.GreenYellow;
            labelRechercheCoureurs.TextDecorations = TextDecorations.Underline;

            labelSelectionneCoureurs.Background = Brushes.LawnGreen;
            labelSelectionneCoureurs.TextDecorations = null;

            lbConnexion.Background = Brushes.LawnGreen;
            lbConnexion.TextDecorations = null;

            labelRechercheCourse.Background = Brushes.LawnGreen;
            labelRechercheCourse.TextDecorations = null;

            labelbMontantTotal.Background = Brushes.LawnGreen;
            labelbMontantTotal.TextDecorations = null;
        }
        private void Button_Suivant_3(object sender, RoutedEventArgs e)
        {
            SelectionCoureurs.Visibility = Visibility.Hidden;
            ConfirmationInscription.Visibility = Visibility.Visible;

            labelbMontantTotal.Background = Brushes.GreenYellow;
            labelbMontantTotal.TextDecorations = TextDecorations.Underline;

            lbConnexion.Background = Brushes.LawnGreen;
            lbConnexion.TextDecorations = null;

            labelRechercheCourse.TextDecorations = null;
            labelRechercheCourse.Background = Brushes.LawnGreen;

            labelRechercheCoureurs.TextDecorations = null;
            labelRechercheCoureurs.Background = Brushes.LawnGreen;

            labelSelectionneCoureurs.Background = Brushes.LawnGreen;
            labelSelectionneCoureurs.TextDecorations = null;
        }

        private void Button_Confirmer(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Merci d'avoir confirmé", "Confirmation",
            MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Precedent_3(object sender, RoutedEventArgs e)
        {
            SelectionCoureurs.Visibility = Visibility.Visible;
            ConfirmationInscription.Visibility = Visibility.Hidden;

            labelSelectionneCoureurs.Background = Brushes.GreenYellow;
            labelSelectionneCoureurs.TextDecorations = TextDecorations.Underline;

            labelRechercheCoureurs.Background = Brushes.LawnGreen;
            labelRechercheCoureurs.TextDecorations = null;

            lbConnexion.Background = Brushes.LawnGreen;
            lbConnexion.TextDecorations = null;

            labelRechercheCourse.Background = Brushes.LawnGreen;
            labelRechercheCourse.TextDecorations = null;

            labelbMontantTotal.Background = Brushes.LawnGreen;
            labelbMontantTotal.TextDecorations = null;
        }

        private void Button_Deconnexion(object sender, RoutedEventArgs e)
        {
            stackPanelConnexion.Visibility = Visibility.Visible;
            RechercheCourse.Visibility = Visibility.Hidden;

            lbConnexion.Background = Brushes.GreenYellow;
            lbConnexion.TextDecorations = TextDecorations.Underline;

            labelRechercheCourse.Background = Brushes.LawnGreen;
            labelRechercheCourse.TextDecorations = null;

            labelRechercheCoureurs.TextDecorations = null;
            labelRechercheCoureurs.Background = Brushes.LawnGreen;

            gridCourse.Visibility = Visibility.Hidden;

            tbLogin.Text = string.Empty;
            pswrdBox.Password = string.Empty;

            lbConnexion.Visibility = Visibility.Visible;
            labelRechercheCourse.Visibility = Visibility.Hidden;
            labelRechercheCoureurs.Visibility = Visibility.Hidden;
            labelbMontantTotal.Visibility = Visibility.Hidden;
        }

        /*    --------------------    LABELS      -------------------      */
        private void connexionLabelClick(object sender, MouseButtonEventArgs e)
        {
            stackPanelConnexion.Visibility = Visibility.Visible;

            RechercheCourse.Visibility = Visibility.Hidden;
            RechercheCoureurs.Visibility = Visibility.Hidden;
            ListeRechercheCoureurs.Visibility = Visibility.Hidden;
            ConfirmationInscription.Visibility = Visibility.Hidden;
            SelectionCoureurs.Visibility = Visibility.Hidden;
            ConfirmationInscription.Visibility = Visibility.Hidden;
            gridCourse.Visibility = Visibility.Hidden;

            lbConnexion.Background = Brushes.GreenYellow;
            lbConnexion.TextDecorations = TextDecorations.Underline;

            labelRechercheCourse.Visibility = Visibility.Hidden;
            labelRechercheCoureurs.Visibility = Visibility.Hidden;
            labelSelectionneCoureurs.Visibility = Visibility.Hidden;
            labelbMontantTotal.Visibility = Visibility.Hidden;

            labelRechercheCourse.Background = Brushes.LawnGreen;
            labelRechercheCourse.TextDecorations = null;

            labelRechercheCoureurs.TextDecorations = null;
            labelRechercheCoureurs.Background = Brushes.LawnGreen;

            labelSelectionneCoureurs.Background = Brushes.LawnGreen;
            labelSelectionneCoureurs.TextDecorations = null;

            labelbMontantTotal.Background = Brushes.LawnGreen;
            labelbMontantTotal.TextDecorations = null;

            tbLogin.Text = string.Empty;
            pswrdBox.Password = string.Empty;
        }
        private void rechercherCourseLabelClick(object sender, MouseButtonEventArgs e)
        {
            RechercheCourse.Visibility = Visibility.Visible;

            stackPanelConnexion.Visibility = Visibility.Hidden;
            RechercheCoureurs.Visibility = Visibility.Hidden;
            ListeRechercheCoureurs.Visibility = Visibility.Hidden;
            ConfirmationInscription.Visibility = Visibility.Hidden;
            SelectionCoureurs.Visibility = Visibility.Hidden;
            ConfirmationInscription.Visibility = Visibility.Hidden;
            gridCourse.Visibility = Visibility.Visible;

            labelRechercheCourse.Background = Brushes.GreenYellow;
            labelRechercheCourse.TextDecorations = TextDecorations.Underline;

            lbConnexion.Background = Brushes.LawnGreen;
            lbConnexion.TextDecorations = null;

            labelRechercheCoureurs.TextDecorations = null;
            labelRechercheCoureurs.Background = Brushes.LawnGreen;

            labelSelectionneCoureurs.Background = Brushes.LawnGreen;
            labelSelectionneCoureurs.TextDecorations = null;

            labelbMontantTotal.Background = Brushes.LawnGreen;
            labelbMontantTotal.TextDecorations = null;

        }

        private void rechercherCoureursLabelClick(object sender, MouseButtonEventArgs e)
        {

            RechercheCoureurs.Visibility = Visibility.Visible;
            ListeRechercheCoureurs.Visibility = Visibility.Visible;

            SelectionCoureurs.Visibility = Visibility.Hidden;
            RechercheCourse.Visibility = Visibility.Hidden;
            stackPanelConnexion.Visibility = Visibility.Hidden;
            ConfirmationInscription.Visibility = Visibility.Hidden;
            ConfirmationInscription.Visibility = Visibility.Hidden;
            gridCourse.Visibility = Visibility.Hidden;

            labelRechercheCoureurs.Background = Brushes.GreenYellow;
            labelRechercheCoureurs.TextDecorations = TextDecorations.Underline;

            lbConnexion.Background = Brushes.LawnGreen;
            lbConnexion.TextDecorations = null;

            labelRechercheCourse.TextDecorations = null;
            labelRechercheCourse.Background = Brushes.LawnGreen;

            labelSelectionneCoureurs.Background = Brushes.LawnGreen;
            labelSelectionneCoureurs.TextDecorations = null;

            labelbMontantTotal.Background = Brushes.LawnGreen;
            labelbMontantTotal.TextDecorations = null;
        }


        private void selectionnerCoureursLabelClick(object sender, MouseButtonEventArgs e)
        {
            SelectionCoureurs.Visibility = Visibility.Visible;

            RechercheCoureurs.Visibility = Visibility.Hidden;
            ListeRechercheCoureurs.Visibility = Visibility.Hidden;
            RechercheCourse.Visibility = Visibility.Hidden;
            stackPanelConnexion.Visibility = Visibility.Hidden;
            ConfirmationInscription.Visibility = Visibility.Hidden;
            ConfirmationInscription.Visibility = Visibility.Hidden;
            gridCourse.Visibility = Visibility.Hidden;

            labelSelectionneCoureurs.Background = Brushes.GreenYellow;
            labelSelectionneCoureurs.TextDecorations = TextDecorations.Underline;

            lbConnexion.Background = Brushes.LawnGreen;
            lbConnexion.TextDecorations = null;

            labelRechercheCourse.TextDecorations = null;
            labelRechercheCourse.Background = Brushes.LawnGreen;

            labelRechercheCoureurs.Background = Brushes.LawnGreen;
            labelRechercheCoureurs.TextDecorations = null;

            labelbMontantTotal.Background = Brushes.LawnGreen;
            labelbMontantTotal.TextDecorations = null;
        }
        private void montantTotalLabelClick(object sender, MouseButtonEventArgs e)
        {
            ConfirmationInscription.Visibility = Visibility.Visible;

            SelectionCoureurs.Visibility = Visibility.Hidden;
            RechercheCoureurs.Visibility = Visibility.Hidden;
            ListeRechercheCoureurs.Visibility = Visibility.Hidden;
            RechercheCourse.Visibility = Visibility.Hidden;
            stackPanelConnexion.Visibility = Visibility.Hidden;
            gridCourse.Visibility = Visibility.Hidden;

            labelbMontantTotal.Background = Brushes.GreenYellow;
            labelbMontantTotal.TextDecorations = TextDecorations.Underline;

            labelSelectionneCoureurs.Background = Brushes.LawnGreen;
            labelSelectionneCoureurs.TextDecorations = null;

            lbConnexion.Background = Brushes.LawnGreen;
            lbConnexion.TextDecorations = null;

            labelRechercheCourse.TextDecorations = null;
            labelRechercheCourse.Background = Brushes.LawnGreen;

            labelRechercheCoureurs.Background = Brushes.LawnGreen;
            labelRechercheCoureurs.TextDecorations = null;
        }
        private void butModifier_Click(object sender, RoutedEventArgs e)
        {
            if (dgCoureurs.SelectedItem != null)
            {
                // Enable editing of PanelClient
                UCPanelClient.IsEnabled = true;
                butModifier.IsEnabled = true;

                // Set the DataContext to the selected item
                UCPanelClient.DataContext = dgCoureurs.SelectedItem;

                // Optionally change the button appearance or text
                butSouvgarder.ToolTip = "Enregistrer les modifications";
                butSouvgarder.IsEnabled = true;

                isAddingNewCoureur = false; // Set the flag to false for modifying an existing coureur
            }
            else
            {
                MessageBox.Show(this, "Veuillez sélectionner un coureur");
            }
        }

        private void butSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCoureurs.SelectedItem != null)
            {
                Coureur coureurSelectionne = (Coureur)dgCoureurs.SelectedItem;
                MessageBoxResult res = MessageBox.Show(this, "Etes-vous sûr de vouloir supprimer " + coureurSelectionne.PrenomCoureur + " " + coureurSelectionne.NomCoureur + " ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (res == MessageBoxResult.Yes)
                {
                    LesCoureurs.Remove(coureurSelectionne);
                    dgCoureurs.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show(this, "Veuillez sélectionner un coureur");
            }

        }

        private void butAjouter_Click(object sender, RoutedEventArgs e)
        {
            Coureur nouveauCoureur = new Coureur();
            UCPanelClient.DataContext = nouveauCoureur;
            UCPanelClient.IsEnabled = true;
            butSouvgarder.IsEnabled = true;

            butSouvgarder.ToolTip = "Enregistrer le nouveau coureur";

            isAddingNewCoureur = true;
        }

        private void butSouvgarder_Click(object sender, RoutedEventArgs e)
        {
            if (UCPanelClient.IsEnabled)
            {
                Coureur coureur = (Coureur)UCPanelClient.DataContext;

                if (isAddingNewCoureur)
                {
                    // Add new coureur
                    LesCoureurs.Add(coureur);
                }
                else
                {
                    // Update existing coureur
                    // No additional code needed if using ObservableCollection and INotifyPropertyChanged
                }

                // Disable editing after saving
                UCPanelClient.IsEnabled = false;
                butSouvgarder.IsEnabled = false;

                // Refresh the DataGrid
                dgCoureurs.Items.Refresh();

                // Reset the flag
                isAddingNewCoureur = false;
            }
        }

        private void Button_Rechercher(object sender, RoutedEventArgs e)
        {
            Coureur coureur = new Coureur();
            string nomRecherche = txbRechercherNom.Text.Trim().ToLower();
            string villeRecherche = tbVilleSelectionne.Text.Trim().ToLower();
            int searchFederationId = cbChoixFederation.SelectedIndex == 0 ? -1 : cbChoixFederation.SelectedIndex;

            List<Coureur> filtereCoureurs = coureur.ListCoureurs();

            if (!string.IsNullOrEmpty(nomRecherche))
            {
                filtereCoureurs = filtereCoureurs.Where(c => c.NomCoureur.ToLower().Contains(nomRecherche)).ToList();
            }

            if (!string.IsNullOrEmpty(villeRecherche))
            {
                filtereCoureurs = filtereCoureurs.Where(c => c.VilleCoureur.ToLower().Contains(villeRecherche)).ToList();
            }

            if (searchFederationId != -1)
            {
                filtereCoureurs = filtereCoureurs.Where(c => c.NumFederation == searchFederationId).ToList();
            }

            dgCoureurs.ItemsSource = filtereCoureurs;

        }

        private void dgCoureurs_Selectionnement(object sender, SelectionChangedEventArgs e)
        {
            if (dgCoureurs.SelectedItem != null)
            {
                UCPanelClient.DataContext = dgCoureurs.SelectedItem;
                UCPanelClient.IsEnabled = true;
            }
        }

        
    }

}
