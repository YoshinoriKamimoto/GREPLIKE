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
            string directory = directoryTextBox.Text;
            string keyword = keywordTextBox.Text;

            // バリデーションチェック
            if (!Validate(directory, keyword))
            {
                return;
            }

            // 検索対象フォルダ取得
            List<string>? targetDirectories = GetTargetDirectories(directory);
            if (targetDirectories == null)
            {
                return;
            }

            // 検索実行
            if (FindTextRadioButton.Checked)
            {
                await FindTextByKeywordInFile(targetDirectories, keyword);
            }
            if (FindFileNameRadioButton.Checked)
            {
                await FindFileNameByKeyword(targetDirectories, keyword);
            }
            ClearCurrentInput();
        }

        private void DirectoryTextBox_Click(object sender, EventArgs e)
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

        // ユーザ選択フォルダ取得
        private void GetUserSelectedDirectory()
        {
            try
            {
                directoryTextBox.Text = DirectoryHelper.GetUserSelectedDirectory();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ユーザ選択フォルダ取得エラー\n{ex}");
                MessageBox.Show($"ユーザ選択フォルダ取得エラー\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // バリデーションチェック
        private bool Validate(string directory, string keyword)
        {
            if (string.IsNullOrEmpty(directory))
            {
                MessageBox.Show("フォルダを指定してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Directory.Exists(directory))
            {
                MessageBox.Show("指定されたフォルダが見つかりませんでした。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("キーワードを入力してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // 検索対象フォルダ取得
        private List<string>? GetTargetDirectories(string directory)
        {
            bool isRecursive = RecursiveFindCheckBox.Checked; // サブフォルダ探索フラグ
            List<string> directories = new FindService().GetTargetDirectories(directory, isRecursive);
            DialogResult dialogResult = MessageBox.Show($"探索対象が'{directories.Count}'フォルダ見つかりました。\n続行してもよろしいですか？", "確認",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No)
            {
                return null;
            }
            return directories;
        }

        // キーワードでファイル内文字列を検索
        private async Task FindTextByKeywordInFile(IReadOnlyList<string> directories, string keyword)
        {
            try
            {
                List<TextResult> textResults;
                try
                {
                    UIHelper.SetUIEnabled(this, false, Cursors.WaitCursor);
                    textResults = await new FindService().FindTextByKeywordInFile(directories, keyword);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    UIHelper.SetUIEnabled(this, true, Cursors.Default);
                }

                new ResultForm(textResults).Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"検索エラー\n{ex}");
                MessageBox.Show($"検索エラー\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // キーワードでファイル名検索
        private async Task FindFileNameByKeyword(IReadOnlyList<string> directories, string keyword)
        {
            try
            {
                List<FileNameResult> fileNameResults;
                try
                {
                    UIHelper.SetUIEnabled(this, false, Cursors.WaitCursor);
                    fileNameResults = await new FindService().FindFileNameByKeyword(directories, keyword);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    UIHelper.SetUIEnabled(this, true, Cursors.Default);
                }

                new ResultForm(fileNameResults).Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"検索エラー\n{ex}");
                MessageBox.Show($"検索エラー\n{ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // 入力値クリア
        private void ClearCurrentInput()
        {
            directoryTextBox.Text = string.Empty;
            keywordTextBox.Text = string.Empty;
            RecursiveFindCheckBox.Checked = false;
        }
    }
}
