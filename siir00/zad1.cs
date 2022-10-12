using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net;

namespace siir00
{
    class Zad1 : TabPage
    {
        private Button sendFilesButton;
        private OpenFileDialog openFileDialog1;

        public Zad1() : base()
        {
            this.sendFilesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            sendFilesButton = new Button
            {
                Size = new Size(85, 20),
                Location = new Point(215, 15),
                Text = "Save File"
            };
            sendFilesButton.Click += new EventHandler(SendFilesButton_Click);
            this.ResumeLayout(false);

            Controls.Add(sendFilesButton);
        }
        private void SendFilesButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }
                using (WebClient wc = new WebClient())
            {
                
            }
        }
    }
}
