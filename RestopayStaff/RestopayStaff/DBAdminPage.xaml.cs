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
using System.Windows.Threading;

namespace RestopayStaff
{
    public partial class DBAdminPage : Page
    {

        ProductsDatabaseEntities _db = new ProductsDatabaseEntities();

        int category = 1;
        public DBAdminPage()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            _db.SaveChanges();

            grid.ItemsSource = _db.beverages.ToList();

        }

        private void ButtonExitClick(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new StaffPage());
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("No entries in back navigation history.");
            }
        }


        private void RemoveItem1(object sender, RoutedEventArgs e)
        {
            switch (category)
            {
                case 1:
                    int id = (grid.SelectedItem as beverage).Id;
                    if (!(grid.SelectedItem as beverage).Name.Equals(null) && (grid.SelectedItem as beverage).Price > 0 && (grid.SelectedItem as beverage).Id != 0)
                    {
                        beverage bev = (from p in _db.beverages where p.Id == id select p).Single();
                        _db.beverages.Remove(bev);
                        _db.SaveChanges();
                        grid.ItemsSource = _db.beverages.ToList();
                    }
                    break;
                case 2:
                    if (!(grid.SelectedItem as appetizer).Name.Equals(null) && (grid.SelectedItem as appetizer).Price > 0 && (grid.SelectedItem as appetizer).Id != 0)
                    {
                        id = (grid.SelectedItem as appetizer).Id;
                        appetizer apet = (from p in _db.appetizers where p.Id == id select p).Single();
                        _db.appetizers.Remove(apet);
                        _db.SaveChanges();
                        grid.ItemsSource = _db.appetizers.ToList();
                    }
                    break;
                case 3:
                    if (!(grid.SelectedItem as mainCourse).Name.Equals(null) && (grid.SelectedItem as mainCourse).Price > 0 && (grid.SelectedItem as mainCourse).Id != 0)
                    {
                        id = (grid.SelectedItem as mainCourse).Id;
                        mainCourse mco = (from p in _db.mainCourses where p.Id == id select p).Single();
                        _db.mainCourses.Remove(mco);
                        _db.SaveChanges();
                        grid.ItemsSource = _db.mainCourses.ToList();
                    }
                    break;
                case 4:
                    if (!(grid.SelectedItem as dessert).Name.Equals(null) && (grid.SelectedItem as dessert).Price > 0 && (grid.SelectedItem as dessert).Id != 0)
                    {
                        id = (grid.SelectedItem as dessert).Id;
                        dessert des = (from p in _db.desserts where p.Id == id select p).Single();
                        _db.desserts.Remove(des);
                        _db.SaveChanges();
                        grid.ItemsSource = _db.desserts.ToList();
                    }
                    break;

            }
        }

        private void UpdateItem1(object sender, RoutedEventArgs e)
        {

            switch (category)
            {
                case 1:
                    int id = (grid.SelectedItem as beverage).Id;
                    if (!(grid.SelectedItem as beverage).Name.Equals(null) && (grid.SelectedItem as beverage).Price > 0)
                    {
                        beverage bev = (from p in _db.beverages where p.Id == id select p).Single();
                        bev.Name = (grid.SelectedItem as beverage).Name;
                        bev.Price = (grid.SelectedItem as beverage).Price;
                        _db.SaveChanges();
                        grid.ItemsSource = _db.beverages.ToList();
                    }
                    break;
                case 2:
                    if (!(grid.SelectedItem as appetizer).Name.Equals(null) && (grid.SelectedItem as appetizer).Price > 0)
                    {
                        id = (grid.SelectedItem as appetizer).Id;
                        appetizer apet = (from p in _db.appetizers where p.Id == id select p).Single();
                        apet.Name = (grid.SelectedItem as appetizer).Name;
                        apet.Price = (grid.SelectedItem as appetizer).Price;
                        _db.SaveChanges();
                        grid.ItemsSource = _db.appetizers.ToList();
                    }
                    break;
                case 3:
                    if (!(grid.SelectedItem as mainCourse).Name.Equals(null) && (grid.SelectedItem as mainCourse).Price > 0)
                    {
                        id = (grid.SelectedItem as mainCourse).Id;
                        mainCourse mco = (from p in _db.mainCourses where p.Id == id select p).Single();
                        mco.Name = (grid.SelectedItem as mainCourse).Name;
                        mco.Price = (grid.SelectedItem as mainCourse).Price;
                        _db.SaveChanges();
                        grid.ItemsSource = _db.mainCourses.ToList();
                    }
                    break;
                case 4:
                    if (!(grid.SelectedItem as dessert).Name.Equals(null) && (grid.SelectedItem as dessert).Price > 0)
                    {
                        id = (grid.SelectedItem as dessert).Id;
                        dessert des = (from p in _db.desserts where p.Id == id select p).Single();
                        des.Name = (grid.SelectedItem as dessert).Name;
                        des.Price = (grid.SelectedItem as dessert).Price;
                        _db.SaveChanges();
                        grid.ItemsSource = _db.desserts.ToList();
                    }
                    break;

            }

        }



        private void InsertItem1(object sender, RoutedEventArgs e)
        {
            switch (category)
            {
                case 1:
                    int id = (grid.SelectedItem as beverage).Id;
                    if (!(grid.SelectedItem as beverage).Name.Equals(null) && (grid.SelectedItem as beverage).Price > 0 && (grid.SelectedItem as beverage).Id == 0)
                    {
                        beverage bev = new beverage();
                        bev.Name = (grid.SelectedItem as beverage).Name;
                        bev.Price = (grid.SelectedItem as beverage).Price;
                        _db.beverages.Add(bev);
                        _db.SaveChanges();
                        grid.ItemsSource = _db.beverages.ToList();
                    }
                    break;
                case 2:
                    if (!(grid.SelectedItem as appetizer).Name.Equals(null) && (grid.SelectedItem as appetizer).Price > 0 && (grid.SelectedItem as appetizer).Id == 0)
                    {
                        appetizer apet = new appetizer();
                        apet.Name = (grid.SelectedItem as appetizer).Name;
                        apet.Price = (grid.SelectedItem as appetizer).Price;
                        _db.appetizers.Add(apet);
                        _db.SaveChanges();
                        grid.ItemsSource = _db.appetizers.ToList();
                    }
                    break;
                case 3:
                    if (!(grid.SelectedItem as mainCourse).Name.Equals(null) && (grid.SelectedItem as mainCourse).Price > 0 && (grid.SelectedItem as mainCourse).Id == 0)
                    {
                        mainCourse mco = new mainCourse();
                        mco.Name = (grid.SelectedItem as mainCourse).Name;
                        mco.Price = (grid.SelectedItem as mainCourse).Price;
                        _db.mainCourses.Add(mco);
                        _db.SaveChanges();
                        grid.ItemsSource = _db.mainCourses.ToList();
                    }
                    break;
                case 4:
                    if (!(grid.SelectedItem as dessert).Name.Equals(null) && (grid.SelectedItem as dessert).Price > 0 && (grid.SelectedItem as dessert).Id == 0)
                    {
                        dessert des = new dessert();
                        des.Name = (grid.SelectedItem as dessert).Name;
                        des.Price = (grid.SelectedItem as dessert).Price;
                        _db.desserts.Add(des);
                        _db.SaveChanges();
                        grid.ItemsSource = _db.desserts.ToList();
                    }
                    break;

            }
        }



        private void ButtonShowClick(object sender, RoutedEventArgs e)
        {
            switch (menuCategory.Text)
            {
                case "Beverages":
                    grid.ItemsSource = _db.beverages.ToList();
                    category = 1;
                    break;
                case "Appetizers":
                    grid.ItemsSource = _db.appetizers.ToList();
                    category = 2;
                    break;
                case "MainCourses":
                    grid.ItemsSource = _db.mainCourses.ToList();
                    category = 3;
                    break;
                case "Desserts":
                    grid.ItemsSource = _db.desserts.ToList();
                    category = 4;
                    break;
                default:
                    grid.ItemsSource = _db.beverages.ToList();
                    category = 1;
                    break;
            }
        }
    }
}

        
 


