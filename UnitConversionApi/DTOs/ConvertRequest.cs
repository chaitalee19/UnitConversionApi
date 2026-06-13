using System.ComponentModel.DataAnnotations;

public class ConvertRequest
{
    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    public string FromUnit { get; set; } = string.Empty;

    [Required]
    public string ToUnit { get; set; } = string.Empty;

    [Range(double.Epsilon, double.MaxValue,
        ErrorMessage = "Value must be greater than zero.")]
    public double Value { get; set; }
}