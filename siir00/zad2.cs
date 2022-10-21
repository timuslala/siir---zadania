using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using MQTTnet;
using MQTTnet.Client;
namespace siir00
{
    
    public class Zad2 : TabPage
    {
        MqttFactory mqttFactory;
        IMqttClient mqttClient;
        Task<MqttClientConnectResult> mqttConnectionResult;
        MqttClientOptions mqttClientOptions;
        CancellationTokenSource tokenSource;
        float cpuValue;
        float cpuDelta = 10;
        float cpuLastVal;
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
            
            mqttFactory = new MqttFactory();
            mqttClient = mqttFactory.CreateMqttClient();
            mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTls()
                .WithTcpServer("2c16d12ae2374a8bbf8c0bd3abc8670f.s1.eu.hivemq.cloud",8883)
                .WithCredentials("timuslala2", "_#96LmfRfPjGxyZ")
                .Build();
            // i dont see this leaked password as security threat. go ahead. have it. remember to subscribe to my cpu values
            Task taskA = new Task(() =>this.mqttConnectionResult = mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None));
            taskA.RunSynchronously();
            taskA.Wait();
            
            onLoad();
        }

        public void onLoad()
        {
            RT(() => this.sendCpuUsage(), 1, this.tokenSource.Token);
        }
        
        async public void sendCpuUsage()
        {
            if (!this.cpuLabel.Visible)return ;
            changeText();
            if (cpuValue <= cpuLastVal - cpuDelta || cpuValue >= cpuLastVal + cpuDelta)
            {
                cpuLastVal = cpuValue;
                


                if (mqttClient.IsConnected)
                {
                    var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic("samples/pcPrzemek/cpuusage")
                    .WithPayload(cpuValue.ToString("0.00"))
                    .WithPayload(DateTime.Now.ToString())
                    .Build();

                    var response = await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);
                    string test = response.ToString();
                }
                else
                {
                    Task taskA = new Task(async () => await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None));
                }
            }
        }

        public void changeText()
        {
            cpuValue = cpuCounter.NextValue();
            string cpuPercent = cpuValue.ToString("0.00") + "%";
            this.cpuLabel.Invoke(new Action(() =>
            {
                cpuLabel.Text = cpuPercent;

            }));
        }
    }
}
