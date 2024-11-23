namespace DrawLuckyWheel
{
    partial class FormMeNu
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
            this.lblChao = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSL = new System.Windows.Forms.Button();
            this.btnCnt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblChao
            // 
            this.lblChao.AutoSize = true;
            this.lblChao.BackColor = System.Drawing.Color.Transparent;
            this.lblChao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblChao.Location = new System.Drawing.Point(125, 4);
            this.lblChao.Name = "lblChao";
            this.lblChao.Size = new System.Drawing.Size(0, 20);
            this.lblChao.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(281, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "Vui lòng chọn chế độ chơi";
            // 
            // btnSL
            // 
            this.btnSL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSL.Location = new System.Drawing.Point(247, 195);
            this.btnSL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSL.Name = "btnSL";
            this.btnSL.Size = new System.Drawing.Size(119, 62);
            this.btnSL.TabIndex = 21;
            this.btnSL.Text = "SOLO";
            this.btnSL.UseVisualStyleBackColor = false;
            this.btnSL.Click += new System.EventHandler(this.btnSL_Click);
            // 
            // btnCnt
            // 
            this.btnCnt.BackColor = System.Drawing.Color.Yellow;
            this.btnCnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCnt.ForeColor = System.Drawing.Color.Teal;
            this.btnCnt.Location = new System.Drawing.Point(433, 195);
            this.btnCnt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCnt.Name = "btnCnt";
            this.btnCnt.Size = new System.Drawing.Size(119, 62);
            this.btnCnt.TabIndex = 22;
            this.btnCnt.Text = "CONNECT";
            this.btnCnt.UseVisualStyleBackColor = false;
            this.btnCnt.Click += new System.EventHandler(this.btnCnt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(100, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(575, 29);
            this.label2.TabIndex = 19;
            this.label2.Text = "Chào Mừng Bạn Đến Với Vòng Quay May Mắn";
            // 
            // FormMeNu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCnt);
            this.Controls.Add(this.btnSL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblChao);
            this.Name = "FormMeNu";
            this.Text = "FormMeNu";
            this.Load += new System.EventHandler(this.FormMeNu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSL;
        private System.Windows.Forms.Button btnCnt;
        private System.Windows.Forms.Label label2;
    }
}