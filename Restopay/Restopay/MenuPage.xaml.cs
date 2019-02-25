using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Restopay
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        ProductsDatabaseEntities _db = new ProductsDatabaseEntities();
        private List<Product> beverage = new List<Product>();
        private List<Product> appetizer = new List<Product>();
        private List<Product> mainCourse = new List<Product>();
        private List<Product> dessert = new List<Product>();

        private static ObservableCollection<Product> bill = new ObservableCollection<Product>();

        TotalAmount tAmount = new TotalAmount();
        public MenuPage()
        {
            InitializeComponent();

            var query1 = from b in _db.beverages select b;
            foreach (var item in query1)
            {
                beverage.Add(new Product { Name = item.Name, Price = item.Price });
            }
            comboBeverage.ItemsSource = beverage;

            var query2 = from a in _db.appetizers select a;
            foreach (var item in query2)
            {
                appetizer.Add(new Product { Name = item.Name, Price = item.Price });
            }
            comboAppetizer.ItemsSource = appetizer;

            var query3 = from m in _db.mainCourses select m;
            foreach (var item in query3)
            {
                mainCourse.Add(new Product { Name = item.Name, Price = item.Price });
            }
            comboMainCourse.ItemsSource = mainCourse;

            var query4 = from m in _db.desserts select m;
            foreach (var item in query4)
            {
                dessert.Add(new Product { Name = item.Name, Price = item.Price });
            }
            comboDessert.ItemsSource = dessert;

            gridBill.ItemsSource = bill;

            tAmount.subtotal = (getTotalAmount(bill)).ToString();
            this.DataContext = tAmount;

        }
        private double getTotalAmount(ObservableCollection<Product> x)
        {
            double sub = 0;
            foreach (Product i in x)
            {
                sub = sub + i.Amount;
            }
            return sub;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            int bi = comboBeverage.SelectedIndex;

            if (bi >= 0 && !String.IsNullOrEmpty(txbBeverageQ.Text))
            {
                if (bill.Contains(beverage[bi]))
                {
                    int oi = bill.IndexOf(beverage[bi]);
                    bill[oi].Quantity = bill[oi].Quantity + Convert.ToInt32(txbBeverageQ.Text);
                    bill[oi].Amount = bill[oi].Quantity * bill[oi].Price;
                    gridBill.Items.Refresh();
                }
                else
                {
                    beverage[bi].Quantity = Convert.ToInt32(txbBeverageQ.Text);
                    beverage[bi].Amount = beverage[bi].Quantity * beverage[bi].Price;
                    beverage[bi].Category = "Bar";
                    bill.Add(beverage[bi]);
                }
            }

            int ai = comboAppetizer.SelectedIndex;

            if (ai >= 0 && !String.IsNullOrEmpty(txbAppetizerQ.Text))
            {
                if (bill.Contains(appetizer[ai]))
                {
                    int oi = bill.IndexOf(appetizer[ai]);
                    bill[oi].Quantity = bill[oi].Quantity + Convert.ToInt32(txbAppetizerQ.Text);
                    bill[oi].Amount = bill[oi].Quantity * bill[oi].Price;
                    gridBill.Items.Refresh();
                }
                else
                {
                    appetizer[ai].Quantity = Convert.ToInt32(txbAppetizerQ.Text);
                    appetizer[ai].Amount = appetizer[ai].Quantity * appetizer[ai].Price;
                    bill.Add(appetizer[ai]);
                }
            }

            int mi = comboMainCourse.SelectedIndex;

            if (mi >= 0 && !String.IsNullOrEmpty(txbMainCourseQ.Text))
            {
                if (bill.Contains(mainCourse[mi]))
                {
                    int oi = bill.IndexOf(mainCourse[mi]);
                    bill[oi].Quantity = bill[oi].Quantity + Convert.ToInt32(txbMainCourseQ.Text);
                    bill[oi].Amount = bill[oi].Quantity * bill[oi].Price;
                    gridBill.Items.Refresh();
                }
                else
                {
                    mainCourse[mi].Quantity = Convert.ToInt32(txbMainCourseQ.Text);
                    mainCourse[mi].Amount = mainCourse[mi].Quantity * mainCourse[mi].Price;
                    bill.Add(mainCourse[mi]);
                }
            }

            int di = comboDessert.SelectedIndex;

            if (di >= 0 && !String.IsNullOrEmpty(txbDessertQ.Text))
            {
                if (bill.Contains(dessert[di]))
                {
                    int oi = bill.IndexOf(dessert[di]);
                    bill[oi].Quantity = bill[oi].Quantity + Convert.ToInt32(txbDessertQ.Text);
                    bill[oi].Amount = bill[oi].Quantity * bill[oi].Price;
                    gridBill.Items.Refresh();
                }
                else
                {
                    dessert[di].Quantity = Convert.ToInt32(txbDessertQ.Text);
                    dessert[di].Amount = dessert[di].Quantity * dessert[di].Price;
                    bill.Add(dessert[di]);
                }
            }

            txbBeverageQ.Clear();
            txbAppetizerQ.Clear();
            txbMainCourseQ.Clear();
            txbDessertQ.Clear();
            comboBeverage.SelectedIndex = -1;
            comboAppetizer.SelectedIndex = -1;
            comboMainCourse.SelectedIndex = -1;
            comboDessert.SelectedIndex = -1;

            tAmount.subtotal = (getTotalAmount(bill)).ToString();
            tAmount.Tax = (twoSignsAfterDot(getTotalAmount(bill) * 0.13)).ToString();
            tAmount.Total = (twoSignsAfterDot(getTotalAmount(bill) * 0.13 + getTotalAmount(bill))).ToString();
           
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            bill.Clear();
            tAmount.subtotal = (getTotalAmount(bill)).ToString();
            tAmount.Tax = (twoSignsAfterDot(getTotalAmount(bill) * 0.13)).ToString();
            tAmount.Total = (twoSignsAfterDot(getTotalAmount(bill) * 0.13 + getTotalAmount(bill))).ToString();
        }

        private void ButtonCart_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in bill)
            {
                cart cartItem = new cart();
                cartItem.Name = item.Name;
                cartItem.Price = item.Price;
                cartItem.Quantity = item.Quantity;
                cartItem.Amount = item.Amount;
                cartItem.Category = item.Category;
                
                cartItem.TableNumber = ApplicationProp.tableNumber;
                _db.carts.Add(cartItem);
                _db.SaveChanges();
            }
            this.NavigationService.Navigate(new CartPage());
        }

        private void gridBill_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (Product i in bill)
            {
                i.Amount = i.Price * i.Quantity;
            }
            gridBill.Items.Refresh();
            tAmount.subtotal = (getTotalAmount(bill)).ToString();
            tAmount.Tax = (twoSignsAfterDot(getTotalAmount(bill) * 0.13)).ToString();
            tAmount.Total = (twoSignsAfterDot(getTotalAmount(bill) * 0.13 + getTotalAmount(bill))).ToString();
        }

        public double twoSignsAfterDot(double n)
        {

            return (System.Convert.ToDouble(Convert.ToUInt32(n * 100))) / 100;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void RemoveRaw(object sender, RoutedEventArgs e)
        {
            try
            {
                bill.Remove(gridBill.SelectedItem as Product);
            }
            catch (Exception)
            {

                //throw;
            }
        }
    }
}
