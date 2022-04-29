using CartApi.Models;
using System.Collections.Generic;

namespace CartApi.Services
{
    public interface IShipmentService
    {
        void Ship(IAddressInfo info, IEnumerable<CartItem> items);
    }
}
