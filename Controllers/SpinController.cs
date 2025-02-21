using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TodoApi.Models;


namespace TodoApi.Controllers;



public class Balance
{
    private int balance;
    private bool isWinner;
    private int bet;

    public Balance(int balance, bool isWinner, int bet)
    {
        this.SetBalance(balance);
        this.SetIsWinner(isWinner);
        this.SetBet(bet);
    }

    public int GetBalance()
    {
        return this.balance;
    }
    public void SetBalance(int balance)
    {

        if (balance < 0)
        {
            throw new ArgumentException(nameof(balance), "Баланс не должен быть меньше 0");
        }
        this.balance = balance;

    }
    public bool GetisWinner()
    {
        return this.isWinner;
    }
    public void SetIsWinner(bool isWinner)
    {

        this.isWinner = isWinner;
    }

    public int GetBet()
    {
        return this.bet;
    }
    public void SetBet(int bet)
    {

        if (bet < 0)
        {
            throw new ArgumentException(nameof(balance), "Ставка не должна быть меньше 0");
        }
        this.bet = bet;

    }


}

[Route("api/[controller]")]
[ApiController]
public class SpinController : ControllerBase
{
    private readonly UsersContext _context;

    public SpinController(UsersContext context)
    {
        _context = context;
    }


    public static int getCoefficient(string attribute)
    {
        switch (attribute)
        {
            case "number":
                return 36;
            case "even":
                return 2;
            case "color":
                return 2;
            case "row":
                return 3;
            case "column":
                return 12;
            case "rank":
                return 2;
            case "sequence":
                return 3;
            default:
                return 1;
        }
    }

    [HttpPut("spin")]
    // public async Task<IActionResult> PutUser(long id, int bet)
    // bet-тип ставки(чётное/нечётное); input=чётное; bet=20$;
    public async Task<ActionResult<List<BetAndWinDTO>>> PutUser(uint id, [FromBody] List<BetDTO> bets)
    {

        if (bets == null || !bets.Any())
        {
            return BadRequest("The request body must contain at least one bet.");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        foreach (BetDTO bet in bets)
        {
            if (bet.Value.Length == 0)
            {
                return BadRequest("Value should be longer than 0");
            }
            if (bet.Stake == 0)
            {
                return BadRequest("Stake should be longer than 0");
            }

            if (bet.Type == "number")
            {
                List<string> validChoices = Enumerable.Range(0, 37).Select(i => i.ToString()).ToList();

                if (!validChoices.Contains(bet.Value))
                {
                    return BadRequest("Invalid range. Numbers should be from 0 to 36.");
                }
            }
            if (bet.Type == "color")
            {

                List<string> validChoices = new List<string>() { "red", "black", "green" };

                if (!validChoices.Contains(bet.Value))
                {
                    return BadRequest("Invalid range. Color should be red, black or green");

                }
            }
            if (bet.Type == "even")
            {
                List<string> validChoices = ["even", "not even"];

                if (!validChoices.Contains(bet.Value))
                {
                    return BadRequest("Invalid range. Even should be even or not even.");

                }
            }
            if (bet.Type == "row")
            {

                List<string> validChoices = Enumerable.Range(1, 3).Select(i => i.ToString()).ToList();

                if (!validChoices.Contains(bet.Value))
                {
                    return BadRequest("Invalid range. Row should be from 1 to 3.");

                }
            }
            if (bet.Type == "column")
            {

                List<string> validChoices = Enumerable.Range(1, 12).Select(i => i.ToString()).ToList();

                if (!validChoices.Contains(bet.Value))
                {
                    return BadRequest("Invalid range. Column should be from 1 to 12.");
                }
            }
            if (bet.Type == "rank")
            {

                List<string> validChoices = ["1/18", "19/36"];

                if (!validChoices.Contains(bet.Value))
                {
                    return BadRequest("Invalid range. Rank should be 1/18 or 19/36");

                }
            }
            if (bet.Type == "sequence")
            {

                List<string> validChoices = ["1/12", "13/24", "25/36"];

                if (!validChoices.Contains(bet.Value))
                {
                    return BadRequest("Invalid range. Sequency should be 1/12 or 13/24 or 25/36");
                }
            }
            if (bet.Type == "numberSet")
            {
                string[] validCollectionChoices = ["1/2", "1/4", "1/2/4/5", "1/2/3/4/5/6", "2/3", "2/5", "2/3/5/6", "3/6", "4/5", "5/6", "5/8", "4/5/7/8", "5/6/8/9", "4/5/6/7/8/9", "6/9", "4/7", "7/8", "7/10", "7/8/10/11", "7/8/9/10/11/12", "8/9", "8/11", "8/9/11/12", "9/12", "10/11", "10/13", "10/11/13/14", "10/11/12/13/14/15", "11/12", "11/14", "11/12/14/15", "12/15", "13/14", "13/16", "13/14/16/17", "13/14/15/16/17/18", "14/15", "15/18", "14/15/17/18", "16/17", "16/19", "16/17/19/20", "16/17/18/19/20/21", "14/17", "17/18", "17/20", "17/18/20/21", "18/21", "19/20", "19/22", "19/20/22/23", "19/20/21/22/23/24", "20/21", "20/23", "20/21/23/24", "21/24", "22/23", "22/25", "22/23/25/26", "22/23/24/25/26", "23/24", "23/26", "23/24/26/27", "22/23/24/25/26/27", "24/27", "25/26", "25/28", "25/26/28/29", "25/26/27/28/29/30", "26/27", "26/29", "26/27/29/30", "27/30", "28/29", "28/31", "28/29/31/32", "28/29/30/31/32/33", "29/30", "29/32", "29/30/32/33", "30/33", "31/32", "31/34", "31/32/34/35", "31/32/33/34/35/36", "32/33", "32/35", "32/33/35/36", "33/36", "34/35", "35/36"];

                if (!validCollectionChoices.Contains(bet.Value))
                {
                    return BadRequest("Invalid range. Not found this numberset");
                }
            }
        }

        List<BetAndWinDTO> res = Spin(bets, user);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!UsersController.UserExists(id, _context))
        {
            return NotFound();
        }

        return Ok(res);

    }


