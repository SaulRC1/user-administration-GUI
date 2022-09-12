using PracticaFinal_Saul_Rodriguez_Naranjo.tabs;
using PracticaFinal_Saul_Rodriguez_Naranjo.utilities;
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

namespace PracticaFinal_Saul_Rodriguez_Naranjo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void botonEnviarClicked(object sender, RoutedEventArgs e)
        {
            if(username.Text != null && password.Password != null)
            {
                UserRepository userRepository = UserRepository.getUserRepository();

                Boolean validCredentials = 
                    userRepository.checkValidCredentials(username.Text, password.Password);

                if(validCredentials)
                {
                    VentanaTabs ventanaTabs = new VentanaTabs();

                    ventanaTabs.Show();
                    this.Close();
                } 
                else
                {
                    MessageBox.Show("Credenciales Incorrectas");
                }
            }
        }
    }
}
