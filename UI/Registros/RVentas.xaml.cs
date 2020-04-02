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
  
    public partial class RVentas : Window
    {
        Ventas ventas = new Ventas(); 
        public RVentas()
        {
            InitializeComponent();
            this.DataContext = ventas;
            VentasIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            VentasIdTextBox.Text = "0";
            FechaDatePickerTextBox.SelectedDate = DateTime.Now;
            TipoVentaComboBox.SelectedItem = string.Empty;
            VendedorIdTextBox.Text = "0";
            ClienteIdTextBox.Text = "0";
            DevueltaTextBox.Text = "0";
            TotaTextBox.Text = "0";
            BalanceTextBox.Text = "0";
            DescuentoLabel.Text = "0";
            UsuarioIdTextBox.Text = "0";

            DetalleDataGrid.ItemsSource = new List<VentasDetalles>();
            
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = ventas;
        }

        private bool Existe()
        {
            ventas = VentasBll.Buscar(Convert.ToInt32(VentasIdTextBox.Text));
            return (ventas != null);
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            //Si todos los TexBoxes estan vacios, no te permite Guardar
            if ((VendedorIdTextBox.Text == "0" ||
            ClienteIdTextBox.Text == "0" ||
            DevueltaTextBox.Text == "0" ||
            TotaTextBox.Text == "0" ||
            BalanceTextBox.Text == "0" || UsuarioIdTextBox.Text == "0"))
            {
                MessageBox.Show("Mi Hermano, Pero llene algo :/ :(", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(VentasIdTextBox.Text) || VentasIdTextBox.Text == "0")
                paso = VentasBll.Guardar(ventas);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = VentasBll.Modificar(ventas);
            }


            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se puede Guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            ventas.VentaDetalle.RemoveAt(DetalleDataGrid.FrozenColumnCount);
            Actualizar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ventas anterior = VentasBll.Buscar(Convert.ToInt32(VentasIdTextBox.Text));

            if (anterior != null)
            {
                ventas = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No encontrado");
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            ventas.VentaDetalle.Add(new VentasDetalles(Convert.ToInt32(VentasIdTextBox.Text), Convert.ToInt32(productoIdTextBox.Text), Convert.ToInt32(CantidadTextBox.Text),
                DescripcionTextBox.Text, Convert.ToInt32(PrecioTextBox.Text)));
            Actualizar();
            productoIdTextBox.Clear();
            CantidadTextBox.Clear();
            DescripcionTextBox.Clear();
            PrecioTextBox.Clear();
            productoIdTextBox.Focus();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(VentasIdTextBox.Text);

            Limpiar();

            if (VentasBll.Eliminar(id))
                MessageBox.Show("Eliminar", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(VentasIdTextBox.Text, "No se puede eliminar porque no existe");
        }
    }
}
