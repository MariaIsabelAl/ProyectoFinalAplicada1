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
using DataVentas.UI.Registros;
using DataVentas.UI.Consultas;

namespace DataVentas
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UsuarioMenutem_Click(object sender, RoutedEventArgs e)
        {
            RUsuarios rusuarios = new RUsuarios();
            rusuarios.Show();
        }

        private void UsuariosConsultasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            UsuariosConsultas consultas = new UsuariosConsultas();
            consultas.Show();
        }

        private void ProductosMenutem_Click(object sender, RoutedEventArgs e)
        {
            RProductos rProductos = new RProductos();
            rProductos.Show();
        }

        private void ClientesMenutem_Click(object sender, RoutedEventArgs e)
        {
            RClientes rClientes = new RClientes();
            rClientes.Show();
        }

        private void ComprasMenutem_Click(object sender, RoutedEventArgs e)
        {
            RCompras rCompras = new RCompras();
            rCompras.Show();
        }

        private void ClientesConsutasMenutem_Click(object sender, RoutedEventArgs e)
        {
            ClientesConsultas consultas = new ClientesConsultas();
            consultas.Show();
        }

        private void ProductosConsutasMenutem_Click(object sender, RoutedEventArgs e)
        {
            ProductosConsultas consultas = new ProductosConsultas();
            consultas.Show();
        }

        private void ComprasConsutasMenutem_Click(object sender, RoutedEventArgs e)
        {
            ComprasConsultas consultas = new ComprasConsultas();
            consultas.Show();
        }

        private void VendedoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RVendedores rVendedores = new RVendedores();
            rVendedores.Show();

        }

        private void VendedoresConsultasmenuItem_Click(object sender, RoutedEventArgs e)
        {
            VendedoresConsultas vendedoresConsulta = new VendedoresConsultas();
            vendedoresConsulta.Show();
        }

        private void SalirAplicacion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void VentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            RVentas rVentas = new RVentas();
            rVentas.Show();
        }
    }
}

