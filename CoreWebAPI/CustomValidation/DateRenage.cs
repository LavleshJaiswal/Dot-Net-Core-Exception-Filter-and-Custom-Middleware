using System.ComponentModel.DataAnnotations;

namespace CoreWebAPI.CustomValidation;

public class DateRenage : ValidationAttribute
{
    private readonly DateTime _minDate;
    private readonly DateTime _maxDate;

    public DateRenage()
    {
        _minDate = DateTime.Parse("1900/01/01");
        _maxDate = DateTime.Now.Date;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return new ValidationResult("Date is required");
        if (value is DateTime dateTime)
        {
            if (dateTime < _minDate || dateTime >= _maxDate)
                return new ValidationResult($"Date must be between {_minDate} and {_maxDate}");
        }
        else
            return new ValidationResult("Date format is wrong");

        return ValidationResult.Success;
    }
}
