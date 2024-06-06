using Microsoft.Win32;
using System.Windows;

namespace BTD6_Profile.Save_Decryptor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string inputPath;
        private string outputPath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            OpenFileDialog openFileDialog = new() {
                Filter = "Save files (*.Save)|*.Save",
                DefaultExt = ".Save"
            };

            // Store the path to the global variable "inputPath" with "" around it
            if (openFileDialog.ShowDialog() == true) { inputPath = '"' + openFileDialog.FileName + '"'; }

            // Prompt user where to save the output file (as a .json)
            SaveFileDialog saveFileDialog = new() {
                Filter = "JSON files (*.json)|*.json"
            };

            // Store the path to the global variable "outputPath"
            if (saveFileDialog.ShowDialog() == true) { outputPath = '"' + saveFileDialog.FileName + '"'; }

            // Decrypt the file using monke.exe
            // Decryption (unpacking)  looks like: monke.exe unpack <inputPath> <outputPath> 11

            // 11 is the decryption key (password or something idk it is what it is)
            // Use Process.Start() construction to run the command

            System.Diagnostics.Process process = new();
            System.Diagnostics.ProcessStartInfo startInfo = new()
            {
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden, // Start cmd hidden
                FileName = "cmd.exe",
                Arguments = "/C monke.exe unpack " + inputPath + " " + outputPath + " 11"
            };
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            OpenFileDialog openFileDialog = new() {
                Filter = "JSON files (*.json)|*.json"
            };

            // Store the path to the global variable "inputPath" with "" around it
            if (openFileDialog.ShowDialog() == true) { inputPath = '"' + openFileDialog.FileName + '"'; }
            // Prompt user where to save the output file (as a .Save)
            SaveFileDialog saveFileDialog = new() {
                Filter = "Save files (*.Save)|*.Save"
            };

            // Store the path to the global variable "outputPath"
            if (saveFileDialog.ShowDialog() == true) { outputPath = '"' + saveFileDialog.FileName + '"';}

            // Encryption (packing) looks like: monke.exe pack <inputPath> <outputPath> 11
            System.Diagnostics.Process process = new();
            System.Diagnostics.ProcessStartInfo startInfo = new() {
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C monke.exe pack " + inputPath + " " + outputPath + " 11"
            };
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}