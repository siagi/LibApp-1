using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.Include(c=>c.MembershipType).ToList();
        }

        public Task<Customer> GetAsyncCustomer(int id)
        {
            return _context.Customers.Include(c=>c.MembershipType).SingleOrDefaultAsync(c=>c.Id == id);
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c=>c.Id == id);
        }

        public void RemoveCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
