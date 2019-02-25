using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Page = Microsoft.Office.Interop.Excel.Page;

namespace RestopayStaff
{
    public partial class OrdersArchivePage : Page
    {

        ProductsDatabaseEntities _db = new ProductsDatabaseEntities();
        private static ObservableCollection<ArchivedOrder> archivedOrdersItems;
        public OrdersArchivePage()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            _db.SaveChanges();

            var query = from o in _db.ArchivedOrders select o;
            archivedOrdersItems = new ObservableCollection<ArchivedOrder>();
            foreach (var item in query)
            {
                archivedOrdersItems.Add(new ArchivedOrder
                {
                    OrderNumber = item.OrderNumber,
                    DateTime = item.DateTime,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    TableNumber = item.TableNumber,
                    Amount = item.Amount

                });


            }
            grid.ItemsSource = archivedOrdersItems;
        }


        private void ButtonUpdateClick(object sender, RoutedEventArgs e)
        {
            archivedOrdersItems.Clear();
            Load();
            grid.Items.Refresh();

        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("No entries in back navigation history.");
            }
        }

        private void RemoveRaw(object sender, RoutedEventArgs e)
        {
            try
            {
                archivedOrdersItems.Remove(grid.SelectedItem as ArchivedOrder);
                _db.SaveChanges();

            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void ExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true; //www.yazilimkodlama.com
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < grid.Columns.Count; j++) //Başlıklar için
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true; //Başlığın Kalın olması için
                sheet1.Columns[j + 1].ColumnWidth = 15; //Sütun genişliği ayarı
                myRange.Value2 = grid.Columns[j].Header;
            }
            for (int i = 0; i < grid.Columns.Count; i++)
            { //www.yazilimkodlama.com
                for (int j = 0; j < grid.Items.Count; j++)
                {
                    TextBlock b = grid.Columns[i].GetCellContent(grid.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }

        public HeaderFooter LeftHeader => throw new NotImplementedException();

        public HeaderFooter CenterHeader => throw new NotImplementedException();

        public HeaderFooter RightHeader => throw new NotImplementedException();

        public HeaderFooter LeftFooter => throw new NotImplementedException();

        public HeaderFooter CenterFooter => throw new NotImplementedException();

        public HeaderFooter RightFooter => throw new NotImplementedException();
    }
}

