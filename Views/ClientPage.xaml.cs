using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ClientPage : ContentPage
{
	public ClientPage()
	{
		InitializeComponent();

        var dbContext = new ShopAppDbContext();

        foreach (var client in dbContext.Clients)
        {
            container.Children.Add(new Label { Text = client.Nombre });
        }

    }
}