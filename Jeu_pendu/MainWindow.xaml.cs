using Jeu_pendu.Properties;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pendu
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Restart();
        }


        //johj

        // Initialisation de toutes les variables
        int nombre_erreur = 0;
        bool Lettre_dedans = false;
        string mot_devine = "";
        string mot_affiche = "";
        public string[] Mots = { "PATATE ", "ROULADE ", "FORCE ", "ORGANE ", "PILOTI ", "FARCEUR ", "MOTIVATION ", "VAILLANCE ", "BOULETTE ", "CONDUCTEUR " };
        // Méthode qui se lance quand on appuie sur oui, qui indique le mot à trouver, qui affiche le mot a deviner caché dans la textbox du bas et le met a jour chaque frame
        // tant que le joueur n'a ni gagné ni perdu, puis indique un message dépendant si il a gagné et passe instantanément au mot suivant (A REVOIR) 
        // !!! PRBLM IMPORTANT !!! LA METHODE NE SE LANCE PAS AU LANCEMENT, CE QUI EMPECHE D'AFFICHER LA TEXTBOX CORRECTEMENT.
        public void Restart()
        {
            Random var = new Random();
            mot_devine = Mots[var.Next(Mots.Length)];
            for (int i = 0; i < mot_devine.Length; i++)
            {
                mot_affiche += "_ ";
            }
            txt_mot_affiche.Text = mot_affiche;
        }


        // Quand on appuie sur un bouton, définie une variable i dans une boucle for qui vérifie si chaque caractère du mot_affiche correspond à la lettre du bouton
        // Si c'est le cas, créer un sous string qui prend tous les caractères strictement avant et après le "_ " correspondant et rajoute la lettre du bouton et défini Lettre_dedans comme vrai
        // Si l'on n'a pas trouvé de correspondante, on rajoute 1 au nombre d'erreur
        // Dans tous les cas on redéfini Lettre dedans comme faux a la fin pour s'en resservir dans les autres cas.
        private void Oui_Click(object sender, RoutedEventArgs e)
        {
            Restart();
            Recommence.Opacity = 0;
            Oui_BTN.Opacity = 0;
        }
        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string btnContent = btn.Content.ToString();
            for (int i = 0; i < mot_devine.Length; i++)
            {
                if (btnContent == mot_devine[i].ToString())
                {
                    Lettre_dedans = true;
                    mot_affiche = mot_affiche.Substring(0, 2 * i) + btnContent + " " + mot_affiche.Substring(2 * i + 2);
                }
            }
            if (Lettre_dedans == false)
            {
                nombre_erreur += 1;
            }
            if (nombre_erreur < 8)
            {
                Image_pendu.Source = new BitmapImage(new Uri("/Ressources/Pendu_" + nombre_erreur.ToString() + "_Erreur.jpg"));
            }
            if (nombre_erreur == 8)
            {
                Image_pendu.Source = new BitmapImage(new Uri("/Ressources/Pendu_Perdu.jpg"));
                txt_mot_affiche.Text = "Le mot était " + mot_devine + ".";
                Recommence.Opacity = 100;
                Oui_BTN.Opacity = 100;
            }
            if (mot_affiche == mot_devine)
            {
                Image_pendu.Source = new BitmapImage(new Uri("/Ressources/Pendu_Gagné.jpg"));
                txt_mot_affiche.Text = mot_affiche + ", vous avez gagné, bien joué !!!";
                Recommence.Opacity = 100;
                Oui_BTN.Opacity = 100;
            }
            Lettre_dedans = false;
            btn.IsEnabled = false;
        }
        private void Oui_Click(object sender, RoutedEventArgs e)
        {
            //toto
            if (Oui_BTN.Opacity == 0)
            {

            }
        }
    }
}