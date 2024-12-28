using System.Diagnostics;
using GREPLIKE.BusinessLogic;
using GREPLIKE.Model;
using GREPLIKE.Utility;

namespace GREPLIKE
{
    public partial class FindForm : Form
    {
        public FindForm()
        {
            InitializeComponent();
        }

        // 参照ボタン
        private void ReferenceButton_Click(object sender, EventArgs e)
        {
            // ユーザ選択フォルダ取得
            GetUserSelectedDirectory();
        }

        // 検索ボタン
        private async void FindButton_Click(object sender, EventArgs e)
        {
            // 検索処理
            await FindKeyword();
        }

        private void DirecotryTextBox_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        private void KeywordTextBox_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        private void RecursiveFindRadioButton_Click(object sender, EventArgs e)
        {
            recursiveFindRadioButton.Checked = !recursiveFindRadioButton.Checked;
        }

        private void DirecotryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string directory = direcotryTextBox.Text;
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(directory))
            {
                keywordTextBox.Focus();
            }
        }

        private void KeywordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                findButton.PerformClick();
            }
        }

        // ユーザ選択フォルダ取得
        private void GetUserSelectedDirectory()
        {
            try
            {
                direcotryTextBox.Text = DirectoryHelper.GetUserSelectedDirectory();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ユーザ選択フォルダ取得エラー\n{ex}");
                MessageBox.Show($"ユーザ選択フォルダ取得エラー\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // キーワード検索
        private async Task FindKeyword()
        {
            string directory = direcotryTextBox.Text;
            if (string.IsNullOrEmpty(directory))
            {
                MessageBox.Show("フォルダを指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(directory))
            {
                MessageBox.Show("指定されたフォルダが見つかりませんでした。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string keyword = keywordTextBox.Text;
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("キーワードを入力してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 検索対象フォルダ取得
                bool isRecursive = recursiveFindRadioButton.Checked; // サブフォルダ探索フラグ
                IReadOnlyList<string> directories = new FindService().GetTargetDirectories(directory, isRecursive);
                DialogResult dialogResult = MessageBox.Show($"探索対象が'{directories.Count}'フォルダ見つかりました。\n続行してもよろしいですか？", "確認",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // 検索結果取得
                IReadOnlyList<FindResult> findResults;
                try
                {
                    UIHelper.SetUIEnabled(this, false, Cursors.WaitCursor);
                    findResults = await new FindService().GetFindResults(directories, keyword);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    UIHelper.SetUIEnabled(this, true, Cursors.Default);
                }

                // 結果表示
                using (ResultForm resultForm = new ResultForm(findResults))
                {
                    resultForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"検索エラー\n{ex}");
                MessageBox.Show($"検索エラー\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearCurrentInput();
        }

        // 入力値クリア
        private void ClearCurrentInput()
        {
            direcotryTextBox.Text = string.Empty;
            keywordTextBox.Text = string.Empty;
            recursiveFindRadioButton.Checked = false;
        }
    }
}
