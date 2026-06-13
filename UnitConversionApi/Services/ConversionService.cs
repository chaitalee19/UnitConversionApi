using UnitConversionApi.Constants;

namespace UnitConversionApi.Services
{
    public class ConversionService : IConversionService
    {
        public double Convert(
            string category,
            string fromUnit,
            string toUnit,
            double value)
        {
            switch (category.ToLower())
            {
                case "length":
                    return ConvertUsingFactors(
                        ConversionFactors.Length,
                        fromUnit,
                        toUnit,
                        value);

                case "weight":
                    return ConvertUsingFactors(
                        ConversionFactors.Weight,
                        fromUnit,
                        toUnit,
                        value);

                case "temperature":
                    return ConvertTemperature(
                        fromUnit,
                        toUnit,
                        value);

                case "area":
                    return ConvertUsingFactors(
                        ConversionFactors.Area,
                        fromUnit,
                        toUnit,
                        value);

                case "volume":
                    return ConvertUsingFactors(
                        ConversionFactors.Volume,
                        fromUnit,
                        toUnit,
                        value);

                case "time":
                    return ConvertUsingFactors(
                        ConversionFactors.Time,
                        fromUnit,
                        toUnit,
                        value);

                default:
                    throw new ArgumentException("Invalid category.");
            }
        }

        private double ConvertUsingFactors(
            Dictionary<string, double> factors,
            string fromUnit,
            string toUnit,
            double value)
        {
            if (!factors.ContainsKey(fromUnit))
                throw new ArgumentException($"Unsupported unit: {fromUnit}");
            if (!factors.ContainsKey(toUnit))
                throw new ArgumentException($"Unsupported unit: {toUnit}");
            double baseValue = value * factors[fromUnit];

            return baseValue / factors[toUnit];
        }

        private double ConvertTemperature(
            string fromUnit,
            string toUnit,
            double value)
        {
            double celsius;

            switch (fromUnit.ToLower())
            {
                case "celsius":
                    celsius = value;
                    break;

                case "fahrenheit":
                    celsius = (value - 32) * 5 / 9;
                    break;

                case "kelvin":
                    celsius = value - 273.15;
                    break;

                default:
                    throw new ArgumentException("Unsupported temperature unit.");
            }

            switch (toUnit.ToLower())
            {
                case "celsius":
                    return celsius;

                case "fahrenheit":
                    return (celsius * 9 / 5) + 32;

                case "kelvin":
                    return celsius + 273.15;

                default:
                    throw new ArgumentException("Unsupported temperature unit.");
            }
        }


        private void ValidateUnit(
    Dictionary<string, double> factors,
    string unit,
    string category)
        {
            if (!factors.ContainsKey(unit))
            {
                throw new ArgumentException(
                    $"'{unit}' is not a valid {category} unit.");
            }
        }
    }
}