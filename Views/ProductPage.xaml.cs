using System.Linq;
using ShopApp.DataAcces;

namespace ShopApp.Views;

public partial class ProductPage : ContentPage
{
	public ProductPage()
	{
		InitializeComponent();

		var dbContext = new ShopAppDbContext(); 

		foreach (var product in dbContext.Products)
		{
			var boton = new Button { Text = product.Nombre };
			boton.Clicked += async (s, e) =>
			{
				var uri = $"{nameof(ProductDetailPage)}?id={product.Id}";
				await Shell.Current.GoToAsync(uri);
			};

			container.Children.Add(boton);
		}
	}
}