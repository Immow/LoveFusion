namespace MyFirstProject
{
    partial class Form
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
            TextBox_BinPath = new TextBox();
            TextBox_GamePath = new TextBox();
            Button_Game = new Button();
            Button_CreateExe = new Button();
            TextBox_GameName = new TextBox();
            lblGameName = new Label();
            TextBox_OutputPath = new TextBox();
            Button_OutputPath = new Button();
            OpenFolder_CheckBox = new CheckBox();
            Label_Version = new Label();
            pictureBox1 = new PictureBox();
            TextBox_IconPath = new TextBox();
            Button_Icon = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Button_Love2d
            // 
            Button_Love2d.Location = new Point(12, 11);
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
            TextBox_Love2dPath.Location = new Point(131, 11);
            TextBox_Love2dPath.Name = "TextBox_Love2dPath";
            TextBox_Love2dPath.Size = new Size(441, 23);
            TextBox_Love2dPath.TabIndex = 2;
            TextBox_Love2dPath.TextChanged += PathTextChanged;
            // 
            // Button_Bin
            // 
            Button_Bin.Location = new Point(12, 69);
            Button_Bin.Name = "Button_Bin";
            Button_Bin.Size = new Size(113, 23);
            Button_Bin.TabIndex = 3;
            Button_Bin.Text = "bin Path";
            Button_Bin.UseVisualStyleBackColor = true;
            Button_Bin.Click += btnBrowse_Click;
            // 
            // TextBox_BinPath
            // 
            TextBox_BinPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_BinPath.Location = new Point(131, 69);
            TextBox_BinPath.Name = "TextBox_BinPath";
            TextBox_BinPath.Size = new Size(441, 23);
            TextBox_BinPath.TabIndex = 4;
            // 
            // TextBox_GamePath
            // 
            TextBox_GamePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_GamePath.Location = new Point(131, 40);
            TextBox_GamePath.Name = "TextBox_GamePath";
            TextBox_GamePath.Size = new Size(441, 23);
            TextBox_GamePath.TabIndex = 6;
            TextBox_GamePath.TextChanged += PathTextChanged;
            // 
            // Button_Game
            // 
            Button_Game.Location = new Point(12, 40);
            Button_Game.Name = "Button_Game";
            Button_Game.Size = new Size(113, 23);
            Button_Game.TabIndex = 5;
            Button_Game.Text = "Game Path";
            Button_Game.UseVisualStyleBackColor = true;
            Button_Game.Click += btnBrowse_Click;
            // 
            // Button_CreateExe
            // 
            Button_CreateExe.BackColor = SystemColors.Control;
            Button_CreateExe.Enabled = false;
            Button_CreateExe.Location = new Point(12, 189);
            Button_CreateExe.Name = "Button_CreateExe";
            Button_CreateExe.Size = new Size(113, 23);
            Button_CreateExe.TabIndex = 7;
            Button_CreateExe.Text = "Create executable";
            Button_CreateExe.UseVisualStyleBackColor = false;
            Button_CreateExe.Click += btnCreateExe_Click;
            // 
            // TextBox_GameName
            // 
            TextBox_GameName.AcceptsReturn = true;
            TextBox_GameName.Location = new Point(131, 156);
            TextBox_GameName.Name = "TextBox_GameName";
            TextBox_GameName.Size = new Size(231, 23);
            TextBox_GameName.TabIndex = 8;
            // 
            // lblGameName
            // 
            lblGameName.AutoSize = true;
            lblGameName.Location = new Point(52, 160);
            lblGameName.Name = "lblGameName";
            lblGameName.Size = new Size(73, 15);
            lblGameName.TabIndex = 9;
            lblGameName.Text = "Game Name";
            // 
            // TextBox_OutputPath
            // 
            TextBox_OutputPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_OutputPath.Location = new Point(131, 98);
            TextBox_OutputPath.Name = "TextBox_OutputPath";
            TextBox_OutputPath.Size = new Size(441, 23);
            TextBox_OutputPath.TabIndex = 11;
            TextBox_OutputPath.TextChanged += PathTextChanged;
            // 
            // Button_OutputPath
            // 
            Button_OutputPath.Location = new Point(12, 98);
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
            OpenFolder_CheckBox.Location = new Point(131, 192);
            OpenFolder_CheckBox.Name = "OpenFolder_CheckBox";
            OpenFolder_CheckBox.Size = new Size(146, 19);
            OpenFolder_CheckBox.TabIndex = 12;
            OpenFolder_CheckBox.Text = "Open folder after build";
            OpenFolder_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Label_Version
            // 
            Label_Version.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Label_Version.AutoSize = true;
            Label_Version.Location = new Point(532, 210);
            Label_Version.Name = "Label_Version";
            Label_Version.Size = new Size(37, 15);
            Label_Version.TabIndex = 13;
            Label_Version.Text = "v 0.01";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = LoveFusion.Properties.Resources.love_app_icon;
            pictureBox1.Location = new Point(523, 156);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // TextBox_IconPath
            // 
            TextBox_IconPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBox_IconPath.Location = new Point(131, 127);
            TextBox_IconPath.Name = "TextBox_IconPath";
            TextBox_IconPath.Size = new Size(441, 23);
            TextBox_IconPath.TabIndex = 16;
            TextBox_IconPath.TextChanged += PathTextChanged;
            // 
            // Button_Icon
            // 
            Button_Icon.Location = new Point(12, 127);
            Button_Icon.Name = "Button_Icon";
            Button_Icon.Size = new Size(113, 23);
            Button_Icon.TabIndex = 17;
            Button_Icon.Text = "Button_Icon";
            Button_Icon.UseVisualStyleBackColor = true;
            Button_Icon.Click += Icon_Click;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(584, 226);
            Controls.Add(Button_Icon);
            Controls.Add(TextBox_IconPath);
            Controls.Add(pictureBox1);
            Controls.Add(Label_Version);
            Controls.Add(OpenFolder_CheckBox);
            Controls.Add(TextBox_OutputPath);
            Controls.Add(Button_OutputPath);
            Controls.Add(lblGameName);
            Controls.Add(TextBox_GameName);
            Controls.Add(Button_CreateExe);
            Controls.Add(TextBox_GamePath);
            Controls.Add(Button_Game);
            Controls.Add(TextBox_BinPath);
            Controls.Add(Button_Bin);
            Controls.Add(TextBox_Love2dPath);
            Controls.Add(Button_Love2d);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaximumSize = new Size(2000, 265);
            MinimumSize = new Size(600, 265);
            Name = "Form";
            Text = "Löve2D Fusion";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Button_Love2d;
        private FolderBrowserDialog folderBrowserDialog;
        private TextBox TextBox_Love2dPath;
        private Button Button_Bin;
        private TextBox TextBox_BinPath;
        private TextBox TextBox_GamePath;
        private Button Button_Game;
        private Button Button_CreateExe;
        private TextBox TextBox_GameName;
        private Label lblGameName;
        private TextBox TextBox_OutputPath;
        private Button Button_OutputPath;
        private CheckBox OpenFolder_CheckBox;
        private Label Label_Version;
        private PictureBox pictureBox1;
        private TextBox TextBox_IconPath;
        private Button Button_Icon;
    }
}