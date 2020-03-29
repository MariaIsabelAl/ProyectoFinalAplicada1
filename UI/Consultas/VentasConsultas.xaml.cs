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
    /// Interaction logic for VentasConsultas.xaml
    /// </summary>
    public partial class VentasConsultas : Window
    {
        public VentasConsultas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ventas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = VentasBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = VentasBll.GetList(p => p.VentaId == id);
                        break;
                    case 2://Fecha
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = VentasBll.GetList(p => p.Fecha == fecha);
                        break;
                    case 3://TipoCompra
                        listado = VentasBll.GetList(p => p.TipoVenta.Contains(CriterioTextBox.Text));
                        break;

                }

            }
            else
            {
                listado = VentasBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;
        }
    }
}
