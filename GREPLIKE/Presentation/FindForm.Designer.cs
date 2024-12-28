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
            direcotryTextBox = new TextBox();
            referenceButton = new Button();
            keywordTextBox = new TextBox();
            label1 = new Label();
            findButton = new Button();
            recursiveFindRadioButton = new RadioButton();
            label2 = new Label();
            SuspendLayout();
            // 
            // direcotryTextBox
            // 
            direcotryTextBox.Location = new Point(39, 36);
            direcotryTextBox.Name = "direcotryTextBox";
            direcotryTextBox.Size = new Size(318, 23);
            direcotryTextBox.TabIndex = 0;
            direcotryTextBox.TabStop = false;
            direcotryTextBox.Click += DirecotryTextBox_Click;
            direcotryTextBox.KeyDown += DirecotryTextBox_KeyDown;
            // 
            // referenceButton
            // 
            referenceButton.Location = new Point(363, 36);
            referenceButton.Name = "referenceButton";
            referenceButton.Size = new Size(75, 23);
            referenceButton.TabIndex = 1;
            referenceButton.Text = "参照";
            referenceButton.UseVisualStyleBackColor = true;
            referenceButton.Click += ReferenceButton_Click;
            // 
            // keywordTextBox
            // 
            keywordTextBox.Location = new Point(39, 134);
            keywordTextBox.Name = "keywordTextBox";
            keywordTextBox.Size = new Size(318, 23);
            keywordTextBox.TabIndex = 3;
            keywordTextBox.Click += KeywordTextBox_Click;
            keywordTextBox.KeyDown += KeywordTextBox_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 116);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 4;
            label1.Text = "キーワード";
            // 
            // findButton
            // 
            findButton.Location = new Point(363, 134);
            findButton.Name = "findButton";
            findButton.Size = new Size(75, 23);
            findButton.TabIndex = 4;
            findButton.Text = "検索";
            findButton.UseVisualStyleBackColor = true;
            findButton.Click += FindButton_Click;
            // 
            // recursiveFindRadioButton
            // 
            recursiveFindRadioButton.AutoCheck = false;
            recursiveFindRadioButton.AutoSize = true;
            recursiveFindRadioButton.Location = new Point(39, 65);
            recursiveFindRadioButton.Name = "recursiveFindRadioButton";
            recursiveFindRadioButton.Size = new Size(103, 19);
            recursiveFindRadioButton.TabIndex = 2;
            recursiveFindRadioButton.TabStop = true;
            recursiveFindRadioButton.Text = "サブフォルダ探索";
            recursiveFindRadioButton.UseVisualStyleBackColor = true;
            recursiveFindRadioButton.Click += RecursiveFindRadioButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 18);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 7;
            label2.Text = "フォルダ";
            // 
            // FindForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 186);
            Controls.Add(label2);
            Controls.Add(recursiveFindRadioButton);
            Controls.Add(findButton);
            Controls.Add(label1);
            Controls.Add(keywordTextBox);
            Controls.Add(referenceButton);
            Controls.Add(direcotryTextBox);
            Name = "FindForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GREPLIKE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox direcotryTextBox;
        private Button referenceButton;
        private TextBox keywordTextBox;
        private Label label1;
        private Button findButton;
        private RadioButton recursiveFindRadioButton;
        private Label label2;
    }
}
