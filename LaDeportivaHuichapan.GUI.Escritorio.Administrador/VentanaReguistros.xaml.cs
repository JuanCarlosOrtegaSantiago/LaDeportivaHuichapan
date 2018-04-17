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
    /// Lógica de interacción para VentanaReguistros.xaml
    /// </summary>
    public partial class VentanaReguistros : Window
    {
        enum accion
        {
            nuevo,
            editar
        }
        accion accionDeDeporte;
        accion accionDeEquipo;
        accion accionDeJugador;
        accion accionDeTorneo;

        IManejadorDeDeportes manejadorDeDeporte;
        IManejadorDeEquipo manejadorDeEquipo;
        IManejadorDeJugador manejadorDeJugador;
        IManejadorDeTorneo manejadorDeTorneo;

        public VentanaReguistros()
        {
            InitializeComponent();

            manejadorDeDeporte = new ManejadorDeDeporte(new RepositorioDeDeporte());
            manejadorDeEquipo = new ManejadorDeEquipo(new RepositorioDeEquipo());
            manejadorDeJugador = new ManejadorDeJugador(new RepositorioDeJugador());
            manejadorDeTorneo = new ManejadorDeTorneo(new RepositorioDeTorneo());

            BotonesDeDeporteEnEdicion(false);
            LimpiarCajasDEDEporte();
            ActualizarTablaDeportes();

            BotonesDeEquipoEnEdicion(false);
            LimpiarcajasDeEquipo();
            ActualizarTablaDeEquipos();

            BotonesDeJugadorEnEdicion(false);
            LimpiarCajasDeJugador();
            ActualizarTablaDeJugadores();

            BotonesDeTorneoEnEdicion(false);
            LimpiarCajasDeTorneo();
            ActualizarTablaDeTorneos();
        }

        private void ActualizarTablaDeTorneos()
        {
            dtgTorneo.ItemsSource = null;
            dtgTorneo.ItemsSource = manejadorDeTorneo.listar;
        }

        private void LimpiarCajasDeTorneo()
        {
            tbxNombreDeTorneo.Clear();
        }

        private void BotonesDeTorneoEnEdicion(bool Habilitada)
        {
            btnCancelarTorneo.IsEnabled = Habilitada;
            btnEditarTorneo.IsEnabled = !Habilitada;
            btnEliminarTorneo.IsEnabled = !Habilitada;
            btnGuardarTorneo.IsEnabled = Habilitada;
            btnNuevoTorneo.IsEnabled = !Habilitada;
            tbxNombreDeTorneo.IsEnabled = Habilitada;
        }

        private void ActualizarTablaDeJugadores()
        {
            dtgJugador.ItemsSource = null;
            dtgJugador.ItemsSource = manejadorDeJugador.listar;
        }

        private void LimpiarCajasDeJugador()
        {
            tbxPosicionDeJugador.Clear();
            tbxNombreJugador.Clear();
            tbxSexioJugador.Clear();
        }

        private void BotonesDeJugadorEnEdicion(bool Habilitada)
        {
            btnCancelarJugador.IsEnabled = Habilitada;
            btnEditarJugador.IsEnabled = !Habilitada;
            btnEliminarJugador.IsEnabled = !Habilitada;
            btnGuardarJugador.IsEnabled = Habilitada;
            btnNuevoJugador.IsEnabled = !Habilitada;
            tbxPosicionDeJugador.IsEnabled = Habilitada;
            tbxNombreJugador.IsEnabled = Habilitada;
            tbxSexioJugador.IsEnabled = Habilitada;
        }

        private void ActualizarTablaDeEquipos()
        {
            dtgEquipo.ItemsSource = null;
            dtgEquipo.ItemsSource = manejadorDeEquipo.listar;
        }

        private void LimpiarcajasDeEquipo()
        {
            tbxNombreEquipo.Clear();
            tbxPuntosDeEquipo.Clear();
            tbxCantidadDeJugadores.Clear();
        }

        private void BotonesDeEquipoEnEdicion(bool Habilitada)
        {
            btnCancelarEquipo.IsEnabled = Habilitada;
            btnEditarEquipo.IsEnabled = !Habilitada;
            btnEliminarEquipo.IsEnabled = !Habilitada;
            btnGuardarEquipo.IsEnabled = Habilitada;
            btnNuevoEquipo.IsEnabled = !Habilitada;
            tbxPuntosDeEquipo.IsEnabled = Habilitada;
            tbxNombreEquipo.IsEnabled = Habilitada;
            tbxCantidadDeJugadores.IsEnabled = Habilitada;
        }

        private void ActualizarTablaDeportes()
        {
            dtgDeportes.ItemsSource = null;
            dtgDeportes.ItemsSource = manejadorDeDeporte.listar;
        }

        private void LimpiarCajasDEDEporte()
        {
            tbxNombreDeDeporte.Clear();
            tbxLugarDeJuegoDeporte.Clear();
        }

        private void BotonesDeDeporteEnEdicion(bool Habilitada)
        {
            btnCancelarDeporte.IsEnabled = Habilitada;
            btnEditarDeporte.IsEnabled = !Habilitada;
            btnEliminarDeporte.IsEnabled = !Habilitada;
            btnGuardarDeporte.IsEnabled = Habilitada;
            btnNuevoDeporte.IsEnabled = !Habilitada;
            tbxLugarDeJuegoDeporte.IsEnabled = Habilitada;
            tbxNombreDeDeporte.IsEnabled = Habilitada;
        }

        private void MensajeNoSeleccionadoNada()
        {
            MessageBox.Show("¡No has seleccionado nada!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void MensajeDeOperacionErronea()
        {
            MessageBox.Show("Error al realizar la operacion ", "", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void MensajeDeOperacionCorrecta()
        {
            MessageBox.Show("La operacion se realizó correctamente", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void salir_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow pagina = new MainWindow();
            pagina.Show();
            this.Close();
        }

        private void btnNuevoDeporte_Click(object sender, RoutedEventArgs e)
        {
            BotonesDeDeporteEnEdicion(true);
            LimpiarCajasDEDEporte();
            accionDeDeporte = accion.nuevo;
        }

        private void btnCancelarDeporte_Click(object sender, RoutedEventArgs e)
        {
            BotonesDeDeporteEnEdicion(false);
            LimpiarCajasDEDEporte();
        }

        private void btnEditarDeporte_Click(object sender, RoutedEventArgs e)
        {
            Deporte deporte= dtgDeportes.SelectedItem as Deporte;
            if (deporte != null)
            {
                tbxLugarDeJuegoDeporte.Text = deporte.LugarDeJuego;
                tbxNombreDeDeporte.Text = deporte.Nombre;
                accionDeDeporte = accion.editar;
                BotonesDeDeporteEnEdicion(true);
            }
            else
            {
                MensajeNoSeleccionadoNada();
            }
        }

        private void btnEliminarDeporte_Click(object sender, RoutedEventArgs e)
        {
            Deporte deporte = dtgDeportes.SelectedItem as Deporte;
            if (deporte != null)
            {
             if(MessageBox.Show("¿Realmente deceas eliminar: "+deporte.Nombre+"?","", MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
                {
                    if (manejadorDeDeporte.Eliminar(deporte.Id))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeportes();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
            }
            else
            {
                MensajeNoSeleccionadoNada();
            }
        }

        private void btnGuardarDeporte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (accionDeDeporte == accion.nuevo)
                {
                    Deporte deporte = new Deporte()
                    {
                        LugarDeJuego = tbxLugarDeJuegoDeporte.Text,
                        Nombre = tbxNombreDeDeporte.Text
                    };
                    if (manejadorDeDeporte.agregar(deporte))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeportes();
                        BotonesDeDeporteEnEdicion(false);
                        LimpiarCajasDEDEporte();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }

                }
                else
                {
                    Deporte deporte = dtgDeportes.SelectedItem as Deporte;
                    deporte.LugarDeJuego = tbxLugarDeJuegoDeporte.Text;
                    deporte.Nombre = tbxNombreDeDeporte.Text;
                    if (manejadorDeDeporte.Modificar(deporte))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeportes();
                        BotonesDeDeporteEnEdicion(false);
                        LimpiarCajasDEDEporte();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex.Message);
            }
            
        }

        private void btnNuevoEquipo_Click(object sender, RoutedEventArgs e)
        {
            BotonesDeEquipoEnEdicion(true);
            LimpiarcajasDeEquipo();
            accionDeEquipo = accion.nuevo;

        }

        private void btnCancelarEquipo_Click(object sender, RoutedEventArgs e)
        {
            BotonesDeEquipoEnEdicion(false);
            LimpiarcajasDeEquipo();
        }

        private void btnEditarEquipo_Click(object sender, RoutedEventArgs e)
        {
            Equipo equipo = dtgEquipo.SelectedItem as Equipo;
            if(equipo != null)
            {
                tbxNombreEquipo.Text = equipo.Nombre;
                tbxPuntosDeEquipo.Text = equipo.Puntos.ToString();
                tbxCantidadDeJugadores.Text = equipo.CantidadDeJugadores.ToString();
                BotonesDeEquipoEnEdicion(true);
                accionDeEquipo = accion.editar;
            }
            else
            {
                MensajeNoSeleccionadoNada();
            }
        }

        private void btnEliminarEquipo_Click(object sender, RoutedEventArgs e)
        {
            Equipo equipo = dtgEquipo.SelectedItem as Equipo;
            if (equipo != null)
            {
                if(MessageBox.Show("¿Realmente deceas eliminar: " + equipo.Nombre + "?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorDeEquipo.Eliminar(equipo.Id))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeEquipos();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
                
            }
            else
            {
                MensajeNoSeleccionadoNada();
            }
        }

        private void btnGuardarEquipo_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (accionDeEquipo == accion.nuevo)
                {
                    Equipo equipo = new Equipo()
                    {
                        Nombre = tbxNombreEquipo.Text,
                        Puntos = int.Parse(tbxPuntosDeEquipo.Text),
                        CantidadDeJugadores = int.Parse(tbxCantidadDeJugadores.Text)
                    };
                    if (manejadorDeEquipo.agregar(equipo))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeEquipos();
                        BotonesDeEquipoEnEdicion(false);
                        LimpiarcajasDeEquipo();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
                else
                {
                    Equipo equipo = dtgEquipo.SelectedItem as Equipo;
                    equipo.Nombre = tbxNombreEquipo.Text;
                    equipo.Puntos = int.Parse(tbxPuntosDeEquipo.Text);
                    equipo.CantidadDeJugadores = int.Parse(tbxCantidadDeJugadores.Text);
                    if (manejadorDeEquipo.Modificar(equipo))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeEquipos();
                        BotonesDeEquipoEnEdicion(false);
                        LimpiarcajasDeEquipo();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex.Message);
            }
            
        }

        private void btnNuevoJugador_Click(object sender, RoutedEventArgs e)
        {
            BotonesDeJugadorEnEdicion(true);
            LimpiarCajasDeJugador();
            accionDeJugador = accion.nuevo;
        }

        private void btnCancelarJugador_Click(object sender, RoutedEventArgs e)
        {
            BotonesDeJugadorEnEdicion(false);
            LimpiarCajasDeJugador();
        }

        private void btnEditarJugador_Click(object sender, RoutedEventArgs e)
        {
            Jugador jugador = dtgJugador.SelectedItem as Jugador;
            if (jugador != null)
            {
                tbxNombreJugador.Text = jugador.Nombre;
                tbxPosicionDeJugador.Text = jugador.Puesto;
                tbxSexioJugador.Text = jugador.Sexo.ToString();
                BotonesDeJugadorEnEdicion(true);
                accionDeJugador = accion.editar;
            }
            else
            {
                MensajeNoSeleccionadoNada();
            }
            
        }

        private void btnEliminarJugador_Click(object sender, RoutedEventArgs e)
        {
            Jugador jugador = dtgJugador.SelectedItem as Jugador;
            if (jugador != null)
            {
                if (MessageBox.Show("¿Realmente deceas eliminar: " + jugador.Nombre + "?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorDeEquipo.Eliminar(jugador.Id))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeJugadores();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
            }
            else
            {
                MensajeNoSeleccionadoNada();
            }

        }

        private void btnGuardarJugador_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (accionDeJugador == accion.nuevo)
                {
                    Jugador jugador = new Jugador()
                    {
                        Nombre = tbxNombreJugador.Text,
                        Puesto = tbxPosicionDeJugador.Text,
                        Sexo = char.Parse(tbxSexioJugador.Text)
                    };
                    if (manejadorDeJugador.agregar(jugador))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeJugadores();
                        BotonesDeJugadorEnEdicion(false);
                        LimpiarCajasDeJugador();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
                else
                {
                    Jugador jugador = dtgJugador.ItemsSource as Jugador;
                    jugador.Nombre = tbxNombreJugador.Text;
                    jugador.Puesto = tbxPosicionDeJugador.Text;
                    jugador.Sexo = char.Parse(tbxSexioJugador.Text);
                    if (manejadorDeJugador.Modificar(jugador))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeJugadores();
                        BotonesDeJugadorEnEdicion(false);
                        LimpiarCajasDeJugador();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex.Message);
            }
            
        }

        private void btnNuevoTorneo_Click(object sender, RoutedEventArgs e)
        {
            BotonesDeTorneoEnEdicion(true);
            LimpiarCajasDeTorneo();
            accionDeTorneo = accion.nuevo;
        }

        private void btnCancelarTorneo_Click(object sender, RoutedEventArgs e)
        {
            BotonesDeTorneoEnEdicion(false);
            LimpiarCajasDeTorneo();
        }

        private void btnEditarTorneo_Click(object sender, RoutedEventArgs e)
        {
            Torneo torneo = dtgTorneo.SelectedItem as Torneo;
            if (torneo != null)
            {
                LimpiarCajasDeTorneo();// verificar a modo de que se limpie antes de que se asignen los campos de texto
                tbxNombreDeTorneo.Text = torneo.Nombre;
                BotonesDeTorneoEnEdicion(true);
                accionDeTorneo = accion.editar;
            }
            else
            {
                MensajeNoSeleccionadoNada();
            }
            

        }

        private void btnEliminarTorneo_Click(object sender, RoutedEventArgs e)
        {
            Torneo torneo = dtgTorneo.SelectedItem as Torneo;
            if (torneo != null)
            {
                if (MessageBox.Show("¿Realmente deceas eliminar: " + torneo.Nombre + "?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorDeEquipo.Eliminar(torneo.Id))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeTorneos();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
            }
            else
            {
                MensajeNoSeleccionadoNada();
            }
        }

        private void btnGuardarTorneo_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (accionDeTorneo == accion.nuevo)
                {
                    Torneo torneo = new Torneo()
                    {
                        Nombre = tbxNombreDeTorneo.Text
                    };
                    if (manejadorDeTorneo.agregar(torneo))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeTorneos();
                        BotonesDeTorneoEnEdicion(false);
                        LimpiarCajasDeTorneo();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
                else
                {
                    Torneo torneo = dtgTorneo.SelectedItem as Torneo;
                    torneo.Nombre = tbxNombreDeTorneo.Text;
                    if (manejadorDeTorneo.Modificar(torneo))
                    {
                        MensajeDeOperacionCorrecta();
                        ActualizarTablaDeTorneos();
                        BotonesDeTorneoEnEdicion(false);
                        LimpiarCajasDeTorneo();
                    }
                    else
                    {
                        MensajeDeOperacionErronea();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("" + ex.Message);
            }
            
        }
    }
}
