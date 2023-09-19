using System.Collections.Immutable;
using System.Linq;
class MulveySean_Lab_2
{
    static void Main(string[] args)
    {
        Start();
    }

    public static void Start()
    {
        List<VideoGame> gameList = File.ReadAllLines("videogames.csv").Select(v => CreateVideoGame(v)).ToList();
        gameList.Sort((x, y) => x.GlobalSales_.CompareTo(y.GlobalSales_));
        gameList.Reverse();
        List<string> keyList = GetKeys(gameList);
        Dictionary<string, List<VideoGame>> dic = CreateDic(gameList, keyList);
        dic.OrderBy(x => x.Key);


            foreach (KeyValuePair<string, List<VideoGame>> pair in dic)
            {
            int i = 0;
                foreach (VideoGame item in pair.Value)
                {
                    
                    if (item.Platform_ == pair.Key && i < 5)
                    {
                        i++;
                        
                        Console.WriteLine($"{pair.Key}: {item.Name_}");
                       
                        
                    }

                }




            }
        

    }
    public static Dictionary<string, List<VideoGame>> CreateDic(List<VideoGame> list, List<string> keys)
    {
        Dictionary<string, List<VideoGame>> dic = new Dictionary<string, List<VideoGame>>();
        List<VideoGame> currPlat = new List<VideoGame>();
        for (int i = 0; i < keys.Count; i++) 
        {
            
            for (int j = 0; j < list.Count; j++)
            {
               if (keys[i] == list[j].Platform_)
                {
                    
                    currPlat.Add(list[j]);
                }
            }
            dic.Add(keys[i], currPlat);
            

        }
        
        
        return dic;
    }
    public static List<string> GetKeys(List<VideoGame> list)
    {
        List<string> keyList = new List<string>();
        for (int i = 0; i < list.Count; i++) 
        {
            if (!keyList.Contains(list[i].Platform_))
            {
                keyList.Add(list[i].Platform_);
            }
        }
        return keyList;
    }
    /*public static void Start()
    {
        Dictionary<VideoGame, string> gameDic = new Dictionary<VideoGame, string>();
        Dictionary<VideoGame, string> sortedDic = new Dictionary<VideoGame, string>();
        List<string> keyList = new List<string>();
        List<VideoGame> gameList = File.ReadAllLines("videogames.csv").Select(v => CreateVideoGame(v)).ToList();
        gameList.OrderBy(x => x.GlobalSales_).ToDictionary(x => x);
        gameDic = SetDic(gameList);
        keyList = GetKeys(gameDic);
        sortedDic = GetSortedDic(gameDic, keyList);

        
        foreach(KeyValuePair<VideoGame, string> entry in sortedDic)
        {
            Console.WriteLine($"{entry.Key.Name_}: {entry.Value}");
        }

    }

    public static Dictionary<VideoGame, string> SetDic(List<VideoGame> list)
    {
        Dictionary<VideoGame, string> gameDic = new Dictionary<VideoGame, string>();
        foreach (VideoGame game in list) 
        {
            
            gameDic.Add(game, game.Platform_);
            
        }
        return gameDic;
    }

    public static List<string> GetKeys(Dictionary<VideoGame, string> dic)
    {
        List<string> keyList = new List<string>();
        foreach (KeyValuePair<VideoGame, string> entry in dic)
        {
             if (!keyList.Contains(entry.Value))
            {
                keyList.Add(entry.Value);
            } 
        }
        return keyList;

    }

    public static Dictionary<VideoGame, string> GetSortedDic(Dictionary<VideoGame, string> dic, List<string> list)
    {
        Dictionary<VideoGame, string> newDic = new Dictionary<VideoGame, string>();
        dic = dic.OrderBy(x => x.Key.GlobalSales_).ToDictionary(x => x.Key, x => x.Value);
        foreach (string k in list)
        {
            Console.WriteLine(k);
            for (int i = 0; i < 5; i++)
            {
                
                try
                {
                    newDic.Add(dic.Keys.ElementAt(i), k);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"An element with Key = \"{k}\" already exists.");
                }
            }
        }
        return newDic;

    }*/


    public static VideoGame CreateVideoGame(string line)
    {
        string[] values = line.Split(',');
        VideoGame videoGame = new VideoGame();
        videoGame.Name_ = values[0];


        videoGame.Platform_ = values[1];


        videoGame.Year_ = Convert.ToInt32(values[2]);


        videoGame.Genre_ = values[3];


        videoGame.Publisher_ = values[4];



        videoGame.NASales_ = Convert.ToDouble(values[5]);
        videoGame.EUSales_ = Convert.ToDouble(values[6]);
        videoGame.JPSales_ = Convert.ToDouble(values[7]);
        videoGame.OtherSales_ = Convert.ToDouble(values[8]);
        videoGame.GlobalSales_ = Convert.ToDouble(values[9]);
        return videoGame;
    }
}

public class VideoGame : IComparable<VideoGame>
{

    private string name;
    private string platform;
    private string genre;
    private string publisher;
    private int year;
    private double NA_Sales;
    private double EU_Sales;
    private double JP_Sales;
    private double Other_Sales;
    private double Global_Sales;

    public VideoGame()
    {

    }

    public VideoGame(string _name, string _platform, string _genre, string _publisher,
    int _year, double naSales, double euSales, double jpSales, double otherSales, double globalSales)
    {
        name = _name;
        platform = _platform;
        genre = _genre;
        publisher = _publisher;
        year = _year;
        NA_Sales = naSales;
        EU_Sales = euSales;
        JP_Sales = jpSales;
        Other_Sales = otherSales;
        Global_Sales = globalSales;
    }

    public string Name_
    {
        get => name;
        set => name = value;
    }

    public string Platform_
    {
        get => platform;
        set => platform = value;
    }

    public string Genre_
    {
        get => genre;
        set => genre = value;
    }


    public string Publisher_
    {
        get => publisher;
        set => publisher = value;
    }

    public int Year_
    {
        get => year;
        set => year = value;
    }

    public double NASales_
    {
        get => NA_Sales;
        set => NA_Sales = value;
    }

    public double EUSales_
    {
        get => EU_Sales;
        set => EU_Sales = value;

    }

    public double JPSales_
    {
        get => JP_Sales;
        set => JP_Sales = value;

    }

    public double OtherSales_
    {
        get => Other_Sales;
        set => Other_Sales = value;

    }

    public double GlobalSales_
    {
        get => Global_Sales;
        set => Global_Sales = value;
    }


    public int CompareTo(VideoGame? other)
    {
        if (other == null)
        {
            return 1;
        }
        return Name_.CompareTo(other.Name_);
    }
}