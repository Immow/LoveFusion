using System.IO.Compression;
using System.Net.Security;

namespace MyFirstProject
{
    public partial class Form1 : Form
    {
        string love2dPath = "";
        string gamePath = "";
        string binPath = "";
        string outputPath = "";
        string gameName = "myGame";
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e) // Love2dPath
        {
            folderBrowserDialog1.ShowDialog();
            txbLove2dPath.Text = folderBrowserDialog1.SelectedPath;
            love2dPath = folderBrowserDialog1.SelectedPath;
        }

        private void btnGame_Click(object sender, EventArgs e) // gamePath
        {
            folderBrowserDialog2.ShowDialog();
            txbGamePath.Text = folderBrowserDialog2.SelectedPath;
            gamePath = folderBrowserDialog2.SelectedPath;
        }

        private void btnBin_Click(object sender, EventArgs e) // binPath
        {
            folderBrowserDialog3.ShowDialog();
            txbBin.Text = folderBrowserDialog3.SelectedPath;
            binPath = folderBrowserDialog3.SelectedPath;
        }

        private void btnOutputPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog4.ShowDialog();
            txbOutputPath.Text = folderBrowserDialog4.SelectedPath;
            outputPath = folderBrowserDialog4.SelectedPath;
        }

        private void txbGameName_TextChanged(object sender, EventArgs e) // gameName
        {
            gameName = textBox1.Text;
        }

        private void btnCreateExe_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(love2dPath) && !string.IsNullOrEmpty(gamePath) && !string.IsNullOrEmpty(outputPath))
            {
                //MessageBox.Show("Both love2dPath and gamePath are set. Performing action...");
                //MessageBox.Show("gameName:" + gameName);
                Directory.CreateDirectory(outputPath + "/bin");

                if (!string.IsNullOrEmpty(love2dPath) && !string.IsNullOrEmpty(outputPath))
                {
                    try
                    {
                        // Get all .dll files in the source directory
                        string[] dllFiles = Directory.GetFiles(love2dPath, "*.dll");

                        // Copy each .dll file to the destination directory
                        foreach (string dllFile in dllFiles)
                        {
                            // Get the file name without the path
                            string fileName = Path.GetFileName(dllFile);

                            // Construct the destination file path
                            string destinationFilePath = Path.Combine(outputPath, fileName);

                            // Copy the file to the destination directory
                            File.Copy(dllFile, destinationFilePath, true); // Set overwrite to true if you want to overwrite existing files
                        }

                        //MessageBox.Show("DLL files copied successfully.");
                        if (dllFiles.Count() == 0)
                        {
                            MessageBox.Show("FAILED to copy DLL files, is your Love2d Path correct?");
                        }
                        else
                        {
                            // Zip the contents of love2dPath to a .zip file
                            string zipFilePath = outputPath + "\\" + gameName + ".zip";
                            ZipFile.CreateFromDirectory(gamePath, zipFilePath);

                            // Rename the .zip file to a .love file
                            string loveFilePath = Path.ChangeExtension(zipFilePath, ".love");
                            File.Move(zipFilePath, loveFilePath);

                            // At this point, the .zip file has been renamed to .love

                            //string loveExePath = "path_to_love_exe\\love.exe"; // Replace "path_to_love_exe" with the actual path to your love.exe
                            //string loveFilePath = "path_to_love_file\\SuperGame.love"; // Replace "path_to_love_file" with the actual path to your SuperGame.love
                            //string outputExePath = "path_to_output\\SuperGame.exe"; // Replace "path_to_output" with the desired output path for the SuperGame.exe

                            try
                            {
                                byte[] loveExeBytes = File.ReadAllBytes(love2dPath + "\\love.exe");
                                byte[] loveFileBytes = File.ReadAllBytes(outputPath + "\\" + gameName + ".love");

                                using (FileStream outputStream = new FileStream(outputPath + "\\" + gameName + ".exe", FileMode.Create))
                                {
                                    outputStream.Write(loveExeBytes, 0, loveExeBytes.Length);
                                    outputStream.Write(loveFileBytes, 0, loveFileBytes.Length);
                                }

                                Console.WriteLine("*.exe created successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error creating *.exe: " + ex.Message);
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
    }
}
