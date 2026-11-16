
using ShopApp.DataAcces;
using ShopApp.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
    public HelpSupportPage(HelpSupportViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }


}



