namespace Business.Interfaces;

public interface IInvoiceProductRepository
{
    public void CreateRecord(int invoiceId, int[] selectedProducts);
}