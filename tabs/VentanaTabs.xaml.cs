using PracticaFinal_Saul_Rodriguez_Naranjo.tabs.informacion;
using PracticaFinal_Saul_Rodriguez_Naranjo.utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticaFinal_Saul_Rodriguez_Naranjo.tabs
{
    /// <summary>
    /// Lógica de interacción para VentanaTabs.xaml
    /// </summary>
    public partial class VentanaTabs : Window, INotifyPropertyChanged
    {
        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies that a properties value has changed.
        /// </summary>
        /// <param name="propertyName">The property that has changed.</param>
        public virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //this.CheckForPropertyErrors();

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Ciudadanos Introducidos por el usuario
        private List<Ciudadano> ciudadanosIntroducidos = new List<Ciudadano>();
        
        public VentanaTabs()
        {
            InitializeComponent();
            DataContext = this;
            AppBackgroundColor = "#263340";
            UpperBorderColor = "#f1304d";
            TextColor = "White";
            FontSizePixels = 12;
            brushConverter = new BrushConverter();
            firstTab.Foreground = new SolidColorBrush(Colors.Black);
        }

        //Creamos BrushConverter para convertir los radio button a colores
        BrushConverter brushConverter;
        //Color de fondo de la aplicación
        private String appBackgroundColor;

        public String AppBackgroundColor
        {
            get { return appBackgroundColor; }
            set 
            { 
                appBackgroundColor = value;
                this.NotifyPropertyChanged();
            }
        }

        //Tamaño de fuente base
        private int fontSize;

        public int FontSizePixels
        {
            get { return fontSize; }
            set { fontSize = value; this.NotifyPropertyChanged(); }
        }


        //Color del borde superior del TabControl
        private String upperBorderColor;

        public String UpperBorderColor
        {
            get { return upperBorderColor; }
            set { upperBorderColor = value; this.NotifyPropertyChanged(); }
        }

        private String textColor;

        public String TextColor
        {
            get { return textColor; }
            set { textColor = value; this.NotifyPropertyChanged();}
        }


        private void tabFocused(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem)sender;

            if(!firstTab.IsSelected)
            {
                firstTab.Foreground = new SolidColorBrush(Colors.White);
            }

            if(tabItem != null)
            {
                tabItem.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void tabLostFocus(object sender, RoutedEventArgs e)
        {
            TabItem tabItem = (TabItem)sender;

            if (tabItem != null)
            {
                tabItem.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        private void changeBackgroundColor(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton selectedRadioButton 
                = (System.Windows.Controls.RadioButton)sender;

            if(sender != null)
            {

                AppBackgroundColor = selectedRadioButton.Name;
                
                    //(string)this.brushConverter.ConvertFromString(selectedRadioButton.Name);
                
            }
            
        }

        private void changeTextColor(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton selectedRadioButton 
                = (System.Windows.Controls.RadioButton)sender;

            if (sender != null)
            {

                TextColor = selectedRadioButton.Name;

                //(string)this.brushConverter.ConvertFromString(selectedRadioButton.Name);

            }
        }

        private void fontSizeChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider fontSizeSlider = (Slider)sender;

            if(fontSizeSlider != null)
            {
                FontSizePixels = (int)fontSizeSlider.Value;

                if(tbFontSize != null)
                {
                    tbFontSize.Text = Convert.ToString((int)fontSizeSlider.Value) + "px";
                }
                
            }
            
        }

        private void closeApp(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("¿Quiere salir de la aplicación?", "Salir de la aplicación", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                //Abrimos la ventana principal
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                //Cerrar la ventana
                this.Close();
            }
            else if (dialogResult == System.Windows.Forms.DialogResult.No)
            {
                //No hacer nada
            }
        }

        private void edadSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider edadSlider = (Slider)sender;

            if(edadSlider != null && edadTextBox != null)
            {
                edadTextBox.Text = Convert.ToString((int)edadSlider.Value) + " años";
            }
        }

        private void enviarFormulario(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button botonEnviarFormulario 
                = (System.Windows.Controls.Button)sender;
            
            if(botonEnviarFormulario != null)
            {
                if( validarFormulario() )
                {
                    Ciudadano ciudadano = new Ciudadano();

                    ciudadano.setEdad((int)edadSlider.Value);
                    ciudadano.setNombre(tbNombre.Text);

                    if(radioButtonCasado.IsChecked == true)
                    {
                        ciudadano.setEstadoCivil(Ciudadano.ESTADO_CIVIL_CASADO);
                    }
                    else if(radioButtonSoltero.IsChecked == true)
                    {
                        ciudadano.setEstadoCivil(Ciudadano.ESTADO_CIVIL_SOLTERO);
                    }
                    else if(radioButtonViudo.IsChecked == true)
                    {
                        ciudadano.setEstadoCivil(Ciudadano.ESTADO_CIVIL_VIUDO);
                    }

                    if(comboBoxSexo.SelectedIndex == 0)
                    {
                        ciudadano.setSexo(Ciudadano.SEXO_MASCULINO);
                    }
                    else
                    {
                        ciudadano.setSexo(Ciudadano.SEXO_FEMENINO);
                    }

                    if(checkboxEspanola.IsChecked == true)
                    {
                        ciudadano.addNacionalidad(Ciudadano.NACIONALIDAD_ESPANOLA);
                    }

                    if(checkboxFrancesa.IsChecked == true)
                    {
                        ciudadano.addNacionalidad(Ciudadano.NACIONALIDAD_FRANCESA);
                    }

                    if(checkboxItaliana.IsChecked == true)
                    {
                        ciudadano.addNacionalidad(Ciudadano.NACIONALIDAD_ITALIANA);
                    }

                    if(checkboxPortuguesa.IsChecked == true)
                    {
                        ciudadano.addNacionalidad(Ciudadano.NACIONALIDAD_PORTUGUESA);
                    }

                    ciudadanosIntroducidos.Add(ciudadano);

                    TextBlock ciudadanoParaLista = new TextBlock();
                    ciudadanoParaLista.Text = ciudadano.getNombre();
                    listaCiudadanos.Items.Add(ciudadanoParaLista);

                    DatosCiudadano datosCiudadanos = new DatosCiudadano();

                    datosCiudadanos.poblarDatos(ciudadano);
                    datosCiudadanos.Show();
                } 
                else
                {
                    System.Windows.MessageBox.Show("Formulario incorrecto, " +
                        "compruebe los campos por favor", "Formulario Incorrecto");
                }
                

                
            }

        }

        /**
         * Método que validara los datos del formulario
         * 
         * @return True - es válido | False - no es válido
         */
        private Boolean validarFormulario()
        {

            if(tbNombre.Text == null || tbNombre.Text.Length == 0)
            {
                return false;
            }

            if((checkboxEspanola.IsChecked == false) && (checkboxFrancesa.IsChecked == false) 
                && (checkboxItaliana.IsChecked == false) && (checkboxPortuguesa.IsChecked == false))
            {
                return false;
            }

            if (radioButtonCasado.IsChecked == false && radioButtonSoltero.IsChecked == false 
                && radioButtonViudo.IsChecked == false)
            {
                return false;
            }

            if(comboBoxSexo.SelectedItem == null)
            {
                return false;
            }

            return true;


        }

        private void ciudadanoSeleccionado(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ListBox list = (System.Windows.Controls.ListBox)sender;

            if(list != null)
            {
                Ciudadano ciudadano = this.ciudadanosIntroducidos.ElementAt(list.SelectedIndex);

                DatosCiudadano datosCiudadano = new DatosCiudadano();
                datosCiudadano.poblarDatos(ciudadano);

                datosCiudadano.Show();
            }
        }

        private void ocultarListaUnchecked(object sender, RoutedEventArgs e)
        {
            ToggleButton ocultarLista = (ToggleButton)sender;

            if (ocultarLista != null)
            {
                ocultarLista.Content = "Ocultar Lista";
                listaCiudadanos.Opacity = 1;
            }
        }

        private void ocultarListaChecked(object sender, RoutedEventArgs e)
        {
            ToggleButton ocultarLista = (ToggleButton)sender;

            if(ocultarLista != null)
            {
                ocultarLista.Content = "Visualizar Lista";
                listaCiudadanos.Opacity = 0;
            }
        }
    }
}
