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
            components = new System.ComponentModel.Container();
            btnLove2d = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            txbLove2dPath = new TextBox();
            btnBin = new Button();
            txbBin = new TextBox();
            folderBrowserDialog2 = new FolderBrowserDialog();
            txbGamePath = new TextBox();
            btnGame = new Button();
            folderBrowserDialog3 = new FolderBrowserDialog();
            btnCreateExe = new Button();
            txbGameName = new TextBox();
            lblGameName = new Label();
            txbOutputPath = new TextBox();
            btnOutputPath = new Button();
            folderBrowserDialog4 = new FolderBrowserDialog();
            imageList1 = new ImageList(components);
            SuspendLayout();
            // 
            // btnLove2d
            // 
            btnLove2d.Location = new Point(12, 12);
            btnLove2d.Name = "btnLove2d";
            btnLove2d.Size = new Size(113, 23);
            btnLove2d.TabIndex = 0;
            btnLove2d.Text = "Löve2D Path";
            btnLove2d.UseVisualStyleBackColor = true;
            btnLove2d.Click += btnBrowse_Click;
            // 
            // txbLove2dPath
            // 
            txbLove2dPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbLove2dPath.Location = new Point(131, 12);
            txbLove2dPath.Name = "txbLove2dPath";
            txbLove2dPath.Size = new Size(1060, 23);
            txbLove2dPath.TabIndex = 2;
            // 
            // btnBin
            // 
            btnBin.Location = new Point(12, 70);
            btnBin.Name = "btnBin";
            btnBin.Size = new Size(113, 23);
            btnBin.TabIndex = 3;
            btnBin.Text = "bin Path";
            btnBin.UseVisualStyleBackColor = true;
            btnBin.Click += btnBrowse_Click;
            // 
            // txbBin
            // 
            txbBin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbBin.Location = new Point(131, 70);
            txbBin.Name = "txbBin";
            txbBin.Size = new Size(1060, 23);
            txbBin.TabIndex = 4;
            // 
            // txbGamePath
            // 
            txbGamePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbGamePath.Location = new Point(131, 41);
            txbGamePath.Name = "txbGamePath";
            txbGamePath.Size = new Size(1060, 23);
            txbGamePath.TabIndex = 6;
            // 
            // btnGame
            // 
            btnGame.Location = new Point(12, 41);
            btnGame.Name = "btnGame";
            btnGame.Size = new Size(113, 23);
            btnGame.TabIndex = 5;
            btnGame.Text = "Game Path";
            btnGame.UseVisualStyleBackColor = true;
            btnGame.Click += btnBrowse_Click;
            // 
            // btnCreateExe
            // 
            btnCreateExe.Location = new Point(12, 161);
            btnCreateExe.Name = "btnCreateExe";
            btnCreateExe.Size = new Size(113, 23);
            btnCreateExe.TabIndex = 7;
            btnCreateExe.Text = "Create executable";
            btnCreateExe.UseVisualStyleBackColor = true;
            btnCreateExe.Click += btnCreateExe_Click;
            // 
            // txbGameName
            // 
            txbGameName.AcceptsReturn = true;
            txbGameName.Location = new Point(131, 128);
            txbGameName.Name = "txbGameName";
            txbGameName.Size = new Size(231, 23);
            txbGameName.TabIndex = 8;
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
            // txbOutputPath
            // 
            txbOutputPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbOutputPath.Location = new Point(131, 99);
            txbOutputPath.Name = "txbOutputPath";
            txbOutputPath.Size = new Size(1060, 23);
            txbOutputPath.TabIndex = 11;
            // 
            // btnOutputPath
            // 
            btnOutputPath.Location = new Point(12, 99);
            btnOutputPath.Name = "btnOutputPath";
            btnOutputPath.Size = new Size(113, 23);
            btnOutputPath.TabIndex = 10;
            btnOutputPath.Text = "Output Path";
            btnOutputPath.UseVisualStyleBackColor = true;
            btnOutputPath.Click += btnBrowse_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1203, 396);
            Controls.Add(txbOutputPath);
            Controls.Add(btnOutputPath);
            Controls.Add(lblGameName);
            Controls.Add(txbGameName);
            Controls.Add(btnCreateExe);
            Controls.Add(txbGamePath);
            Controls.Add(btnGame);
            Controls.Add(txbBin);
            Controls.Add(btnBin);
            Controls.Add(txbLove2dPath);
            Controls.Add(btnLove2d);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MinimumSize = new Size(300, 200);
            Name = "Form1";
            Text = "Löve2D Fusion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLove2d;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox txbLove2dPath;
        private Button btnBin;
        private TextBox txbBin;
        private FolderBrowserDialog folderBrowserDialog2;
        private TextBox txbGamePath;
        private Button btnGame;
        private FolderBrowserDialog folderBrowserDialog3;
        private Button btnCreateExe;
        private TextBox txbGameName;
        private Label lblGameName;
        private TextBox txbOutputPath;
        private Button btnOutputPath;
        private FolderBrowserDialog folderBrowserDialog4;
        private ImageList imageList1;
    }
}
