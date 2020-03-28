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
  
    public partial class ClientesConsultas : Window
    {
        public ClientesConsultas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Clientes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = ClientesBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = ClientesBll.GetList(p => p.ClienteId == id);
                        break;
                    case 2://Nombres
                        listado = ClientesBll.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Telefono
                        listado = ClientesBll.GetList(p => p.Telefono.Contains(CriterioTextBox.Text));
                        break;
                    case 4://Cedula
                        listado = ClientesBll.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;

                }

            }
            else
            {
                listado = ClientesBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;

        }
    
    }
}
