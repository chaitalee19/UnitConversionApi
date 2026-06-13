namespace UnitConversionApi.Constants
{
    public static class ConversionFactors
    {
        public static readonly Dictionary<string, double> Length =
      new(StringComparer.OrdinalIgnoreCase)
  {
    { "Meter", 1 },
    { "Kilometer", 1000 },
    { "Centimeter", 0.01 },
    { "Millimeter", 0.001 },
    { "Foot", 0.3048 },
    { "Inch", 0.0254 },
    { "Yard", 0.9144 }
  };

        public static readonly Dictionary<string, double> Weight =
            new(StringComparer.OrdinalIgnoreCase)
        {
    { "Kilogram", 1 },
    { "Gram", 0.001 },
    { "Milligram", 0.000001 },
    { "Pound", 0.453592 }
        };
 



    public static readonly Dictionary<string, double> Area =
    new(StringComparer.OrdinalIgnoreCase)
{
    { "SquareMeter", 1 },
    { "SquareKilometer", 1000000 },
    { "SquareFoot", 0.092903 },
    { "SquareInch", 0.00064516 },
    { "Acre", 4046.86 }
};

    public static readonly Dictionary<string, double> Volume =
        new(StringComparer.OrdinalIgnoreCase)
    {
    { "Liter", 1 },
    { "Milliliter", 0.001 },
    { "CubicMeter", 1000 },
    { "Gallon", 3.78541 }
    };

    public static readonly Dictionary<string, double> Time =
        new(StringComparer.OrdinalIgnoreCase)
    {
    { "Second", 1 },
    { "Minute", 60 },
    { "Hour", 3600 },
    { "Day", 86400 }
    };



        
    };


}
