﻿using System;
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
        public GenerarLosTorneos()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            VentanaDeSeleccion pagina = new VentanaDeSeleccion();
            pagina.Show();
            this.Close();
        }
    }
}
