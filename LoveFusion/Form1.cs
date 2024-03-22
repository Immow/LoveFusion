using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using LoveFusion.Properties;

// TODO
// Change messagebox to: DialogResult result = MessageBox.Show("...", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
// Option to change game.exe icon?

namespace MyFirstProject
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            Button_Love2d.Tag = TextBox_Love2dPath;
            Button_Game.Tag = TextBox_GamePath;
            Button_Bin.Tag = TextBox_BinPath;
            Button_OutputPath.Tag = TextBox_OutputPath;
            Button_Icon.Tag = TextBox_IconPath;

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
            TextBox_BinPath.Text = LoveFusion.Properties.Settings.Default.BinPath;
            TextBox_OutputPath.Text = LoveFusion.Properties.Settings.Default.OutputPath;
            TextBox_IconPath.Text = LoveFusion.Properties.Settings.Default.IconPath;
            TextBox_GameName.Text = LoveFusion.Properties.Settings.Default.GameName;
            OpenFolder_CheckBox.Checked = LoveFusion.Properties.Settings.Default.OpenFolder_CheckBox;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Save the current user input to settings
            LoveFusion.Properties.Settings.Default.Love2dPath = TextBox_Love2dPath.Text;
            LoveFusion.Properties.Settings.Default.GamePath = TextBox_GamePath.Text;
            LoveFusion.Properties.Settings.Default.BinPath = TextBox_BinPath.Text;
            LoveFusion.Properties.Settings.Default.OutputPath = TextBox_OutputPath.Text;
            LoveFusion.Properties.Settings.Default.IconPath = TextBox_IconPath.Text;
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
            string[] licenseFile = Directory.GetFiles(TextBox_Love2dPath.Text, "license.txt");
            string[] loveExeFile = Directory.GetFiles(TextBox_Love2dPath.Text, "love.exe");

            string[] files = dllFiles.Concat(licenseFile).Concat(loveExeFile).ToArray();

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

        private void ChangeIcon()
        {
            string exeFilePath = Path.Combine(TextBox_OutputPath.Text, "love.exe");
            if (File.Exists(exeFilePath) && (!string.IsNullOrEmpty(TextBox_IconPath.Text)))
            {
                string rceditPath = "rcedit-x64.exe";
                string arguments = $"\"{Path.Combine(TextBox_OutputPath.Text, "love.exe")}\" --set-icon \"{TextBox_IconPath.Text}\"";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = rceditPath,
                    Arguments = arguments,
                    UseShellExecute = false, // Required to redirect standard output and error
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        string errorMessage = process.StandardError.ReadToEnd();
                        MessageBox.Show($"Failed to change icon: {errorMessage}");
                    }
                }
            }
        }

        private void FuseGame()
        {
            byte[] loveExeBytes = File.ReadAllBytes(Path.Combine(TextBox_OutputPath.Text, "love.exe"));
            byte[] loveFileBytes = File.ReadAllBytes(Path.Combine(TextBox_OutputPath.Text, TextBox_GameName.Text + ".love"));

            using (FileStream outputStream = new FileStream(Path.Combine(TextBox_OutputPath.Text, TextBox_GameName.Text + ".exe"), FileMode.Create))
            {
                outputStream.Write(loveExeBytes, 0, loveExeBytes.Length);
                outputStream.Write(loveFileBytes, 0, loveFileBytes.Length);
            }
        }

        private void SetGameName()
        {
            if (string.IsNullOrEmpty(TextBox_GameName.Text))
            {
                TextBox_GameName.Text = Path.GetFileName(TextBox_GamePath.Text);
            }
        }
        private void PrepareGameFiles()
        {
            SetGameName();

            string zipFilePath = Path.Combine(TextBox_OutputPath.Text, TextBox_GameName.Text + ".zip");
            string loveFilePath = Path.ChangeExtension(zipFilePath, ".love");

            ZipFile.CreateFromDirectory(TextBox_GamePath.Text, zipFilePath);
            File.Move(zipFilePath, loveFilePath);
            ChangeIcon();
            FuseGame();

            File.Delete(Path.Combine(TextBox_OutputPath.Text, TextBox_GameName.Text + ".love"));
            File.Delete(Path.Combine(TextBox_OutputPath.Text, "love.exe"));
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
                DialogResult result = MessageBox.Show("There are files in the output directory. Do you want to delete them?\n\nThis action will delete all files and folders, including subfolders and files, in that directory.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Directory.Delete(TextBox_OutputPath.Text, true);
                }
                else
                {
                    return;
                }
            }

            if (!string.IsNullOrEmpty(TextBox_BinPath.Text))
            {
                Directory.CreateDirectory(Path.Combine(TextBox_OutputPath.Text, "bin"));
            }
            else
            {
                Directory.CreateDirectory(TextBox_OutputPath.Text);
            }

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
                        PrepareGameFiles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("FAILED to create *.exe" + ex.Message);
                    }

                    try
                    {
                        if (TextBox_BinPath.Text.Length > 0)
                        {
                            CopyAll(TextBox_BinPath.Text, Path.Combine(TextBox_OutputPath.Text, "bin"));
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

        private void Icon_Click(object sender, EventArgs e)
        {
            // Create a new instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the properties of the dialog
            openFileDialog.Title = "Open File";
            //openFileDialog.Filter = "All files (*.*)|*.*"; // You can set specific file types here
            openFileDialog.Filter = "Icon files (*.ico)|*.ico";
            openFileDialog.Multiselect = false; // Allow only single file selection

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file name
                TextBox_IconPath.Text = openFileDialog.FileName;
            }
        }
    }
}
