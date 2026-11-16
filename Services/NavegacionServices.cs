using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Services
{
    public class Navegacionservice : INavegacionService
    {
        public Task GoToAsync(string uri)
        {
            return Shell.Current.GoToAsync(uri);
        }
        public Task GetTaskAsync(string uri, IDictionary<string, object> parameters)
        {
            return Shell.Current.GoToAsync(uri, parameters);
        }
    }
}
