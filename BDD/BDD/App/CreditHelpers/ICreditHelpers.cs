namespace App.CreditHelpers
{
    public interface ICreditHelpers
    {
        int GetCreditLimitWithImportantClient(Customer customer);
        int GetCreditLimitWithNormalClient(Customer customer);
    }
}
