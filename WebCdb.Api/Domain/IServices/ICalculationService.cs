using WebCdb.Models.Request;
using WebCdb.Models.Response;

namespace WebCdb.Domain.IServices
{
    public interface ICalculationService
    {
        CdbResponse CalculateCdb(CdbRequest request);
    }
}
