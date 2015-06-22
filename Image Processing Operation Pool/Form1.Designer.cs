namespace Image_Processing_Operation_Pool
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
            iTalk.ControlRenderer controlRenderer1 = new iTalk.ControlRenderer();
            iTalk.MSColorTable msColorTable1 = new iTalk.MSColorTable();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbFuncToolBox = new System.Windows.Forms.ListBox();
            this.lbScript = new System.Windows.Forms.ListBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.iTalk_Label2 = new iTalk.iTalk_Label();
            this.iTalk_Label1 = new iTalk.iTalk_Label();
            this.iTalk_Button_Create = new iTalk.iTalk_Button_2();
            this.iTalk_Icon_Info1 = new iTalk.iTalk_Icon_Info();
            this.iTalk_Button_Up = new iTalk.iTalk_Button_1();
            this.iTalk_Button_Down = new iTalk.iTalk_Button_1();
            this.iTalk_Button_Remove = new iTalk.iTalk_Button_1();
            this.iTalk_Buttton_AddScript = new iTalk.iTalk_Button_1();
            this.iTalk_MenuStrip1 = new iTalk.iTalk_MenuStrip();
            this.chooseJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadJsonFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.iTalk_Button_SortA2Z = new iTalk.iTalk_Button_1();
            this.iTalk_Label3 = new iTalk.iTalk_Label();
            this.createJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.iTalk_MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbFuncToolBox
            // 
            this.lbFuncToolBox.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbFuncToolBox.FormattingEnabled = true;
            this.lbFuncToolBox.HorizontalScrollbar = true;
            this.lbFuncToolBox.ItemHeight = 18;
            this.lbFuncToolBox.Location = new System.Drawing.Point(20, 126);
            this.lbFuncToolBox.Name = "lbFuncToolBox";
            this.lbFuncToolBox.ScrollAlwaysVisible = true;
            this.lbFuncToolBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFuncToolBox.Size = new System.Drawing.Size(173, 274);
            this.lbFuncToolBox.TabIndex = 5;
            this.lbFuncToolBox.SelectedIndexChanged += new System.EventHandler(this.lbFuncToolBox_SelectedIndexChanged);
            // 
            // lbScript
            // 
            this.lbScript.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbScript.FormattingEnabled = true;
            this.lbScript.ItemHeight = 18;
            this.lbScript.Location = new System.Drawing.Point(299, 126);
            this.lbScript.Name = "lbScript";
            this.lbScript.ScrollAlwaysVisible = true;
            this.lbScript.Size = new System.Drawing.Size(189, 274);
            this.lbScript.TabIndex = 8;
            this.lbScript.SelectedValueChanged += new System.EventHandler(this.lbScript_SelectedValueChanged);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // iTalk_Label2
            // 
            this.iTalk_Label2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.iTalk_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label2.Location = new System.Drawing.Point(15, 100);
            this.iTalk_Label2.Name = "iTalk_Label2";
            this.iTalk_Label2.Size = new System.Drawing.Size(141, 23);
            this.iTalk_Label2.TabIndex = 25;
            this.iTalk_Label2.Text = "Functions Box";
            // 
            // iTalk_Label1
            // 
            this.iTalk_Label1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.iTalk_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label1.Location = new System.Drawing.Point(294, 98);
            this.iTalk_Label1.Name = "iTalk_Label1";
            this.iTalk_Label1.Size = new System.Drawing.Size(64, 26);
            this.iTalk_Label1.TabIndex = 24;
            this.iTalk_Label1.Text = "Script";
            // 
            // iTalk_Button_Create
            // 
            this.iTalk_Button_Create.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_Create.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.iTalk_Button_Create.ForeColor = System.Drawing.Color.White;
            this.iTalk_Button_Create.Image = null;
            this.iTalk_Button_Create.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_Create.Location = new System.Drawing.Point(772, 390);
            this.iTalk_Button_Create.Name = "iTalk_Button_Create";
            this.iTalk_Button_Create.Size = new System.Drawing.Size(72, 33);
            this.iTalk_Button_Create.TabIndex = 23;
            this.iTalk_Button_Create.Text = "Create";
            this.iTalk_Button_Create.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Button_Create.Click += new System.EventHandler(this.iTalk_Button_Create_Click);
            // 
            // iTalk_Icon_Info1
            // 
            this.iTalk_Icon_Info1.BackColor = System.Drawing.Color.White;
            this.iTalk_Icon_Info1.ForeColor = System.Drawing.Color.DimGray;
            this.iTalk_Icon_Info1.Location = new System.Drawing.Point(767, 87);
            this.iTalk_Icon_Info1.Name = "iTalk_Icon_Info1";
            this.iTalk_Icon_Info1.Size = new System.Drawing.Size(33, 39);
            this.iTalk_Icon_Info1.TabIndex = 22;
            this.iTalk_Icon_Info1.Text = "iTalk_Icon_Info1";
            // 
            // iTalk_Button_Up
            // 
            this.iTalk_Button_Up.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_Up.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.iTalk_Button_Up.Image = null;
            this.iTalk_Button_Up.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_Up.Location = new System.Drawing.Point(326, 406);
            this.iTalk_Button_Up.Name = "iTalk_Button_Up";
            this.iTalk_Button_Up.Size = new System.Drawing.Size(61, 27);
            this.iTalk_Button_Up.TabIndex = 20;
            this.iTalk_Button_Up.Text = "Up";
            this.iTalk_Button_Up.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Button_Up.Click += new System.EventHandler(this.iTalk_Button_Up_Click);
            // 
            // iTalk_Button_Down
            // 
            this.iTalk_Button_Down.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_Down.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.iTalk_Button_Down.Image = null;
            this.iTalk_Button_Down.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_Down.Location = new System.Drawing.Point(393, 406);
            this.iTalk_Button_Down.Name = "iTalk_Button_Down";
            this.iTalk_Button_Down.Size = new System.Drawing.Size(61, 27);
            this.iTalk_Button_Down.TabIndex = 19;
            this.iTalk_Button_Down.Text = "Down";
            this.iTalk_Button_Down.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Button_Down.Click += new System.EventHandler(this.iTalk_Button_Down_Click);
            // 
            // iTalk_Button_Remove
            // 
            this.iTalk_Button_Remove.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_Remove.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.iTalk_Button_Remove.Image = null;
            this.iTalk_Button_Remove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_Remove.Location = new System.Drawing.Point(209, 296);
            this.iTalk_Button_Remove.Name = "iTalk_Button_Remove";
            this.iTalk_Button_Remove.Size = new System.Drawing.Size(76, 32);
            this.iTalk_Button_Remove.TabIndex = 17;
            this.iTalk_Button_Remove.Text = "Remove";
            this.iTalk_Button_Remove.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Button_Remove.Click += new System.EventHandler(this.iTalk_Button_Remove_Click);
            // 
            // iTalk_Buttton_AddScript
            // 
            this.iTalk_Buttton_AddScript.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Buttton_AddScript.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.iTalk_Buttton_AddScript.Image = null;
            this.iTalk_Buttton_AddScript.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Buttton_AddScript.Location = new System.Drawing.Point(209, 238);
            this.iTalk_Buttton_AddScript.Name = "iTalk_Buttton_AddScript";
            this.iTalk_Buttton_AddScript.Size = new System.Drawing.Size(76, 29);
            this.iTalk_Buttton_AddScript.TabIndex = 16;
            this.iTalk_Buttton_AddScript.Text = ">>";
            this.iTalk_Buttton_AddScript.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Buttton_AddScript.Click += new System.EventHandler(this.iTalk_Buttton_AddScript_Click);
            // 
            // iTalk_MenuStrip1
            // 
            this.iTalk_MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createJsonToolStripMenuItem,
            this.chooseJsonToolStripMenuItem,
            this.chooseImageToolStripMenuItem,
            this.loadJsonFileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.iTalk_MenuStrip1.Location = new System.Drawing.Point(20, 60);
            this.iTalk_MenuStrip1.Name = "iTalk_MenuStrip1";
            controlRenderer1.ColorTable = msColorTable1;
            controlRenderer1.RoundedEdges = true;
            this.iTalk_MenuStrip1.Renderer = controlRenderer1;
            this.iTalk_MenuStrip1.Size = new System.Drawing.Size(824, 24);
            this.iTalk_MenuStrip1.TabIndex = 27;
            this.iTalk_MenuStrip1.Text = "iTalk_MenuStrip1";
            // 
            // chooseJsonToolStripMenuItem
            // 
            this.chooseJsonToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.chooseJsonToolStripMenuItem.Name = "chooseJsonToolStripMenuItem";
            this.chooseJsonToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.chooseJsonToolStripMenuItem.Text = "Load Json";
            this.chooseJsonToolStripMenuItem.Click += new System.EventHandler(this.LoadJsonToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // chooseImageToolStripMenuItem
            // 
            this.chooseImageToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.chooseImageToolStripMenuItem.Name = "chooseImageToolStripMenuItem";
            this.chooseImageToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.chooseImageToolStripMenuItem.Text = "Choose Image";
            this.chooseImageToolStripMenuItem.Click += new System.EventHandler(this.chooseImageToolStripMenuItem_Click);
            // 
            // loadJsonFileToolStripMenuItem
            // 
            this.loadJsonFileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.loadJsonFileToolStripMenuItem.Name = "loadJsonFileToolStripMenuItem";
            this.loadJsonFileToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.loadJsonFileToolStripMenuItem.Text = "Load Script";
            this.loadJsonFileToolStripMenuItem.Click += new System.EventHandler(this.LoadScriptToolStripMenuItem_Click);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Location = new System.Drawing.Point(497, 126);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(264, 274);
            this.ControlsPanel.TabIndex = 28;
            // 
            // iTalk_Button_SortA2Z
            // 
            this.iTalk_Button_SortA2Z.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_SortA2Z.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.iTalk_Button_SortA2Z.Image = global::Image_Processing_Operation_Pool.Properties.Resources._1434561580_sort_ascend;
            this.iTalk_Button_SortA2Z.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_SortA2Z.Location = new System.Drawing.Point(20, 406);
            this.iTalk_Button_SortA2Z.Name = "iTalk_Button_SortA2Z";
            this.iTalk_Button_SortA2Z.Size = new System.Drawing.Size(36, 37);
            this.iTalk_Button_SortA2Z.TabIndex = 29;
            this.iTalk_Button_SortA2Z.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Button_SortA2Z.Click += new System.EventHandler(this.iTalk_Button_SortA2Z_Click);
            // 
            // iTalk_Label3
            // 
            this.iTalk_Label3.AutoSize = true;
            this.iTalk_Label3.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.iTalk_Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label3.Location = new System.Drawing.Point(492, 98);
            this.iTalk_Label3.Name = "iTalk_Label3";
            this.iTalk_Label3.Size = new System.Drawing.Size(107, 25);
            this.iTalk_Label3.TabIndex = 30;
            this.iTalk_Label3.Text = "Parameters";
            // 
            // createJsonToolStripMenuItem
            // 
            this.createJsonToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.createJsonToolStripMenuItem.Name = "createJsonToolStripMenuItem";
            this.createJsonToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.createJsonToolStripMenuItem.Text = "Create Json";
            this.createJsonToolStripMenuItem.Click += new System.EventHandler(this.createJsonToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(864, 492);
            this.Controls.Add(this.iTalk_Label3);
            this.Controls.Add(this.iTalk_Button_SortA2Z);
            this.Controls.Add(this.ControlsPanel);
            this.Controls.Add(this.iTalk_Label2);
            this.Controls.Add(this.iTalk_Label1);
            this.Controls.Add(this.iTalk_Button_Create);
            this.Controls.Add(this.iTalk_Icon_Info1);
            this.Controls.Add(this.iTalk_Button_Up);
            this.Controls.Add(this.iTalk_Button_Down);
            this.Controls.Add(this.iTalk_Button_Remove);
            this.Controls.Add(this.iTalk_Buttton_AddScript);
            this.Controls.Add(this.lbScript);
            this.Controls.Add(this.lbFuncToolBox);
            this.Controls.Add(this.iTalk_MenuStrip1);
            this.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MainMenuStrip = this.iTalk_MenuStrip1;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "Form1";
            this.Text = "Operation Pool";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.iTalk_MenuStrip1.ResumeLayout(false);
            this.iTalk_MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox lbFuncToolBox;
        private System.Windows.Forms.ListBox lbScript;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private iTalk.iTalk_Button_1 iTalk_Buttton_AddScript;
        private iTalk.iTalk_Button_1 iTalk_Button_Remove;
        private iTalk.iTalk_Button_1 iTalk_Button_Down;
        private iTalk.iTalk_Button_1 iTalk_Button_Up;
        private iTalk.iTalk_Icon_Info iTalk_Icon_Info1;
        private iTalk.iTalk_Button_2 iTalk_Button_Create;
        private iTalk.iTalk_Label iTalk_Label1;
        private iTalk.iTalk_Label iTalk_Label2;
        private iTalk.iTalk_MenuStrip iTalk_MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chooseJsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseImageToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadJsonFileToolStripMenuItem;
        private System.Windows.Forms.Panel ControlsPanel;
        private iTalk.iTalk_Button_1 iTalk_Button_SortA2Z;
        private iTalk.iTalk_Label iTalk_Label3;
        private System.Windows.Forms.ToolStripMenuItem createJsonToolStripMenuItem;
    }
}

