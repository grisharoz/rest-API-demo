public class ListOfRoulette
{
    public Dictionary<string, RouletteNumber> Numbers { get; private set; }

    public ListOfRoulette()
    {
        Numbers = new Dictionary<string, RouletteNumber>();
        GenerateRouletteNumbers();
    }

    private void GenerateRouletteNumbers()
    {
        Numbers.Add("0", new RouletteNumber(0, true,"green"));
        Numbers.Add("1", new RouletteNumber(1, false, "red", "1", "1", "1/18", "1/12", new List<string> { "1/2", "1/4","1/2/3", "1/2/4/5", "1/2/3/4/5/6" }));
        Numbers.Add("2", new RouletteNumber(2, true, "black", "2", "1", "1/18", "1/12", new List<string> { "1/2", "2/3", "2/5","1/2/3", "1/2/4/5", "2/3/5/6", "1/2/3/4/5/6" }));
        Numbers.Add("3", new RouletteNumber(3, false, "red", "3", "1", "1/18", "1/12", new List<string> { "2/3", "3/6","1/2/3", "2/3/5/6", "1/2/3/4/5/6" }));
        Numbers.Add("4", new RouletteNumber(4, true, "black", "1", "2", "1/18", "1/12", new List<string> { "1/4", "4/5", "4/7","4/5/6", "1/2/4/5", "4/5/7/8", "1/2/3/4/5/6","4/5/6/7/8/9" }));
        Numbers.Add("5", new RouletteNumber(5, false, "red", "2", "2", "1/18", "1/12", new List<string> { "2/5", "4/5","5/6", "5/8", "4/5/6", "1/2/4/5","2/3/5/6","4/5/7/8","5/6/8/9","1/2/3/4/5/6","4/5/6/7/8/9" }));
        Numbers.Add("6", new RouletteNumber(6, true, "black", "3", "2", "1/18", "1/12", new List<string> { "3/6", "5/6", "6/9","4/5/6", "2/3/5/6", "5/6/8/9", "1/2/3/4/5/6","4/5/6/7/8/9" }));
        Numbers.Add("7", new RouletteNumber(7, false, "red", "1", "3", "1/18", "1/12", new List<string> { "4/7", "7/8","7/10", "7/8/9", "4/5/7/8","7/8/10/11","4/5/6/7/8/9","7/8/9/10/11/12"}));
        Numbers.Add("8", new RouletteNumber(8, true, "black", "2", "3", "1/18", "1/12", new List<string> { "5/8", "7/8","8/9", "8/11", "7/8/9","4/5/7/8","5/6/8/9","7/8/10/11","8/9/11/12","4/5/6/7/8/9","7/8/9/10/11/12" }));
        Numbers.Add("9", new RouletteNumber(9, false, "red", "3", "3", "1/18", "1/12", new List<string> { "6/9", "8/9", "9/12","7/8/9", "5/6/8/9", "8/9/11/12", "4/5/6/7/8/9","7/8/9/10/11/12" }));
        Numbers.Add("10", new RouletteNumber(10, true, "black", "1", "4", "1/18", "1/12", new List<string> { "7/10", "10/11","10/13", "10/11/12", "7/8/10/11","10/11/13/14","7/8/9/10/11/12","10/11/12/13/14/15"}));
        Numbers.Add("11", new RouletteNumber(11, false, "black", "2", "4", "1/18", "1/12", new List<string> { "8/11", "10/11","11/12", "11/14", "10/11/12","7/8/10/11","8/9/11/12","10/11/13/14","11/12/14/15","7/8/9/10/11/12","10/11/12/13/14/15" }));
        Numbers.Add("12", new RouletteNumber(12, true, "red", "3", "4", "1/18", "1/12", new List<string> { "9/12", "11/12", "12/15","10/11/12", "8/9/11/12", "11/12/14/15", "7/8/9/10/11/12","10/11/12/13/14/15" }));
        Numbers.Add("13", new RouletteNumber(13, false, "black", "1", "5", "1/18", "13/24", new List<string> { "10/13", "13/14","13/16", "13/14/15", "10/11/13/14","13/14/16/17","10/11/12/13/14/15","13/14/15/16/17/18"}));
        Numbers.Add("14", new RouletteNumber(14, true, "red", "2", "5", "1/18", "13/24", new List<string> { "11/14", "13/14","14/15", "14/17", "13/14/15","10/11/13/14","11/12/14/15","13/14/16/17","14/15/17/18","10/11/12/13/14/15","13/14/15/16/17/18" }));
        Numbers.Add("15", new RouletteNumber(15, false, "black", "3", "5", "1/18", "13/24", new List<string> { "12/15", "14/15", "15/18","13/14/15", "11/12/14/15", "14/15/17/18", "10/11/12/13/14/15","13/14/15/16/17/18" }));
        Numbers.Add("16", new RouletteNumber(16, true, "red", "1", "6", "1/18", "13/24", new List<string> { "13/16", "16/17","16/19", "16/17/18", "13/14/16/17","16/17/19/20","13/14/15/16/17/18","16/17/18/19/20/21"}));
        Numbers.Add("17", new RouletteNumber(17, false, "black", "2", "6", "1/18", "13/24", new List<string> { "14/17", "16/17","17/18", "17/20", "16/17/18","13/14/16/17","14/15/17/18","16/17/19/20","17/18/20/21","13/14/15/16/17/18","16/17/18/19/20/21" }));
        Numbers.Add("18", new RouletteNumber(18, true, "red", "3", "6", "1/18", "13/24", new List<string> { "15/18", "17/18", "18/21","16/17/18", "14/15/17/18", "17/18/20/21", "13/14/15/16/17/18","16/17/18/19/20/21" }));
        Numbers.Add("19", new RouletteNumber(19, false, "red", "1", "7", "18/36", "13/24", new List<string> { "16/19", "19/20","19/22", "19/20/21", "16/17/19/20","19/20/22/23","16/17/18/19/20/21","19/20/21/22/23/24"}));
        Numbers.Add("20", new RouletteNumber(20, true, "black", "2", "7", "18/36", "13/24", new List<string> { "17/20", "19/20","20/21", "20/23", "19/20/21","16/17/19/20","17/18/20/21","19/20/22/23","20/21/23/24","16/17/18/19/20/21","19/20/21/22/23/24" }));
        Numbers.Add("21", new RouletteNumber(21, false, "red", "3", "7", "18/36", "13/24", new List<string> { "18/21", "20/21", "21/24","19/20/21", "17/18/20/21", "20/21/23/24", "16/17/18/19/20/21","19/20/21/22/23/24" }));
        Numbers.Add("22", new RouletteNumber(22, true, "black", "1", "8", "18/36", "13/24", new List<string> { "19/22", "22/23","22/25", "22/23/24", "19/20/22/23","22/23/25/26","19/20/21/22/23/24","22/23/24/25/26/27"}));
        Numbers.Add("23", new RouletteNumber(23, false, "red", "2", "8", "18/36", "13/24", new List<string> { "20/23", "22/23","23/24", "23/26", "22/23/24","19/20/22/23","20/21/23/24","22/23/25/26","23/24/26/27","19/20/21/22/23/24","22/23/24/25/26/27" }));
        Numbers.Add("24", new RouletteNumber(24, true, "black", "3", "8", "18/36", "13/24", new List<string> { "21/24", "23/24", "24/27","22/23/24", "20/21/23/24", "23/24/26/27", "19/20/21/22/23/24","22/23/24/25/26/27" }));
        Numbers.Add("25", new RouletteNumber(25, false, "red", "1", "9", "18/36", "25/36", new List<string> { "22/25", "25/26","25/28", "25/26/27", "22/23/25/26","25/26/28/29","22/23/24/25/26/27","25/26/27/28/29/30"}));
        Numbers.Add("26", new RouletteNumber(26, true, "black", "2", "9", "18/36", "25/36", new List<string> { "23/26", "25/26","26/27", "26/29", "25/26/27","22/23/25/26","23/24/26/27","25/26/28/29","26/27/29/30","22/23/24/25/26/27","25/26/27/28/29/30" }));
        Numbers.Add("27", new RouletteNumber(27, false, "red", "3", "9", "18/36", "25/36", new List<string> { "24/27", "26/27", "27/30","25/26/27", "23/24/26/27", "26/27/29/30", "22/23/24/25/26/27","25/26/27/28/29/30" }));
        Numbers.Add("28", new RouletteNumber(28, true, "black", "1", "10", "18/36", "25/36", new List<string> { "25/28", "28/29","28/31", "28/29/30", "25/26/28/29","28/29/31/32","25/26/27/28/29/30","28/29/30/31/32/33"}));
        Numbers.Add("29", new RouletteNumber(29, false, "black", "2", "10", "18/36", "25/36", new List<string> { "26/29", "28/29","29/30", "29/32", "28/29/30","25/26/28/29","26/27/29/30","28/29/31/32","29/30/32/33","25/26/27/28/29/30","28/29/30/31/32/33" }));
        Numbers.Add("30", new RouletteNumber(30, true, "red", "3", "10", "18/36", "25/36", new List<string> { "27/30", "29/30", "30/33","28/29/30", "26/27/29/30", "29/30/32/33", "25/26/27/28/29/30","28/29/30/31/32/33" }));
        Numbers.Add("31", new RouletteNumber(31, false, "black", "1", "11", "18/36", "25/36", new List<string> { "28/31", "31/32","31/34", "31/32/33", "28/29/31/32","31/32/34/35","28/29/30/31/32/33","31/32/33/34/35/36"}));
        Numbers.Add("32", new RouletteNumber(32, true, "red", "2", "11", "18/36", "25/36", new List<string> { "29/32", "31/32","32/33", "32/35", "31/32/33","28/29/31/32","29/30/32/33","31/32/34/35","32/33/35/36","28/29/30/31/32/33","31/32/33/34/35/36" }));
        Numbers.Add("33", new RouletteNumber(33, false, "black", "3", "11", "18/36", "25/36", new List<string> { "30/33", "32/33", "33/36","31/32/33", "29/30/32/33", "32/33/35/36", "28/29/30/31/32/33","31/32/33/34/35/36" }));
        Numbers.Add("34", new RouletteNumber(34, true, "red", "1", "12", "18/36", "25/36", new List<string> { "31/34","34/35", "34/35/36", "31/32/34/35","31/32/33/34/35/36"}));
        Numbers.Add("35", new RouletteNumber(35, false, "black", "2", "12", "18/36", "25/36", new List<string> { "32/35", "34/35", "35/36", "34/35/36","31/32/34/35","32/33/35/36","31/32/33/34/35/36" }));
        Numbers.Add("36", new RouletteNumber(36, true, "red", "3", "12", "18/36", "25/36", new List<string> { "33/36", "35/36","34/35/36", "32/33/35/36","31/32/33/34/35/36" }));
    }

    public void PrintRouletteNumbers()
    {
        foreach (var number in Numbers)
        {
            Console.WriteLine($"Number: {number.Value.number}, even: {number.Value.even}, color: {number.Value.color}, row: {number.Value.row}, Column: {number.Value.column}, Rank: {number.Value.rank}, Sequence: {number.Value.sequence}, Number Set: {string.Join(", ", number.Value.numberSet)}");
        }
    }

    public RouletteNumber getNumberByKey(string key)
    {
        return Numbers[key];
    }
}