using System.ComponentModel.DataAnnotations;
namespace Services5263;
public class Guest
{
    [Key]
    public int GuestId { get; set; }

    [Required]
    [StringLength(200)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(400)]
    public string LastName { get; set; }

    [Required]
    public DateTime DOB { get; set; }

    [Required]
    [StringLength(600)]
    public string Address { get; set; }

    [Required]
    public string Nationality { get; set; }

    [Required]
    public DateTime CheckInDate { get; set; }

    [Required]
    public DateTime CheckOutDate { get; set; }
}
