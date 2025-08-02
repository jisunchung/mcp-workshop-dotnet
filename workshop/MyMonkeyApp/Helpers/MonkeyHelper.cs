using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// 원숭이 데이터를 관리하는 정적 헬퍼 클래스
/// </summary>
public static class MonkeyHelper
{
    private static readonly Random _random = new();
    private static readonly Dictionary<string, int> _accessCounts = new();
    private static List<Monkey>? _monkeys;

    /// <summary>
    /// 하드코딩된 원숭이 데이터 (Monkey MCP 서버 데이터 기반)
    /// </summary>
    private static readonly List<Monkey> _monkeyData = new()
    {
        new Monkey
        {
            Name = "Baboon",
            Location = "Africa & Asia",
            Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/baboon.jpg",
            Population = 10000,
            Latitude = -8.783195,
            Longitude = 34.508523
        },
        new Monkey
        {
            Name = "Capuchin Monkey",
            Location = "Central & South America",
            Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae. Prior to 2011, the subfamily contained only a single genus, Cebus.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/capuchin.jpg",
            Population = 23000,
            Latitude = 12.769013,
            Longitude = -85.602364
        },
        new Monkey
        {
            Name = "Blue Monkey",
            Location = "Central and East Africa",
            Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa, ranging from the upper Congo River basin east to the East African Rift and south to northern Angola and Zambia",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/bluemonkey.jpg",
            Population = 12000,
            Latitude = 1.957709,
            Longitude = 37.297204
        },
        new Monkey
        {
            Name = "Squirrel Monkey",
            Location = "Central & South America",
            Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri. They are the only genus in the subfamily Saimirinae. The name of the genus Saimiri is of Tupi origin, and was also used as an English name by early researchers.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/saimiri.jpg",
            Population = 11000,
            Latitude = -8.783195,
            Longitude = -55.491477
        },
        new Monkey
        {
            Name = "Golden Lion Tamarin",
            Location = "Brazil",
            Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/tamarin.jpg",
            Population = 19000,
            Latitude = -14.235004,
            Longitude = -51.92528
        },
        new Monkey
        {
            Name = "Howler Monkey",
            Location = "South America",
            Details = "Howler monkeys are among the largest of the New World monkeys. Fifteen species are currently recognised. Previously classified in the family Cebidae, they are now placed in the family Atelidae.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/alouatta.jpg",
            Population = 8000,
            Latitude = -8.783195,
            Longitude = -55.491477
        },
        new Monkey
        {
            Name = "Japanese Macaque",
            Location = "Japan",
            Details = "The Japanese macaque, is a terrestrial Old World monkey species native to Japan. They are also sometimes known as the snow monkey because they live in areas where snow covers the ground for months each",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/macasa.jpg",
            Population = 1000,
            Latitude = 36.204824,
            Longitude = 138.252924
        },
        new Monkey
        {
            Name = "Mandrill",
            Location = "Southern Cameroon, Gabon, and Congo",
            Details = "The mandrill is a primate of the Old World monkey family, closely related to the baboons and even more closely to the drill. It is found in southern Cameroon, Gabon, Equatorial Guinea, and Congo.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/mandrill.jpg",
            Population = 17000,
            Latitude = 7.369722,
            Longitude = 12.354722
        },
        new Monkey
        {
            Name = "Proboscis Monkey",
            Location = "Borneo",
            Details = "The proboscis monkey or long-nosed monkey, known as the bekantan in Malay, is a reddish-brown arboreal Old World monkey that is endemic to the south-east Asian island of Borneo.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/borneo.jpg",
            Population = 15000,
            Latitude = 0.961883,
            Longitude = 114.55485
        },
        new Monkey
        {
            Name = "Sebastian",
            Location = "Seattle",
            Details = "This little trouble maker lives in Seattle with James and loves traveling on adventures with James and tweeting @MotzMonkeys. He by far is an Android fanboy and is getting ready for the new Google Pixel 9!",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/sebastian.jpg",
            Population = 1,
            Latitude = 47.606209,
            Longitude = -122.332071
        },
        new Monkey
        {
            Name = "Henry",
            Location = "Phoenix",
            Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. His favorite platform is iOS by far and is excited for the new iPhone Xs!",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/henry.jpg",
            Population = 1,
            Latitude = 33.448377,
            Longitude = -112.074037
        },
        new Monkey
        {
            Name = "Red-shanked douc",
            Location = "Vietnam",
            Details = "The red-shanked douc is a species of Old World monkey, among the most colourful of all primates. The douc is an arboreal and diurnal monkey that eats and sleeps in the trees of the forest.",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/douc.jpg",
            Population = 1300,
            Latitude = 16.111648,
            Longitude = 108.262122
        },
        new Monkey
        {
            Name = "Mooch",
            Location = "Seattle",
            Details = "An adorable Monkey who is traveling the world with Heather and live tweets his adventures @MotzMonkeys. Her favorite platform is iOS by far and is excited for the new iPhone 16!",
            Image = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/Mooch.PNG",
            Population = 1,
            Latitude = 47.608013,
            Longitude = -122.335167
        }
    };

