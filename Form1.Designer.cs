namespace TerrariaNEA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gameTick = new System.Windows.Forms.Timer(components);
            screenPictureBox = new PictureBox();
            mapPictureBox = new PictureBox();
            time = new System.Windows.Forms.Timer(components);
            loadVisual = new Label();
            hotbarPictureBox = new PictureBox();
            inventoryPictureBox = new PictureBox();
            chestUIPictureBox = new PictureBox();
            mapBackground = new PictureBox();
            menuScreenPictureBox = new PictureBox();
            craftingPictureBox = new PictureBox();
            dialoguePictureBox = new PictureBox();
            shopPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)screenPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mapPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hotbarPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inventoryPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chestUIPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mapBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuScreenPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)craftingPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dialoguePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shopPictureBox).BeginInit();
            SuspendLayout();
            // 
            // gameTick
            // 
            gameTick.Tick += gameTick_Tick;
            // 
            // screenPictureBox
            // 
            screenPictureBox.Location = new Point(0, 0);
            screenPictureBox.Name = "screenPictureBox";
            screenPictureBox.Size = new Size(1602, 880);
            screenPictureBox.TabIndex = 1;
            screenPictureBox.TabStop = false;
            screenPictureBox.MouseDown += mouseClickDown;
            screenPictureBox.MouseUp += mouseClickUp;
            // 
            // mapPictureBox
            // 
            mapPictureBox.Location = new Point(0, 0);
            mapPictureBox.Name = "mapPictureBox";
            mapPictureBox.Size = new Size(5000, 1000);
            mapPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            mapPictureBox.TabIndex = 1;
            mapPictureBox.TabStop = false;
            mapPictureBox.Visible = false;
            mapPictureBox.MouseDown += mapPictureBox_MouseDown;
            mapPictureBox.MouseMove += mapPictureBox_MouseMove;
            mapPictureBox.MouseUp += mapPictureBox_MouseUp;
            mapPictureBox.MouseWheel += mapPictureBox_MouseScroll;
            // 
            // time
            // 
            time.Enabled = true;
            time.Interval = 1000;
            time.Tick += time_Tick;
            // 
            // loadVisual
            // 
            loadVisual.AutoSize = true;
            loadVisual.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            loadVisual.Location = new Point(12, 9);
            loadVisual.Name = "loadVisual";
            loadVisual.Size = new Size(90, 37);
            loadVisual.TabIndex = 6;
            loadVisual.Text = "label1";
            // 
            // hotbarPictureBox
            // 
            hotbarPictureBox.Location = new Point(20, 20);
            hotbarPictureBox.Name = "hotbarPictureBox";
            hotbarPictureBox.Size = new Size(600, 60);
            hotbarPictureBox.TabIndex = 7;
            hotbarPictureBox.TabStop = false;
            hotbarPictureBox.Click += hotbarClick;
            // 
            // inventoryPictureBox
            // 
            inventoryPictureBox.Location = new Point(20, 20);
            inventoryPictureBox.Name = "inventoryPictureBox";
            inventoryPictureBox.Size = new Size(600, 240);
            inventoryPictureBox.TabIndex = 8;
            inventoryPictureBox.TabStop = false;
            inventoryPictureBox.Visible = false;
            inventoryPictureBox.MouseDown += inventoryClickDown;
            inventoryPictureBox.MouseUp += inventoryClickUp;
            // 
            // chestUIPictureBox
            // 
            chestUIPictureBox.Location = new Point(20, 20);
            chestUIPictureBox.Name = "chestUIPictureBox";
            chestUIPictureBox.Size = new Size(600, 480);
            chestUIPictureBox.TabIndex = 9;
            chestUIPictureBox.TabStop = false;
            chestUIPictureBox.Visible = false;
            chestUIPictureBox.MouseDown += chestUIClickDown;
            chestUIPictureBox.MouseUp += chestUIClickUp;
            // 
            // mapBackground
            // 
            mapBackground.BackColor = Color.DimGray;
            mapBackground.Location = new Point(0, 0);
            mapBackground.Name = "mapBackground";
            mapBackground.Size = new Size(1602, 880);
            mapBackground.TabIndex = 10;
            mapBackground.TabStop = false;
            // 
            // menuScreenPictureBox
            // 
            menuScreenPictureBox.Location = new Point(0, 0);
            menuScreenPictureBox.Name = "menuScreenPictureBox";
            menuScreenPictureBox.Size = new Size(1602, 880);
            menuScreenPictureBox.TabIndex = 11;
            menuScreenPictureBox.TabStop = false;
            menuScreenPictureBox.MouseClick += menuScreenPictureBox_Click;
            // 
            // craftingPictureBox
            // 
            craftingPictureBox.Location = new Point(20, 560);
            craftingPictureBox.Name = "craftingPictureBox";
            craftingPictureBox.Size = new Size(60, 300);
            craftingPictureBox.TabIndex = 12;
            craftingPictureBox.TabStop = false;
            craftingPictureBox.Visible = false;
            craftingPictureBox.MouseDown += craftingPictureBox_MouseDown;
            // 
            // dialoguePictureBox
            // 
            dialoguePictureBox.BackColor = Color.Red;
            dialoguePictureBox.Location = new Point(550, 350);
            dialoguePictureBox.Name = "dialoguePictureBox";
            dialoguePictureBox.Size = new Size(500, 200);
            dialoguePictureBox.TabIndex = 13;
            dialoguePictureBox.TabStop = false;
            dialoguePictureBox.Visible = false;
            dialoguePictureBox.MouseDown += dialoguePictureBox_MouseDown;
            // 
            // shopPictureBox
            // 
            shopPictureBox.Location = new Point(20, 20);
            shopPictureBox.Name = "shopPictureBox";
            shopPictureBox.Size = new Size(600, 480);
            shopPictureBox.TabIndex = 14;
            shopPictureBox.TabStop = false;
            shopPictureBox.Visible = false;
            shopPictureBox.MouseDown += shopPictureBox_MouseDown;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1444, 881);
            Controls.Add(shopPictureBox);
            Controls.Add(menuScreenPictureBox);
            Controls.Add(mapBackground);
            Controls.Add(chestUIPictureBox);
            Controls.Add(inventoryPictureBox);
            Controls.Add(hotbarPictureBox);
            Controls.Add(loadVisual);
            Controls.Add(mapPictureBox);
            Controls.Add(screenPictureBox);
            Controls.Add(craftingPictureBox);
            Controls.Add(dialoguePictureBox);
            Name = "Form1";
            Text = "Terraria for the sigmas";
            Load += gameLoad;
            KeyDown += keyPressDown;
            KeyUp += keyPressUp;
            ((System.ComponentModel.ISupportInitialize)screenPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)mapPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)hotbarPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)inventoryPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)chestUIPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)mapBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuScreenPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)craftingPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dialoguePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)shopPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer gameTick;
        private PictureBox mapPictureBox;
        private PictureBox screenPictureBox;
        private System.Windows.Forms.Timer time;
        private Label loadVisual;
        private PictureBox hotbarPictureBox;
        private PictureBox inventoryPictureBox;
        private PictureBox chestUIPictureBox;
        private PictureBox mapBackground;
        private PictureBox dialoguePictureBox;
        private PictureBox menuScreenPictureBox;
        private PictureBox craftingPictureBox;
        private PictureBox shopPictureBox;
    }
}