namespace TodoApi.Models;

public class User
{
    public uint Id { get; set; }
    public string? Name { get; set; }
    public int Balance { get; set; }
}
public class UserDTO
{
    public uint Id { get; set; }
    public string? Name { get; set; }
}