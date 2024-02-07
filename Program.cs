// grepのようなプログラム
internal class Program
{
    private static string folder = string.Empty;
    private static string keyword = string.Empty;
    private static string findPattern = string.Empty;
    
    private static void Main(string[] args)
    {
        GetUserInput(); // ユーザ入力取得
        if (!Validate()) // バリデーションチェック
        {
            ExitMessage();
            return;
        }
        List<Item> items = FindKeyword(); // キーワード検索
        OutputResult(items); // 結果出力
        ExitMessage();
        return;
    }

    // ユーザ入力取得
    private static void GetUserInput()
    {
        Console.Write("検索したいフォルダパスを入力 => ");
        folder = Console.ReadLine();
        Console.Write("検索したいキーワードを入力 => ");
        keyword = Console.ReadLine();
        Console.Write("サブフォルダを探索しますか？[y / n] => ");
        findPattern = Console.ReadLine();
    }

    // バリデーションチェック
    private static bool Validate()
    {
        if (!Directory.Exists(folder))
        {
            Console.WriteLine("WARN : 指定されたフォルダが見つかりませんでした");
            return false;
        }
        if (string.IsNullOrEmpty(keyword))
        {
            Console.WriteLine("WARN : キーワードが入力されていません");
            return false;
        }
        if (findPattern != "y" && findPattern != "n")
        {
            Console.WriteLine("WARN : 'y'または'n'で入力してください");
            return false;
        }
        return true;
    }

    // キーワード検索
    private static List<Item> FindKeyword()
    {
        try
        {
            if (findPattern == "y")
            {
                List<Item> items = FindKeywordByFolder(folder);
                string[] childFolders = Directory.GetDirectories(folder);
                foreach (string childFolder in childFolders)
                {
                    items.AddRange(FindKeywordByFolder(childFolder));
                }
                return items;
            }
            else
            {
                return FindKeywordByFolder(folder);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR : エラーが発生しました\n{ex}");
            return new List<Item>();
        }
    }

    // 実際のキーワード検索処理
    private static List<Item> FindKeywordByFolder(string targetFolder)
    {
        string[] files = Directory.GetFiles(targetFolder);
        List<Item> items = new List<Item>();
        foreach (string file in files)
        {
            using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                string line;
                int lineNumber = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (line.Contains(keyword))
                    {
                        items.Add(new Item(file, lineNumber));
                    }
                }
            }
        }
        return items;
    }

    // 終了メッセージ
    private static void ExitMessage()
    {
        Console.Write("何かキーを押して入力...");
        Console.ReadLine();
    }

    // 結果出力
    private static void OutputResult(IReadOnlyList<Item> items)
    {
        if (!items.Any())
        {
            Console.WriteLine("INFO : 対象なし");
            return;
        }

        foreach (Item item in items)
        {
            Console.WriteLine($"INFO : {item.FilePath}  {item.LineNumber}行目");
        }
    }
}

// キーワード該当情報を管理
public class Item
{
    public string FilePath { get; private set; } = string.Empty;
    public int LineNumber { get; private set; }
    
    public Item(string filePath, int lineNumber)
    {
        this.FilePath = filePath;
        this.LineNumber = lineNumber;
    }
}