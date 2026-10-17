using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.Platform.Compatibility;
using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage, IQueryAttributable
{
	public HelpSupportDetailPage()
	{
		InitializeComponent();
	}
        
    public class HelpSupportDetailData : BindingUtilObject
    {
        public HelpSupportDetailData()
        {
            var database = new ShopDbContext();
            Products = new ObservableCollection<Product>(database.Products);
        }

        private ObservableCollection<Product> _products;
        private Product _productoSeleccionado;
        private int _cantidad;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                RaisePropertyChanged();
            }
        }

        public Product ProductoSeleccionado
        {
            get { return _productoSeleccionado; }
            set
            {
                if (_productoSeleccionado != value)
                {
                    _productoSeleccionado = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                if(_cantidad != value)
                {
                    _cantidad = value;
                    RaisePropertyChanged();
                }
            }
        }


    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
		Title = $"Cliente: {query["id"]}";
    }
}