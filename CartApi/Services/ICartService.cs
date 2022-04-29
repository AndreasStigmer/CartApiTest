using CartApi.Models;
using System.Collections.Generic;

namespace CartApi.Services
{
    public interface ICartService
    {
        double Total();
        IEnumerable<CartItem> Items();
    }
}
