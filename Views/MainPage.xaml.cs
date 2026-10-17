using System.Text;
using ShopApp.DataAcces;

namespace ShopApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var dbContext = new ShopAppDbContext();

            // ==========================================
            // CANTIDAD DE REGISTROS
            // ==========================================

            category.Text = "Cantidad de categorías: "
                            + dbContext.Categories.Count();

            client.Text = "Cantidad de clientes: "
                          + dbContext.Clients.Count();

            product.Text = "Cantidad de productos: "
                           + dbContext.Products.Count();


            // ==========================================
            // 1. PRODUCTOS DE LA CATEGORÍA COMPUTADORAS
            // ==========================================

            var categoriaComputadoras = dbContext.Categories
                .FirstOrDefault(c => c.Nombre == "Computadoras");

            if (categoriaComputadoras != null)
            {
                var productosComputadoras = dbContext.Products
                    .Where(p => p.CategoryId == categoriaComputadoras.Id)
                    .ToList();

                foreach (var p in productosComputadoras)
                {
                    var label = new Label
                    {
                        Text = $"• {p.Nombre} - ${p.Precio}",
                        FontSize = 16
                    };

                    listaComputadoras.Children.Add(label);
                }
            }


            // ==========================================
            // 2. PRODUCTOS CON PRECIO MAYOR A $1000
            // ==========================================

            var productosCaros = dbContext.Products
                .Where(p => p.Precio > 1000)
                .ToList();

            foreach (var p in productosCaros)
            {
                var label = new Label
                {
                    Text = $"• {p.Nombre} - ${p.Precio}",
                    FontSize = 16
                };

                listaProductosCaros.Children.Add(label);
            }


            // ==========================================
            // 3. CATEGORÍA DEL PRODUCTO MÁS CARO
            // ==========================================

            var productoCaro = dbContext.Products
                .OrderByDescending(p => p.Precio)
                .FirstOrDefault();

            if (productoCaro != null)
            {
                var categoria = dbContext.Categories
                    .FirstOrDefault(c => c.Id == productoCaro.CategoryId);

                productoMasCaro.Text =
                    $"Producto: {productoCaro.Nombre}";

                precioMasCaro.Text =
                    $"Precio: ${productoCaro.Precio}";

                if (categoria != null)
                {
                    categoriaMasCaro.Text =
                        $"Categoría: {categoria.Nombre}";
                }
            }
        }
    }
}
