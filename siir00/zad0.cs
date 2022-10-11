using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace siir00
{
    class Zad0 :TabPage
    {
        private OpenFileDialog openFileDialog1;
        private TextBox mainTextBox;
        private TextBox urlTextBox;
        private Button binaryFileLoadButton;
        private Button jsonFileLoadButton;
        private Button fileSaveButton;
        private Button downloadJsonButton;
        private Label currentPathLabel;
        private TreeView treeView1;
        private String currentPath;
        private bool binaryFileLoaded;
        public Zad0() : base()
        {
            openFileDialog1 = new OpenFileDialog();
            binaryFileLoadButton = new Button
            {
                Size = new Size(85, 20),
                Location = new Point(15, 15),
                Text = "Load Binary"
            };
            binaryFileLoadButton.Click += new EventHandler(FileLoadButton_Click);
            jsonFileLoadButton = new Button
            {
                Size = new Size(85, 20),
                Location = new Point(115, 15),
                Text = "Load JSON"
            };
            jsonFileLoadButton.Click += new EventHandler(FileLoadButton_Click);
            fileSaveButton = new Button
            {
                Size = new Size(85, 20),
                Location = new Point(215, 15),
                Text = "Save File"
            };
            fileSaveButton.Click += new EventHandler(FileSaveButton_Click);
            downloadJsonButton = new Button
            {
                Size = new Size(85, 20),
                Location = new Point(630, 15),
                Text = "Download JSON"
            };
            downloadJsonButton.Click += new EventHandler(DownloadJsonButton_Click);
            mainTextBox = new TextBox
            {
                Size = new Size(300, 300),
                Location = new Point(15, 40),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            mainTextBox.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            urlTextBox = new TextBox
            {
                Size = new Size(300, 30),
                Location = new Point(320, 15),
                Multiline = false,
                ScrollBars = ScrollBars.Horizontal,
                Text = "https://jsonplaceholder.typicode.com/todos/1"
            };
            currentPathLabel = new Label
            {
                Location = new Point(320, 40),
                Text = "file:                    ",
                Font = new System.Drawing.Font("Microsoft Sans Serif", 14F),
                AutoSize = true
            };
            treeView1 = new TreeView
            {
                Location = new Point(320, 70),
                Size = new Size(500, 500)
            };

            ClientSize = new Size(330, 360);
            Controls.Add(binaryFileLoadButton);
            Controls.Add(jsonFileLoadButton);
            Controls.Add(fileSaveButton);
            Controls.Add(downloadJsonButton);
            Controls.Add(mainTextBox);
            Controls.Add(urlTextBox);
            Controls.Add(currentPathLabel);
            Controls.Add(treeView1);
        }
        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!this.binaryFileLoaded) return;
            // Check for a naughty character in the KeyDown event.
            if (e.KeyChar!= '0'&& e.KeyChar != '1'&& e.KeyChar != '' && e.KeyChar != ' ')
            {
                // Stop the character from being entered into the control since it is illegal.
                e.Handled = true;
            }

        }

        private void SetText(string text)
        {
            mainTextBox.Text = text;
        }
        private void FileLoadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (sender.Equals(binaryFileLoadButton))
                    {
                        byte[] data = File.ReadAllBytes(openFileDialog1.FileName);
                        SetText(string.Join(" ",data.Select(x => Convert.ToString(x,2).PadLeft(8,'0'))));
                        this.binaryFileLoaded = true;
                    }
                    else
                    {
                        var sr = new StreamReader(openFileDialog1.FileName);
                        SetText(sr.ReadToEnd());
                        sr.Close();
                        this.binaryFileLoaded = false;
                    }
                    this.currentPath = openFileDialog1.FileName;
                    this.currentPathLabel.Text = "file: " + openFileDialog1.FileName;

                }
             
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        private void FileSaveButton_Click(object sender, EventArgs e)
        { 
            if(String.IsNullOrEmpty(this.currentPath)) {
                MessageBox.Show("filepath empty");
                return;
            };
            byte[] byteArray;
            if (this.binaryFileLoaded)
            {
                var bytesAsStrings = mainTextBox.Text.Replace(Environment.NewLine, "").Replace(" ", "").Select((c, i) => new { Char = c, Index = i })
                    .GroupBy(x => x.Index / 8)
                    .Select(g => new string(g.Select(x => x.Char).ToArray()));
                byteArray = bytesAsStrings.Select(s => Convert.ToByte(s, 2)).ToArray();
            }
            else
            {
                byteArray = Encoding.ASCII.GetBytes(mainTextBox.Text);
            }
            try
            {
                using (var fs = new FileStream(this.currentPath, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    fs.Close();
                    this.currentPathLabel.Text = "File saved at: "+ this.currentPath;
                    this.currentPath = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception.\n\nException message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }   
            
        }
        private void DisplayTreeView(JToken root, string rootName)
        {
            treeView1.BeginUpdate();
            try
            {
                treeView1.Nodes.Clear();
                var tNode = treeView1.Nodes[treeView1.Nodes.Add(new TreeNode(rootName))];
                tNode.Tag = root;

                AddNode(root, tNode);

                treeView1.ExpandAll();
            }
            finally
            {
                treeView1.EndUpdate();
            }
        }

        private void AddNode(JToken token, TreeNode inTreeNode)
        {
            if (token == null)
                return;
            if (token is JValue)
            {
                var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(token.ToString()))];
                childNode.Tag = token;
            }
            else if (token is JObject)
            {
                var obj = (JObject)token;
                foreach (var property in obj.Properties())
                {
                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(property.Name))];
                    childNode.Tag = property;
                    AddNode(property.Value, childNode);
                }
            }
            else if (token is JArray)
            {
                var array = (JArray)token;
                for (int i = 0; i < array.Count; i++)
                {
                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(i.ToString()))];
                    childNode.Tag = array[i];
                    AddNode(array[i], childNode);
                }
            }
            else
            {
                MessageBox.Show(string.Format("{0} not implemented", token.Type)); // JConstructor, JRaw
            }
        }
        private void DownloadJsonButton_Click(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(urlTextBox.Text);
                var root = JToken.Parse(json);
                SortJson((JObject)root);
                DisplayTreeView(root, urlTextBox.Text);
            }
        }
        void SortJson(JObject jObj)
        {
            var props = jObj.Properties().ToList();
            foreach (var prop in props)
            {
                prop.Remove();
            }

            foreach (var prop in props.OrderBy(p => p.Name))
            {
                jObj.Add(prop);
                if (prop.Value is JObject)
                    SortJson((JObject)prop.Value);
            }
        }
    }
}
