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
   
    public partial class rClientes : Window
    {
        Clientes clientes = new Clientes();
        public rClientes()
        {
            InitializeComponent();
            this.DataContext = clientes;
            ClienteIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            ClienteIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            UsuarioIdTextBox.Text = "0";


        }

        private bool Existe()
        {
            Clientes clienteA = ClientesBll.Buscar(clientes.ClienteId);
            return (clientes != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click_1(object sender, RoutedEventArgs e)
        {

            bool paso = false;

            ////Si todos los TexBoxes estan vacios, no te permite Guardar
            //if ((NombresTextBox.Text == string.Empty || EmailTextBox.Text == string.Empty || TelefonoTextBox.Text == string.Empty || CelularTextBox.Text == string.Empty || CedulaTextBox.Text == string.Empty || DireccionTextBox.Text == string.Empty))
            //{
            //    MessageBox.Show("Mi Hermano, Pero llene algo :/ :(", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            if (ClienteIdTextBox.Text == "0")
                paso = ClientesBll.Guardar(clientes);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = ClientesBll.Modificar(clientes);
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
            id = Convert.ToInt32(ClienteIdTextBox.Text);

            Limpiar();

            if (ClientesBll.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(ClienteIdTextBox.Text, "No se puede eliminar porque no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes anterior = ClientesBll.Buscar(Convert.ToInt32(ClienteIdTextBox.Text));

            if (anterior != null)
            {
                clientes = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("No Encontrado");

            }
        }
    }
}
