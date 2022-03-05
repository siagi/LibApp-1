using LibApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        Task<Customer> GetAsyncCustomer(int id);
        void AddCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        int Save();
    }
}
