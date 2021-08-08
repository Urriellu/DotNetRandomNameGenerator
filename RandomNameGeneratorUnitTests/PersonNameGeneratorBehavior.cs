using System.Diagnostics;
using System.Linq;
using RandomNameGeneratorNG;
using Xunit;

namespace RandomNameGeneratorUnitTests
{
    public class PersonNameGeneratorBehavior
    {
        private readonly PersonNameGenerator _personGenerator;

        public PersonNameGeneratorBehavior()
        {
            _personGenerator = new PersonNameGenerator();
        }

        [Fact]
        public void GetTheProperNumberOfRequestedNamesWithoutRepeats()
        {
            var result = _personGenerator.GenerateMultipleFirstAndLastNames(2).AsQueryable();
            Debug.WriteLine($"Generated names: {string.Join(", ", result)}");
            Assert.Equal(2, result.Count());
            Assert.NotEqual(result.First(), result.Last());
        }

        [Fact]
        public void WhenAFirstAndLastNameAreGeneratedTogetherTheyShouldHaveASpaceBetweenThem()
        {
            string result = _personGenerator.GenerateRandomFirstAndLastName();
            Debug.WriteLine($"Generated name: {result}");
            Assert.NotNull(result);
            Assert.NotEqual(-1, result.IndexOf(' '));
        }

        [Fact]
        public void WhenMultipleFemaleFirstAndLastNamesAreGeneratedTogetherTheyShouldHaveASpaceBetweenThem()
        {
            string result = _personGenerator.GenerateMultipleFemaleFirstAndLastNames(2).First();
            Debug.WriteLine($"Generated name: {result}");
            Assert.NotNull(result);
            Assert.NotEqual(-1, result.IndexOf(' '));
        }
    }
}