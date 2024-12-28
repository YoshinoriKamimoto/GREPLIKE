namespace GREPLIKE.Utility
{
    internal static class DirectoryHelper
    {
        // ユーザ選択フォルダ取得
        public static string GetUserSelectedDirectory()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.SelectedPath;
                }
            }
            return string.Empty;
        }

        // サブフォルダ取得
        public static List<string> GetChildDirectories(string parentDirectory)
        {
            List<string> childDirectories = Directory.GetDirectories(parentDirectory).ToList();
            foreach (string childDirectory in new List<string>(childDirectories))
            {
                if (!ExistsChildDirectory(childDirectory))
                {
                    continue;
                }
                childDirectories.AddRange(GetChildDirectories(childDirectory)); // 再帰探索
            }
            return childDirectories;
        }

        // サブフォルダ存在チェック
        private static bool ExistsChildDirectory(string directory)
        {
            return Directory.GetDirectories(directory).Any();
        }
    }
}