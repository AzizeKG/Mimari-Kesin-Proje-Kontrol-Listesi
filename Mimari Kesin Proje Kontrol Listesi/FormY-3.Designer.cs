namespace Mimari_Kesin_Proje_Kontrol_Listesi
{
    partial class FormY_3
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnOnay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(103, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modeli onay için Atayan tarafa iletebilirsiniz. ";
            // 
            // btnKapat
            // 
            this.btnKapat.BackColor = System.Drawing.Color.Gainsboro;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKapat.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKapat.Location = new System.Drawing.Point(350, 203);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(187, 44);
            this.btnKapat.TabIndex = 107;
            this.btnKapat.Text = "KAPAT";
            this.btnKapat.UseVisualStyleBackColor = false;
            // 
            // btnOnay
            // 
            this.btnOnay.BackColor = System.Drawing.Color.Silver;
            this.btnOnay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOnay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOnay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOnay.Location = new System.Drawing.Point(97, 203);
            this.btnOnay.Name = "btnOnay";
            this.btnOnay.Size = new System.Drawing.Size(187, 44);
            this.btnOnay.TabIndex = 106;
            this.btnOnay.Text = "ONAYA GÖNDER";
            this.btnOnay.UseVisualStyleBackColor = false;
            this.btnOnay.Click += new System.EventHandler(this.btnKontrol_Click);
            // 
            // FormY_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(644, 347);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnOnay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormY_3";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnOnay;
    }
}