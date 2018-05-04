using LaDeportivaHuichapan.BIZ;
using LaDeportivaHuichapan.COMMON.Entidades;
using LaDeportivaHuichapan.COMMON.Interfaces;
using LaDeportivaHuichapan.DAL;
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

namespace LaDeportivaHuichapan.GUI.Escritorio.Administrador
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Contrasena usuario;
        IManejadorDeContrasena manejadorDeContrasena;
        public MainWindow()
        {
            InitializeComponent();

            manejadorDeContrasena = new ManejadorDeContrasena(new RepositorioDeContrasena());


            LimpiarCajas();
            cmbxUsuario.ItemsSource = null;
            cmbxUsuario.ItemsSource = manejadorDeContrasena.listar;
            lblError.Visibility = Visibility.Hidden;
        }
        
        private void LimpiarCajas()
        {
            cmbxUsuario.Text="";
            pwbxContrasena.Clear();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            ValidacionDeContrasena();

        }

        private void ValidacionDeContrasena()
        {
            

            if (cmbxUsuario.SelectedItem == null || string.IsNullOrWhiteSpace(pwbxContrasena.Password))
            {
                if (MessageBox.Show("Faltan datos por llenar ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                    LimpiarCajas();
                    return;
                }
            }
            else
            {
                usuario = cmbxUsuario.SelectedItem as Contrasena;
                string contra = usuario.contrasena;
                if (pwbxContrasena.Password != contra)
                {
                    lblError.Visibility = Visibility.Visible;
                    LimpiarCajas();
                    return;
                }
                if (pwbxContrasena.Password == contra)
                {
                    VentanaDeSeleccion pagina = new VentanaDeSeleccion();
                    pagina.Show();
                    this.Close();
                }

            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pwbxContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                ValidacionDeContrasena();
            }
        }

        //private void jk1(object sender, MouseEventArgs e)
        //{
        //    MessageBox.Show("Presiono enter 1", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //}

        //private void pwbxContrasena_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    MessageBox.Show("Presiono enter 1", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //} //este evento ocurre cuando el cursos pasa sobre un objeto

    }
}
