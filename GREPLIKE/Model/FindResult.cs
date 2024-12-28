namespace GREPLIKE.Model
{
    internal class FindResult
    {
        public string FilePath { get; private set; }
        public int LineNumber { get; private set; }

        public FindResult(string filePath, int lineNumber)
        {
            FilePath = filePath;
            LineNumber = lineNumber;
        }

        public override bool Equals(object? obj)
        {
            if (obj is FindResult findResult)
            {
                return FilePath == findResult.FilePath
                    && LineNumber == findResult.LineNumber;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FilePath, LineNumber);
        }
    }
}
