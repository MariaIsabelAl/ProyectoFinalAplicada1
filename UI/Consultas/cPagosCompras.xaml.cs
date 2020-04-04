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
    /// Interaction logic for cPagosCompras.xaml
    /// </summary>
    public partial class cPagosCompras : Window
    {
        public cPagosCompras()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click_1(object sender, RoutedEventArgs e)
        {
            var listado = new List<PagosCompras>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = PagosComprasBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = PagosComprasBll.GetList(p => p.CompraId == id);
                        break;
                    case 2://Fecha
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = PagosComprasBll.GetList(p => p.Fecha == fecha);
                        break;
                }
            }
            else
            {
                listado = PagosComprasBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;

        }
    }
}
