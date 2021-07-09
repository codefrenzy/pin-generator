using NUnit.Framework;
using PIN.Generator;

namespace PIN.Tests
{
    [TestFixture]
    public class PINGeneratorServiceTests
    {
        private IPINGeneratorService pinGeneratorService; 

        [SetUp]
        public void SetUp()
        {
            pinGeneratorService = new PINGeneratorService();
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(1000)]
        public void GenerateUniqueNumericPINs_CorrectNumberOfPins(int numberOfPins)
        {
            var pins = pinGeneratorService.GenerateUniqueNumericPINs(numberOfPins, 4);
            Assert.AreEqual(pins.Count, numberOfPins);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void GenerateUniqueNumericPINs_InvalidNumberOfPins(int numberOfPins)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>
                (() => pinGeneratorService.GenerateUniqueNumericPINs(numberOfPins, 4));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void GenerateUniqueNumericPINs_InvalidLength(int length)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>
                (() => pinGeneratorService.GenerateUniqueNumericPINs(10, length));
        }

        [Test]
        public void GenerateAndPrint1000PINs()
        {
            var pins = pinGeneratorService.GenerateUniqueNumericPINs(1000, 4);

            foreach (var pin in pins)
            {
                TestContext.WriteLine(pin);
            }
        }
    }
}
