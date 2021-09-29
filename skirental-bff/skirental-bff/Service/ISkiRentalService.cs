using skirental_bff.Models;

namespace skirental_bff.Service
{
    public interface ISkiRentalService
    {
        public SkiResponseModel GetSkiLength(int height, string ageCategory, string skiType);
    }
}