    /// <summary>
    /// 모든 원숭이의 목록을 반환합니다
    /// </summary>
    /// <returns>원숭이 목록</returns>
    public static List<Monkey> GetMonkeys()
    {
        _monkeys ??= new List<Monkey>(_monkeyData);
        return _monkeys;
    }

    /// <summary>
    /// 무작위로 원숭이를 선택하고 액세스 횟수를 추적합니다
    /// </summary>
    /// <returns>무작위로 선택된 원숭이</returns>
    public static Monkey GetRandomMonkey()
    {
        var monkeys = GetMonkeys();
        if (monkeys.Count == 0)
            throw new InvalidOperationException("사용 가능한 원숭이가 없습니다.");

        var randomMonkey = monkeys[_random.Next(monkeys.Count)];
        
        // 액세스 횟수 추적
        if (_accessCounts.ContainsKey(randomMonkey.Name))
            _accessCounts[randomMonkey.Name]++;
        else
            _accessCounts[randomMonkey.Name] = 1;

        return randomMonkey;
    }

    /// <summary>
    /// 이름으로 원숭이를 찾습니다 (대소문자 구분 안함)
    /// </summary>
    /// <param name="name">찾을 원숭이의 이름</param>
    /// <returns>찾은 원숭이, 없으면 null</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        var monkeys = GetMonkeys();
        return monkeys.FirstOrDefault(m => 
            string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// 이름의 일부로 원숭이를 검색합니다 (대소문자 구분 안함)
    /// </summary>
    /// <param name="partialName">검색할 이름의 일부</param>
    /// <returns>매칭되는 원숭이들의 목록</returns>
    public static List<Monkey> SearchMonkeysByName(string partialName)
    {
        if (string.IsNullOrWhiteSpace(partialName))
            return new List<Monkey>();

        var monkeys = GetMonkeys();
        return monkeys.Where(m => 
            m.Name.Contains(partialName, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    /// <summary>
    /// 특정 원숭이의 액세스 횟수를 반환합니다
    /// </summary>
    /// <param name="monkeyName">원숭이 이름</param>
    /// <returns>액세스 횟수</returns>
    public static int GetAccessCount(string monkeyName)
    {
        return _accessCounts.GetValueOrDefault(monkeyName, 0);
    }

    /// <summary>
    /// 모든 원숭이의 액세스 통계를 반환합니다
    /// </summary>
    /// <returns>원숭이 이름과 액세스 횟수의 딕셔너리</returns>
    public static Dictionary<string, int> GetAllAccessCounts()
    {
        return new Dictionary<string, int>(_accessCounts);
    }

    /// <summary>
    /// 가장 많이 액세스된 원숭이를 반환합니다
    /// </summary>
    /// <returns>가장 인기 있는 원숭이와 액세스 횟수</returns>
    public static (Monkey? Monkey, int AccessCount) GetMostPopularMonkey()
    {
        if (_accessCounts.Count == 0)
            return (null, 0);

        var mostAccessed = _accessCounts.MaxBy(kvp => kvp.Value);
        var monkey = GetMonkeyByName(mostAccessed.Key);
        return (monkey, mostAccessed.Value);
    }

    /// <summary>
    /// 액세스 통계를 초기화합니다
    /// </summary>
    public static void ResetAccessCounts()
    {
        _accessCounts.Clear();
    }

    /// <summary>
    /// 원숭이 데이터의 통계 정보를 반환합니다
    /// </summary>
    /// <returns>통계 정보 문자열</returns>
    public static string GetStatistics()
    {
        var monkeys = GetMonkeys();
        var totalPopulation = monkeys.Sum(m => m.Population);
        var avgPopulation = monkeys.Average(m => m.Population);
        var mostPopulated = monkeys.MaxBy(m => m.Population);
        var leastPopulated = monkeys.MinBy(m => m.Population);

        return $"""
            📊 원숭이 데이터 통계
            ━━━━━━━━━━━━━━━━━━━━━━
            🐒 총 원숭이 종류: {monkeys.Count}개
            👥 총 개체수: {totalPopulation:N0}마리
            📈 평균 개체수: {avgPopulation:N0}마리
            🥇 최대 개체수: {mostPopulated?.Name} ({mostPopulated?.Population:N0}마리)
            🥉 최소 개체수: {leastPopulated?.Name} ({leastPopulated?.Population:N0}마리)
            🎲 총 무작위 액세스: {_accessCounts.Values.Sum()}회
            """;
    }
}
