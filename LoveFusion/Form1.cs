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
            btnLove2d.Tag     = txbLove2dPath;
            btnGame.Tag       = txbGamePath;
            btnBin.Tag        = txbBin;
            btnOutputPath.Tag = txbOutputPath;
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

        private string[] CopyDllFiles()
        {
            // Get all .dll files in the source directory
            string[] dllFiles = Directory.GetFiles(txbLove2dPath.Text, "*.dll");

            // Copy each .dll file to the destination directory
            foreach (string dllFile in dllFiles)
            {
                // Get the file name without the path
                string fileName = Path.GetFileName(dllFile);

                // Construct the destination file path
                string destinationFilePath = Path.Combine(txbOutputPath.Text, fileName);

                // Copy the file to the destination directory
                File.Copy(dllFile, destinationFilePath, true); // Set overwrite to true if you want to overwrite existing files
            }

            return dllFiles;
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
            // TODO: license.txt
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
                string[] dllFiles = CopyDllFiles();
                if (dllFiles.Length == 0)
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying DLL files: " + ex.Message);
            }
        }
    }
}
