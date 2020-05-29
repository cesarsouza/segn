using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using NGeoNames;
using NGeoNames.Entities;

namespace GeoNamesEnumGenerator
{

    class Program
    {
        static void Main(string[] args)
        {
            var downloader = GeoFileDownloader.CreateGeoFileDownloader();
            string destinationPath = Environment.CurrentDirectory;
            string countryPath = downloader.DownloadFile("countryInfo.txt", destinationPath).Single();
            IEnumerable<CountryInfo> countries = GeoFileReader.ReadCountryInfo(countryPath);

            var sb = new StringBuilder();
            sb.AppendLine("using System.ComponentModel.DataAnnotations;");
            sb.AppendLine();
            sb.AppendLine("public enum Countries");
            sb.AppendLine("{");
            foreach (CountryInfo country in countries)
            {
                sb.AppendLine(format(
                    name: country.Country,
                    groupName: country.Continent,
                    description: country.ISO_Numeric,
                    shortName: country.ISO_Alpha2,
                    memberName: country.ISO_Alpha3,
                    value: country.GeoNameId
                ));
            }
            sb.AppendLine("}");

            File.WriteAllText("..\\..\\..\\Countries.cs", sb.ToString());
        }

        private static string format(string name, string groupName, string description, string shortName, string memberName, int? value)
        {
            return $@"
    [Display(Name = ""{name}"", GroupName = ""{groupName}"", Description = ""{description}"", ShortName = ""{shortName}"")]
    {memberName} = {value},";
        }
    }
}
