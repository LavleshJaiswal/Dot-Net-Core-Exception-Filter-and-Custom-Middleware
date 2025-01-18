

namespace CoreWebAPI.Models;

public class Students
{ 
    [Required(ErrorMessage = "Enter Student Name"), JsonPropertyName("name")]

    public string StudentName { get; set; }
    [Required(ErrorMessage ="Mobile Number Field is Required"), JsonPropertyName("mobileno")]
    public string MobileNo { get; set; }
    [JsonPropertyName("address")]
    public string Address { get; set; }
    [JsonPropertyName("dbo")]
    [DateRenage]
    public DateTime DOB { get; set; }

}

public class Manage
{
    [Required]
    public string Name { get; set; }
    [Required(ErrorMessage ="Email field is required")]
    public string Email { get; set; }
}


