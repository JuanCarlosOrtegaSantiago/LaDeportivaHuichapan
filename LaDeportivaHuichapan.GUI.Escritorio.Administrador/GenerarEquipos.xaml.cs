﻿using LaDeportivaHuichapan.BIZ;
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
    /// Lógica de interacción para GenerarEquipos.xaml
    /// </summary>
    public partial class GenerarEquipos : Window
    {
        enum accion
        {
            nuevo,
            editar
        }
        accion AccionEquipos;
        IManejadorDeEquipo manejadorDeEquipo;
        IManejadorDeJugador manejadorDeJugador;
        Equipo equipo;
        public GenerarEquipos()
        {
            InitializeComponent();

            manejadorDeEquipo = new ManejadorDeEquipo(new RepositorioDeEquipo());
            manejadorDeJugador = new ManejadorDeJugador(new RepositorioDeJugador());

            //cmbxNombreEquipo.SelectedItem = itemNombreEquipo;
            //cmbxNombreJugador.SelectedItem = itemJugador;
            LimpearCombos();
            HabilitarBotones(true);
            HabilitarCombos(false);
            ActualizarCombos();
            ActualizarTablaDeEquipo();
            lstvJugadoresEnEquipo.ItemsSource = null;
        }

        private void LimpearCombos()
        {
            cmbxNombreEquipo.ItemsSource = null;
            cmbxNombreJugador.ItemsSource = null;
        }

        private void ActualizarTablaDeJugadoresEnEquipo()
        {
            lstvJugadoresEnEquipo.ItemsSource = null;
            lstvJugadoresEnEquipo.ItemsSource = equipo.jugadores;
        }

        private void ActualizarTablaDeEquipo()
        {
            lstvTorneos.ItemsSource = null;
            lstvTorneos.ItemsSource = manejadorDeEquipo.listar;
        }

        private void HabilitarCombos(bool habilitado)
        {
            cmbxNombreJugador.IsEnabled = habilitado;
            cmbxNombreEquipo.IsEnabled = habilitado;
            btnQuitar.IsEnabled = habilitado;
            btnAgregar.IsEnabled = habilitado;
        }

        private void HabilitarBotones(bool habilitado)
        {
            btnNuevo.IsEnabled = habilitado;
            btnElimiar.IsEnabled = habilitado;
            btnGuardar.IsEnabled = !habilitado;
            btnRegresar.IsEnabled = habilitado;
            btnCancelar.IsEnabled = !habilitado;
        }

        private void ActualizarCombos()
        {
            cmbxNombreEquipo.ItemsSource = null;
            cmbxNombreEquipo.ItemsSource = manejadorDeEquipo.listar;

            cmbxNombreJugador.ItemsSource = null;
            cmbxNombreJugador.ItemsSource = manejadorDeJugador.listar;
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
            AccionEquipos = accion.nuevo;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarBotones(true);
            HabilitarCombos(false);
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbxNombreEquipo != null)
            {
                if (cmbxNombreJugador != null)
                {
                    equipo.jugadores.Add(cmbxNombreJugador.SelectedItem as Jugador);
                    ActualizarTablaDeJugadoresEnEquipo();
                }
                else
                {
                    MensajeDeNoSeleccinado("Jugador");
                }

            }
            else
            {
                MensajeDeNoSeleccinado("Equipo");
            }
        }

        private void MensajeDeNoSeleccinado(string v)
        {
            MessageBox.Show("Aun no has seleccionado ningun "+v,"Error",MessageBoxButton.OK,MessageBoxImage.Warning);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbxNombreEquipo != null && cmbxNombreJugador!=null)
            {
                equipo = cmbxNombreEquipo.SelectedItem as Equipo;
                if (manejadorDeEquipo.Modificar(equipo))
                {
                    MessageBox.Show("Se agregaron correctamento los jugadores", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);

                    HabilitarBotones(true);
                    HabilitarCombos(false);
                    //LimpearCombos();
                    ActualizarTablaDeEquipo();
                    lstvJugadoresEnEquipo.ItemsSource = null;
                }
                else
                {
                    MessageBox.Show("Ocurion un error en la operacion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MensajeDeNoSeleccinado("Elemento");
            }
        }

        private void cmbxNombreEquipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AccionEquipos== accion.nuevo)
            {
                equipo = cmbxNombreEquipo.SelectedItem as Equipo;
                equipo.jugadores = new List<Jugador>();
            }
 
        }

        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            if (lstvJugadoresEnEquipo.SelectedItem != null)
            {
                    equipo.jugadores.Remove(lstvJugadoresEnEquipo.SelectedItem as Jugador);
                    ActualizarTablaDeJugadoresEnEquipo();
            }
            else
            {
                MensajeDeNoSeleccinado("elemento de la lista");
            }
        }

        private void btnElimiar_Click(object sender, RoutedEventArgs e)
        {
            if(lstvTorneos.SelectedItem!= null)
            {
                equipo= lstvTorneos.SelectedItem as Equipo;
                equipo.jugadores = null;
                if (manejadorDeEquipo.Modificar(equipo))
                {
                    ActualizarTablaDeEquipo();
                    MessageBox.Show("Se agregaron correctamento los jugadores", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Ocurion un error en la operacion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MensajeDeNoSeleccinado("elemento de la lista");
            }
        }

    }
}
