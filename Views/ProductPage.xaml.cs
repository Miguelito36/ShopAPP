using ShopApp.DataAcces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShopApp.Views
{
    public partial class ProductPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<Product> _products;
        private Product _productSelected;
        private bool _isRefreshing;
        private ICommand _refreshProductsCommand;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public Product ProductSelected
        {
            get { return _productSelected; }
            set
            {
                if (_productSelected != value)
                {
                    _productSelected = value;
                    OnPropertyChanged();
                    if (value != null)
                    {
                        GoToProductDetail(value);
                    }
                }
            }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RefreshProductsCommand
        {
            get
            {
                _refreshProductsCommand ??= new Command(LoadProducts);
                return _refreshProductsCommand;
            }
        }

        public ProductPage()
        {
            InitializeComponent();
            BindingContext = this;
            Products = new ObservableCollection<Product>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                IsRefreshing = true;
                using var dbContext = new ShopDbContext();
                var products = dbContext.Products.ToList();

                Products.Clear();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async void GoToProductDetail(Product product)
        {
            await Shell.Current.GoToAsync($"ProductDetailPage?id={product.Id}");
            ProductSelected = null; // Reset selection
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}