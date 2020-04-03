using DataVentas.BLL;
using DataVentas.Entidades;
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

namespace DataVentas.UI.Registros
{

    public partial class RVendedores : Window
    {
        Vendedores vendedores = new Vendedores();
        public RVendedores()
        {
            InitializeComponent();
            this.DataContext = vendedores;
            VendedorIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            VendedorIdTextBox.Text = "0";
            VededorNombreTextBox.Text = string.Empty;
            VendedorEmailTextBox.Text = string.Empty;
            VendedorTelefonoTextBox.Text = string.Empty;
            VendedorCelularTextBox.Text = string.Empty;
            VendedorCedulaTextBox.Text = string.Empty;
            VendedorDireccionTextBox.Text = string.Empty;
            UsuarioIdTextBox.Text = "0";

        }

        private bool Existe()
        {
            Vendedores vendedorA = VendedoresBll.Buscar(vendedores.VendedorId);
            return (vendedorA != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = vendedores;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            //Si todos los TexBoxes estan vacios, no te permite Guardar
            if ((VededorNombreTextBox.Text == string.Empty || VendedorEmailTextBox.Text == string.Empty ||
            VendedorTelefonoTextBox.Text == string.Empty ||
            VendedorCelularTextBox.Text == string.Empty ||
            VendedorCedulaTextBox.Text == string.Empty ||
            VendedorDireccionTextBox.Text == string.Empty))
            {

                MessageBox.Show("Mi Hermano, Pero llene algo :/ :(", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(VendedorIdTextBox.Text) || VendedorIdTextBox.Text == "0")
                paso = VendedoresBll.Guardar(vendedores);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = VendedoresBll.Modificar(vendedores);

            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(VendedorIdTextBox.Text);

            Limpiar();

            if (VendedoresBll.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(VendedorIdTextBox.Text, "No se puede eliminar porque no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

            Vendedores anterior = VendedoresBll.Buscar(Convert.ToInt32(VendedorIdTextBox.Text));

            if (anterior != null)
            {
                vendedores = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No Encontrado");

            }
        }

    }
}
