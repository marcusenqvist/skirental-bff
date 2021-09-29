using skirental_bff.Service;
using Xunit;

namespace SkiRentalTests
{
    public class SkiRentalTests
    {
        [Fact]
        public void GetSkis_Under5years_ShouldReturnHeight()
        {
            var skiService = new SkiRentalService();

            var expectedMinLength = 70;
            var expectedMaxLength = 70;

            var actual = skiService.GetSkiLength(70, "TODDLER", "CLASSIC");

            Assert.Equal(expectedMinLength, actual.MinLength);
            Assert.Equal(expectedMaxLength, actual.MaxLength);
        }

        [Fact]
        public void GetSkis_Between5and8_ShouldReturnHeightPlus10to20()
        {
            var skiService = new SkiRentalService();

            var expectedMinLength = 80;
            var expectedMaxLength = 90;

            var actual = skiService.GetSkiLength(70, "CHILD", "CLASSIC");

            Assert.Equal(expectedMinLength, actual.MinLength);
            Assert.Equal(expectedMaxLength, actual.MaxLength);
        }

        [Fact]
        public void GetSkis_Between5and8_ShouldReturnSameLengthForDifferentSkis()
        {
            var skiService = new SkiRentalService();

            var classic = skiService.GetSkiLength(70, "CHILD", "CLASSIC");
            var freestyle = skiService.GetSkiLength(70, "CHILD", "FREESTYLE");

            Assert.Equal(classic.MinLength, freestyle.MinLength);
            Assert.Equal(classic.MaxLength, freestyle.MaxLength);
        }

        [Fact]
        public void GetSkis_AdultWithClassic_ShouldReturnHeightPlus20()
        {
            var skiService = new SkiRentalService();

            var expectedMinLength = 190;
            var expectedMaxLength = 190;

            var actual = skiService.GetSkiLength(170, "ADULT", "CLASSIC");

            Assert.Equal(expectedMinLength, actual.MinLength);
            Assert.Equal(expectedMaxLength, actual.MaxLength);
        }

        [Fact]
        public void GetSkis_AdultWithClassic_ShouldReturnMax207()
        {
            var skiService = new SkiRentalService();

            var expectedMinLength = 207;
            var expectedMaxLength = 207;

            var actual = skiService.GetSkiLength(200, "ADULT", "CLASSIC");

            Assert.Equal(expectedMinLength, actual.MinLength);
            Assert.Equal(expectedMaxLength, actual.MaxLength);
        }

        [Fact]
        public void GetSkis_AdultWithFreestyle_ShouldReturnHeightPlus10to15()
        {
            var skiService = new SkiRentalService();

            var expectedMinLength = 180;
            var expectedMaxLength = 185;

            var actual = skiService.GetSkiLength(170, "ADULT", "FREESTYLE");

            Assert.Equal(expectedMinLength, actual.MinLength);
            Assert.Equal(expectedMaxLength, actual.MaxLength);
        }
    }
}
