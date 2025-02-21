using System.ComponentModel.DataAnnotations;
using System;
using System.Linq;

public class AllowedValuesAttribute : ValidationAttribute
{
    private readonly string[] _allowedValues;

    public AllowedValuesAttribute(params string[] allowedValues)
    {
        _allowedValues = allowedValues;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Если значение отсутствует, пусть [Required] обработает это отдельно
        if (value == null)
            return ValidationResult.Success;

        if (value is string stringValue)
        {
            if (_allowedValues.Contains(stringValue))
                return ValidationResult.Success;
        }
        
        var allowed = string.Join(", ", _allowedValues);
        return new ValidationResult(ErrorMessage ?? $"Значение должно быть одним из следующих: {allowed}.");
    }
}

public class Bet
{
    public string Type { get; set; }
    public string Value { get; set; }
    public int Stake { get; set; }

}

public class BetDTO
{
    [Required]
    [AllowedValues("number", "color", "rank", "row", "numberSet", "column", "sequence", "even",
        ErrorMessage = "This type is incorect. Possible types: number, color, rank, row, numberSet, column, sequence, even")]
    public string Type{get;set;}
    [Required]
    public string Value{get;set;}

    [Required]
    public int Stake{get;set;}

}

public class BetAndWinDTO:BetDTO
{
    [Required]
    public bool Win {get; set;}
    [Required]
    public string Rand {get; set;}
}
