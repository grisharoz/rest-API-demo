public class RouletteNumber
{
    public int number { get; set; }
    public bool even { get; set; }
    public string color { get; set; }
    public string row { get; set; }
    public string column { get; set; }
    public string rank { get; set; }
    public string sequence { get; set; }
    public List<string> numberSet { get; set; }

    public RouletteNumber(int number, bool even, string color, string row = "",
                        string column = "", string rank = "",
                        string sequence = "", List<string>? numberSet = null)
    {
        this.number = number;
        this.even = even;
        this.color = color;
        this.row = row;
        this.column = column;
        this.rank = rank;
        this.sequence = sequence;
        this.numberSet = numberSet ?? new List<string>();
    }

    public object getByAttribute(string attribute)
    {
        switch (attribute)
        {
            case "number":
                return number;
            case "even":
                return even;
            case "color":
                return color;
            case "row":
                return row;
            case "column":
                return column;
            case "rank":
                return rank;
            case "sequence":
                return sequence;
            case "numberSet":
                return numberSet;
            default:
                return "There is no such an attribute";
        }
    }
}