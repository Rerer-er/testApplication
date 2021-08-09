using Entities.Models;

namespace Pact
{
    public interface ICurrencyConverter
    {
        decimal ConvertToCurrentForFiltr(decimal price, string currency);
        void ConvertToCurrent(Product products, string currency);
    }
}
