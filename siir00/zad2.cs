using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace siir00
{
    public class Zad2 : TabPage
    {
        CancellationTokenSource tokenSource;
        void RT(Action action, int seconds, CancellationToken token)
        {
            if (action == null)
                return;
            Task.Run(async () => {
                while (!token.IsCancellationRequested)
                {
                    action();
                    await Task.Delay(TimeSpan.FromSeconds(seconds), token);
                }
            }, token);
        }
        PerformanceCounter cpuCounter;
        Label cpuLabel;
        
        public Zad2() : base()
        {

            tokenSource = new CancellationTokenSource();
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            
            this.SuspendLayout();

            cpuLabel = new Label
            {
                Location = new System.Drawing.Point(15, 15),
                AutoSize = true
            };

            this.ResumeLayout(false);
            
            this.Controls.Add(cpuLabel);
            onLoad();
            
        }

        public void onLoad()
        {
            RT(() => this.sendCpuUsage(), 1, this.tokenSource.Token);
        }
        
        public void sendCpuUsage()
        {

            changeText();
            
        }

        public void changeText()
        {
            string cpuPercent = cpuCounter.NextValue() + "%";
            this.cpuLabel.Invoke(new Action(() =>
            {
                cpuLabel.Text = cpuPercent;

            }));
        }
    }
}
