<h1><b>S</b>ystem.<b>E</b>nums.<b>G</b>eo<b>N</b>ames (segn)</h1>

This super small project can be used to generate strongly-typed enumerations for country names and other information contained in the [GeoNames database](http://www.geonames.org/). You can use it to generate enum types to [copy and paste into your projects](https://github.com/cesarsouza/segn/blob/master/src/Countries.cs). To generate a custom enumeration, just download the source and customize which properties from [NGeoNames.CountryInfo](https://github.com/RobThree/NGeoNames/blob/master/NGeoNames/Entities/CountryInfo.cs) you would like to see in your enumeration by changing [the main program](https://github.com/cesarsouza/segn/blob/d131525cc921deb06d01af06bcc84e519fb96111/src/Program.cs#L27-L36):


```csharp
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
```

With just a few modifications you can also use it to generate state/region names and/or include additional information, such as currency, languages, or set the enum value directly to the respective ISO-3166-1 code for each country.

If you are just interested in copy-pasting the default enum into your projects, [just copy it from here](https://github.com/cesarsouza/segn/blob/master/src/Countries.cs).

-----

See also:
 - [System.Enums.FontAwesome (sefa)](https://github.com/cesarsouza/sefa): strongly typed enumerations for [Font Awesome](https://fontawesome.com/).
