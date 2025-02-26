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

        // �Q�ƃ{�^��
        private void ReferenceButton_Click(object sender, EventArgs e)
        {
            // ���[�U�I���t�H���_�擾
            GetUserSelectedDirectory();
        }

        // �����{�^��
        private async void FindButton_Click(object sender, EventArgs e)
        {
            string directory = directoryTextBox.Text;
            string keyword = keywordTextBox.Text;

            // �o���f�[�V�����`�F�b�N
            if (!Validate(directory, keyword))
            {
                return;
            }

            // �����Ώۃt�H���_�擾
            List<string>? targetDirectories = GetTargetDirectories(directory);
            if (targetDirectories == null)
            {
                return;
            }

            // �������s
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

        // ���[�U�I���t�H���_�擾
        private void GetUserSelectedDirectory()
        {
            try
            {
                directoryTextBox.Text = DirectoryHelper.GetUserSelectedDirectory();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"���[�U�I���t�H���_�擾�G���[\n{ex}");
                MessageBox.Show($"���[�U�I���t�H���_�擾�G���[\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �o���f�[�V�����`�F�b�N
        private bool Validate(string directory, string keyword)
        {
            if (string.IsNullOrEmpty(directory))
            {
                MessageBox.Show("�t�H���_���w�肵�Ă��������B", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Directory.Exists(directory))
            {
                MessageBox.Show("�w�肳�ꂽ�t�H���_��������܂���ł����B", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("�L�[���[�h����͂��Ă��������B", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // �����Ώۃt�H���_�擾
        private List<string>? GetTargetDirectories(string directory)
        {
            bool isRecursive = RecursiveFindCheckBox.Checked; // �T�u�t�H���_�T���t���O
            List<string> directories = new FindService().GetTargetDirectories(directory, isRecursive);
            DialogResult dialogResult = MessageBox.Show($"�T���Ώۂ�'{directories.Count}'�t�H���_������܂����B\n���s���Ă���낵���ł����H", "�m�F",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No)
            {
                return null;
            }
            return directories;
        }

        // �L�[���[�h�Ńt�@�C���������������
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
                Debug.WriteLine($"�����G���[\n{ex}");
                MessageBox.Show($"�����G���[\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // �L�[���[�h�Ńt�@�C��������
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
                Debug.WriteLine($"�����G���[\n{ex}");
                MessageBox.Show($"�����G���[\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // ���͒l�N���A
        private void ClearCurrentInput()
        {
            directoryTextBox.Text = string.Empty;
            keywordTextBox.Text = string.Empty;
            RecursiveFindCheckBox.Checked = false;
        }
    }
}
