namespace GREPLIKE.Model
{
    // ファイル名検索結果
    class FileNameResult
    {
        public string FilePath { get; private set; }
        public string FileName { get; private set; }

        public FileNameResult(string filePath, string fileName)
        {
            this.FilePath = filePath;
            this.FileName = fileName;
        }
    }
}
