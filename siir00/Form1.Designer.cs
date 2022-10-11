
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.zad0 = new siir00.Zad0();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.zad0);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(10000, 10000);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.ShowToolTips = true;
            // 
            // zad0
            // 
            this.zad0.Location = new System.Drawing.Point(4, 22);
            this.zad0.Name = "zad0";
            this.zad0.Padding = new System.Windows.Forms.Padding(3);
            this.zad0.Size = new System.Drawing.Size(9992, 9974);
            this.zad0.TabIndex = 0;
            this.zad0.Text = "zad0";
            this.zad0.UseVisualStyleBackColor = true;
            this.zad0.Click += new System.EventHandler(this.zad0_Click);
            this.zad0.ToolTipText = @"Należy napisać w dowolnym języku programowania aplikację potrafiąca:

wczytać plik binarny i zmodyfikować jego zawartość,
wczytać i zmodyfikować plik JSON,
pobrać(HTTP GET) plik JSON i posortować znajdujące się w nim wartości.";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(9992, 9974);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "zad1";
            this.tabPage2.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.TabPage tabPage2;
    }
}

