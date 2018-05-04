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
using System.Windows.Shapes;

namespace LaDeportivaHuichapan.GUI.Escritorio.Administrador
{
    /// <summary>
    /// Lógica de interacción para VentanaDeCambioDeContrasena.xaml
    /// </summary>
    public partial class VentanaDeCambioDeContrasena : Window
    {
        IManejadorDeContrasena manejadorDeContrasena;
        Contrasena contrasena;
        public VentanaDeCambioDeContrasena()
        {
            InitializeComponent();

            manejadorDeContrasena = new ManejadorDeContrasena(new RepositorioDeContrasena());
            lblError.Visibility = Visibility.Hidden;
            cmbxUsuario.ItemsSource = null;
            cmbxUsuario.ItemsSource = manejadorDeContrasena.listar;
            LimpiarCampos();


        }

        private void LimpiarCampos()
        {
            cmbxUsuario.Text = "";
            tbxContrasena.Clear();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbxUsuario.SelectedItem != null)
            {
                contrasena = cmbxUsuario.SelectedItem as Contrasena;
                //contrasena = new Contrasena();
                ObtenerDatos();
                
                if (manejadorDeContrasena.Modificar(contrasena))
                {
                    MessageBox.Show("Se cambio la contraseña ahora es " + contrasena.contrasena,"Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se pudo cambiar la contraseña", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aun no has seleccionado tu usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ObtenerDatos()
        {
            if(!string.IsNullOrWhiteSpace(tbxContrasena.Text))
            {
                contrasena.Nombre = "Administrador";
                contrasena.contrasena = tbxContrasena.Text;
            }
            
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaDeSeleccion pagina = new VentanaDeSeleccion();
            pagina.Show();
            this.Close();
        }
    }
}
