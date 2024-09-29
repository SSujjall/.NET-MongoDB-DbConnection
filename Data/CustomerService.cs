using MongoDB.Driver;
using NetMongoDbTest.Models;

namespace NetMongoDbTest.Data
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customerCollection;
        public CustomerService(DbContext context)
        {
            _customerCollection = context._customerCollection;
        }

        public async Task<List<Customer>> GetAsync()
        {
            return await _customerCollection.Find(customer => true).ToListAsync();
        }

        public async Task<Customer> GetAsyncById(Guid id)
        {
            return await _customerCollection.Find(customer => customer.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Customer customer)
        {
            await _customerCollection.InsertOneAsync(customer);
        }

        public async Task UpdateAsync(Guid id, Customer customer)
        {
            await _customerCollection.ReplaceOneAsync(c => c.Id == id, customer);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _customerCollection.DeleteOneAsync(c => c.Id == id);
        }
    }
}