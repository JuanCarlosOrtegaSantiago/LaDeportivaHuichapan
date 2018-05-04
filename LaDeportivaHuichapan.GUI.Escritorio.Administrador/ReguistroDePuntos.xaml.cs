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
    /// Lógica de interacción para ReguistroDePuntos.xaml
    /// </summary>
    public partial class ReguistroDePuntos : Window

    {
        IManejadorDeTorneo manejadorDeTorneo;
        IManejadorDePartida manejadorDePartida;
        Torneo torneo;
        Equipo equipo1;
        Equipo equipo2;
        public ReguistroDePuntos()
        {
            InitializeComponent();

            manejadorDeTorneo = new ManejadorDeTorneo(new RepositorioDeTorneo());
            manejadorDePartida = new ManejadorDePartida(new RepositorioDePartida());

            BotonesHabiltados(false);
            CombosHabilitados(false);
            cmbxNombreTorneo.ItemsSource = null;
            cmbxNombreTorneo.ItemsSource = manejadorDeTorneo.listar;
            LimpiarCampos();
            ActualziarTablas();
        }

        private void ActualziarTablas()
        {
            lstvTorneos.ItemsSource = null;
            lstvTorneos.ItemsSource = manejadorDeTorneo.listar;
            
        }

        private void LimpiarCampos()
        {
            cmbxNombreEquipo1.Text = "";
            cmbxNombreEquipo2.Text = "";
            cmbxNombreTorneo.Text = "";
            tbxEquipo1.Clear();
            tbxEquipo2.Clear();
            NombreEquipo1.Content = "Numero de goles del equipo 1:";
            NombreEquipo2.Content = "Numero de goles del equipo 2:";
        }

        private void ActualizarcomboEquipo()
        {
            if (cmbxNombreTorneo.SelectedItem != null)
            {
                torneo = cmbxNombreTorneo.SelectedItem as Torneo;
                cmbxNombreEquipo1.ItemsSource = null;
                cmbxNombreEquipo1.ItemsSource = torneo.equipos;

                cmbxNombreEquipo2.ItemsSource = null;
                cmbxNombreEquipo2.ItemsSource = torneo.equipos;
            }

        }

        private void CombosHabilitados(bool habilitado)
        {
            cmbxNombreEquipo1.IsEnabled = habilitado;
            cmbxNombreEquipo2.IsEnabled = habilitado;
            cmbxNombreTorneo.IsEnabled = habilitado;
            tbxEquipo1.IsEnabled = habilitado;
            tbxEquipo2.IsEnabled = habilitado;
        }

        private void BotonesHabiltados(bool habilitado)
        {

            btnCancelar.IsEnabled = habilitado;
            btnGuardar.IsEnabled = habilitado;
            btnNuevo.IsEnabled = !habilitado;
            btnRegresar.IsEnabled = !habilitado;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaDeSeleccion pagina = new VentanaDeSeleccion();
            pagina.Show();
            this.Close();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
            CombosHabilitados(true);
            BotonesHabiltados(true);
        }

        private void cmbxNombreTorneo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualizarcomboEquipo();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
            CombosHabilitados(false);
            BotonesHabiltados(false);
        }

        private void cmbxNombreEquipo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbxNombreEquipo1.SelectedItem != null)
            {
                equipo1 = cmbxNombreEquipo1.SelectedItem as Equipo;
                NombreEquipo1.Content = "Numero de goles de " + equipo1.Nombre + ":";
            }

        }

        private void cmbxNombreEquipo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbxNombreEquipo2.SelectedItem != null)
            {
                equipo2 = cmbxNombreEquipo2.SelectedItem as Equipo;
                NombreEquipo2.Content = "Numero de goles de " + equipo2.Nombre + ":";
            }

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Marcador1, Marcador2;
                Marcador1= int.Parse(tbxEquipo1.Text);
                Marcador2 = int.Parse(tbxEquipo2.Text);
                if (manejadorDePartida.AsignarPuntos(equipo1, Marcador1, equipo2, Marcador2))
                {
                    MessageBox.Show("Los Cambios se agregaron correctamente","Operacion Satisfactoria",MessageBoxButton.OK,MessageBoxImage.Information);
                    LimpiarCampos();
                    CombosHabilitados(false);
                    BotonesHabiltados(false);
                    ActualziarTablas();
                }
                else
                {
                    MessageBox.Show("Ocurrio algun error al guardar los cambios", "Operacion Incorrecta", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(""+ex.Message);
            }
        }
    }
}