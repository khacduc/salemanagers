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
public class CustomerData : ICustomer
{
    private List<Customer> _all = null;
    public CustomerData()
    {
    }

    private static IEnumerable<Customer> All()
    {
        // The following is order summary data
        return GetAllData();
    }
    private static IEnumerable<Customer> GetAllData()
    {       
        return Data.statistics.SalesManager.Customers.Values.ToList();
    }
    public async Task<IEnumerable<Customer>> GetContentGridDataAsync()
    {
        _all = new List<Customer>(All());

        await Task.CompletedTask;
        return _all;
    }

    public async Task<IEnumerable<Customer>> GetGridDataAsync()
    {
        _all = new List<Customer>(All());

        await Task.CompletedTask;
        return _all;
    }

    public void SortById(int i)
    {
        switch (i)
        {
            case 1:
                SortItem.SortCustomersByID(_all, false);
                break;
            default:
                SortItem.SortCustomersByID(_all, false);
                break;
        }
    }

    public ICollection<Customer> Customers
    {
        get; set;
    }
  
}