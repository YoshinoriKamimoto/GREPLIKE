using System.Data;
internal class Program
{
    private static void Main(string[] args)
    {
        // 検索対象のフォルダを入力から取得
        Console.Write("検索したいフォルダパスを入力 => ");
        string dirPath = Console.ReadLine();

        // 検索対象の文字列を入力から取得
        Console.Write("検索したい文字列を入力 => ");
        string searchWord = Console.ReadLine();


        // 入力値チェック
        if (Directory.Exists(dirPath) == false)
        {
            Console.WriteLine("WARNING : フォルダが見つかりません。");
            Console.Write("何かキーを入力して終了...");
            Console.ReadLine();
            return;
        }

        if (searchWord == "" || searchWord == null)
        {
            Console.WriteLine("WARNING : 検索したい文字列が未入力です。");
            Console.Write("何かキーを入力して終了...");
            Console.ReadLine();
            return;
        }
        

        // フォルダ配下の全ファイルを取得
        string[] files = Directory.GetFiles(dirPath);

        // 全ファイルの文字列をチェック
        DataTable dt;
        try
        {
            dt = CheckString(files, searchWord);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"ERROR : 文字列検索エラー\n{ex}");
            Console.Write("何かキーを入力して終了...");
            Console.ReadLine();
            return;
        }
        
    
        // 結果を表示
        if (dt.Rows.Count <= 0)
        {
            Console.WriteLine("INFO : 対象なし");
        }
        else
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine($"INFO : {dt.Rows[i]["file_path"]}  {dt.Rows[i]["line_number"]}行目");
            }
        }
        


        // 検索終了
        Console.Write("何かキーを入力して終了...");
        Console.ReadLine();
        return;
    }

    // ファイルの文字列チェックメソッド
    private static DataTable CheckString(string[] files, string searchWord)
    {
        // 戻り値用のコレクションを作成
        // Key:ファイルパス、Value:検索文字列があった行番号
        DataTable dt = new DataTable();
        dt.Columns.Add("file_path", typeof(string));
        dt.Columns.Add("line_number", typeof(string));


        // 全ファイルチェック
        try
        {
            foreach (string file in files)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    // 1行ずつ読み込む
                    int lineNum = 0;
                    while (sr.Peek() >= 0)
                    {
                        // 行番号をカウントアップ
                        lineNum++;
                        string str = sr.ReadLine();

                        // 検索文字列が含まれていれば、ファイルパス、行番号をコレクションに追加
                        if (str.Contains(searchWord))
                        {
                            DataRow dr = dt.NewRow();
                            dr["file_path"] = file;
                            dr["line_number"] = lineNum.ToString();
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
        }
        catch
        {
            throw;
        }
        
        return dt;
    }
}