using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Restopay
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        ProductsDatabaseEntities _db = new ProductsDatabaseEntities();
        private static ObservableCollection<cart> cartItems = new ObservableCollection<cart>();
        TotalAmount tAmount = new TotalAmount();
        
        public CartPage()
        {
            InitializeComponent();
            tAmount.subtotal = "0";
            tAmount.Tax = "0";
            tAmount.Total = "0";
            var query1 = from b in _db.carts where b.TableNumber== ApplicationProp.
                         tableNumber select b;
            foreach (var item in query1)
            {
                cartItems.Add(new cart {
                    Id = item.Id,
                    Name = item.Name, Price = item.Price, 
                    Quantity = item.Quantity, Amount = item.Amount,
                    Category = item.Category, TableNumber = item.TableNumber
                });
                
            }
            gridBill.ItemsSource = cartItems;
            tAmount.subtotal = (getTotalAmount(cartItems)).ToString();
            tAmount.Tax = (twoSignsAfterDot(getTotalAmount(cartItems) * 0.13)).ToString();
            tAmount.Total = (twoSignsAfterDot(getTotalAmount(cartItems) * 0.13 + getTotalAmount(cartItems))).ToString();

            this.DataContext = tAmount;

        }
        private double getTotalAmount(ObservableCollection<cart> x)
        {
            double sub = 0;
            foreach (var i in x)
            {
                if (i.Amount.HasValue) { sub = sub + i.Amount.Value; }
                
            }
            return sub;
        }
        public double twoSignsAfterDot(double n)
        {

            return (System.Convert.ToDouble(Convert.ToUInt32(n * 100))) / 100;
        }
        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage());
        }

        private void ButtonRemoveClick(object sender, RoutedEventArgs e)
        {

            var query1 = from b in _db.carts select b;
            foreach (var item in query1)
            {
                _db.carts.Remove(item);
            }
            _db.SaveChanges();

            cartItems.Clear();
            gridBill.ItemsSource = null;
            tAmount.subtotal = "0";
            tAmount.Tax = "0";
            tAmount.Total = "0";
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            long? orderID = _db.GetNextSequenceValue().Single();
            _db.SaveChanges();
            string dateNow = DateTime.Now.ToString();
            OrdersInProgress orderInPrItem = new OrdersInProgress();
            foreach (var item in cartItems)
            {
                
                orderInPrItem.Name = item.Name;
                orderInPrItem.Price = item.Price;
                orderInPrItem.Quantity = item.Quantity.Value;
                orderInPrItem.Amount = item.Amount.Value;
                orderInPrItem.Category = item.Category;
                orderInPrItem.DateTime = dateNow;
                orderInPrItem.OrderNumber = orderID.Value;
                orderInPrItem.TableNumber = item.TableNumber;
                orderInPrItem.WaiterStatus_ = "In-progress";
                orderInPrItem.CookStatus_ = "In-progress";
                orderInPrItem.BartenderStatus_ = "In-progress";
                _db.OrdersInProgresses.Add(orderInPrItem);
                _db.SaveChanges();
            }
            



            var query1 = from b in _db.carts select b;
            foreach (var item in query1)
            {
                _db.carts.Remove(item);


            }
            _db.SaveChanges();

            cartItems.Clear();
            gridBill.ItemsSource = null;
            tAmount.subtotal = "0";
            tAmount.Tax = "0";
            tAmount.Total = "0";

            if (paymentMethod.SelectedIndex == 0)
            {
                this.NavigationService.Navigate(new PaypalPaymentPage());
            }
            else
            {
                this.NavigationService.Navigate(new CardPaymentPage());
            }


        }

        private void RemoveRaw(object sender, RoutedEventArgs e)
        {
            int id = (gridBill.SelectedItem as cart).Id;
            if (!(gridBill.SelectedItem as cart).Name.Equals(null) )
            {
                cart car = (from c in _db.carts where c.Id == id select c).Single();
                _db.carts.Remove(car);
                _db.SaveChanges();
                cart carOL = (from c in cartItems where c.Id == id select c).Single();
                cartItems.Remove(carOL);
                gridBill.ItemsSource = cartItems;
                foreach (cart i in cartItems)
                {
                    i.Amount = i.Price * i.Quantity;
                }
                gridBill.Items.Refresh();
                tAmount.subtotal = (getTotalAmount(cartItems)).ToString();
                tAmount.Tax = (twoSignsAfterDot(getTotalAmount(cartItems) * 0.13)).ToString();
                tAmount.Total = (twoSignsAfterDot(getTotalAmount(cartItems) * 0.13 + getTotalAmount(cartItems))).ToString();
            }
        }
    }
}
