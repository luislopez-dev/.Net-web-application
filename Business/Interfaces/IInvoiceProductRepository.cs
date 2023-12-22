namespace Business.Interfaces;

public interface IInvoiceProductRepository
{
    public Task CreateRecordAsync(int invoiceId, int[] selectedProducts);
}