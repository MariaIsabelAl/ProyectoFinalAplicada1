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
using DataVentas.Validaciones;
using Microsoft.EntityFrameworkCore;


namespace DataVentas.UI.Registros
{
    
    public partial class RUsuarios : Window
    {
        Usuarios usuarios = new Usuarios();
        public RUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;
            UsuarioIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            NombreUsuarioTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
           
        }

       
        private bool Existe()
        {
            usuarios = UsuariosBll.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));
            return (usuarios != null);
        }

        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = usuarios;
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            

            if (string.IsNullOrWhiteSpace(UsuarioIdTextBox.Text) || UsuarioIdTextBox.Text == "0")
                paso = UsuariosBll.Guardar(usuarios);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = UsuariosBll.Modificar(usuarios);
                Actualizar();
                
            }

            if ((NombreTextBox.Text == string.Empty || NombreUsuarioTextBox.Text == string.Empty || EmailTextBox.Text == string.Empty || ClaveTextBox.Text == string.Empty))
            {
                MessageBox.Show("Mi Hermano, Pero llene algo :/ :(", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
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
            id = Convert.ToInt32(UsuarioIdTextBox.Text);

            Limpiar();

            if (UsuariosBll.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(UsuarioIdTextBox.Text, "No se puede eliminar una persona que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios anterior = UsuariosBll.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));

            if (anterior != null)
            {
                usuarios = anterior;
                Actualizar();
            }
            else
            {
                MessageBox.Show("Persona no Encontrada");

            }
        }
    }
}
