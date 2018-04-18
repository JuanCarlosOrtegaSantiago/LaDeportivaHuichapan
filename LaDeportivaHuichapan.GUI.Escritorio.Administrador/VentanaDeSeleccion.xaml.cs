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
    /// Lógica de interacción para VentanaDeSeleccion.xaml
    /// </summary>
    public partial class VentanaDeSeleccion : Window
    {
        public VentanaDeSeleccion()
        {
            InitializeComponent();
            lblNoSelecionado.Visibility = Visibility.Hidden;
            cmbxVentana.SelectedItem = itemSelecciona;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pagina = new MainWindow();
            pagina.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

            if (cmbxVentana.SelectedItem == itemSelecciona)

                lblNoSelecionado.Visibility = Visibility.Visible;
            
            if (cmbxVentana.SelectedItem == itemAltasYBajas)
            {
                VentanaReguistros pagina = new VentanaReguistros();
                pagina.Show();
                this.Close();
            }
            if (cmbxVentana.SelectedItem == itemGenerarDatos)
            {
                GenerarLosTorneos pagina = new GenerarLosTorneos();
                pagina.Show();
                this.Close();
            }
            if (cmbxVentana.SelectedItem == itemGenerarEquipos)
            {
                GenerarEquipos pagina = new GenerarEquipos();
                pagina.Show();
                this.Close();
            }
        }
    }
}

