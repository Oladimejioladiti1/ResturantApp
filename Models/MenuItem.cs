namespace ResturantApp.Models
{
public class MenuItem
{
public int MenuItemId{get; set;}
public string?  MenuItemName{get; set;}

public Customer?     Customer { get; set;}

}
}