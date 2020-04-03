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
using DataVentas.BLL;
using DataVentas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DataVentas.UI.Registros
{
    
    public partial class RCompras : Window
    {
        Compras compras = new Compras();

        public RCompras()
        {
            InitializeComponent();
            this.DataContext = compras;
            CompraIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            CompraIdTextBox.Text = "0";
            FechaDatePickerTextBox.SelectedDate = DateTime.Now;
            TipoCompraComboBox.SelectedItem = string.Empty;
            DevueltaTextBox.Text = "0";
            MontoTextBox.Text = "0";
            BalanceTextBox.Text = "0";
            DescuentoTextBox.Text = "0";
            UsuarioIdTextBox.Text = "0";

            DetalleDataGrid.ItemsSource = new List<ComprasDetalles>();
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = compras;
        }

        private bool Existe()
        {
            Compras compraA = ComprasBll.Buscar(compras.CompraId);
            //compras = ComprasBll.Buscar(Convert.ToInt32(CompraIdTextBox.Text));
            return (compras != null);
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            //Si todos los TexBoxes estan vacios, no te permite Guardar
            if ((DevueltaTextBox.Text == "0"||
            MontoTextBox.Text == "0"||
            BalanceTextBox.Text == "0"||
            DescuentoTextBox.Text == "0"||
            UsuarioIdTextBox.Text == "0"))
            {
                MessageBox.Show("Mi Hermano, Pero llene algo :/ :(", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (string.IsNullOrWhiteSpace(CompraIdTextBox.Text) || CompraIdTextBox.Text == "0")
                paso = ComprasBll.Guardar(compras);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ComprasBll.Modificar(compras);
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

        private void EiminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(CompraIdTextBox.Text);

            Limpiar();

            if (ComprasBll.Eliminar(id))
                MessageBox.Show("Eliminar", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(CompraIdTextBox.Text, "No se puede eliminar porque no existe");
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            compras.CompraDetalle.RemoveAt(DetalleDataGrid.FrozenColumnCount);
            Actualizar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Compras anterior = ComprasBll.Buscar(Convert.ToInt32(CompraIdTextBox.Text));

            if (anterior != null)
            {
                compras = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No encontrado");
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            compras.CompraDetalle.Add(new ComprasDetalles(Convert.ToInt32(CompraIdTextBox.Text),Convert.ToInt32(productoIdTextBox.Text), Convert.ToInt32(CantidadTextBox.Text),
                DescripcionTextBox.Text, Convert.ToInt32(PrecioTextBox.Text)));
            Actualizar();
            productoIdTextBox.Clear();
            CantidadTextBox.Clear();
            DescripcionTextBox.Clear();
            PrecioTextBox.Clear();
            productoIdTextBox.Focus();
        }
    }
}
