using CartApi.Models;

namespace CartApi.Services
{
    public interface IPaymentService
    {
        bool Charge(double total, ICard card);
    }
}
