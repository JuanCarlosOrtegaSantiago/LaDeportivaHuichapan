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
    /// Lógica de interacción para GenerarLosTorneos.xaml
    /// </summary>
    public partial class GenerarLosTorneos : Window
    {
        enum accion
        {
            nuevo,
            editar
        }
        accion AccionTorneos;
        IManejadorDeEquipo manejadorDeEquipo;
        IManejadorDeTorneo manejadorDeTorneo;
        IManejadorDeDeportes manejadorDeDeportes;
        Torneo torneo;
        public GenerarLosTorneos()
        {
            InitializeComponent();

            manejadorDeEquipo = new ManejadorDeEquipo(new RepositorioDeEquipo());
            manejadorDeTorneo = new ManejadorDeTorneo(new RepositorioDeTorneo());
            manejadorDeDeportes = new ManejadorDeDeporte(new RepositorioDeDeporte());

            HabilitarBotones(true);
            HabilitarCombos(false);
            ActualizarCombos();
            ActualizarTablaDeTorneos();
            lstvDeEquiposEnTorneo.ItemsSource = null;
        }

        private void ActualizarTablaDeTorneos()
        {
            lstvTorneos.ItemsSource = null;
            lstvTorneos.ItemsSource = manejadorDeTorneo.listar;
        }

        private void ActualizarCombos()
        {
            cmbxNombreDeporte.ItemsSource = null;
            cmbxNombreDeporte.ItemsSource = manejadorDeDeportes.listar;
            cmbxNombreEquipo.ItemsSource = null;
            cmbxNombreEquipo.ItemsSource = manejadorDeEquipo.listar;
            cmbxNombreTorneo.ItemsSource = null;
            cmbxNombreTorneo.ItemsSource = manejadorDeTorneo.listar;
        }

        private void HabilitarCombos(bool v)
        {
            cmbxNombreDeporte.IsEnabled = v;
            cmbxNombreEquipo.IsEnabled = v;
            cmbxNombreTorneo.IsEnabled = v;
        }

        private void HabilitarBotones(bool habilitado)
        {
            btnNuevo.IsEnabled = habilitado;
            btnElimiar.IsEnabled = habilitado;
            btnGuardar.IsEnabled = !habilitado;
            btnRegresar.IsEnabled = habilitado;
            btnCancelar.IsEnabled = !habilitado;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaDeSeleccion pagina = new VentanaDeSeleccion();
            pagina.Show();
            this.Close();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarBotones(false);
            HabilitarCombos(true);
            AccionTorneos = accion.nuevo;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarBotones(true);
            HabilitarCombos(false);
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbxNombreDeporte.SelectedItem != null)
            {
                if (cmbxNombreEquipo.SelectedItem != null)
                {
                    torneo.equipos.Add(cmbxNombreEquipo.SelectedItem as Equipo);
                    ActualizarTablaDeEquiposEnTorneo();
                }
                else
                {
                    MensajeDeNoSeleccinado("Equipo");
                }
            }
            else
            {
                MensajeDeNoSeleccinado("Deporte");
            }

               
        }

        private void ActualizarTablaDeEquiposEnTorneo()
        {
            lstvDeEquiposEnTorneo.ItemsSource = null;
            lstvDeEquiposEnTorneo.ItemsSource = torneo.equipos;
        }

        private void MensajeDeNoSeleccinado(string v)
        {
            MessageBox.Show("Aun no has seleccionado ningun " + v, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if(cmbxNombreDeporte.SelectedItem !=null && cmbxNombreEquipo.SelectedItem != null)
            {
                torneo = cmbxNombreTorneo.SelectedItem as Torneo;
                torneo.deporte = cmbxNombreDeporte.SelectedItem as Deporte;
                if (manejadorDeTorneo.Modificar(torneo))
                {
                    MessageBox.Show("Se agregaron correctamento los jugadores", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);

                    HabilitarBotones(true);
                    HabilitarCombos(false);

                    ActualizarTablaDeTorneos();
                    lstvDeEquiposEnTorneo.ItemsSource = null;
                    //LimpearCombos();
                }
                else
                {
                    MessageBox.Show("Ocurion un error en la operacion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MensajeDeNoSeleccinado("elemento");
            }
        }

        private void cmbxNombreTorneo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccionTorneos == accion.nuevo)
            {
                torneo = cmbxNombreTorneo.SelectedItem as Torneo;
                torneo.equipos = new List<Equipo>();
            }
        }

        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            if (lstvDeEquiposEnTorneo.SelectedItem != null)
            {
                torneo.equipos.Remove(lstvDeEquiposEnTorneo.SelectedItem as Equipo);
                ActualizarTablaDeEquiposEnTorneo();
            }
            else
            {

                MensajeDeNoSeleccinado("Elementod e la lista");
            }
        }

        private void btnElimiar_Click(object sender, RoutedEventArgs e)
        {
            if (lstvTorneos.SelectedItem != null)
            {
                torneo = lstvTorneos.SelectedItem as Torneo;
                torneo.deporte = null;
                torneo.equipos = null;
                if (manejadorDeTorneo.Modificar(torneo))
                {
                    ActualizarTablaDeTorneos();
                    MessageBox.Show("Se han eliminado correctamente los datos", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ocurion un error en la operacion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