    public static List<BetAndWinDTO> Spin([FromBody] List<BetDTO> bets, User user)
    {
        var roulette = new ListOfRoulette();
        Random random = new Random();
        string rand = random.Next(roulette.Numbers.Count()).ToString();
        List<BetAndWinDTO> wins = new List<BetAndWinDTO>(); 

        Dictionary<string, int> coefficients = new Dictionary<string, int>(){
            {"2",18},
            {"3",12},
            {"4",9},
            {"6",6},
        };

        bets.ForEach(delegate (BetDTO betrequest)
        {
            string type = betrequest.Type;
            string value = betrequest.Value;
            int stakeAmount = betrequest.Stake;

            if (type == "numberSet")
            {
                if (roulette.getNumberByKey(rand).getByAttribute(type) is List<string> collectionOfNumbers)
                {

                    if (collectionOfNumbers.Contains(value))
                    {
                        string collectionOfNumbersCount = value.Split("/").Length.ToString();

                        user.Balance += stakeAmount * coefficients[collectionOfNumbersCount];
                        wins.Add(new BetAndWinDTO{
                            Type = type,
                            Value = value,
                            Stake = stakeAmount,
                            Win = true,
                            Rand = rand
                        });

                    }
                    else
                    {
                        user.Balance -= stakeAmount;
                        wins.Add(new BetAndWinDTO{
                            Type = type,
                            Value = value,
                            Stake = stakeAmount,
                            Win = false,
                            Rand = rand
                        });
                    }
                }
            }
            else
            {
                if (roulette.getNumberByKey(rand).getByAttribute(type).ToString() == value)
                {

                    user.Balance += stakeAmount * getCoefficient(type);
                    wins.Add(new BetAndWinDTO{
                            Type = type,
                            Value = value,
                            Stake = stakeAmount,
                            Win = true,
                            Rand = rand
                        });

                }
                else
                {
                    user.Balance -= stakeAmount;
                    wins.Add(new BetAndWinDTO{
                        Type = type,
                        Value = value,
                        Stake = stakeAmount,
                        Win = false,
                        Rand = rand
                    });

                }
            }

        });

        return wins;
    }

}
