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




        // Initialisation de toutes les variables
        int nombre_erreur = 0;
        bool Lettre_dedans = false;
        bool gagne = false;
        bool perdu = false;
        bool continuer = false;
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
        }
        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string btnContent = btn.Content.ToString();
            btn.IsEnabled = false;
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
            Lettre_dedans = false;
        }
        //private void A_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "A " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void B_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("B" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "B " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void C_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("C" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "C " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void D_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("D" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "D " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void E_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("E" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "E " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void F_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("F" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "F " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void G_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("G" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "G " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void H_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("H" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "H " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void I_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("I" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "I " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void J_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("J" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "J " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void K_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("K" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "K " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void L_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("L" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "L " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void M_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("M" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "M " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void N_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("N" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "N " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void O_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("O" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "O " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void P_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("P" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "P " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void Q_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("Q" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "Q " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void R_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("R" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "R " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void S_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("S" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "S " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void T_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("T" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "T " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void U_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("U" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "U " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void V_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("V" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "V " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void W_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("W" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "W " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void X_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("X" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "X " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void Y_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("Y" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "Y " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

        //private void Z_Click(object sender, RoutedEventArgs e)
        //{
        //    for (int i = 0; i < mot_devine.Length; i++)
        //    {
        //        if ("Z" == mot_devine[i].ToString())
        //        {
        //            Lettre_dedans = true;
        //            mot_affiche = mot_affiche.Substring(0, 2 * i) + "Z " + mot_affiche.Substring(2 * i + 2);
        //        }
        //    }
        //    if (Lettre_dedans == false)
        //    {
        //        nombre_erreur += 1;
        //    }
        //    Lettre_dedans = false;
        //}

    }
}