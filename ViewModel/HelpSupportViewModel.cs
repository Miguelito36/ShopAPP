
using ShopApp.DataAcces;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShopApp.ViewModels;

public partial class HelpSupportViewModel : INotifyPropertyChanged
{
    private int _visitasPendientes = 5;
    private ObservableCollection<Client> _clients = new();
    private Client _clienteSeleccionado;

    private readonly INavegacionService _navegacionService;

    public HelpSupportViewModel(INavegacionService navegacionService)
    {
        var database = new ShopDbContext();

        Clients = new ObservableCollection<Client>(
            database.Clients.ToList());

        _navegacionService = navegacionService;
    }

    public int VisitasPendientes
    {
        get => _visitasPendientes;
        set
        {
            if (_visitasPendientes != value)
            {
                _visitasPendientes = value;
                RaisePropertyChanged();
            }
        }
    }

    public ObservableCollection<Client> Clients
    {
        get => _clients;
        set
        {
            if (_clients != value)
            {
                _clients = value;
                RaisePropertyChanged();
            }
        }
    }

    public Client ClienteSeleccionado
    {
        get => _clienteSeleccionado;
        set
        {
            if (_clienteSeleccionado != value)
            {
                _clienteSeleccionado = value;
                RaisePropertyChanged();

                if (_clienteSeleccionado != null)
                {
                    _ = AbrirDetalleAsync(_clienteSeleccionado.Id);
                }
            }
        }
    }

    private async Task AbrirDetalleAsync(int clienteId)
    {
        var uri = $"{nameof(HelpSupportDetailPage)}?id={clienteId}";
        await _navegacionService.GoToAsync(uri);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void RaisePropertyChanged(
        [CallerMemberName] string nombre = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(nombre));
    }
}
