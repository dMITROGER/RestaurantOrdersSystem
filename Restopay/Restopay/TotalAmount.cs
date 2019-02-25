using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restopay
{
    class TotalAmount : INotifyPropertyChanged
    {
        string subt = null;

        public string subtotal
        {
            get { return subt; }
            set
            {
                if (subt != value)
                {
                    subt = value;
                    OnPropertyChanged("subtotal");
                    OnPropertyChanged("Tax");
                    OnPropertyChanged("Total");
                }
            }
        }

        string tax = null;
        public string Tax
        {
            get { return tax; }
            set
            {
                if (tax != value)
                {
                    tax = value;
                    OnPropertyChanged("Tax");
                }
            }
        }
        string total = null;
        public string Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                    OnPropertyChanged("Total");
                }
            }
        }



        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
