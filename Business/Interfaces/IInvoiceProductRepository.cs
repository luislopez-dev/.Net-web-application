/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */

namespace Business.Interfaces;

public interface IInvoiceProductRepository
{
    public Task CreateRecordAsync(int invoiceId, int[] selectedProducts, CancellationToken cancellationToken);
}