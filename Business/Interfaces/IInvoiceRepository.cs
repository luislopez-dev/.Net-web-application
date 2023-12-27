/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */

using Business.Models;

namespace Business.Interfaces;

public interface IInvoiceRepository
{
    public Task AddInvoice(Invoice invoice, CancellationToken cancellationToken);
    public Task<List<Invoice>> GetInvoicesPaginatedAsync(CancellationToken cancellationToken);
}