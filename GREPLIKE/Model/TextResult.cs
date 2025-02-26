namespace GREPLIKE.Model
{
    // ファイル内文字列検索結果
    internal class TextResult
    {
        public string FilePath { get; private set; }
        public int LineNumber { get; private set; }

        public TextResult(string filePath, int lineNumber)
        {
            this.FilePath = filePath;
            this.LineNumber = lineNumber;
        }

        public override bool Equals(object? obj)
        {
            if (obj is TextResult findResult)
            {
                return this.FilePath == findResult.FilePath
                    && this.LineNumber == findResult.LineNumber;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.FilePath, this.LineNumber);
        }
    }
}
