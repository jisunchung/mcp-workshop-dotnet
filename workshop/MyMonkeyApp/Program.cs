using MyMonkeyApp.Models;
using MyMonkeyApp.Helpers;

namespace MyMonkeyApp;

/// <summary>
/// MyMonkeyApp의 메인 진입점
/// </summary>
class Program
{
    private static readonly Random _random = new();
    
    /// <summary>
    /// 재미있는 ASCII 아트 컬렉션
    /// </summary>
    private static readonly string[] _asciiArts = 
    {
        @"
             .=""=.
            / _  _ \
           |  d  b  |
           |   <   |
           |  ___  |
            \     /
             |___|
        ",
        @"
            .-""-."" 
           /     \
          | () () |
           \  ^  /
            ||||
            ||||
        ",
        @"
           @@@@@@@@@@@
          @@         @@
         @@  ^     ^  @@
        @@      <      @@
        @@             @@
         @@    ___    @@
          @@         @@
           @@@@@@@@@@@
        ",
        @"
            🐒 MONKE TIME 🐒
              \   /
               \_/
               /|\
              / | \
             🍌   🍌
        ",
        @"
            .-""""""-. 
          .'          '.
         /   O      O   \
        :           `    :
        |                |
        :    \______/    :
         \              /
          '.          .'
            '-.......-'
        "
    };

    /// <summary>
    /// 애플리케이션 시작점
    /// </summary>
    /// <param name="args">명령줄 인수</param>
    static void Main(string[] args)
    {
        ShowWelcomeBanner();
        ShowMenu();
    }

    /// <summary>
    /// 환영 배너와 무작위 ASCII 아트를 표시합니다
    /// </summary>
    private static void ShowWelcomeBanner()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        
        // 무작위 ASCII 아트 선택
        var randomArt = _asciiArts[_random.Next(_asciiArts.Length)];
        Console.WriteLine(randomArt);
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine();
        Console.WriteLine("🐒🐒🐒🐒🐒��🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒");
        Console.WriteLine("            🌟 Welcome to MyMonkeyApp! 🌟");
        Console.WriteLine("         원숭이 정보 콘솔 애플리케이션");
        Console.WriteLine("🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒🐒");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("💡 전 세계 다양한 원숭이 종에 대한 정보를 탐험해보세요!");
        Console.WriteLine();
    }

    /// <summary>
    /// 메인 메뉴를 표시하고 사용자 입력을 처리합니다
    /// </summary>
    private static void ShowMenu()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine("🎯 메뉴를 선택하세요:");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ResetColor();
            
            Console.WriteLine("1️⃣  🐒 모든 원숭이 나열");
            Console.WriteLine("2️⃣  🔍 이름으로 특정 원숭이의 세부 정보 가져오기");
            Console.WriteLine("3️⃣  🎲 무작위 원숭이 가져오기");
            Console.WriteLine("4️⃣  🚪 앱 종료");
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("선택 (1-4): ");
            Console.ResetColor();

            var input = Console.ReadLine();
            Console.WriteLine();

            try
            {
                switch (input)
                {
                    case "1":
                        ListAllMonkeys();
                        break;
                    case "2":
                        GetMonkeyDetailsByName();
                        break;
                    case "3":
                        GetRandomMonkey();
                        break;
                    case "4":
                        ShowExitMessage();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ 잘못된 선택입니다. 1-4 사이의 숫자를 입력하세요.");
                        Console.ResetColor();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ 오류가 발생했습니다: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("⏸️  계속하려면 아무 키나 누르세요...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            ShowRandomAsciiArt();
        }
    }

    /// <summary>
    /// 모든 원숭이 목록을 표시합니다
    /// </summary>
    private static void ListAllMonkeys()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🐒 모든 원숭이 목록:");
        Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        Console.ResetColor();

        var monkeys = MonkeyHelper.GetMonkeys();
        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkey = monkeys[i];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{i + 1,2}. ");
            Console.ResetColor();
            Console.WriteLine($"{monkey.Name} - {monkey.Location}");
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"    👥 개체수: {monkey.Population:N0}마리");
            Console.WriteLine($"    🛡️  보존 상태: {monkey.GetConservationStatus()}");
            Console.ResetColor();
            Console.WriteLine();
        }
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"📊 총 {monkeys.Count}종의 원숭이가 등록되어 있습니다!");
        Console.ResetColor();
    }

    /// <summary>
    /// 이름으로 원숭이를 찾고 세부 정보를 표시합니다
    /// </summary>
    private static void GetMonkeyDetailsByName()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("🔍 찾을 원숭이의 이름을 입력하세요: ");
        Console.ResetColor();
        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ 이름을 입력해주세요.");
            Console.ResetColor();
            return;
        }

        var monkey = MonkeyHelper.GetMonkeyByName(name);
        if (monkey != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ 원숭이를 찾았습니다!");
            Console.ResetColor();
            Console.WriteLine();
            
            DisplayMonkeyDetails(monkey);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ '{name}'이라는 이름의 원숭이를 찾을 수 없습니다.");
            Console.ResetColor();
            
            // 부분 검색 시도
            var similarMonkeys = MonkeyHelper.SearchMonkeysByName(name);
            if (similarMonkeys.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n💡 비슷한 이름의 원숭이들:");
                Console.ResetColor();
                foreach (var similar in similarMonkeys.Take(3))
                {
                    Console.WriteLine($"   • {similar.Name}");
                }
            }
        }
    }

    /// <summary>
    /// 무작위 원숭이를 선택하고 표시합니다
    /// </summary>
    private static void GetRandomMonkey()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("🎲 무작위 원숭이를 선택합니다...");
        Console.ResetColor();
        
        // 재미있는 로딩 효과
        for (int i = 0; i < 3; i++)
        {
            Console.Write("🐒");
            Thread.Sleep(300);
        }
        Console.WriteLine(" 🎉");
        Console.WriteLine();

        var randomMonkey = MonkeyHelper.GetRandomMonkey();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("�� 선택된 원숭이:");
        Console.ResetColor();
        
        DisplayMonkeyDetails(randomMonkey);
        
        var accessCount = MonkeyHelper.GetAccessCount(randomMonkey.Name);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"📊 이 원숭이가 무작위로 선택된 횟수: {accessCount}회");
        Console.ResetColor();
    }

    /// <summary>
    /// 원숭이의 상세 정보를 예쁘게 표시합니다
    /// </summary>
    /// <param name="monkey">표시할 원숭이</param>
    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("┌─────────────────────────────────────────────────────────────┐");
        Console.WriteLine($"│ 🐒 {monkey.Name.PadRight(55)} │");
        Console.WriteLine("├─────────────────────────────────────────────────────────────┤");
        Console.ResetColor();
        
        Console.WriteLine($"│ 📍 위치: {monkey.Location.PadRight(49)} │");
        Console.WriteLine($"│ 👥 개체수: {monkey.Population:N0}마리".PadRight(63) + " │");
        Console.WriteLine($"│ 🌍 좌표: {monkey.Latitude:F2}, {monkey.Longitude:F2}".PadRight(63) + " │");
        Console.WriteLine($"│ 🛡️  보존 상태: {monkey.GetConservationStatus()}".PadRight(75) + " │");
        Console.WriteLine("├─────────────────────────────────────────────────────────────┤");
        
        // 설명을 여러 줄로 나누기
        var description = monkey.Details;
        var maxWidth = 55;
        while (description.Length > 0)
        {
            var lineLength = Math.Min(description.Length, maxWidth);
            var line = description.Substring(0, lineLength);
            
            // 단어 경계에서 자르기
            if (description.Length > maxWidth)
            {
                var lastSpace = line.LastIndexOf(' ');
                if (lastSpace > maxWidth / 2)
                {
                    line = line.Substring(0, lastSpace);
                    lineLength = lastSpace;
                }
            }
            
            Console.WriteLine($"│ 📖 {line.PadRight(57)} │");
            description = description.Substring(lineLength).TrimStart();
        }
        
        Console.WriteLine("├─────────────────────────────────────────────────────────────┤");
        Console.WriteLine($"│ 🖼️  이미지: {monkey.Image.PadRight(47)} │");
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("└─────────────────────────────────────────────────────────────┘");
        Console.ResetColor();
    }

    /// <summary>
    /// 무작위 ASCII 아트를 표시합니다
    /// </summary>
    private static void ShowRandomAsciiArt()
    {
        var randomArt = _asciiArts[_random.Next(_asciiArts.Length)];
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(randomArt);
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// 종료 메시지를 표시합니다
    /// </summary>
    private static void ShowExitMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        
        Console.WriteLine();
        Console.WriteLine("                 🌟 감사합니다! 🌟");
        Console.WriteLine();
        Console.WriteLine("               .-\"\"\"\"\"\"\"\"\"\"\"\"-.");
        Console.WriteLine("             .'                  '.");
        Console.WriteLine("            /   🐒  GOODBYE!  🐒   \\");
        Console.WriteLine("           |                        |");
        Console.WriteLine("           |     원숭이들과 함께한      |");
        Console.WriteLine("           |      즐거운 시간!        |");
        Console.WriteLine("           |                        |");
        Console.WriteLine("            \\   🍌    🍌    🍌     /");
        Console.WriteLine("             '.________________.'");
        Console.WriteLine("                     ||||");
        Console.WriteLine("                     ||||");
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("🐒 MyMonkeyApp을 이용해주셔서 감사합니다! 🐒");
        Console.WriteLine("🌟 원숭이들과 함께한 즐거운 시간이었기를 바랍니다! 🌟");
        Console.WriteLine("🍌 또 만나요! 🍌");
        Console.ResetColor();
        Console.WriteLine();
        
        // 작은 애니메이션 효과
        string[] waveEmojis = { "👋", "🐒", "🍌", "🌟" };
        for (int i = 0; i < 8; i++)
        {
            Console.Write(waveEmojis[i % waveEmojis.Length] + " ");
            Thread.Sleep(200);
        }
        Console.WriteLine();
    }
}
