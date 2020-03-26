using System;
using System.Collections.Generic;
using System.Linq;
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
using DataVentas.DAL;
using DataVentas.Entidades;

namespace DataVentas.UI.Login
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window 
    {
        List<Usuarios> lista = new List<Usuarios>();
        public static int UsuarioId;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void EntrarButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();

            lista = UsuariosBll.GetList(p => true);
            bool paso = false;
            foreach (var item in lista)
            {
                if ((item.NombreUsuario == UsuarioTexbox.Text) && (item.Clave == PasswordBox.Password))
                {
                    UsuarioId = item.UsuarioId;
                    m.Show();
                    paso = true;
                    break;
                }
            }
            if (paso == false)
            {
                MessageBox.Show("Nombre de usuario o Contraseña incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                UsuarioTexbox.Text = string.Empty;
                PasswordBox.Password = string.Empty;
                UsuarioTexbox.Focus();
            }
        }
    }
}
