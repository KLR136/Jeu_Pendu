using Jeu_pendu.Properties;
using System;
using System.IO;
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
    ///bouh
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
        // finito

        // Initialisation de toutes les variables
        int nombre_erreur = 0;
        bool Lettre_dedans = false;
        string mot_devine = "";
        string mot_affiche = "";
        string mot_affiche_sans_espace = "";
        public string[] Mots = {"BONJOUR", "CSHARP", "LISTE", "PROGRAMME", "INFORMATIQUE", "LANGAGE", "MODELE", "ENTRAINEMENT", "INTELLIGENCE", "ARTIFICIELLE", "DEVELOPPEMENT", "OPENAI", "GPT", "SYNTAXE", "VARIABLE", "BOUCLE", "CONDITION", "METHODE", "CLASSE"};
        public void Restart()
        {
            foreach (Button tout_bouton in Lettres.Children.OfType<Button>())
            {
                tout_bouton.IsEnabled = true;
            }
            Image_pendu.Source = new BitmapImage(new Uri("/Ressources/Pendu_0_Erreur.jpg", UriKind.Relative));
            mot_affiche = "";
            nombre_erreur = 0;
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
            if (Oui_BTN.Opacity == 100)
            { 
                Restart();
                Recommence.Opacity = 0;
                Oui_BTN.Opacity = 0;
            }
        }

        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string btnContent = btn.Content.ToString();
            StringBuilder newMotAffiche = new StringBuilder(mot_affiche);
            for (int i = 0; i < mot_devine.Length; i++)
            {
                if (btnContent == mot_devine[i].ToString())
                {
                    Lettre_dedans = true;
                    if (Char.IsLetter(mot_devine[i]))
                    {
                        newMotAffiche[i * 2] = btnContent[0];
                    }
                }
            }
            mot_affiche = newMotAffiche.ToString();
            txt_mot_affiche.Text = mot_affiche;

            if (Lettre_dedans == false)
            {
                nombre_erreur += 1;
            }
            if (nombre_erreur < 8)
            {
                Image_pendu.Source = new BitmapImage(new Uri("/Ressources/Pendu_" + nombre_erreur.ToString() + "_Erreur.jpg", UriKind.Relative));
            }
            if (nombre_erreur == 8)
            {
                Image_pendu.Source = new BitmapImage(new Uri("/Ressources/Pendu_Perdu.jpg", UriKind.Relative));
                txt_mot_affiche.Text = "Le mot était " + mot_devine + ".";
                Recommence.Opacity = 100;
                Oui_BTN.Opacity = 100;
                foreach (Button tout_bouton in Lettres.Children.OfType<Button>())
                {
                    tout_bouton.IsEnabled = false;
                }
            }
            mot_affiche_sans_espace = mot_affiche.Replace(" ", "");
            if (mot_affiche_sans_espace == mot_devine)
            {
                Image_pendu.Source = new BitmapImage(new Uri("/Ressources/Pendu_Gagné.jpg", UriKind.Relative));
                txt_mot_affiche.FontSize = 20;
                txt_mot_affiche.Text = mot_affiche + ", vous avez gagné, bien joué !!!";
                Recommence.Opacity = 100;
                Oui_BTN.Opacity = 100;
                foreach (Button tout_bouton in Lettres.Children.OfType<Button>())
                {
                    tout_bouton.IsEnabled = false;
                }
            }
            Lettre_dedans = false;
            btn.IsEnabled = false;
        }
    }
}