using System.ComponentModel.DataAnnotations;

namespace RingoMedia.ModulesTask.Services;

public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime dateTime)
        {
            return dateTime > DateTime.Now;
        }
        else
        {
            throw new ArgumentException("This attribute must be applied to DateTime value.");
        }
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} must be a future date time.";
    }
}

