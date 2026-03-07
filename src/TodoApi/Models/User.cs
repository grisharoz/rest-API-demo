namespace TodoApi.Models;

public class User
{
    public ulong Id { get; set; }
    public string? Name { get; set; }
    public int Balance { get; set; }
}
public class UserDTO
{
    public ulong Id { get; set; }
    public string? Name { get; set; }
}