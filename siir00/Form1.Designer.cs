
namespace siir00
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.zad0 = new siir00.Zad0();
            this.zad1 = new siir00.Zad1();
            this.zad2 = new siir00.Zad2();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.zad0);
            this.tabControl1.Controls.Add(this.zad1);
            this.tabControl1.Controls.Add(this.zad2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(10000, 10000);
            this.tabControl1.TabIndex = 0;
            // 
            // zad0
            // 
            this.zad0.Location = new System.Drawing.Point(4, 22);
            this.zad0.Name = "zad 0";
            this.zad0.Padding = new System.Windows.Forms.Padding(3);
            this.zad0.Size = new System.Drawing.Size(9992, 9974);
            this.zad0.TabIndex = 0;
            this.zad0.Text = "zad 0";
            this.zad0.ToolTipText = resources.GetString("zad0.ToolTipText");
            this.zad0.UseVisualStyleBackColor = true;
            // 
            // zad1
            // 
            this.zad1.Location = new System.Drawing.Point(4, 22);
            this.zad1.Name = "zad 1";
            this.zad1.Padding = new System.Windows.Forms.Padding(3);
            this.zad1.Size = new System.Drawing.Size(9992, 9974);
            this.zad1.TabIndex = 1;
            this.zad1.Text = "zad 1";
            this.zad1.UseVisualStyleBackColor = true;
            // 
            // zad2
            // 
            this.zad2.Location = new System.Drawing.Point(4, 22);
            this.zad2.Name = "zad 2";
            this.zad2.Padding = new System.Windows.Forms.Padding(3);
            this.zad2.Size = new System.Drawing.Size(9992, 9974);
            this.zad2.TabIndex = 2;
            this.zad2.Text = "zad 2";
            this.zad2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 639);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Zadania na siir";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.TabControl tabControl1;
        private Zad0 zad0;
        private Zad1 zad1;
        public Zad2 zad2;
    }
}

