namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Encrypt_DecryptMode = new System.Windows.Forms.ComboBox();
            this.SourceDirLabel = new System.Windows.Forms.Label();
            this.TargetLabel = new System.Windows.Forms.Label();
            this.SourcePath = new System.Windows.Forms.TextBox();
            this.TargetPath = new System.Windows.Forms.TextBox();
            this.ChoseSourceButton = new System.Windows.Forms.Button();
            this.ChoseDestButton = new System.Windows.Forms.Button();
            this.TransformButton = new System.Windows.Forms.Button();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.KeyLable = new System.Windows.Forms.Label();
            this.Dialog = new System.Windows.Forms.Label();
            this.SourceFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.TargetFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SourceFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ker = new WindowsFormsApplication1.Prog();
            this.SuspendLayout();
            // 
            // Encrypt_DecryptMode
            // 
            this.Encrypt_DecryptMode.FormattingEnabled = true;
            this.Encrypt_DecryptMode.Items.AddRange(new object[] {
            "Encrypt",
            "Decrypt"});
            this.Encrypt_DecryptMode.Location = new System.Drawing.Point(12, 12);
            this.Encrypt_DecryptMode.Name = "Encrypt_DecryptMode";
            this.Encrypt_DecryptMode.Size = new System.Drawing.Size(121, 21);
            this.Encrypt_DecryptMode.TabIndex = 0;
            this.Encrypt_DecryptMode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SourceDirLabel
            // 
            this.SourceDirLabel.AutoSize = true;
            this.SourceDirLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SourceDirLabel.Location = new System.Drawing.Point(9, 45);
            this.SourceDirLabel.Name = "SourceDirLabel";
            this.SourceDirLabel.Size = new System.Drawing.Size(152, 13);
            this.SourceDirLabel.TabIndex = 1;
            this.SourceDirLabel.Text = "Chose file or folder to transform";
            // 
            // TargetLabel
            // 
            this.TargetLabel.AutoSize = true;
            this.TargetLabel.Location = new System.Drawing.Point(9, 95);
            this.TargetLabel.Name = "TargetLabel";
            this.TargetLabel.Size = new System.Drawing.Size(120, 13);
            this.TargetLabel.TabIndex = 2;
            this.TargetLabel.Text = "Chose destination folder";
            // 
            // SourcePath
            // 
            this.SourcePath.Location = new System.Drawing.Point(12, 62);
            this.SourcePath.Name = "SourcePath";
            this.SourcePath.Size = new System.Drawing.Size(261, 20);
            this.SourcePath.TabIndex = 3;
            this.SourcePath.TextChanged += new System.EventHandler(this.SourcePath_TextChanged);
            // 
            // TargetPath
            // 
            this.TargetPath.Location = new System.Drawing.Point(12, 111);
            this.TargetPath.Name = "TargetPath";
            this.TargetPath.Size = new System.Drawing.Size(261, 20);
            this.TargetPath.TabIndex = 4;
            this.TargetPath.TextChanged += new System.EventHandler(this.TargetPath_TextChanged);
            // 
            // ChoseSourceButton
            // 
            this.ChoseSourceButton.Location = new System.Drawing.Point(296, 62);
            this.ChoseSourceButton.Name = "ChoseSourceButton";
            this.ChoseSourceButton.Size = new System.Drawing.Size(96, 19);
            this.ChoseSourceButton.TabIndex = 5;
            this.ChoseSourceButton.Text = "Chose Folder";
            this.ChoseSourceButton.UseVisualStyleBackColor = true;
            this.ChoseSourceButton.Click += new System.EventHandler(this.ChoseSourceButton_Click);
            // 
            // ChoseDestButton
            // 
            this.ChoseDestButton.Location = new System.Drawing.Point(296, 111);
            this.ChoseDestButton.Name = "ChoseDestButton";
            this.ChoseDestButton.Size = new System.Drawing.Size(96, 19);
            this.ChoseDestButton.TabIndex = 6;
            this.ChoseDestButton.Text = "ChoseFolder";
            this.ChoseDestButton.UseVisualStyleBackColor = true;
            this.ChoseDestButton.Click += new System.EventHandler(this.ChoseDestButton_Click);
            // 
            // TransformButton
            // 
            this.TransformButton.Location = new System.Drawing.Point(12, 185);
            this.TransformButton.Name = "TransformButton";
            this.TransformButton.Size = new System.Drawing.Size(149, 23);
            this.TransformButton.TabIndex = 7;
            this.TransformButton.Text = "Ready!";
            this.TransformButton.UseVisualStyleBackColor = true;
            this.TransformButton.Click += new System.EventHandler(this.TransformButton_Click);
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Location = new System.Drawing.Point(12, 159);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(261, 20);
            this.KeyTextBox.TabIndex = 10;
            this.KeyTextBox.TextChanged += new System.EventHandler(this.KeyTextBox_TextChanged);
            // 
            // KeyLable
            // 
            this.KeyLable.AutoSize = true;
            this.KeyLable.Location = new System.Drawing.Point(9, 143);
            this.KeyLable.Name = "KeyLable";
            this.KeyLable.Size = new System.Drawing.Size(78, 13);
            this.KeyLable.TabIndex = 9;
            this.KeyLable.Text = "Type Key Here";
            // 
            // Dialog
            // 
            this.Dialog.AutoSize = true;
            this.Dialog.BackColor = System.Drawing.SystemColors.Control;
            this.Dialog.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Dialog.Location = new System.Drawing.Point(328, 162);
            this.Dialog.Name = "Dialog";
            this.Dialog.Size = new System.Drawing.Size(0, 16);
            this.Dialog.TabIndex = 11;
            // 
            // SourceFileDialog
            // 
            this.SourceFileDialog.FileName = "openFileDialog1";
            // 
            // ker
            // 
            this.ker.Location = new System.Drawing.Point(459, 218);
            this.ker.Name = "ker";
            this.ker.Size = new System.Drawing.Size(10, 10);
            this.ker.TabIndex = 12;
            this.ker.Text = "prog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 240);
            this.Controls.Add(this.ker);
            this.Controls.Add(this.Dialog);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.KeyLable);
            this.Controls.Add(this.TransformButton);
            this.Controls.Add(this.ChoseDestButton);
            this.Controls.Add(this.ChoseSourceButton);
            this.Controls.Add(this.TargetPath);
            this.Controls.Add(this.SourcePath);
            this.Controls.Add(this.TargetLabel);
            this.Controls.Add(this.SourceDirLabel);
            this.Controls.Add(this.Encrypt_DecryptMode);
            this.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.Name = "Form1";
            this.Text = "MyArchive";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Encrypt_DecryptMode;
        private System.Windows.Forms.Label SourceDirLabel;
        private System.Windows.Forms.Label TargetLabel;
        private System.Windows.Forms.TextBox SourcePath;
        private System.Windows.Forms.TextBox TargetPath;
        private System.Windows.Forms.Button ChoseSourceButton;
        private System.Windows.Forms.Button ChoseDestButton;
        private System.Windows.Forms.Button TransformButton;
        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.Label KeyLable;
        private System.Windows.Forms.Label Dialog;
        private System.Windows.Forms.FolderBrowserDialog SourceFolderDialog;
        private System.Windows.Forms.FolderBrowserDialog TargetFolderDialog;
        private System.Windows.Forms.OpenFileDialog SourceFileDialog;
        private Prog ker;
    }
}

