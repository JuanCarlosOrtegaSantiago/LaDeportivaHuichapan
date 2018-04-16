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
        
        public MainWindow()
        {
            InitializeComponent();
            LimpiarCajas();
            lblError.Visibility = Visibility.Hidden;
        }
        
        private void LimpiarCajas()
        {
            tbxUsuario.Clear();
            pwbxContrasena.Clear();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            //string contra = "juankx99";
            //string usuario = "juankx";
            //if (string.IsNullOrWhiteSpace(tbxUsuario.Text) || string.IsNullOrWhiteSpace(pwbxContrasena.Password))
            //{
            //    if (MessageBox.Show("Faltan datos por llenar ", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
            //    {
            //        LimpiarCajas();
            //        return;
            //    }
            //}
            //if (tbxUsuario.Text != usuario || pwbxContrasena.Password != contra)
            //{
            //    lblError.Visibility = Visibility.Visible;
            //    LimpiarCajas();
            //    return;
            //}
            //if (tbxUsuario.Text == usuario && pwbxContrasena.Password == contra)
            //{
                VentanaReguistros pagina = new VentanaReguistros();
                pagina.Show();
                this.Close();
            //}

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pwbxContrasena_PreviewDragEnter(object sender, DragEventArgs e)
        {
            MessageBox.Show("Presiono enter", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
