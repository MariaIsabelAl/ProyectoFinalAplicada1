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
    
    public partial class rPagosCompras : Window
    {
        PagosCompras pagoscompras = new PagosCompras();
        public rPagosCompras()
        {
            InitializeComponent();
            this.DataContext = pagoscompras;
            PagoCompraIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            PagoCompraIdTextBox.Text = "0";
            CompraIdTextBox.Text = "0";
            FechaDatePicker.SelectedDate = DateTime.Now;
            MontoTextBox.Text = "0";
            DescuentoTextBox.Text = "0";
            UsuarioIdTextBox.Text = "0";
            
        }

        private bool Existe()
        {
            PagosCompras pagocompraA = PagosComprasBll.Buscar(pagoscompras.PagoCompraId);
            return (pagoscompras != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = pagoscompras;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            //Si todos los TexBoxes estan vacios, no te permite Guardar
            if ((MontoTextBox.Text == "0"))
            {
                MessageBox.Show("Mi Hermano, Pero llene algo :/ :(", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (string.IsNullOrWhiteSpace(PagoCompraIdTextBox.Text) || PagoCompraIdTextBox.Text == "0")
                paso = PagosComprasBll.Guardar(pagoscompras);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PagosComprasBll.Modificar(pagoscompras);
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
            id = Convert.ToInt32(PagoCompraIdTextBox.Text);

            Limpiar();

            if (PagosComprasBll.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(PagoCompraIdTextBox.Text, "No se puede eliminar una persona que no existe");

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            PagosCompras anterior = PagosComprasBll.Buscar(Convert.ToInt32(PagoCompraIdTextBox.Text));

            if (anterior != null)
            {
                pagoscompras = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("Compra no Encontrada");

            }
        }
    }
}
