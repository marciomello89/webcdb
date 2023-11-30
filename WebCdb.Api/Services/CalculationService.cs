using WebCdb.Domain.IServices;
using WebCdb.Models.Request;
using WebCdb.Models.Response;

namespace WebCdb.Services
{
    public class CalculationService : ICalculationService
    {
        public CdbResponse CalculateCdb(CdbRequest request)
        {
            decimal rawValue = request.Value;
            decimal initialValue = request.Value;

            for (int i = 1; i <= request.Period; i++)
            {
                rawValue = CalculateByPeriod(rawValue);
            }

            return new CdbResponse()
            {
                RawValue = rawValue,
                LiquidValue = CalculateLiquidValue(rawValue, initialValue, request.Period)
            };
        }

        private decimal CalculateByPeriod(decimal rawValue)
        {
            decimal fixedValue = 0.009M * 1.08M;

            return rawValue * (1 + fixedValue);
        }

        private decimal GetTaxValue(int period)
        {
            if (period <= 6)
                return 0.225M;
            else if (period <= 12)
                return 0.2M;
            else if (period <= 24)
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