using System;
using System.Collections.Generic;
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

namespace RestopayStaff
{
    /// <summary>
    /// Interaction logic for StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        public StaffPage()
        {
            InitializeComponent();
        }

        private void COOK_Click(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new CookPage());
        }

        private void BARTENDER_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BartenderPage());
        }

        private void WAITER_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WaiterPage());

        }

        private void MANAGER_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ManagerPage());
        }

        private void OWNER_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OwnerPage());
        }

        private void ADMINISTRATOR_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DBAdminPage());
        }
    }
}
