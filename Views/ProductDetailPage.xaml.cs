using System.ComponentModel;
using ShopApp.DataAcces;
using System.Linq;

namespace ShopApp.Views;

public partial class ProductDetailPage : ContentPage, IQueryAttributable
{
    public ProductDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("id", out var idObj) && idObj is string idStr && int.TryParse(idStr, out var id))
        {
            var dbContext = new ShopAppDbContext();
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                container.Children.Add(new Label { Text = product.Nombre });
                container.Children.Add(new Label { Text = product.Descripcion });
                container.Children.Add(new Label { Text = product.Precio.ToString() });
            }
        }
    }
}
 