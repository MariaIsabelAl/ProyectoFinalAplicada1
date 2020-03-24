using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataVentas.UI.Registros;
using DataVentas.UI.Consultas;

namespace DataVentas.UI.Registros
{
    
    public partial class RMenu : Window
    {
        public RMenu()
        {
            InitializeComponent();
        }

        private void UsuariosButton_Click(object sender, RoutedEventArgs e)
        {
            RUsuarios rUsuarios = new RUsuarios();
            rUsuarios.Show();
        }

        private void ConsultarUsuariosButton_Click_1(object sender, RoutedEventArgs e)
        {
            UsuariosConsultas consultas = new UsuariosConsultas();
            consultas.Show();
        }
    }
}
