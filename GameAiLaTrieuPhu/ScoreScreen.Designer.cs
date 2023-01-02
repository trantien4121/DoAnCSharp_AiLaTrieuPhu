namespace GameAiLaTrieuPhu
{
    partial class ScoreScreen
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
            this.lblTitle = new System.Windows.Forms.Button();
            this.lblPrizeAmount = new System.Windows.Forms.Button();
            this.btnReturnToForm1 = new System.Windows.Forms.Button();
            this.btnBacktoMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.BackgroundImage = global::GameAiLaTrieuPhu.Properties.Resources.mocCauHoi;
            this.lblTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.lblTitle.Location = new System.Drawing.Point(175, 33);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(367, 80);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Giải thưởng của bạn:";
            this.lblTitle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.lblTitle.UseVisualStyleBackColor = false;
            // 
            // lblPrizeAmount
            // 
            this.lblPrizeAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblPrizeAmount.BackgroundImage = global::GameAiLaTrieuPhu.Properties.Resources.mocCauHoi;
            this.lblPrizeAmount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lblPrizeAmount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPrizeAmount.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrizeAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.lblPrizeAmount.Location = new System.Drawing.Point(236, 132);
            this.lblPrizeAmount.Margin = new System.Windows.Forms.Padding(2);
            this.lblPrizeAmount.Name = "lblPrizeAmount";
            this.lblPrizeAmount.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.lblPrizeAmount.Size = new System.Drawing.Size(251, 53);
            this.lblPrizeAmount.TabIndex = 3;
            this.lblPrizeAmount.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.lblPrizeAmount.UseVisualStyleBackColor = false;
            this.lblPrizeAmount.Click += new System.EventHandler(this.lblPrizeAmount_Click);
            // 
            // btnReturnToForm1
            // 
            this.btnReturnToForm1.BackColor = System.Drawing.Color.Transparent;
            this.btnReturnToForm1.BackgroundImage = global::GameAiLaTrieuPhu.Properties.Resources.mocCauHoi;
            this.btnReturnToForm1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReturnToForm1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReturnToForm1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnToForm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnReturnToForm1.Location = new System.Drawing.Point(236, 209);
            this.btnReturnToForm1.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturnToForm1.Name = "btnReturnToForm1";
            this.btnReturnToForm1.Size = new System.Drawing.Size(251, 50);
            this.btnReturnToForm1.TabIndex = 4;
            this.btnReturnToForm1.Text = "Chơi lại";
            this.btnReturnToForm1.UseVisualStyleBackColor = false;
            this.btnReturnToForm1.Click += new System.EventHandler(this.btnReturnToForm1_Click);
            // 
            // btnBacktoMenu
            // 
            this.btnBacktoMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnBacktoMenu.BackgroundImage = global::GameAiLaTrieuPhu.Properties.Resources.mocCauHoi;
            this.btnBacktoMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBacktoMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBacktoMenu.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBacktoMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnBacktoMenu.Location = new System.Drawing.Point(236, 290);
            this.btnBacktoMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnBacktoMenu.Name = "btnBacktoMenu";
            this.btnBacktoMenu.Size = new System.Drawing.Size(251, 43);
            this.btnBacktoMenu.TabIndex = 5;
            this.btnBacktoMenu.Text = "Trở lại Menu";
            this.btnBacktoMenu.UseVisualStyleBackColor = false;
            this.btnBacktoMenu.Click += new System.EventHandler(this.btnBacktoMenu_Click);
            // 
            // ScoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameAiLaTrieuPhu.Properties.Resources.mainBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(687, 344);
            this.ControlBox = false;
            this.Controls.Add(this.btnBacktoMenu);
            this.Controls.Add(this.btnReturnToForm1);
            this.Controls.Add(this.lblPrizeAmount);
            this.Controls.Add(this.lblTitle);
            this.Name = "ScoreScreen";
            this.Text = "ScoreScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lblTitle;
        private System.Windows.Forms.Button lblPrizeAmount;
        private System.Windows.Forms.Button btnReturnToForm1;
        private System.Windows.Forms.Button btnBacktoMenu;
    }
}