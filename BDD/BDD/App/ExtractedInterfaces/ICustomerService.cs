namespace App.ExtractedInterfaces
{
    public interface ICustomerService
    {
        bool AddCustomer(Customer customerInfo);
        void GetCustomerCredit(Company company, Customer customer);
    }
}
