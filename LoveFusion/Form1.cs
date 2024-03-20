using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

// TODO
// Change messagebox to: DialogResult result = MessageBox.Show("...", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
// Add an image to background
// Min height adjustment
// Remember last known settings

namespace MyFirstProject
{
    public partial class Form1 : Form
    {
        public Form1()
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
            // Get .dll files in the source directory
            string[] dllFiles = Directory.GetFiles(TextBox_Love2dPath.Text, "*.dll");

            // Get license.txt files in the source directory
            string[] licenseFiles = Directory.GetFiles(TextBox_Love2dPath.Text, "license.txt");

            // Concatenate the two arrays
            string[] files = dllFiles.Concat(licenseFiles).ToArray();

            // Copy each file to the destination directory
            foreach (string file in files)
            {
                // Get the file name without the path
                string fileName = Path.GetFileName(file);

                // Construct the destination file path
                string destinationFilePath = Path.Combine(TextBox_OutputPath.Text, fileName);

                // Copy the file to the destination directory
                File.Copy(file, destinationFilePath, true); // Set overwrite to true if you want to overwrite existing files
            }

            return files;
        }

        static void CopyAll(string source, string target)
        {
            // Copy each file
            foreach (string file in Directory.GetFiles(source))
            {
                string targetFile = Path.Combine(target, Path.GetFileName(file));
                File.Copy(file, targetFile, true);
            }

            // Copy each subdirectory
            foreach (string subDirectory in Directory.GetDirectories(source))
            {
                string targetSubDirectory = Path.Combine(target, Path.GetFileName(subDirectory));
                Directory.CreateDirectory(targetSubDirectory);
                CopyAll(subDirectory, targetSubDirectory);
            }
        }

        private void ZipGame()
        {
            // Zip the contents of love2dPath to a .zip file
            if (string.IsNullOrEmpty(TextBox_GameName.Text))
            {
                TextBox_GameName.Text = Path.GetFileName(TextBox_GamePath.Text);
            }
            string zipFilePath = Path.Combine(TextBox_OutputPath.Text, TextBox_GameName.Text + ".zip");
            ZipFile.CreateFromDirectory(TextBox_GamePath.Text, zipFilePath);

            // Rename the .zip file to a .love file
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
                // Prompt the user if they want to delete the existing files
                DialogResult result = MessageBox.Show("There are files in the output directory. Do you want to delete them?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Directory.Delete(TextBox_OutputPath.Text, true);
                }
                else
                {
                    // User chose not to delete the files, return early
                    return;
                }
            }

            Directory.CreateDirectory(Path.Combine(TextBox_OutputPath.Text, "bin")); // Create bin directory

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
    }
}
