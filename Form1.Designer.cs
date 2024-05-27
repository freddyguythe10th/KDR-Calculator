namespace KDR_Calculator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.KDROutput = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.killsOutput = new System.Windows.Forms.TextBox();
            this.deathsOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "KDR:";
            // 
            // KDROutput
            // 
            this.KDROutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KDROutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KDROutput.Location = new System.Drawing.Point(72, 9);
            this.KDROutput.Name = "KDROutput";
            this.KDROutput.Size = new System.Drawing.Size(126, 35);
            this.KDROutput.TabIndex = 1;
            this.KDROutput.Text = "0:0";
            this.KDROutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Deaths:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Kills:";
            // 
            // killsOutput
            // 
            this.killsOutput.Location = new System.Drawing.Point(72, 53);
            this.killsOutput.Name = "killsOutput";
            this.killsOutput.Size = new System.Drawing.Size(126, 20);
            this.killsOutput.TabIndex = 10;
            this.killsOutput.Text = "0";
            this.killsOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.killsOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ModifySavedData);
            // 
            // deathsOutput
            // 
            this.deathsOutput.Location = new System.Drawing.Point(72, 84);
            this.deathsOutput.Name = "deathsOutput";
            this.deathsOutput.Size = new System.Drawing.Size(126, 20);
            this.deathsOutput.TabIndex = 11;
            this.deathsOutput.Text = "0";
            this.deathsOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.deathsOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ModifySavedData);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 121);
            this.Controls.Add(this.deathsOutput);
            this.Controls.Add(this.killsOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KDROutput);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "KDR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label KDROutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox killsOutput;
        private System.Windows.Forms.TextBox deathsOutput;
    }
}

