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
using System.Windows.Shapes;

namespace PracticaFinal_Saul_Rodriguez_Naranjo.tabs.informacion
{
    /// <summary>
    /// Lógica de interacción para DatosCiudadano.xaml
    /// </summary>
    public partial class DatosCiudadano : Window
    {
        public DatosCiudadano()
        {
            InitializeComponent();
        }

        public void poblarDatos(Ciudadano ciudadano)
        {
            tbNombre.Text = ciudadano.getNombre();

            tbEdad.Text = "Edad: " + ciudadano.getEdad();

            tbEstadoCivil.Text = "Estado Civil: " + ciudadano.getEstadoCivil();

            tbSexo.Text = "Sexo: " + ciudadano.getSexo();

            String textoNacionalidades = "Nacionalidades: ";
            List<String> nacionalidades = ciudadano.getNacionalidades();

            foreach (String nacionalidad in nacionalidades)
            {
                textoNacionalidades += nacionalidad + " ";
            }

            tbNacionalidades.Text = textoNacionalidades;
        }
    }
}
