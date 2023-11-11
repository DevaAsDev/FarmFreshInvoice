using System.ComponentModel;

namespace FarmFreshInvoice
{
    public interface IProduct
    {
        string Amount { get; set; }
        string Price { get; set; }
        string ProductName { get; set; }
        string Quantity { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}