namespace GREPLIKE
{
    partial class FindForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            directoryTextBox = new TextBox();
            referenceButton = new Button();
            keywordTextBox = new TextBox();
            label1 = new Label();
            findButton = new Button();
            label2 = new Label();
            RecursiveFindCheckBox = new CheckBox();
            groupBox1 = new GroupBox();
            FindTextRadioButton = new RadioButton();
            FindFileNameRadioButton = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // directoryTextBox
            // 
            directoryTextBox.Location = new Point(36, 134);
            directoryTextBox.Name = "directoryTextBox";
            directoryTextBox.Size = new Size(318, 23);
            directoryTextBox.TabIndex = 3;
            directoryTextBox.TabStop = false;
            directoryTextBox.Click += DirectoryTextBox_Click;
            // 
            // referenceButton
            // 
            referenceButton.Location = new Point(360, 134);
            referenceButton.Name = "referenceButton";
            referenceButton.Size = new Size(75, 23);
            referenceButton.TabIndex = 4;
            referenceButton.Text = "参照";
            referenceButton.UseVisualStyleBackColor = true;
            referenceButton.Click += ReferenceButton_Click;
            // 
            // keywordTextBox
            // 
            keywordTextBox.Location = new Point(36, 232);
            keywordTextBox.Name = "keywordTextBox";
            keywordTextBox.Size = new Size(318, 23);
            keywordTextBox.TabIndex = 6;
            keywordTextBox.Click += KeywordTextBox_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 214);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 4;
            label1.Text = "キーワード";
            // 
            // findButton
            // 
            findButton.Location = new Point(360, 232);
            findButton.Name = "findButton";
            findButton.Size = new Size(75, 23);
            findButton.TabIndex = 7;
            findButton.Text = "検索";
            findButton.UseVisualStyleBackColor = true;
            findButton.Click += FindButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 116);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 7;
            label2.Text = "フォルダ";
            // 
            // RecursiveFindCheckBox
            // 
            RecursiveFindCheckBox.AutoSize = true;
            RecursiveFindCheckBox.Location = new Point(36, 163);
            RecursiveFindCheckBox.Name = "RecursiveFindCheckBox";
            RecursiveFindCheckBox.Size = new Size(104, 19);
            RecursiveFindCheckBox.TabIndex = 9;
            RecursiveFindCheckBox.Text = "サブフォルダ探索";
            RecursiveFindCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(FindFileNameRadioButton);
            groupBox1.Controls.Add(FindTextRadioButton);
            groupBox1.Location = new Point(36, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 80);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "検索モード";
            // 
            // FindTextRadioButton
            // 
            FindTextRadioButton.AutoSize = true;
            FindTextRadioButton.Checked = true;
            FindTextRadioButton.Location = new Point(24, 22);
            FindTextRadioButton.Name = "FindTextRadioButton";
            FindTextRadioButton.Size = new Size(131, 19);
            FindTextRadioButton.TabIndex = 11;
            FindTextRadioButton.TabStop = true;
            FindTextRadioButton.Text = "ファイル内文字列検索";
            FindTextRadioButton.UseVisualStyleBackColor = true;
            // 
            // FindFileNameRadioButton
            // 
            FindFileNameRadioButton.AutoSize = true;
            FindFileNameRadioButton.Location = new Point(24, 47);
            FindFileNameRadioButton.Name = "FindFileNameRadioButton";
            FindFileNameRadioButton.Size = new Size(95, 19);
            FindFileNameRadioButton.TabIndex = 12;
            FindFileNameRadioButton.TabStop = true;
            FindFileNameRadioButton.Text = "ファイル名検索";
            FindFileNameRadioButton.UseVisualStyleBackColor = true;
            // 
            // FindForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 288);
            Controls.Add(groupBox1);
            Controls.Add(RecursiveFindCheckBox);
            Controls.Add(label2);
            Controls.Add(findButton);
            Controls.Add(label1);
            Controls.Add(keywordTextBox);
            Controls.Add(referenceButton);
            Controls.Add(directoryTextBox);
            Name = "FindForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GREPLIKE";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox directoryTextBox;
        private Button referenceButton;
        private TextBox keywordTextBox;
        private Label label1;
        private Button findButton;
        private Label label2;
        private CheckBox RecursiveFindCheckBox;
        private GroupBox groupBox1;
        private RadioButton FindTextRadioButton;
        private RadioButton FindFileNameRadioButton;
    }
}
