namespace MyFirstProject
{
    partial class Form1
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
            Button_Love2d = new Button();
            folderBrowserDialog = new FolderBrowserDialog();
            TextBox_Love2dPath = new TextBox();
            Button_Bin = new Button();
            TextBox_Bin = new TextBox();
            TextBox_GamePath = new TextBox();
            Button_Game = new Button();
            Button_CreateExe = new Button();
            TextBox_GameName = new TextBox();
            lblGameName = new Label();
            TextBox_OutputPath = new TextBox();
            Button_OutputPath = new Button();
            OpenFolder_CheckBox = new CheckBox();
            SuspendLayout();
            // 
            // Button_Love2d
            // 
            Button_Love2d.Location = new Point(12, 12);
            Button_Love2d.Name = "Button_Love2d";
            Button_Love2d.Size = new Size(113, 23);
            Button_Love2d.TabIndex = 0;
            Button_Love2d.Text = "Löve2D Path";
            Button_Love2d.UseVisualStyleBackColor = true;
            Button_Love2d.Click += btnBrowse_Click;
            // 
            // TextBox_Love2dPath
            // 
            TextBox_Love2dPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_Love2dPath.Location = new Point(131, 12);
            TextBox_Love2dPath.Name = "TextBox_Love2dPath";
            TextBox_Love2dPath.Size = new Size(1060, 23);
            TextBox_Love2dPath.TabIndex = 2;
            // 
            // Button_Bin
            // 
            Button_Bin.Location = new Point(12, 70);
            Button_Bin.Name = "Button_Bin";
            Button_Bin.Size = new Size(113, 23);
            Button_Bin.TabIndex = 3;
            Button_Bin.Text = "bin Path";
            Button_Bin.UseVisualStyleBackColor = true;
            Button_Bin.Click += btnBrowse_Click;
            // 
            // TextBox_Bin
            // 
            TextBox_Bin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_Bin.Location = new Point(131, 70);
            TextBox_Bin.Name = "TextBox_Bin";
            TextBox_Bin.Size = new Size(1060, 23);
            TextBox_Bin.TabIndex = 4;
            // 
            // TextBox_GamePath
            // 
            TextBox_GamePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_GamePath.Location = new Point(131, 41);
            TextBox_GamePath.Name = "TextBox_GamePath";
            TextBox_GamePath.Size = new Size(1060, 23);
            TextBox_GamePath.TabIndex = 6;
            // 
            // Button_Game
            // 
            Button_Game.Location = new Point(12, 41);
            Button_Game.Name = "Button_Game";
            Button_Game.Size = new Size(113, 23);
            Button_Game.TabIndex = 5;
            Button_Game.Text = "Game Path";
            Button_Game.UseVisualStyleBackColor = true;
            Button_Game.Click += btnBrowse_Click;
            // 
            // Button_CreateExe
            // 
            Button_CreateExe.Location = new Point(12, 161);
            Button_CreateExe.Name = "Button_CreateExe";
            Button_CreateExe.Size = new Size(113, 23);
            Button_CreateExe.TabIndex = 7;
            Button_CreateExe.Text = "Create executable";
            Button_CreateExe.UseVisualStyleBackColor = true;
            Button_CreateExe.Click += btnCreateExe_Click;
            // 
            // TextBox_GameName
            // 
            TextBox_GameName.AcceptsReturn = true;
            TextBox_GameName.Location = new Point(131, 128);
            TextBox_GameName.Name = "TextBox_GameName";
            TextBox_GameName.Size = new Size(231, 23);
            TextBox_GameName.TabIndex = 8;
            // 
            // lblGameName
            // 
            lblGameName.AutoSize = true;
            lblGameName.Location = new Point(52, 136);
            lblGameName.Name = "lblGameName";
            lblGameName.Size = new Size(73, 15);
            lblGameName.TabIndex = 9;
            lblGameName.Text = "Game Name";
            // 
            // TextBox_OutputPath
            // 
            TextBox_OutputPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_OutputPath.Location = new Point(131, 99);
            TextBox_OutputPath.Name = "TextBox_OutputPath";
            TextBox_OutputPath.Size = new Size(1060, 23);
            TextBox_OutputPath.TabIndex = 11;
            // 
            // Button_OutputPath
            // 
            Button_OutputPath.Location = new Point(12, 99);
            Button_OutputPath.Name = "Button_OutputPath";
            Button_OutputPath.Size = new Size(113, 23);
            Button_OutputPath.TabIndex = 10;
            Button_OutputPath.Text = "Output Path";
            Button_OutputPath.UseVisualStyleBackColor = true;
            Button_OutputPath.Click += btnBrowse_Click;
            // 
            // OpenFolder_CheckBox
            // 
            OpenFolder_CheckBox.AutoSize = true;
            OpenFolder_CheckBox.Location = new Point(131, 164);
            OpenFolder_CheckBox.Name = "OpenFolder_CheckBox";
            OpenFolder_CheckBox.Size = new Size(146, 19);
            OpenFolder_CheckBox.TabIndex = 12;
            OpenFolder_CheckBox.Text = "Open folder after build";
            OpenFolder_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1203, 396);
            Controls.Add(OpenFolder_CheckBox);
            Controls.Add(TextBox_OutputPath);
            Controls.Add(Button_OutputPath);
            Controls.Add(lblGameName);
            Controls.Add(TextBox_GameName);
            Controls.Add(Button_CreateExe);
            Controls.Add(TextBox_GamePath);
            Controls.Add(Button_Game);
            Controls.Add(TextBox_Bin);
            Controls.Add(Button_Bin);
            Controls.Add(TextBox_Love2dPath);
            Controls.Add(Button_Love2d);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(300, 200);
            Name = "Form1";
            Text = "Löve2D Fusion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Button_Love2d;
        private FolderBrowserDialog folderBrowserDialog;
        private TextBox TextBox_Love2dPath;
        private Button Button_Bin;
        private TextBox TextBox_Bin;
        private TextBox TextBox_GamePath;
        private Button Button_Game;
        private Button Button_CreateExe;
        private TextBox TextBox_GameName;
        private Label lblGameName;
        private TextBox TextBox_OutputPath;
        private Button Button_OutputPath;
        private CheckBox OpenFolder_CheckBox;
    }
}
