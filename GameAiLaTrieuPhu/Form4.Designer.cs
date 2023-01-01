namespace GameAiLaTrieuPhu
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.lbllaw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbllaw
            // 
            this.lbllaw.BackColor = System.Drawing.Color.Transparent;
            this.lbllaw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lbllaw.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbllaw.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllaw.ForeColor = System.Drawing.Color.White;
            this.lbllaw.Image = global::GameAiLaTrieuPhu.Properties.Resources.mocCauHoi;
            this.lbllaw.Location = new System.Drawing.Point(22, 12);
            this.lbllaw.Name = "lbllaw";
            this.lbllaw.Size = new System.Drawing.Size(913, 525);
            this.lbllaw.TabIndex = 1;
            this.lbllaw.Text = resources.GetString("lbllaw.Text");
            this.lbllaw.UseVisualStyleBackColor = true;
            this.lbllaw.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameAiLaTrieuPhu.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(955, 536);
            this.Controls.Add(this.lbllaw);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lbllaw;
    }
}