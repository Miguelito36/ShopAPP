using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;

namespace ShopApp
{
    public class BindingUtilObject : INotifyPropertyChanged
    {
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
