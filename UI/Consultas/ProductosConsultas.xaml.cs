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
    
    public partial class ProductosConsultas : Window
    {
        public ProductosConsultas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = ProductosBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = ProductosBll.GetList(p => p.ProductoId == id);
                        break;
                    case 2://Descripcion
                        string descripcion = Convert.ToString(CriterioTextBox.Text);
                        listado = ProductosBll.GetList(p => p.Descripcion == descripcion);
                        break;
                    

                }

            }
            else
            {
                listado = ProductosBll.GetList(p => true);
            }

            ConsultaDataGrip.ItemsSource = null;
            ConsultaDataGrip.ItemsSource = listado;

        }
    
    }
}
