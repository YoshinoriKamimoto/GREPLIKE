using System.Diagnostics;
using GREPLIKE.Model;

namespace GREPLIKE
{
    internal partial class ResultForm : Form
    {
        IReadOnlyList<FindResult> findResults;

        public ResultForm(IReadOnlyList<FindResult> findResults)
        {
            InitializeComponent();
            this.findResults = findResults;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            // データソース初期化
            if (!InitializeDataSource())
            {
                this.Close();
                return;
            }
        }

        // フォルダを開くボタン
        private void DirectoryOpenButton_Click(object sender, EventArgs e)
        {
            OpenSelectedFileDirectory();
        }

        // データソース初期化
        private bool InitializeDataSource()
        {
            // 該当データなし
            if (!this.findResults.Any())
            {
                MessageBox.Show("該当データが見つかりませんでした", "検索完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            MessageBox.Show($"'{this.findResults.Count}'件のデータが見つかりました", "検索完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // データ表示
            try
            {
                resultDataGridView.DataSource = this.findResults;
                resultDataGridView.Columns["LineNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"データソース初期化エラー\n{ex}");
                MessageBox.Show($"データソース初期化エラー\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
