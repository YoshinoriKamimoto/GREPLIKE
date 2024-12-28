namespace GREPLIKE
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            resultDataGridView = new DataGridView();
            directoryOpenButton = new Button();
            ((System.ComponentModel.ISupportInitialize)resultDataGridView).BeginInit();
            SuspendLayout();
            // 
            // resultDataGridView
            // 
            resultDataGridView.AllowUserToAddRows = false;
            resultDataGridView.AllowUserToDeleteRows = false;
            resultDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultDataGridView.Location = new Point(12, 39);
            resultDataGridView.Name = "resultDataGridView";
            resultDataGridView.Size = new Size(480, 314);
            resultDataGridView.TabIndex = 0;
            // 
            // directoryOpenButton
            // 
            directoryOpenButton.Location = new Point(12, 10);
            directoryOpenButton.Name = "directoryOpenButton";
            directoryOpenButton.Size = new Size(96, 23);
            directoryOpenButton.TabIndex = 1;
            directoryOpenButton.Text = "フォルダを開く";
            directoryOpenButton.UseVisualStyleBackColor = true;
            directoryOpenButton.Click += DirectoryOpenButton_Click;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 363);
            Controls.Add(directoryOpenButton);
            Controls.Add(resultDataGridView);
            Name = "ResultForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GREPLIKE";
            WindowState = FormWindowState.Maximized;
            Load += ResultForm_Load;
            ((System.ComponentModel.ISupportInitialize)resultDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView resultDataGridView;
        private Button directoryOpenButton;
    }
}