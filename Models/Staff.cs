namespace ResturantApp.Models
{
public class Staff
{

public int StaffId{get; set;}
public string? StaffName{get; set;}
public string? Role{get; set;}

public List<Order>? Orders {get; set;}
public List<MenuItem>?Items{get; set;}
public List<Reservation>?Reservations{get; set;}
}
}