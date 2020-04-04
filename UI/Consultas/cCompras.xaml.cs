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

    public partial class cCompras : Window
    {
        public cCompras()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Compras>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = ComprasBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = ComprasBll.GetList(p => p.CompraId == id);
                        break;
                    case 2://Fecha
                        DateTime fecha = Convert.ToDateTime(CriterioTextBox.Text);
                        listado = ComprasBll.GetList(p => p.Fecha == fecha);
                        break;
                    case 3://TipoCompra
                        listado = ComprasBll.GetList(p => p.TipoCompra.Contains(CriterioTextBox.Text));
                        break;


                }

            }
            else
            {
                listado = ComprasBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;
        }
    }
}
