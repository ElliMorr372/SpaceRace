namespace SpaceRace
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
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.p1ScoreLabel = new System.Windows.Forms.Label();
            this.p2ScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Interval = 20;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick_1);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(8, 118);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(481, 24);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "titleLabel";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.Location = new System.Drawing.Point(8, 150);
            this.subtitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(481, 24);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "subtitleLabel";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1ScoreLabel
            // 
            this.p1ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p1ScoreLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1ScoreLabel.Location = new System.Drawing.Point(84, 263);
            this.p1ScoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p1ScoreLabel.Name = "p1ScoreLabel";
            this.p1ScoreLabel.Size = new System.Drawing.Size(72, 24);
            this.p1ScoreLabel.TabIndex = 2;
            this.p1ScoreLabel.Text = "p1ScoreLabel";
            this.p1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2ScoreLabel
            // 
            this.p2ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.p2ScoreLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2ScoreLabel.Location = new System.Drawing.Point(369, 263);
            this.p2ScoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.p2ScoreLabel.Name = "p2ScoreLabel";
            this.p2ScoreLabel.Size = new System.Drawing.Size(72, 24);
            this.p2ScoreLabel.TabIndex = 3;
            this.p2ScoreLabel.Text = "p2ScoreLabel";
            this.p2ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.p2ScoreLabel);
            this.Controls.Add(this.p1ScoreLabel);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label p1ScoreLabel;
        private System.Windows.Forms.Label p2ScoreLabel;
    }
}

