namespace Business.Interfaces;

public interface IInvoiceProductRepository
{
    public Task CreateRecord(int invoiceId, int[] selectedProducts);
}