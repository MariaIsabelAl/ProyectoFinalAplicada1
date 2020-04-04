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
using DataVentas.Entidades;
using DataVentas.BLL;

namespace DataVentas.UI.Consultas
{
    
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click_1(object sender, RoutedEventArgs e)
        {
                var listado = new List<Usuarios>();

                if (CriterioTextBox.Text.Trim().Length > 0)
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0://todo
                            listado = UsuariosBll.GetList(p => true);
                            break;
                        case 1://ID
                            int id = Convert.ToInt32(CriterioTextBox.Text);
                            listado = UsuariosBll.GetList(p => p.UsuarioId == id);
                            break;
                        case 2://Nombre
                            listado = UsuariosBll.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                            break;
                        case 3://NombreUsuarios
                            listado = UsuariosBll.GetList(p => p.NombreUsuario.Contains(CriterioTextBox.Text));
                            break;
                        case 4://Email
                            listado = UsuariosBll.GetList(p => p.Email.Contains(CriterioTextBox.Text));
                            break;

                    }

                }
                else
                {
                    listado = UsuariosBll.GetList(p => true);
                }

                ConsultaDataGrip.ItemsSource = null;
                ConsultaDataGrip.ItemsSource = listado;
            
        }
    }
    
}
