namespace s3m
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.importOBJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportOBJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xYZAxisesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groundGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solidViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wireViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.extractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightEffectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutS3DMakerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3D = new System.Windows.Forms.Panel();
            this.panelTools = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pBoxRotation = new System.Windows.Forms.PictureBox();
            this.pBoxZoomOut = new System.Windows.Forms.PictureBox();
            this.pBoxZoomIn = new System.Windows.Forms.PictureBox();
            this.pBoxTexture = new System.Windows.Forms.PictureBox();
            this.pBoxView = new System.Windows.Forms.PictureBox();
            this.pBoxLight = new System.Windows.Forms.PictureBox();
            this.pBoxViewMode = new System.Windows.Forms.PictureBox();
            this.pBoxBottom = new System.Windows.Forms.PictureBox();
            this.pBoxTop = new System.Windows.Forms.PictureBox();
            this.pBoxRight = new System.Windows.Forms.PictureBox();
            this.pBoxLeft = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.pBoxFront = new System.Windows.Forms.PictureBox();
            this.pBoxDefault = new System.Windows.Forms.PictureBox();
            this.pBoxUndo = new System.Windows.Forms.PictureBox();
            this.pBoxRedo = new System.Windows.Forms.PictureBox();
            this.pBoxSave = new System.Windows.Forms.PictureBox();
            this.pBoxOpen = new System.Windows.Forms.PictureBox();
            this.pBoxNew = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabProperty = new System.Windows.Forms.TabControl();
            this.tabSpace = new System.Windows.Forms.TabPage();
            this.propertyGridSpace = new System.Windows.Forms.PropertyGrid();
            this.tabObject = new System.Windows.Forms.TabPage();
            this.propertyGridObject = new System.Windows.Forms.PropertyGrid();
            this.treeView = new System.Windows.Forms.TreeView();
            this.openFileDialogOBJ = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogOBJ = new System.Windows.Forms.SaveFileDialog();
            this.ViewTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxZoomOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxZoomIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxViewMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxUndo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRedo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxNew)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabProperty.SuspendLayout();
            this.tabSpace.SuspendLayout();
            this.tabObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.textureToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.importOBJToolStripMenuItem,
            this.exportOBJToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileToolStripMenuItem.Text = "File(&F)";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.newToolStripMenuItem.Text = "&New Scene";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // importOBJToolStripMenuItem
            // 
            this.importOBJToolStripMenuItem.Name = "importOBJToolStripMenuItem";
            this.importOBJToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importOBJToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.importOBJToolStripMenuItem.Text = "&Import OBJ";
            this.importOBJToolStripMenuItem.Click += new System.EventHandler(this.importOBJToolStripMenuItem_Click);
            // 
            // exportOBJToolStripMenuItem
            // 
            this.exportOBJToolStripMenuItem.Name = "exportOBJToolStripMenuItem";
            this.exportOBJToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportOBJToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exportOBJToolStripMenuItem.Text = "&Export OBJ";
            this.exportOBJToolStripMenuItem.Click += new System.EventHandler(this.exportOBJToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(174, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.toolStripSeparator4,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.editToolStripMenuItem.Text = "Edit(&E)";
            // 
            // doToolStripMenuItem
            // 
            this.doToolStripMenuItem.Enabled = false;
            this.doToolStripMenuItem.Name = "doToolStripMenuItem";
            this.doToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.doToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.doToolStripMenuItem.Text = "&Do";
            this.doToolStripMenuItem.Click += new System.EventHandler(this.doToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xYZAxisesToolStripMenuItem,
            this.groundGridToolStripMenuItem,
            this.viewModeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.viewToolStripMenuItem.Text = "View(&V)";
            // 
            // xYZAxisesToolStripMenuItem
            // 
            this.xYZAxisesToolStripMenuItem.Checked = true;
            this.xYZAxisesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xYZAxisesToolStripMenuItem.Name = "xYZAxisesToolStripMenuItem";
            this.xYZAxisesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.xYZAxisesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.xYZAxisesToolStripMenuItem.Text = "&X Y Z Axises";
            this.xYZAxisesToolStripMenuItem.Click += new System.EventHandler(this.xYZAxisesToolStripMenuItem_Click);
            // 
            // groundGridToolStripMenuItem
            // 
            this.groundGridToolStripMenuItem.Checked = true;
            this.groundGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.groundGridToolStripMenuItem.Name = "groundGridToolStripMenuItem";
            this.groundGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.groundGridToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.groundGridToolStripMenuItem.Text = "&Ground Grid";
            this.groundGridToolStripMenuItem.Click += new System.EventHandler(this.groundGridToolStripMenuItem_Click);
            // 
            // viewModeToolStripMenuItem
            // 
            this.viewModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solidViewToolStripMenuItem,
            this.wireViewToolStripMenuItem});
            this.viewModeToolStripMenuItem.Name = "viewModeToolStripMenuItem";
            this.viewModeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.viewModeToolStripMenuItem.Text = "&View Mode";
            // 
            // solidViewToolStripMenuItem
            // 
            this.solidViewToolStripMenuItem.Checked = true;
            this.solidViewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.solidViewToolStripMenuItem.Name = "solidViewToolStripMenuItem";
            this.solidViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.solidViewToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.solidViewToolStripMenuItem.Text = "&Solid View";
            this.solidViewToolStripMenuItem.Click += new System.EventHandler(this.solidViewToolStripMenuItem_Click);
            // 
            // wireViewToolStripMenuItem
            // 
            this.wireViewToolStripMenuItem.Name = "wireViewToolStripMenuItem";
            this.wireViewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.wireViewToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.wireViewToolStripMenuItem.Text = "&Wire View";
            this.wireViewToolStripMenuItem.Click += new System.EventHandler(this.wireViewToolStripMenuItem_Click);
            // 
            // textureToolStripMenuItem
            // 
            this.textureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.extractionToolStripMenuItem});
            this.textureToolStripMenuItem.Name = "textureToolStripMenuItem";
            this.textureToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.textureToolStripMenuItem.Text = "Texture(&T)";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem1.Text = "&Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // extractionToolStripMenuItem
            // 
            this.extractionToolStripMenuItem.Name = "extractionToolStripMenuItem";
            this.extractionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.extractionToolStripMenuItem.Text = "&Extraction";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.lightEffectToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.settingToolStripMenuItem.Text = "Option(&O)";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.optionToolStripMenuItem.Text = "&View Assistance";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // lightEffectToolStripMenuItem
            // 
            this.lightEffectToolStripMenuItem.Name = "lightEffectToolStripMenuItem";
            this.lightEffectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.lightEffectToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.lightEffectToolStripMenuItem.Text = "&Light Effect";
            this.lightEffectToolStripMenuItem.Click += new System.EventHandler(this.lightEffectToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutS3DMakerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.helpToolStripMenuItem.Text = "Help(&H)";
            // 
            // aboutS3DMakerToolStripMenuItem
            // 
            this.aboutS3DMakerToolStripMenuItem.Name = "aboutS3DMakerToolStripMenuItem";
            this.aboutS3DMakerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.aboutS3DMakerToolStripMenuItem.Text = "&About S3DMaker";
            this.aboutS3DMakerToolStripMenuItem.Click += new System.EventHandler(this.aboutS3DMakerToolStripMenuItem_Click);
            // 
            // panel3D
            // 
            this.panel3D.BackColor = System.Drawing.Color.Black;
            this.panel3D.Location = new System.Drawing.Point(0, 0);
            this.panel3D.Name = "panel3D";
            this.panel3D.Size = new System.Drawing.Size(500, 501);
            this.panel3D.TabIndex = 0;
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTools.Location = new System.Drawing.Point(0, 0);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(65, 501);
            this.panelTools.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pBoxRotation);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxZoomOut);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxZoomIn);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxTexture);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxView);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxLight);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxViewMode);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxBottom);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxTop);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxRight);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxLeft);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxBack);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxFront);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxDefault);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxUndo);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxRedo);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxSave);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxOpen);
            this.splitContainer1.Panel1.Controls.Add(this.pBoxNew);
            this.splitContainer1.Panel1.MouseEnter += new System.EventHandler(this.splitContainer1_Panel1_MouseEnter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 562);
            this.splitContainer1.SplitterDistance = 57;
            this.splitContainer1.TabIndex = 24;
            this.splitContainer1.TabStop = false;
            // 
            // pBoxRotation
            // 
            this.pBoxRotation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxRotation.Image = global::s3m.Properties.Resources.allRotation;
            this.pBoxRotation.Location = new System.Drawing.Point(194, 25);
            this.pBoxRotation.Name = "pBoxRotation";
            this.pBoxRotation.Size = new System.Drawing.Size(30, 30);
            this.pBoxRotation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxRotation.TabIndex = 16;
            this.pBoxRotation.TabStop = false;
            this.pBoxRotation.MouseLeave += new System.EventHandler(this.pBoxRotation_MouseLeave);
            this.pBoxRotation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxRotation_MouseDown);
            this.pBoxRotation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxRotation_MouseUp);
            this.pBoxRotation.MouseEnter += new System.EventHandler(this.pBoxRotation_MouseEnter);
            // 
            // pBoxZoomOut
            // 
            this.pBoxZoomOut.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxZoomOut.Image = global::s3m.Properties.Resources.zoomout;
            this.pBoxZoomOut.Location = new System.Drawing.Point(450, 25);
            this.pBoxZoomOut.Name = "pBoxZoomOut";
            this.pBoxZoomOut.Size = new System.Drawing.Size(30, 30);
            this.pBoxZoomOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxZoomOut.TabIndex = 15;
            this.pBoxZoomOut.TabStop = false;
            this.pBoxZoomOut.MouseLeave += new System.EventHandler(this.pBoxZoomOut_MouseLeave);
            this.pBoxZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxZoomOut_MouseDown);
            this.pBoxZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxZoomOut_MouseUp);
            this.pBoxZoomOut.MouseEnter += new System.EventHandler(this.pBoxZoomOut_MouseEnter);
            // 
            // pBoxZoomIn
            // 
            this.pBoxZoomIn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxZoomIn.Image = global::s3m.Properties.Resources.zoomin;
            this.pBoxZoomIn.Location = new System.Drawing.Point(418, 25);
            this.pBoxZoomIn.Name = "pBoxZoomIn";
            this.pBoxZoomIn.Size = new System.Drawing.Size(30, 30);
            this.pBoxZoomIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxZoomIn.TabIndex = 14;
            this.pBoxZoomIn.TabStop = false;
            this.pBoxZoomIn.MouseLeave += new System.EventHandler(this.pBoxZoomIn_MouseLeave);
            this.pBoxZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxZoomIn_MouseDown);
            this.pBoxZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxZoomIn_MouseUp);
            this.pBoxZoomIn.MouseEnter += new System.EventHandler(this.pBoxZoomIn_MouseEnter);
            // 
            // pBoxTexture
            // 
            this.pBoxTexture.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxTexture.Image = global::s3m.Properties.Resources.image;
            this.pBoxTexture.Location = new System.Drawing.Point(577, 25);
            this.pBoxTexture.Name = "pBoxTexture";
            this.pBoxTexture.Size = new System.Drawing.Size(30, 30);
            this.pBoxTexture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxTexture.TabIndex = 13;
            this.pBoxTexture.TabStop = false;
            this.pBoxTexture.MouseLeave += new System.EventHandler(this.pBoxTexture_MouseLeave);
            this.pBoxTexture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxTexture_MouseDown);
            this.pBoxTexture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxTexture_MouseUp);
            this.pBoxTexture.MouseEnter += new System.EventHandler(this.pBoxTexture_MouseEnter);
            // 
            // pBoxView
            // 
            this.pBoxView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBoxView.Image = global::s3m.Properties.Resources.grid;
            this.pBoxView.Location = new System.Drawing.Point(546, 25);
            this.pBoxView.Name = "pBoxView";
            this.pBoxView.Size = new System.Drawing.Size(30, 30);
            this.pBoxView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxView.TabIndex = 12;
            this.pBoxView.TabStop = false;
            this.pBoxView.MouseLeave += new System.EventHandler(this.pBoxView_MouseLeave);
            this.pBoxView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxView_MouseDown);
            this.pBoxView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxView_MouseUp);
            this.pBoxView.MouseEnter += new System.EventHandler(this.pBoxView_MouseEnter);
            // 
            // pBoxLight
            // 
            this.pBoxLight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxLight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBoxLight.Image = global::s3m.Properties.Resources.light;
            this.pBoxLight.Location = new System.Drawing.Point(514, 25);
            this.pBoxLight.Name = "pBoxLight";
            this.pBoxLight.Size = new System.Drawing.Size(30, 30);
            this.pBoxLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxLight.TabIndex = 11;
            this.pBoxLight.TabStop = false;
            this.pBoxLight.MouseLeave += new System.EventHandler(this.pBoxLight_MouseLeave);
            this.pBoxLight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxLight_MouseDown);
            this.pBoxLight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxLight_MouseUp);
            this.pBoxLight.MouseEnter += new System.EventHandler(this.pBoxLight_MouseEnter);
            // 
            // pBoxViewMode
            // 
            this.pBoxViewMode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxViewMode.Image = global::s3m.Properties.Resources.solid;
            this.pBoxViewMode.Location = new System.Drawing.Point(482, 25);
            this.pBoxViewMode.Name = "pBoxViewMode";
            this.pBoxViewMode.Size = new System.Drawing.Size(30, 30);
            this.pBoxViewMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxViewMode.TabIndex = 10;
            this.pBoxViewMode.TabStop = false;
            this.pBoxViewMode.MouseLeave += new System.EventHandler(this.pBoxViewMode_MouseLeave);
            this.pBoxViewMode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxViewMode_MouseDown);
            this.pBoxViewMode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxViewMode_MouseUp);
            this.pBoxViewMode.MouseEnter += new System.EventHandler(this.pBoxViewMode_MouseEnter);
            // 
            // pBoxBottom
            // 
            this.pBoxBottom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxBottom.Image = global::s3m.Properties.Resources._6;
            this.pBoxBottom.Location = new System.Drawing.Point(386, 25);
            this.pBoxBottom.Name = "pBoxBottom";
            this.pBoxBottom.Size = new System.Drawing.Size(30, 30);
            this.pBoxBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxBottom.TabIndex = 9;
            this.pBoxBottom.TabStop = false;
            this.pBoxBottom.MouseLeave += new System.EventHandler(this.pBoxBottom_MouseLeave);
            this.pBoxBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxBottom_MouseDown);
            this.pBoxBottom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxBottom_MouseUp);
            this.pBoxBottom.MouseEnter += new System.EventHandler(this.pBoxBottom_MouseEnter);
            // 
            // pBoxTop
            // 
            this.pBoxTop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxTop.Image = global::s3m.Properties.Resources._5;
            this.pBoxTop.Location = new System.Drawing.Point(354, 25);
            this.pBoxTop.Name = "pBoxTop";
            this.pBoxTop.Size = new System.Drawing.Size(30, 30);
            this.pBoxTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxTop.TabIndex = 8;
            this.pBoxTop.TabStop = false;
            this.pBoxTop.MouseLeave += new System.EventHandler(this.pBoxTop_MouseLeave);
            this.pBoxTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxTop_MouseDown);
            this.pBoxTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxTop_MouseUp);
            this.pBoxTop.MouseEnter += new System.EventHandler(this.pBoxTop_MouseEnter);
            // 
            // pBoxRight
            // 
            this.pBoxRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxRight.Image = global::s3m.Properties.Resources._4;
            this.pBoxRight.Location = new System.Drawing.Point(322, 25);
            this.pBoxRight.Name = "pBoxRight";
            this.pBoxRight.Size = new System.Drawing.Size(30, 30);
            this.pBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxRight.TabIndex = 7;
            this.pBoxRight.TabStop = false;
            this.pBoxRight.MouseLeave += new System.EventHandler(this.pBoxRight_MouseLeave);
            this.pBoxRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxRight_MouseDown);
            this.pBoxRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxRight_MouseUp);
            this.pBoxRight.MouseEnter += new System.EventHandler(this.pBoxRight_MouseEnter);
            // 
            // pBoxLeft
            // 
            this.pBoxLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxLeft.Image = global::s3m.Properties.Resources._3;
            this.pBoxLeft.Location = new System.Drawing.Point(290, 25);
            this.pBoxLeft.Name = "pBoxLeft";
            this.pBoxLeft.Size = new System.Drawing.Size(30, 30);
            this.pBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxLeft.TabIndex = 6;
            this.pBoxLeft.TabStop = false;
            this.pBoxLeft.MouseLeave += new System.EventHandler(this.pBoxLeft_MouseLeave);
            this.pBoxLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxLeft_MouseDown);
            this.pBoxLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxLeft_MouseUp);
            this.pBoxLeft.MouseEnter += new System.EventHandler(this.pBoxLeft_MouseEnter);
            // 
            // pBoxBack
            // 
            this.pBoxBack.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxBack.Image = global::s3m.Properties.Resources._2;
            this.pBoxBack.Location = new System.Drawing.Point(258, 25);
            this.pBoxBack.Name = "pBoxBack";
            this.pBoxBack.Size = new System.Drawing.Size(30, 30);
            this.pBoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxBack.TabIndex = 5;
            this.pBoxBack.TabStop = false;
            this.pBoxBack.MouseLeave += new System.EventHandler(this.pBoxBack_MouseLeave);
            this.pBoxBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxBack_MouseDown);
            this.pBoxBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxBack_MouseUp);
            this.pBoxBack.MouseEnter += new System.EventHandler(this.pBoxBack_MouseEnter);
            // 
            // pBoxFront
            // 
            this.pBoxFront.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxFront.Image = global::s3m.Properties.Resources._1;
            this.pBoxFront.Location = new System.Drawing.Point(226, 25);
            this.pBoxFront.Name = "pBoxFront";
            this.pBoxFront.Size = new System.Drawing.Size(30, 30);
            this.pBoxFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxFront.TabIndex = 4;
            this.pBoxFront.TabStop = false;
            this.pBoxFront.MouseLeave += new System.EventHandler(this.pBoxFront_MouseLeave);
            this.pBoxFront.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxFront_MouseDown);
            this.pBoxFront.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxFront_MouseUp);
            this.pBoxFront.MouseEnter += new System.EventHandler(this.pBoxFront_MouseEnter);
            // 
            // pBoxDefault
            // 
            this.pBoxDefault.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxDefault.Image = global::s3m.Properties.Resources._default;
            this.pBoxDefault.Location = new System.Drawing.Point(98, 25);
            this.pBoxDefault.Name = "pBoxDefault";
            this.pBoxDefault.Size = new System.Drawing.Size(30, 30);
            this.pBoxDefault.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxDefault.TabIndex = 3;
            this.pBoxDefault.TabStop = false;
            this.pBoxDefault.MouseLeave += new System.EventHandler(this.pBoxDefault_MouseLeave);
            this.pBoxDefault.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxDefault_MouseDown);
            this.pBoxDefault.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxDefault_MouseUp);
            this.pBoxDefault.MouseEnter += new System.EventHandler(this.pBoxDefault_MouseEnter);
            // 
            // pBoxUndo
            // 
            this.pBoxUndo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxUndo.Image = global::s3m.Properties.Resources.undo;
            this.pBoxUndo.Location = new System.Drawing.Point(130, 25);
            this.pBoxUndo.Name = "pBoxUndo";
            this.pBoxUndo.Size = new System.Drawing.Size(30, 30);
            this.pBoxUndo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxUndo.TabIndex = 2;
            this.pBoxUndo.TabStop = false;
            this.pBoxUndo.MouseLeave += new System.EventHandler(this.pBoxUndo_MouseLeave);
            this.pBoxUndo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxUndo_MouseDown);
            this.pBoxUndo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxUndo_MouseUp);
            this.pBoxUndo.MouseEnter += new System.EventHandler(this.pBoxUndo_MouseEnter);
            // 
            // pBoxRedo
            // 
            this.pBoxRedo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxRedo.BackColor = System.Drawing.SystemColors.Control;
            this.pBoxRedo.Image = global::s3m.Properties.Resources.redo;
            this.pBoxRedo.Location = new System.Drawing.Point(162, 25);
            this.pBoxRedo.Name = "pBoxRedo";
            this.pBoxRedo.Size = new System.Drawing.Size(30, 30);
            this.pBoxRedo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxRedo.TabIndex = 1;
            this.pBoxRedo.TabStop = false;
            this.pBoxRedo.MouseLeave += new System.EventHandler(this.pBoxRedo_MouseLeave);
            this.pBoxRedo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxRedo_MouseDown);
            this.pBoxRedo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxRedo_MouseUp);
            this.pBoxRedo.MouseEnter += new System.EventHandler(this.pBoxRedo_MouseEnter);
            // 
            // pBoxSave
            // 
            this.pBoxSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxSave.Image = global::s3m.Properties.Resources.save;
            this.pBoxSave.Location = new System.Drawing.Point(66, 25);
            this.pBoxSave.Name = "pBoxSave";
            this.pBoxSave.Size = new System.Drawing.Size(30, 30);
            this.pBoxSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxSave.TabIndex = 1;
            this.pBoxSave.TabStop = false;
            this.pBoxSave.MouseLeave += new System.EventHandler(this.pBoxSave_MouseLeave);
            this.pBoxSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxSave_MouseDown);
            this.pBoxSave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxSave_MouseUp);
            this.pBoxSave.MouseEnter += new System.EventHandler(this.pBoxSave_MouseEnter);
            // 
            // pBoxOpen
            // 
            this.pBoxOpen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxOpen.Image = global::s3m.Properties.Resources.open;
            this.pBoxOpen.Location = new System.Drawing.Point(34, 25);
            this.pBoxOpen.Name = "pBoxOpen";
            this.pBoxOpen.Size = new System.Drawing.Size(30, 30);
            this.pBoxOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxOpen.TabIndex = 1;
            this.pBoxOpen.TabStop = false;
            this.pBoxOpen.MouseLeave += new System.EventHandler(this.pBoxOpen_MouseLeave);
            this.pBoxOpen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxOpen_MouseDown);
            this.pBoxOpen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxOpen_MouseUp);
            this.pBoxOpen.MouseEnter += new System.EventHandler(this.pBoxOpen_MouseEnter);
            // 
            // pBoxNew
            // 
            this.pBoxNew.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pBoxNew.Image = global::s3m.Properties.Resources._new;
            this.pBoxNew.Location = new System.Drawing.Point(2, 25);
            this.pBoxNew.Name = "pBoxNew";
            this.pBoxNew.Size = new System.Drawing.Size(30, 30);
            this.pBoxNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxNew.TabIndex = 1;
            this.pBoxNew.TabStop = false;
            this.pBoxNew.MouseLeave += new System.EventHandler(this.pBoxNew_MouseLeave);
            this.pBoxNew.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxNew_MouseDown);
            this.pBoxNew.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxNew_MouseUp);
            this.pBoxNew.MouseEnter += new System.EventHandler(this.pBoxNew_MouseEnter);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(784, 501);
            this.splitContainer2.SplitterDistance = 569;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.panelTools);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.panel3D);
            this.splitContainer4.Size = new System.Drawing.Size(569, 501);
            this.splitContainer4.SplitterDistance = 65;
            this.splitContainer4.TabIndex = 23;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.AutoScroll = true;
            this.splitContainer3.Panel1.Controls.Add(this.tabProperty);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.Controls.Add(this.treeView);
            this.splitContainer3.Size = new System.Drawing.Size(211, 501);
            this.splitContainer3.SplitterDistance = 314;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabProperty
            // 
            this.tabProperty.Controls.Add(this.tabSpace);
            this.tabProperty.Controls.Add(this.tabObject);
            this.tabProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProperty.Location = new System.Drawing.Point(0, 0);
            this.tabProperty.Name = "tabProperty";
            this.tabProperty.SelectedIndex = 0;
            this.tabProperty.Size = new System.Drawing.Size(211, 314);
            this.tabProperty.TabIndex = 0;
            this.tabProperty.Click += new System.EventHandler(this.tabProperty_Click);
            // 
            // tabSpace
            // 
            this.tabSpace.Controls.Add(this.propertyGridSpace);
            this.tabSpace.Location = new System.Drawing.Point(4, 22);
            this.tabSpace.Name = "tabSpace";
            this.tabSpace.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpace.Size = new System.Drawing.Size(203, 288);
            this.tabSpace.TabIndex = 0;
            this.tabSpace.Text = "Enviroment";
            this.tabSpace.UseVisualStyleBackColor = true;
            // 
            // propertyGridSpace
            // 
            this.propertyGridSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridSpace.Location = new System.Drawing.Point(3, 3);
            this.propertyGridSpace.Name = "propertyGridSpace";
            this.propertyGridSpace.Size = new System.Drawing.Size(197, 282);
            this.propertyGridSpace.TabIndex = 1;
            this.propertyGridSpace.Leave += new System.EventHandler(this.propertyGridSpace_Leave);
            this.propertyGridSpace.Enter += new System.EventHandler(this.propertyGridSpace_Enter);
            this.propertyGridSpace.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridSpace_PropertyValueChanged);
            // 
            // tabObject
            // 
            this.tabObject.Controls.Add(this.propertyGridObject);
            this.tabObject.Location = new System.Drawing.Point(4, 22);
            this.tabObject.Name = "tabObject";
            this.tabObject.Padding = new System.Windows.Forms.Padding(3);
            this.tabObject.Size = new System.Drawing.Size(203, 288);
            this.tabObject.TabIndex = 1;
            this.tabObject.Text = "Object";
            this.tabObject.UseVisualStyleBackColor = true;
            // 
            // propertyGridObject
            // 
            this.propertyGridObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridObject.Location = new System.Drawing.Point(3, 3);
            this.propertyGridObject.Name = "propertyGridObject";
            this.propertyGridObject.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGridObject.Size = new System.Drawing.Size(197, 282);
            this.propertyGridObject.TabIndex = 0;
            this.propertyGridObject.Leave += new System.EventHandler(this.propertyGridObject_Leave);
            this.propertyGridObject.Enter += new System.EventHandler(this.propertyGridObject_Enter);
            this.propertyGridObject.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGridObject_PropertyValueChanged);
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.HideSelection = false;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(211, 183);
            this.treeView.TabIndex = 1;
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // openFileDialogOBJ
            // 
            this.openFileDialogOBJ.Filter = "obj files (*.obj)|*.obj|All files (*.*)|*.*";
            this.openFileDialogOBJ.InitialDirectory = "c:\\";
            this.openFileDialogOBJ.RestoreDirectory = true;
            // 
            // saveFileDialogOBJ
            // 
            this.saveFileDialogOBJ.Filter = "obj files (*.obj)|*.obj|All files (*.*)|*.*";
            this.saveFileDialogOBJ.InitialDirectory = "c:\\";
            this.saveFileDialogOBJ.RestoreDirectory = true;
            // 
            // ViewTimer
            // 
            this.ViewTimer.Interval = 10;
            this.ViewTimer.Tick += new System.EventHandler(this.ViewTimer_Tick);
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            this.openFileDialogImage.InitialDirectory = "c:\\";
            this.openFileDialogImage.SupportMultiDottedExtensions = true;
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple 3D Maker";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.mainForm_MouseWheel);
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxZoomOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxZoomIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxViewMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxUndo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxRedo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxNew)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.tabProperty.ResumeLayout(false);
            this.tabSpace.ResumeLayout(false);
            this.tabObject.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportOBJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutS3DMakerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractionToolStripMenuItem;
        public System.Windows.Forms.Panel panel3D;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        public System.Windows.Forms.PropertyGrid propertyGridSpace;
        private System.Windows.Forms.ToolStripMenuItem importOBJToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogOBJ;
        private System.Windows.Forms.SaveFileDialog saveFileDialogOBJ;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.TabControl tabProperty;
        private System.Windows.Forms.TabPage tabSpace;
        private System.Windows.Forms.TabPage tabObject;
        private System.Windows.Forms.PropertyGrid propertyGridObject;
        private System.Windows.Forms.ToolStripMenuItem xYZAxisesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groundGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solidViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wireViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightEffectToolStripMenuItem;
        private System.Windows.Forms.PictureBox pBoxNew;
        private System.Windows.Forms.PictureBox pBoxRedo;
        private System.Windows.Forms.PictureBox pBoxSave;
        private System.Windows.Forms.PictureBox pBoxOpen;
        public System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.PictureBox pBoxUndo;
        private System.Windows.Forms.PictureBox pBoxDefault;
        private System.Windows.Forms.PictureBox pBoxFront;
        private System.Windows.Forms.Timer ViewTimer;
        private System.Windows.Forms.PictureBox pBoxBottom;
        private System.Windows.Forms.PictureBox pBoxTop;
        private System.Windows.Forms.PictureBox pBoxRight;
        private System.Windows.Forms.PictureBox pBoxLeft;
        private System.Windows.Forms.PictureBox pBoxBack;
        private System.Windows.Forms.PictureBox pBoxViewMode;
        private System.Windows.Forms.PictureBox pBoxLight;
        private System.Windows.Forms.PictureBox pBoxView;
        private System.Windows.Forms.PictureBox pBoxTexture;
        private System.Windows.Forms.PictureBox pBoxZoomOut;
        private System.Windows.Forms.PictureBox pBoxZoomIn;
        private System.Windows.Forms.PictureBox pBoxRotation;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
    }
}

