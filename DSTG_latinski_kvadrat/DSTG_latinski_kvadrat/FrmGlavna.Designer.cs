namespace DSTG_latinski_kvadrat
{
    partial class FrmGlavna
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGlavna));
            this.label1 = new System.Windows.Forms.Label();
            this.txtVelicinaTablice = new System.Windows.Forms.TextBox();
            this.btnKreirajTablicu = new System.Windows.Forms.Button();
            this.btnProvjeri = new System.Windows.Forms.Button();
            this.btnPrikaziRjesenje = new System.Windows.Forms.Button();
            this.checkIspravljanje = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(58, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Veličina tablice:";
            // 
            // txtVelicinaTablice
            // 
            this.txtVelicinaTablice.Location = new System.Drawing.Point(63, 74);
            this.txtVelicinaTablice.Name = "txtVelicinaTablice";
            this.txtVelicinaTablice.Size = new System.Drawing.Size(143, 22);
            this.txtVelicinaTablice.TabIndex = 1;
            this.txtVelicinaTablice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVelicinaTablice_KeyDown);
            // 
            // btnKreirajTablicu
            // 
            this.btnKreirajTablicu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKreirajTablicu.Location = new System.Drawing.Point(252, 30);
            this.btnKreirajTablicu.Name = "btnKreirajTablicu";
            this.btnKreirajTablicu.Size = new System.Drawing.Size(160, 66);
            this.btnKreirajTablicu.TabIndex = 2;
            this.btnKreirajTablicu.Text = "Kreiraj tablicu";
            this.btnKreirajTablicu.UseVisualStyleBackColor = true;
            this.btnKreirajTablicu.Click += new System.EventHandler(this.btnKreirajTablicu_Click);
            // 
            // btnProvjeri
            // 
            this.btnProvjeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnProvjeri.Location = new System.Drawing.Point(449, 30);
            this.btnProvjeri.Name = "btnProvjeri";
            this.btnProvjeri.Size = new System.Drawing.Size(160, 66);
            this.btnProvjeri.TabIndex = 4;
            this.btnProvjeri.Text = "Provjeri rješenje";
            this.btnProvjeri.UseVisualStyleBackColor = true;
            this.btnProvjeri.Click += new System.EventHandler(this.btnProvjeri_Click);
            // 
            // btnPrikaziRjesenje
            // 
            this.btnPrikaziRjesenje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrikaziRjesenje.Location = new System.Drawing.Point(652, 30);
            this.btnPrikaziRjesenje.Name = "btnPrikaziRjesenje";
            this.btnPrikaziRjesenje.Size = new System.Drawing.Size(160, 66);
            this.btnPrikaziRjesenje.TabIndex = 5;
            this.btnPrikaziRjesenje.Text = "Prikaži/sakrij rješenje";
            this.btnPrikaziRjesenje.UseVisualStyleBackColor = true;
            this.btnPrikaziRjesenje.Click += new System.EventHandler(this.btnPrikaziRjesenje_Click);
            // 
            // checkIspravljanje
            // 
            this.checkIspravljanje.AutoSize = true;
            this.checkIspravljanje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkIspravljanje.Location = new System.Drawing.Point(63, 127);
            this.checkIspravljanje.Name = "checkIspravljanje";
            this.checkIspravljanje.Size = new System.Drawing.Size(280, 24);
            this.checkIspravljanje.TabIndex = 6;
            this.checkIspravljanje.Text = "Ispravljanje nakon svakog unosa?";
            this.checkIspravljanje.UseVisualStyleBackColor = true;
            // 
            // FrmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(882, 653);
            this.Controls.Add(this.checkIspravljanje);
            this.Controls.Add(this.btnPrikaziRjesenje);
            this.Controls.Add(this.btnProvjeri);
            this.Controls.Add(this.btnKreirajTablicu);
            this.Controls.Add(this.txtVelicinaTablice);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGlavna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkyScraper";
            this.Load += new System.EventHandler(this.FrmGlavna_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVelicinaTablice;
        private System.Windows.Forms.Button btnKreirajTablicu;
        private System.Windows.Forms.Button btnProvjeri;
        private System.Windows.Forms.Button btnPrikaziRjesenje;
        private System.Windows.Forms.CheckBox checkIspravljanje;
    }
}

