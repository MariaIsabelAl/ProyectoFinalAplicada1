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
            rUsuarios rusuarios = new rUsuarios();
            rusuarios.Show();
        }

        private void UsuariosConsultasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios consultas = new cUsuarios();
            consultas.Show();
        }

        private void ProductosMenutem_Click(object sender, RoutedEventArgs e)
        {
            rProductos rProductos = new rProductos();
            rProductos.Show();
        }

        private void ClientesMenutem_Click(object sender, RoutedEventArgs e)
        {
            rClientes rClientes = new rClientes();
            rClientes.Show();
        }

        private void ComprasMenutem_Click(object sender, RoutedEventArgs e)
        {
            rCompras rCompras = new rCompras();
            rCompras.Show();
        }

        private void ClientesConsutasMenutem_Click(object sender, RoutedEventArgs e)
        {
            cClientes consultas = new cClientes();
            consultas.Show();
        }

        private void ProductosConsutasMenutem_Click(object sender, RoutedEventArgs e)
        {
            cProductos consultas = new cProductos();
            consultas.Show();
        }

        private void ComprasConsutasMenutem_Click(object sender, RoutedEventArgs e)
        {
            cCompras consultas = new cCompras();
            consultas.Show();
        }

        private void VendedoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rVendedores rVendedores = new rVendedores();
            rVendedores.Show();

        }

        private void VendedoresConsultasmenuItem_Click(object sender, RoutedEventArgs e)
        {
            cVendedores vendedoresConsulta = new cVendedores();
            vendedoresConsulta.Show();
        }

        private void VentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rVentas rVentas = new rVentas();
            rVentas.Show();
        }

        private void VentasConsultasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cVentas vConsultas = new cVentas();
            vConsultas.Show();
        }

        private void PagosComprasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPagosCompras rPagosCompras = new rPagosCompras();
            rPagosCompras.Show();
        }

        private void PagosComprasMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            cPagosCompras cPagosC = new cPagosCompras();
            cPagosC.Show();
        }

        private void PagosVentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPagosVentas rPagosVentas = new rPagosVentas();
            rPagosVentas.Show();
        }

        private void PagosVentasConsultasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cPagosVentas pVentasC = new cPagosVentas();
            pVentasC.Show();
        }

        private void SalirPrograma_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

