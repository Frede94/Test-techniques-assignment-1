using Xunit;

namespace BusCompany.UnitTests
{
    public class PriceCalculatorTests
    {
        PriceCalculator calculator;

        public PriceCalculatorTests(){
            calculator = new PriceCalculator();
        }

        [Theory]
        [InlineData(BusType.Standard, 0, 2500)]
        [InlineData(BusType.Mini, 99, 2594)]
        [InlineData(BusType.Luxory, 100, 4747)]
        [InlineData(BusType.Standard, 500, 6698)]
        [InlineData(BusType.Standard, 501, 6704)]
        //[InlineData(1,1, 22, -1)]
        //[InlineData(1,1, 75, -1)]
        public void CalculatePrice_ValidInlineData_PriceIsCorrect(BusType busType,int distance,decimal expectedPrice)
        {
            //Arrange
            PriceCalculator calculator = new PriceCalculator();
            //Act
            decimal price = calculator.CalculatePrice(distance, busType);
            //Assert
            Assert.Equal(price,expectedPrice);
        }

        //[Fact]
        //public void CalculatePrice_ValidInlineData_PriceIsWrong_Throws()
        //{
        //    //Arrange
        //    PriceCalculator calculator = new PriceCalculator();
        //    //Act
        //    decimal price = calculator.CalculatePrice(distance, busType);
        //    //Assert
        //    Assert.Equal(price, expectedPrice);
        //}

        [Fact]
        public void CalculatePrice_NegativeDistance_ThrowsException()
        {
            Assert.Throws<System.ArgumentException>(() => calculator.CalculatePrice(-1, BusType.Standard));
        }

    }
}
