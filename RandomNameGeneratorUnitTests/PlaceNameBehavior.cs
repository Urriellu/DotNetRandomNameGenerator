using System;
using System.Diagnostics;
using RandomNameGeneratorNG;
using Xunit;

namespace RandomNameGeneratorUnitTests
{
    public class PlaceNameBehavior
    {
        private readonly PlaceNameGenerator _placeGenerator = new PlaceNameGenerator();

        [Fact]
        public void ShouldGenerateRandomName()
        {
            string name = _placeGenerator.GenerateRandomPlaceName();
            Debug.WriteLine($"Generated name: {name}");
            Assert.False(string.IsNullOrWhiteSpace(name));
        }

        [Fact]
        public void ShouldGenerateSameNameIfSameRandomGenerator()
        {
            PersonNameGenerator personNameGenerator1 = new PersonNameGenerator(new Random(42));
            PersonNameGenerator personNameGenerator2 = new PersonNameGenerator(new Random(42));

            string firstName = personNameGenerator1.GenerateRandomFirstAndLastName();
            string secondName = personNameGenerator2.GenerateRandomFirstAndLastName();
            Debug.WriteLine($"Generated names: {firstName}, {secondName}");
            Assert.Equal(firstName, secondName);
        }
    }
}