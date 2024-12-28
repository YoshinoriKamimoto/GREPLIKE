using System.Text;
using GREPLIKE.Model;
using GREPLIKE.Utility;

namespace GREPLIKE.BusinessLogic
{
    internal class FindService
    {
        // 検索対象フォルダ取得
        public List<string> GetTargetDirectories(string directory, bool isRecursive)
        {
            List<string> directories = new List<string>();
            directories.Add(directory);
            if (isRecursive) // サブフォルダ再帰探索
            {
                directories.AddRange(DirectoryHelper.GetChildDirectories(directory));
            }
            return directories;
        }

        // 検索結果取得
        public async Task<List<FindResult>> GetFindResults(IReadOnlyList<string> directories, string keyword)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            List<FindResult> findResults = new List<FindResult>();
            await Task.Run(() =>
            {
                foreach (string directory in directories)
                {
                    string[] files = Directory.GetFiles(directory);
                    foreach (string file in files)
                    {
                        // utf-8
                        using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                        {
                            string? line;
                            int lineNumber = 0;
                            while ((line = streamReader.ReadLine()) != null)
                            {
                                lineNumber++;
                                if (!line.Contains(keyword))
                                {
                                    continue;
                                }
                                findResults.Add(new FindResult(file, lineNumber));
                            }
                        }

                        // Shift_JIS
                        using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (StreamReader streamReader = new StreamReader(fileStream, Encoding.GetEncoding("Shift_JIS")))
                        {
                            string? line;
                            int lineNumber = 0;
                            while ((line = streamReader.ReadLine()) != null)
                            {
                                lineNumber++;
                                if (!line.Contains(keyword))
                                {
                                    continue;
                                }
                                findResults.Add(new FindResult(file, lineNumber));
                            }
                        }
                    }
                }
            });
            return findResults.Distinct().ToList();
        }
    }
}
