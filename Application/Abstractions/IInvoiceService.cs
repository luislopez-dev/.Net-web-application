/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */

using Business.Models;

namespace Application.Abstractions;

public interface IInvoiceService
{
    public Task AddInvoiceAsync(Invoice invoice, int[] selectedProducts, CancellationToken cancellationToken);
    public Task<List<Invoice>> GetInvoicesPaginatedAsync(CancellationToken cancellationToken);
}