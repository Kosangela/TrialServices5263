using Services5263;
using System.ComponentModel.DataAnnotations;

public class Room
{
    [Key]
    public int RoomId { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    public int Floor { get; set; }

    [Required]
    public string Type { get; set; }

    // Navigation property for relating guests to rooms
    public ICollection<Guest> Guests { get; set; }
}
