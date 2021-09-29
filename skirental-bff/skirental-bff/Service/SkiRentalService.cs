using skirental_bff.Constants;
using skirental_bff.Models;
using System;

namespace skirental_bff.Service
{
    public class SkiRentalService : ISkiRentalService
    {
        public SkiResponseModel GetSkiLength(int height, string ageCategory, string skiType)
        {
            switch (ageCategory)
            {
                case nameof(AgeCategories.ADULT):
                    return skiType == nameof(SkiTypes.FREESTYLE) ? GetFreestyleSkis(height) : GetClassicSkis(height);

                case nameof(AgeCategories.CHILD):
                    return GetChildSkis(height);

                case nameof(AgeCategories.TODDLER):
                    return GetToddlerSkis(height);
                
                default:
                    throw new InvalidOperationException(ageCategory);
            }
        }

        private static SkiResponseModel GetClassicSkis(int height)
        {
            var response = new SkiResponseModel();

            response.MinLength = (height + 20) > 207 ? 207 : height + 20;
            response.MaxLength = (height + 20) > 207 ? 207 : height + 20;

            return response;
        }

        private static SkiResponseModel GetFreestyleSkis(int height)
        {
            var response = new SkiResponseModel();

            response.MinLength = height + 10;
            response.MaxLength = height + 15;

            return response;
        }

        private static SkiResponseModel GetChildSkis(int height)
        {
            var response = new SkiResponseModel();

            response.MinLength = height + 10;
            response.MaxLength = height + 20;

            return response;
        }

        private static SkiResponseModel GetToddlerSkis(int height)
        {
            var response = new SkiResponseModel();

            response.MinLength = height;
            response.MaxLength = height;

            return response;
        }
    }
}
