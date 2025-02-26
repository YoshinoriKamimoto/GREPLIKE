using System.Diagnostics;

namespace GREPLIKE
{
    internal partial class ResultForm : Form
    {
        private object dataSource;

        public ResultForm(object dataSource)
        {
            InitializeComponent();
            this.dataSource = dataSource;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            // データソース初期化
            InitializeDataSource();
        }

        // フォルダを開くボタン
        private void DirectoryOpenButton_Click(object sender, EventArgs e)
        {
            OpenSelectedFileDirectory();
        }

        // データソース初期化
        private void InitializeDataSource()
        {
            try
            {
                resultDataGridView.DataSource = this.dataSource;
                foreach (DataGridViewColumn column in resultDataGridView.Columns)
                {
                    if (column.Name == "LineNumber")
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    }
                }
                int resultRecordCount = resultDataGridView.Rows.Count;
                MessageBox.Show($"'{resultRecordCount}'件のデータが見つかりました。", "検索完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"データソース初期化エラー\n{ex}");
                MessageBox.Show($"データソース初期化エラー\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 選択中ファイルのフォルダを開く
        private void OpenSelectedFileDirectory()
        {
            string? file = resultDataGridView.CurrentCell.Value.ToString();
            if (!File.Exists(file))
            {
                return;
            }

            string? directory = Path.GetDirectoryName(file);
            if (!Directory.Exists(directory))
            {
                return;
            }

            try
            {
                Process.Start("explorer.exe", $@"/select,{file}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"フォルダオープンエラー\n{ex}");
                MessageBox.Show($"フォルダオープンエラー\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
