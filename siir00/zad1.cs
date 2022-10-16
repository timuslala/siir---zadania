using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace siir00
{
    public class FileInfo
    {
        public uint count { get; set; }
        public ulong size { get; set; }
        public string[] filePaths { get; set; }
    }
    class Zad1 : TabPage
    {
        private Button sendFilesButton;
        private Button readLineButton;
        private ComboBox readLineFileComboBox;
        private Label responseLabel;
        private OpenFileDialog openFileDialog1;
        private NumericUpDown lineToRead;
        
        public Zad1() : base()
        {
            this.openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            this.SuspendLayout();

            lineToRead = new NumericUpDown
            {
                AutoSize = true,
                Location = new Point(430, 15),
                Name = "Line to read"
            };

            readLineFileComboBox = new ComboBox
            {
                Size = new Size(200,200),
                Location = new Point(215,15)
            };

            sendFilesButton = new Button
            {
                Size = new Size(85, 20),
                Location = new Point(15, 15),
                Text = "Send Files"
            };
            sendFilesButton.Click += new EventHandler(SendFilesButton_Click);
            
            readLineButton = new Button
            {
                Size = new Size(85, 20),
                Location = new Point(115, 15),
                Text = "Read Line"
            };
            readLineButton.Click += new EventHandler(ReadLineButton_Click);
            
            responseLabel = new Label
            {
                AutoSize = true,
                Location = new Point(15, 40)
            };
            
            this.ResumeLayout(false);

            Controls.Add(sendFilesButton);
            Controls.Add(readLineButton);
            Controls.Add(responseLabel);
            Controls.Add(readLineFileComboBox);
            Controls.Add(lineToRead);
        }
        private void SendFilesButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (HttpClient hc = new HttpClient())
                {
                    var multiPartContent = new MultipartFormDataContent();
                    foreach (string filename in openFileDialog1.FileNames)
                    {
                        multiPartContent.Add(new ByteArrayContent(File.ReadAllBytes(filename)), "files", filename);
                    }
                    Uri webService = new Uri("https://localhost:44308/FileUpload");
                    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, webService);
                    requestMessage.Headers.ExpectContinue = false;
                    requestMessage.Content = multiPartContent;
                    var task = hc.PostAsync(webService,multiPartContent);
                    task.Wait();
                    var task2 = task.Result.Content.ReadAsStringAsync();
                    task2.Wait();
                    responseLabel.Text = task2.Result;
                    FileInfo fileInfo = JsonSerializer.Deserialize<FileInfo>(task2.Result);
                    foreach(string fileName in fileInfo.filePaths)
                    {
                        readLineFileComboBox.Items.Add(fileName);
                    }
                    
                }
            }
        }
        private void ReadLineButton_Click(object sender, EventArgs e)
        {

        }

    }
}
