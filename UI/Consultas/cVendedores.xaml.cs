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

namespace DataVentas.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cVendedores.xaml
    /// </summary>
    public partial class cVendedores : Window
    {
        public cVendedores()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Vendedores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = VendedoresBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = VendedoresBll.GetList(p => p.VendedorId == id);
                        break;
                    case 2://Nombres
                        listado = VendedoresBll.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Telefono
                        listado = VendedoresBll.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));
                        break;
                    case 4://Cedula
                        listado = VendedoresBll.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;

                }

            }
            else
            {
                listado = VendedoresBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;
        }
    }
}
