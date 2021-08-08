using System.Collections.Generic;

namespace RandomNameGeneratorNG
{
    public interface IPlaceNameGenerator
    {
        string GenerateRandomPlaceName();

        IEnumerable<string> GenerateMultiplePlaceNames(int numberOfNames);
    }
}