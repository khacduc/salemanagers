using Template.Core.Models;

namespace Template.Core.Contracts.Services;

// Remove this class once your pages/features are using your data.
public interface ISampleDataService
{
    Task<IEnumerable<SampleOrder>> GetContentGridDataAsync();

    Task<IEnumerable<SampleOrder>> GetGridDataAsync();
}

public interface ICustomer
{
    Task<IEnumerable<Customer>> GetContentGridDataAsync();

    Task<IEnumerable<Customer>> GetGridDataAsync();

    void SortById(int i);
}

public interface IOrder
{
    Task<IEnumerable<Order>> GetContentGridDataAsync();

    Task<IEnumerable<Order>> GetGridDataAsync();
}

public interface IProduct
{
    Task<IEnumerable<Product>> GetContentGridDataAsync();

    Task<IEnumerable<Product>> GetGridDataAsync();
}
