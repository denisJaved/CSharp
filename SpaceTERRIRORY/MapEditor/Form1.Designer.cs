namespace MapEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.экспортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методыSPAWNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кодКартыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.корабльToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вражескийСтандартныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.барьерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стандартныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workspace = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(51, 22);
            this.toolStripDropDownButton1.Text = "Карта";
            // 
            // экспортToolStripMenuItem
            // 
            this.экспортToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.методыSPAWNToolStripMenuItem,
            this.кодКартыToolStripMenuItem});
            this.экспортToolStripMenuItem.Name = "экспортToolStripMenuItem";
            this.экспортToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.экспортToolStripMenuItem.Text = "Экспорт";
            // 
            // методыSPAWNToolStripMenuItem
            // 
            this.методыSPAWNToolStripMenuItem.Name = "методыSPAWNToolStripMenuItem";
            this.методыSPAWNToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.методыSPAWNToolStripMenuItem.Text = "Методы SPAWN";
            this.методыSPAWNToolStripMenuItem.Click += new System.EventHandler(this.exportMethods);
            // 
            // кодКартыToolStripMenuItem
            // 
            this.кодКартыToolStripMenuItem.Name = "кодКартыToolStripMenuItem";
            this.кодКартыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.кодКартыToolStripMenuItem.Text = "Код карты";
            this.кодКартыToolStripMenuItem.Click += new System.EventHandler(this.exportCode);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(72, 22);
            this.toolStripSplitButton1.Text = "Объекты";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.корабльToolStripMenuItem,
            this.барьерToolStripMenuItem});
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            // 
            // корабльToolStripMenuItem
            // 
            this.корабльToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вражескийСтандартныйToolStripMenuItem});
            this.корабльToolStripMenuItem.Name = "корабльToolStripMenuItem";
            this.корабльToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.корабльToolStripMenuItem.Text = "Корабль";
            // 
            // вражескийСтандартныйToolStripMenuItem
            // 
            this.вражескийСтандартныйToolStripMenuItem.Name = "вражескийСтандартныйToolStripMenuItem";
            this.вражескийСтандартныйToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.вражескийСтандартныйToolStripMenuItem.Text = "Вражеский | Стандартный";
            this.вражескийСтандартныйToolStripMenuItem.Click += new System.EventHandler(this.createStandartEnemy);
            // 
            // барьерToolStripMenuItem
            // 
            this.барьерToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стандартныйToolStripMenuItem});
            this.барьерToolStripMenuItem.Name = "барьерToolStripMenuItem";
            this.барьерToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.барьерToolStripMenuItem.Text = "Барьер";
            // 
            // стандартныйToolStripMenuItem
            // 
            this.стандартныйToolStripMenuItem.Name = "стандартныйToolStripMenuItem";
            this.стандартныйToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.стандартныйToolStripMenuItem.Text = "Стандартный";
            this.стандартныйToolStripMenuItem.Click += new System.EventHandler(this.createBasicBarrier);
            // 
            // workspace
            // 
            this.workspace.Location = new System.Drawing.Point(0, 28);
            this.workspace.Name = "workspace";
            this.workspace.Size = new System.Drawing.Size(800, 675);
            this.workspace.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 661);
            this.Controls.Add(this.workspace);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Territory Classic Map editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem корабльToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вражескийСтандартныйToolStripMenuItem;
        private System.Windows.Forms.Panel workspace;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem экспортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методыSPAWNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кодКартыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem барьерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стандартныйToolStripMenuItem;
    }
}

