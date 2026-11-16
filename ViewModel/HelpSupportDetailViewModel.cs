using ShopApp.DataAcces;
using ShopApp;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public class HelpSupportDetailViewModel : ViewModelGlobal, IQueryAttributable
{
    private ObservableCollection<Product> _products = new();
    private Product _productoseleccionado;
    private int _cantidad = 1;
    private int _clienteId;
    private ObservableCollection<Compra> _compras = new();

    public HelpSupportDetailViewModel()
    {
        var database = new ShopDbContext();

        Products = new ObservableCollection<Product>(database.Products);

        AddCommand = new MiComando(() =>
        {
            if (productoseleccionado == null)
                return;

            var compra = new Compra(
                ClienteId,
                productoseleccionado.Id,
                cantidad
            );

            Compras.Add(compra);
        }, () => productoseleccionado != null);
    }

    public ObservableCollection<Product> Products
    {
        get => _products;
        set
        {
            _products = value;
            RaisePropertyChanged();
        }
    }

    public Product productoseleccionado
    {
        get => _productoseleccionado;
        set
        {
            _productoseleccionado = value;
            RaisePropertyChanged();
        }
    }

    public int cantidad
    {
        get => _cantidad;
        set
        {
            _cantidad = value;
            RaisePropertyChanged();
        }
    }

    public int ClienteId
    {
        get => _clienteId;
        set
        {
            _clienteId = value;
            RaisePropertyChanged();
        }
    }

    public ObservableCollection<Compra> Compras
    {
        get => _compras;
        set
        {
            _compras = value;
            RaisePropertyChanged();
        }
    }

    public ICommand AddCommand { get; set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ClienteId = int.Parse(query["id"].ToString());
    }
}