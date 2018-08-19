namespace Dodge
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
            this.components = new System.ComponentModel.Container();
            this.UserNameText = new System.Windows.Forms.Label();
            this.LevelText = new System.Windows.Forms.Label();
            this.HpText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ScoreText = new System.Windows.Forms.Label();
            this.PauseText = new System.Windows.Forms.Label();
            this.GameoverText = new System.Windows.Forms.Label();
            this.TryAgainBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ContinueBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserNameText
            // 
            this.UserNameText.AutoSize = true;
            this.UserNameText.BackColor = System.Drawing.Color.Transparent;
            this.UserNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameText.ForeColor = System.Drawing.Color.Black;
            this.UserNameText.Location = new System.Drawing.Point(31, 29);
            this.UserNameText.Name = "UserNameText";
            this.UserNameText.Size = new System.Drawing.Size(119, 25);
            this.UserNameText.TabIndex = 0;
            this.UserNameText.Text = "User Name";
            // 
            // LevelText
            // 
            this.LevelText.AutoSize = true;
            this.LevelText.BackColor = System.Drawing.Color.Transparent;
            this.LevelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelText.ForeColor = System.Drawing.Color.Black;
            this.LevelText.Location = new System.Drawing.Point(31, 67);
            this.LevelText.Name = "LevelText";
            this.LevelText.Size = new System.Drawing.Size(64, 25);
            this.LevelText.TabIndex = 1;
            this.LevelText.Text = "Level";
            // 
            // HpText
            // 
            this.HpText.AutoSize = true;
            this.HpText.BackColor = System.Drawing.Color.Transparent;
            this.HpText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HpText.ForeColor = System.Drawing.Color.Black;
            this.HpText.Location = new System.Drawing.Point(31, 106);
            this.HpText.Name = "HpText";
            this.HpText.Size = new System.Drawing.Size(41, 25);
            this.HpText.TabIndex = 2;
            this.HpText.Text = "HP";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ScoreText
            // 
            this.ScoreText.AutoSize = true;
            this.ScoreText.BackColor = System.Drawing.Color.Transparent;
            this.ScoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreText.ForeColor = System.Drawing.Color.Black;
            this.ScoreText.Location = new System.Drawing.Point(31, 144);
            this.ScoreText.Name = "ScoreText";
            this.ScoreText.Size = new System.Drawing.Size(69, 25);
            this.ScoreText.TabIndex = 3;
            this.ScoreText.Text = "Score";
            // 
            // PauseText
            // 
            this.PauseText.AutoSize = true;
            this.PauseText.BackColor = System.Drawing.Color.Transparent;
            this.PauseText.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PauseText.Location = new System.Drawing.Point(470, 330);
            this.PauseText.Name = "PauseText";
            this.PauseText.Size = new System.Drawing.Size(134, 38);
            this.PauseText.TabIndex = 5;
            this.PauseText.Text = "PAUSE";
            this.PauseText.Visible = false;
            // 
            // GameoverText
            // 
            this.GameoverText.AutoSize = true;
            this.GameoverText.BackColor = System.Drawing.Color.Transparent;
            this.GameoverText.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameoverText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GameoverText.Location = new System.Drawing.Point(431, 330);
            this.GameoverText.Name = "GameoverText";
            this.GameoverText.Size = new System.Drawing.Size(226, 38);
            this.GameoverText.TabIndex = 6;
            this.GameoverText.Text = "GAME OVER";
            this.GameoverText.Visible = false;
            // 
            // TryAgainBtn
            // 
            this.TryAgainBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TryAgainBtn.ForeColor = System.Drawing.Color.Black;
            this.TryAgainBtn.Location = new System.Drawing.Point(335, 397);
            this.TryAgainBtn.Name = "TryAgainBtn";
            this.TryAgainBtn.Size = new System.Drawing.Size(189, 62);
            this.TryAgainBtn.TabIndex = 7;
            this.TryAgainBtn.Text = "Try Again";
            this.TryAgainBtn.UseVisualStyleBackColor = true;
            this.TryAgainBtn.Visible = false;
            this.TryAgainBtn.Click += new System.EventHandler(this.TryAgainBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.Black;
            this.ExitBtn.Location = new System.Drawing.Point(555, 397);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(189, 62);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "No More";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Visible = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.Color.Black;
            this.SaveBtn.Location = new System.Drawing.Point(335, 397);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(189, 62);
            this.SaveBtn.TabIndex = 9;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Visible = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueBtn.ForeColor = System.Drawing.Color.Black;
            this.ContinueBtn.Location = new System.Drawing.Point(555, 397);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.Size = new System.Drawing.Size(189, 62);
            this.ContinueBtn.TabIndex = 10;
            this.ContinueBtn.Text = "Continue";
            this.ContinueBtn.UseVisualStyleBackColor = true;
            this.ContinueBtn.Visible = false;
            this.ContinueBtn.Click += new System.EventHandler(this.ContinueBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1082, 1055);
            this.Controls.Add(this.ContinueBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.TryAgainBtn);
            this.Controls.Add(this.GameoverText);
            this.Controls.Add(this.PauseText);
            this.Controls.Add(this.ScoreText);
            this.Controls.Add(this.HpText);
            this.Controls.Add(this.LevelText);
            this.Controls.Add(this.UserNameText);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Dodge";
            this.Load += new System.EventHandler(this.StartGame);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownEvent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserNameText;
        private System.Windows.Forms.Label LevelText;
        private System.Windows.Forms.Label HpText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ScoreText;
        private System.Windows.Forms.Label PauseText;
        private System.Windows.Forms.Label GameoverText;
        private System.Windows.Forms.Button TryAgainBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button ContinueBtn;
    }
}

