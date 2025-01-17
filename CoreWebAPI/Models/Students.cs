using System.ComponentModel.DataAnnotations;
using CoreWebAPI.CustomValidation;

namespace CoreWebAPI.Models;

public class Students
{
    [Required(ErrorMessage = "Enter Studnt Name")]

    public string StudentName { get; set; }

    public string MobileNo { get; set; }
    public string Address { get; set; }
    [DateRenage]
    public DateTime DOB { get; set; }

}

