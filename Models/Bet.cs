using System.ComponentModel.DataAnnotations;

public class Bet
{
    public string Type { get; set; }
    public string Value { get; set; }
    public int Stake { get; set; }

}

public class BetDTO
{
    [Required]
    public string Type { get; set; }
    [Required]
    public string Value { get; set; }

    [Required]
    public int Stake { get; set; }
}