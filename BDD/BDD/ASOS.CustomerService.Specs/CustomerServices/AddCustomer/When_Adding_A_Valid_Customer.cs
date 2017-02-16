using Machine.Specifications;

namespace ASOS.CustomerService.Specs.CustomerServices.AddCustomer
{
    public class When_Adding_A_Valid_Customer : GivenACustomer
    {
        private static bool _result;

        Because of = () => _result = _mockCustomerService.AddCustomer(_customerInfo);

        It Should_Return_True = () =>
        {
            _result.ShouldEqual(true);
        };
    
    }
}