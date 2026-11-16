
using ShopApp.DataAcces;
using ShopApp;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage, IQueryAttributable
{
    public HelpSupportDetailPage()
    {
        InitializeComponent();
        BindingContext = new HelpSupportDetailData();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Title = $"Cliente: {query["id"]}";

        var clienteId = int.Parse(query["id"].ToString());

        (BindingContext as HelpSupportDetailData).ClienteId = clienteId;
    }
}

public class HelpSupportDetailData : ViewModelGlobal
{
    private ObservableCollection<Product> _products;
    private Product _productoseleccionado;
    private int _cantidad;

    public HelpSupportDetailData()
    {
        var database = new ShopDbContext();

        Products = new ObservableCollection<Product>(database.Products);

        cantidad = 1;

        AddCommand = new MiComando(() =>
        {
            if (productoseleccionado == null)
                return;

            var compra = new Compra(
                ClienteId,
                productoseleccionado.Id,
                cantidad);

            Compras.Add(compra);

        }, () => productoseleccionado != null);
    }

    public ICommand AddCommand { get; set; }

    private ObservableCollection<Compra> _compras = new();

    public ObservableCollection<Compra> Compras
    {
        get => _compras;
        set
        {
            if (_compras != value)
            {
                _compras = value;
                RaisePropertyChanged();
            }
        }
    }

    private int _clienteId;

    public int ClienteId
    {
        get => _clienteId;
        set
        {
            if (_clienteId != value)
            {
                _clienteId = value;
                RaisePropertyChanged();
            }
        }
    }

    public ObservableCollection<Product> Products
    {
        get => _products;
        set
        {
            if (_products != value)
            {
                _products = value;
                RaisePropertyChanged();
            }
        }
    }

    public Product productoseleccionado
    {
        get => _productoseleccionado;
        set
        {
            if (_productoseleccionado != value)
            {
                _productoseleccionado = value;
                RaisePropertyChanged();

                (AddCommand as MiComando)?.RaiseCanExecuteChanged();
            }
        }
    }

    public int cantidad
    {
        get => _cantidad;
        set
        {
            if (_cantidad != value)
            {
                _cantidad = value;
                RaisePropertyChanged();
            }
        }
    }
}

