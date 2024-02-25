namespace ResturantApp.Models
{
    public class Reservation
    {
  public int ReservationId { get; set; }
    public int CustomerId { get; set; } 
    public DateTime ReservationDateTime {get; set;}
    public int NumberOfGuests { get; set; }
    public Customer ? Customer { get; set; }

    }
}