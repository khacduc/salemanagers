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
public class SampleDataService : ISampleDataService
{
    private List<SampleOrder> _allOrders;

    public SampleDataService()
    {
    }

    private static IEnumerable<SampleOrder> AllOrders()
    {
        // The following is order summary data
        var companies = AllCompanies();
        return companies.SelectMany(c => c.Orders);
    }

    private static IEnumerable<SampleCompany> AllCompanies()
    {
        return new List<SampleCompany>()
        {
           
        };
    }

    public async Task<IEnumerable<SampleOrder>> GetContentGridDataAsync()
    {
        if (_allOrders == null)
        {
            _allOrders = new List<SampleOrder>(AllOrders());
        }

        await Task.CompletedTask;
        return _allOrders;
    }

    public async Task<IEnumerable<SampleOrder>> GetGridDataAsync()
    {
        if (_allOrders == null)
        {
            _allOrders = new List<SampleOrder>(AllOrders());
        }

        await Task.CompletedTask;
        return _allOrders;
    }
}
