﻿using System;
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
    
    public partial class RProductos : Window
    {
        Productos productos = new Productos();
        public RProductos()
        {
            InitializeComponent();
            this.DataContext = productos;
            ProductoIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            ProductoIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            CantidadTextBox.Text =string.Empty;
            precioTextBox.Text = string.Empty;
            CostoTextBox.Text = string.Empty;
            UsuarioIdTextBox.Text = string.Empty;


        }

        private bool Existe()
        {
            productos = ProductosBll.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            return (productos != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = productos;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            Actualizar();

            if (string.IsNullOrWhiteSpace(ProductoIdTextBox.Text) || ProductoIdTextBox.Text == "0")
                paso = ProductosBll.Guardar(productos);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ProductosBll.Modificar(productos);
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
            id = Convert.ToInt32(ProductoIdTextBox.Text);

            Limpiar();

            if (ProductosBll.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(ProductoIdTextBox.Text, "No se puede eliminar porque no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Productos anterior = ProductosBll.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));

            if (anterior != null)
            {
                productos = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No Encontrado");

            }
        }
    }
}
