using SalesManagerCore;
using Template.Core.Contracts.Services;
using Template.Core.Models;

namespace Template.Core.Services;

// This class holds sample data used by some generated pages to show how they can be used.
// TODO: The following classes have been created to display sample data. Delete these files once your app is using real data.
// 1. Contracts/Services/ISampleDataService.cs
// 2. Services/SampleDataService.cs
// 3. Models/SampleCompany.cs
// 4. Models/SampleOrder.cs
// 5. Models/SampleOrderDetail.cs
public class ProductData : IProduct
{
    private List<Product> _all = null;
    public ProductData()
    {
    }

    private static IEnumerable<Product> All()
    {
        // The following is order summary data
        return GetAllData();
    }
    private static IEnumerable<Product> GetAllData()
    {
        return Data.statistics.SalesManager.Products.Values;
    }
    public async Task<IEnumerable<Product>> GetContentGridDataAsync()
    {
        _all = new List<Product>(All());

        await Task.CompletedTask;
        return _all;
    }

    public async Task<IEnumerable<Product>> GetGridDataAsync()
    {
        _all = new List<Product>(All());

        await Task.CompletedTask;
        return _all;
    }
    public ICollection<Product> Products
    {
        get; set;
    }
}