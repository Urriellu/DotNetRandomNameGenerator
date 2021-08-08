using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace RandomNameGeneratorNG
{
    public abstract class BaseNameGenerator
    {
        private static readonly string ResourcePathPrefix = $"{nameof(RandomNameGeneratorNG)}.Resources.";
        protected readonly Random RandGen;

        protected BaseNameGenerator()
        {
            RandGen = new Random();
        }

        protected BaseNameGenerator(Random randGen)
        {
            RandGen = randGen;
        }

        private static Stream ReadResourceStreamForFileName(string resourceFileName)
        {
            Assembly ass = typeof(BaseNameGenerator).GetTypeInfo().Assembly;
            return ass.GetManifestResourceStream(ResourcePathPrefix + resourceFileName) ?? throw new Exception($"Resource '{resourceFileName}' not found. Resources available: {string.Join(", ", ass.GetManifestResourceNames())}");
        }

        protected static string[] ReadResourceByLine(string resourceFileName)
        {
            var stream = ReadResourceStreamForFileName(resourceFileName);

            var list = new List<string>();

            var streamReader = new StreamReader(stream);
            string str;

            while ((str = streamReader.ReadLine()) != null)
            {
                if (str != string.Empty)
                    list.Add(str);
            }

            return list.ToArray();
        }
    }
}