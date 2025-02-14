namespace TodoApi.Models;

public class User
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public int Balance { get; set; }
}
public class UserDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
}