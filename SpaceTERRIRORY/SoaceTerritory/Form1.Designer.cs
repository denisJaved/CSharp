namespace SpaceTerritory
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.player = new System.Windows.Forms.PictureBox();
            this.ticker = new System.Windows.Forms.Timer(this.components);
            this.label = new System.Windows.Forms.Label();
            this.bulletTicker = new System.Windows.Forms.Timer(this.components);
            this.enemyTicker = new System.Windows.Forms.Timer(this.components);
            this.optimizerTicker = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Black;
            this.player.ErrorImage = ((System.Drawing.Image)(resources.GetObject("player.ErrorImage")));
            this.player.ImageLocation = "D:\\denisJava\\C\\public\\CSharp\\SpaceTERRIRORY\\SoaceTerritory\\bin\\Debug\\assets\\PL-1-" +
    "1.png";
            this.player.Location = new System.Drawing.Point(12, 528);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(96, 96);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // ticker
            // 
            this.ticker.Enabled = true;
            this.ticker.Tick += new System.EventHandler(this.tickHandler);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 13);
            this.label.TabIndex = 1;
            // 
            // bulletTicker
            // 
            this.bulletTicker.Enabled = true;
            this.bulletTicker.Tick += new System.EventHandler(this.bulletTick);
            // 
            // enemyTicker
            // 
            this.enemyTicker.Enabled = true;
            this.enemyTicker.Tick += new System.EventHandler(this.enemyTick);
            // 
            // optimizerTicker
            // 
            this.optimizerTicker.Tick += new System.EventHandler(this.optimizerTick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 636);
            this.Controls.Add(this.label);
            this.Controls.Add(this.player);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpaceTerritory | CLASSIC";
            this.Shown += new System.EventHandler(this.shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.up);
            this.Resize += new System.EventHandler(this.resize);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer ticker;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Timer bulletTicker;
        private System.Windows.Forms.Timer enemyTicker;
        private System.Windows.Forms.Timer optimizerTicker;
    }
}

