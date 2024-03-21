using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using LoveFusion.Properties;

// TODO
// Change messagebox to: DialogResult result = MessageBox.Show("...", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
// When bin folder is not set, don't create it in output path.

namespace MyFirstProject
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            Button_Love2d.Tag = TextBox_Love2dPath;
            Button_Game.Tag = TextBox_GamePath;
            Button_Bin.Tag = TextBox_Bin;
            Button_OutputPath.Tag = TextBox_OutputPath;
            //TextBox_Love2dPath.Text = "C:\\Program Files\\LOVE";
            //TextBox_GamePath.Text = "D:\\Documents\\Programming\\Lua\\Test\\FFI";
            //TextBox_Bin.Text = "D:\\Documents\\Programming\\Lua\\Test\\FFI\\bin";
            //TextBox_OutputPath.Text = "C:\\Dev\\test";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the last user input from settings
            TextBox_Love2dPath.Text = LoveFusion.Properties.Settings.Default.Love2dPath;
            TextBox_GamePath.Text = LoveFusion.Properties.Settings.Default.GamePath;
            TextBox_Bin.Text = LoveFusion.Properties.Settings.Default.BinPath;
            TextBox_OutputPath.Text = LoveFusion.Properties.Settings.Default.OutputPath;
            TextBox_GameName.Text = LoveFusion.Properties.Settings.Default.GameName;
            OpenFolder_CheckBox.Checked = LoveFusion.Properties.Settings.Default.OpenFolder_CheckBox;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Save the current user input to settings
            LoveFusion.Properties.Settings.Default.Love2dPath = TextBox_Love2dPath.Text;
            LoveFusion.Properties.Settings.Default.GamePath = TextBox_GamePath.Text;
            LoveFusion.Properties.Settings.Default.BinPath = TextBox_Bin.Text;
            LoveFusion.Properties.Settings.Default.OutputPath = TextBox_OutputPath.Text;
            LoveFusion.Properties.Settings.Default.GameName = TextBox_GameName.Text;
            LoveFusion.Properties.Settings.Default.OpenFolder_CheckBox = OpenFolder_CheckBox.Checked;

            LoveFusion.Properties.Settings.Default.Save();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var textBox = button.Tag as TextBox;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (textBox != null)
                {
                    textBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private string[] CopyLove2dFiles()
        {
            string[] dllFiles = Directory.GetFiles(TextBox_Love2dPath.Text, "*.dll");
            string[] licenseFiles = Directory.GetFiles(TextBox_Love2dPath.Text, "license.txt");
            string[] files = dllFiles.Concat(licenseFiles).ToArray();

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationFilePath = Path.Combine(TextBox_OutputPath.Text, fileName);
                File.Copy(file, destinationFilePath, true);
            }
            return files;
        }

        static void CopyAll(string source, string target)
        {
            foreach (string file in Directory.GetFiles(source))
            {
                string targetFile = Path.Combine(target, Path.GetFileName(file));
                File.Copy(file, targetFile, true);
            }

            foreach (string subDirectory in Directory.GetDirectories(source))
            {
                string targetSubDirectory = Path.Combine(target, Path.GetFileName(subDirectory));
                Directory.CreateDirectory(targetSubDirectory);
                CopyAll(subDirectory, targetSubDirectory);
            }
        }

        private void ZipGame()
        {
            if (string.IsNullOrEmpty(TextBox_GameName.Text))
            {
                TextBox_GameName.Text = Path.GetFileName(TextBox_GamePath.Text);
            }
            string zipFilePath = Path.Combine(TextBox_OutputPath.Text, TextBox_GameName.Text + ".zip");
            ZipFile.CreateFromDirectory(TextBox_GamePath.Text, zipFilePath);

            string loveFilePath = Path.ChangeExtension(zipFilePath, ".love");
            File.Move(zipFilePath, loveFilePath);

            byte[] loveExeBytes = File.ReadAllBytes(Path.Combine(TextBox_Love2dPath.Text, "love.exe"));
            byte[] loveFileBytes = File.ReadAllBytes(Path.Combine(TextBox_OutputPath.Text, TextBox_GameName.Text + ".love"));

            using (FileStream outputStream = new FileStream(Path.Combine(TextBox_OutputPath.Text, TextBox_GameName.Text + ".exe"), FileMode.Create))
            {
                outputStream.Write(loveExeBytes, 0, loveExeBytes.Length);
                outputStream.Write(loveFileBytes, 0, loveFileBytes.Length);
            }
            File.Delete(Path.Combine(TextBox_OutputPath.Text, TextBox_GameName.Text + ".love"));
            Console.WriteLine("*.exe created successfully.");
        }

        private void btnCreateExe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_Love2dPath.Text)) { MessageBox.Show("Love2d path not set"); return; }
            if (string.IsNullOrEmpty(TextBox_GamePath.Text)) { MessageBox.Show("Game path not set"); return; }
            if (string.IsNullOrEmpty(TextBox_OutputPath.Text)) { MessageBox.Show("Output path not set"); return; }

            string[] filesInOutputDir = Directory.GetFiles(TextBox_OutputPath.Text);
            if (filesInOutputDir.Length > 0)
            {
                DialogResult result = MessageBox.Show("There are files in the output directory. Do you want to delete them?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Directory.Delete(TextBox_OutputPath.Text, true);
                }
                else
                {
                    return;
                }
            }

            Directory.CreateDirectory(Path.Combine(TextBox_OutputPath.Text, "bin"));

            try
            {
                string[] files = CopyLove2dFiles();
                if (files.Length == 0)
                {
                    MessageBox.Show("FAILED to copy DLL files, is your Love2d Path correct?");
                }
                else
                {
                    try
                    {
                        ZipGame();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("FAILED to create *.exe" + ex.Message);
                    }

                    try
                    {
                        if (TextBox_Bin.Text.Length > 0)
                        {
                            CopyAll(TextBox_Bin.Text, Path.Combine(TextBox_OutputPath.Text, "bin"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("FAILED to copy bin files & folders " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying DLL files: " + ex.Message);
            }
            MessageBox.Show("Task run successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (OpenFolder_CheckBox.Checked) { Process.Start("explorer.exe", TextBox_OutputPath.Text); }
        }

        private void PathTextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(TextBox_Love2dPath.Text)) && (!string.IsNullOrEmpty(TextBox_GamePath.Text)) && (!string.IsNullOrEmpty(TextBox_OutputPath.Text)))
            {
                Button_CreateExe.Enabled = true;
                Button_CreateExe.FlatStyle = FlatStyle.Standard;
                Button_CreateExe.BackColor = Color.White;
            }
            else
            {
                Button_CreateExe.Enabled = false;
                Button_CreateExe.FlatStyle = FlatStyle.Flat;
                Button_CreateExe.BackColor = Color.DarkGray; // Change the background color
            }
        }
    }
}
