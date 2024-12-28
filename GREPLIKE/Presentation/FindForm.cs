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
            // ��������
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

        // ���[�U�I���t�H���_�擾
        private void GetUserSelectedDirectory()
        {
            try
            {
                direcotryTextBox.Text = DirectoryHelper.GetUserSelectedDirectory();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"���[�U�I���t�H���_�擾�G���[\n{ex}");
                MessageBox.Show($"���[�U�I���t�H���_�擾�G���[\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �L�[���[�h����
        private async Task FindKeyword()
        {
            string directory = direcotryTextBox.Text;
            if (string.IsNullOrEmpty(directory))
            {
                MessageBox.Show("�t�H���_���w�肵�Ă��������B", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(directory))
            {
                MessageBox.Show("�w�肳�ꂽ�t�H���_��������܂���ł����B", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string keyword = keywordTextBox.Text;
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("�L�[���[�h����͂��Ă��������B", "�x��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // �����Ώۃt�H���_�擾
                bool isRecursive = recursiveFindRadioButton.Checked; // �T�u�t�H���_�T���t���O
                IReadOnlyList<string> directories = new FindService().GetTargetDirectories(directory, isRecursive);
                DialogResult dialogResult = MessageBox.Show($"�T���Ώۂ�'{directories.Count}'�t�H���_������܂����B\n���s���Ă���낵���ł����H", "�m�F",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // �������ʎ擾
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

                // ���ʕ\��
                using (ResultForm resultForm = new ResultForm(findResults))
                {
                    resultForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"�����G���[\n{ex}");
                MessageBox.Show($"�����G���[\n{ex.Message}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearCurrentInput();
        }

        // ���͒l�N���A
        private void ClearCurrentInput()
        {
            direcotryTextBox.Text = string.Empty;
            keywordTextBox.Text = string.Empty;
            recursiveFindRadioButton.Checked = false;
        }
    }
}
