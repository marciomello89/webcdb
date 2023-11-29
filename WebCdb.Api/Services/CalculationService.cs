using WebCdb.Domain.IServices;
using WebCdb.Models.Request;
using WebCdb.Models.Response;

namespace WebCdb.Services
{
    public class CalculationService : ICalculationService
    {
        public CdbResponse CalculateCdb(CdbRequest request)
        {
            decimal rawValue = request.value;
            decimal initialValue = request.value;

            for (int i = 1; i <= request.period; i++)
            {
                rawValue = CalculateByPeriod(rawValue, i);
            }

            return new CdbResponse()
            {
                rawValue = rawValue,
                liquidValue = CalculateLiquidValue(rawValue, initialValue, request.period)
            };
        }

        private decimal CalculateByPeriod(decimal rawValue, int period)
        {
            decimal fixedValue = 0.009M * 1.08M;

            return rawValue * (1 + fixedValue);
        }

        private decimal GetTaxValue(int period)
        {
            if (period <= 6)
                return 0.225M;
            else if (period > 6 && period <= 12)
                return 0.2M;
            else if (period > 12 && period <= 24)
                return 0.175M;
            else
                return 0.15M;
        }

        private decimal CalculateLiquidValue(decimal rawValue, decimal initialValue, int period)
        {
            decimal difference = rawValue - initialValue;
            return rawValue - (difference * GetTaxValue(period));
        }
    }
}