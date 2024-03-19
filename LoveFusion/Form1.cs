using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace MyFirstProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnLove2d.Tag      = txbLove2dPath;
            btnGame.Tag        = txbGamePath;
            btnBin.Tag         = txbBin;
            btnOutputPath.Tag  = txbOutputPath;
            //txbLove2dPath.Text = "C:\\Program Files\\LOVE";
            //txbGamePath.Text   = "D:\\Documents\\Programming\\Lua\\Test\\FFI";
            //txbBin.Text        = "D:\\Documents\\Programming\\Lua\\Test\\FFI\\bin";
            //txbOutputPath.Text = "C:\\Dev\\test";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var textBox = button.Tag as TextBox;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (textBox != null)
                {
                    textBox.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        // TODO Add button to open output path.

        private string[] CopyLove2dFiles()
        {
            // Get .dll files in the source directory
            string[] dllFiles = Directory.GetFiles(txbLove2dPath.Text, "*.dll");

            // Get license.txt files in the source directory
            string[] licenseFiles = Directory.GetFiles(txbLove2dPath.Text, "license.txt");

            // Concatenate the two arrays
            string[] files = dllFiles.Concat(licenseFiles).ToArray();

            // Copy each file to the destination directory
            foreach (string file in files)
            {
                // Get the file name without the path
                string fileName = Path.GetFileName(file);

                // Construct the destination file path
                string destinationFilePath = Path.Combine(txbOutputPath.Text, fileName);

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
            string zipFilePath = Path.Combine(txbOutputPath.Text, txbGameName.Text + ".zip");
            ZipFile.CreateFromDirectory(txbGamePath.Text, zipFilePath);

            // Rename the .zip file to a .love file
            string loveFilePath = Path.ChangeExtension(zipFilePath, ".love");
            File.Move(zipFilePath, loveFilePath);

            byte[] loveExeBytes = File.ReadAllBytes(Path.Combine(txbLove2dPath.Text, "love.exe"));
            byte[] loveFileBytes = File.ReadAllBytes(Path.Combine(txbOutputPath.Text, txbGameName.Text + ".love"));

            using (FileStream outputStream = new FileStream(Path.Combine(txbOutputPath.Text, txbGameName.Text + ".exe"), FileMode.Create))
            {
                outputStream.Write(loveExeBytes, 0, loveExeBytes.Length);
                outputStream.Write(loveFileBytes, 0, loveFileBytes.Length);
            }
            // TODO Bin (copy files)
            File.Delete(Path.Combine(txbOutputPath.Text, txbGameName.Text + ".love"));
            Console.WriteLine("*.exe created successfully.");
        }

        private void btnCreateExe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbLove2dPath.Text)) { MessageBox.Show("Love2d path not set"); return; }
            if (string.IsNullOrEmpty(txbGamePath.Text)) { MessageBox.Show("Game path not set"); return; }
            if (string.IsNullOrEmpty(txbOutputPath.Text)) { MessageBox.Show("Output path not set"); return; }

            string[] filesInOutputDir = Directory.GetFiles(txbOutputPath.Text);
            if (filesInOutputDir.Length > 0)
            {
                // Prompt the user if they want to delete the existing files
                DialogResult result = MessageBox.Show("There are files in the output directory. Do you want to delete them?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Directory.Delete(txbOutputPath.Text, true);
                }
                else
                {
                    // User chose not to delete the files, return early
                    return;
                }
            }
            
            Directory.CreateDirectory(Path.Combine(txbOutputPath.Text, "bin")); // Create bin directory

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
                        if (txbBin.Text.Length > 0)
                        {
                            CopyAll(txbBin.Text, Path.Combine(txbOutputPath.Text, "bin"));
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
        }
    }
}
