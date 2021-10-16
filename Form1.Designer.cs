namespace HM5ResourceEditor
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
            this.txtGamePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectGamePath = new System.Windows.Forms.Button();
            this.lvHeaderlibs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExportAllFilesInSelectedFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportFilesFromFromAllFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExportFile = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHeaderInfo = new System.Windows.Forms.Label();
            this.lblVideoMemoryRequirement = new System.Windows.Forms.Label();
            this.lblSystemMemoryRequirement = new System.Windows.Forms.Label();
            this.lblDataSize = new System.Windows.Forms.Label();
            this.lblStatesChunkSize = new System.Windows.Forms.Label();
            this.lblReferencesChunkSize = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblWorkingDirectory = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportOutfitNames = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportItemNames = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportWeaponNames = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectExportPath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            this.btnDisplayResourcesInfo = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGamePath
            // 
            this.txtGamePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGamePath.Location = new System.Drawing.Point(16, 53);
            this.txtGamePath.Name = "txtGamePath";
            this.txtGamePath.Size = new System.Drawing.Size(754, 29);
            this.txtGamePath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Game path:";
            // 
            // btnSelectGamePath
            // 
            this.btnSelectGamePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectGamePath.Location = new System.Drawing.Point(776, 49);
            this.btnSelectGamePath.Name = "btnSelectGamePath";
            this.btnSelectGamePath.Size = new System.Drawing.Size(123, 39);
            this.btnSelectGamePath.TabIndex = 2;
            this.btnSelectGamePath.Text = "Select Path";
            this.btnSelectGamePath.UseVisualStyleBackColor = true;
            this.btnSelectGamePath.Click += new System.EventHandler(this.BtnSelectGamePath_Click);
            // 
            // lvHeaderlibs
            // 
            this.lvHeaderlibs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvHeaderlibs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvHeaderlibs.HideSelection = false;
            this.lvHeaderlibs.Location = new System.Drawing.Point(245, 194);
            this.lvHeaderlibs.Name = "lvHeaderlibs";
            this.lvHeaderlibs.Size = new System.Drawing.Size(699, 529);
            this.lvHeaderlibs.TabIndex = 3;
            this.lvHeaderlibs.UseCompatibleStateImageBehavior = false;
            this.lvHeaderlibs.View = System.Windows.Forms.View.Details;
            this.lvHeaderlibs.SelectedIndexChanged += new System.EventHandler(this.LvResourceLibs_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 500;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(16, 194);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(223, 529);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportAllFilesInSelectedFolder,
            this.tsmiExportFilesFromFromAllFoldersToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(245, 70);
            // 
            // tsmiExportAllFilesInSelectedFolder
            // 
            this.tsmiExportAllFilesInSelectedFolder.Name = "tsmiExportAllFilesInSelectedFolder";
            this.tsmiExportAllFilesInSelectedFolder.Size = new System.Drawing.Size(244, 22);
            this.tsmiExportAllFilesInSelectedFolder.Text = "Export all files in selected folder";
            this.tsmiExportAllFilesInSelectedFolder.Click += new System.EventHandler(this.TsmiExportAllFilesInSelectedFolder_Click);
            // 
            // tsmiExportFilesFromFromAllFoldersToolStripMenuItem
            // 
            this.tsmiExportFilesFromFromAllFoldersToolStripMenuItem.Name = "tsmiExportFilesFromFromAllFoldersToolStripMenuItem";
            this.tsmiExportFilesFromFromAllFoldersToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.tsmiExportFilesFromFromAllFoldersToolStripMenuItem.Text = "Export files from from all folders";
            this.tsmiExportFilesFromFromAllFoldersToolStripMenuItem.Click += new System.EventHandler(this.TsmiExportFilesFromFromAllFoldersToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportFile});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(109, 26);
            // 
            // tsmiExportFile
            // 
            this.tsmiExportFile.Name = "tsmiExportFile";
            this.tsmiExportFile.Size = new System.Drawing.Size(108, 22);
            this.tsmiExportFile.Text = "Export";
            this.tsmiExportFile.Click += new System.EventHandler(this.TsmiExportFile_Click);
            // 
            // lblHeaderInfo
            // 
            this.lblHeaderInfo.AutoSize = true;
            this.lblHeaderInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderInfo.Location = new System.Drawing.Point(950, 194);
            this.lblHeaderInfo.Name = "lblHeaderInfo";
            this.lblHeaderInfo.Size = new System.Drawing.Size(113, 24);
            this.lblHeaderInfo.TabIndex = 6;
            this.lblHeaderInfo.Text = "Header Info:";
            // 
            // lblVideoMemoryRequirement
            // 
            this.lblVideoMemoryRequirement.AutoSize = true;
            this.lblVideoMemoryRequirement.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoMemoryRequirement.Location = new System.Drawing.Point(974, 399);
            this.lblVideoMemoryRequirement.Name = "lblVideoMemoryRequirement";
            this.lblVideoMemoryRequirement.Size = new System.Drawing.Size(248, 24);
            this.lblVideoMemoryRequirement.TabIndex = 19;
            this.lblVideoMemoryRequirement.Text = "Video Memory Requirement";
            // 
            // lblSystemMemoryRequirement
            // 
            this.lblSystemMemoryRequirement.AutoSize = true;
            this.lblSystemMemoryRequirement.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemMemoryRequirement.Location = new System.Drawing.Point(974, 366);
            this.lblSystemMemoryRequirement.Name = "lblSystemMemoryRequirement";
            this.lblSystemMemoryRequirement.Size = new System.Drawing.Size(259, 24);
            this.lblSystemMemoryRequirement.TabIndex = 18;
            this.lblSystemMemoryRequirement.Text = "System Memory Requirement";
            // 
            // lblDataSize
            // 
            this.lblDataSize.AutoSize = true;
            this.lblDataSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataSize.Location = new System.Drawing.Point(974, 331);
            this.lblDataSize.Name = "lblDataSize";
            this.lblDataSize.Size = new System.Drawing.Size(88, 24);
            this.lblDataSize.TabIndex = 17;
            this.lblDataSize.Text = "Data Size";
            // 
            // lblStatesChunkSize
            // 
            this.lblStatesChunkSize.AutoSize = true;
            this.lblStatesChunkSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatesChunkSize.Location = new System.Drawing.Point(974, 296);
            this.lblStatesChunkSize.Name = "lblStatesChunkSize";
            this.lblStatesChunkSize.Size = new System.Drawing.Size(161, 24);
            this.lblStatesChunkSize.TabIndex = 16;
            this.lblStatesChunkSize.Text = "States Chunk Size";
            // 
            // lblReferencesChunkSize
            // 
            this.lblReferencesChunkSize.AutoSize = true;
            this.lblReferencesChunkSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencesChunkSize.Location = new System.Drawing.Point(974, 263);
            this.lblReferencesChunkSize.Name = "lblReferencesChunkSize";
            this.lblReferencesChunkSize.Size = new System.Drawing.Size(208, 24);
            this.lblReferencesChunkSize.TabIndex = 15;
            this.lblReferencesChunkSize.Text = "References Chunk Size";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(974, 229);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(53, 24);
            this.lblType.TabIndex = 14;
            this.lblType.Text = "Type";
            // 
            // lblWorkingDirectory
            // 
            this.lblWorkingDirectory.AutoSize = true;
            this.lblWorkingDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkingDirectory.Location = new System.Drawing.Point(241, 167);
            this.lblWorkingDirectory.Name = "lblWorkingDirectory";
            this.lblWorkingDirectory.Size = new System.Drawing.Size(162, 24);
            this.lblWorkingDirectory.TabIndex = 20;
            this.lblWorkingDirectory.Text = "Working directory:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1334, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExportOutfitNames,
            this.tsmiExportItemNames,
            this.tsmiExportWeaponNames});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // tsmiExportOutfitNames
            // 
            this.tsmiExportOutfitNames.Name = "tsmiExportOutfitNames";
            this.tsmiExportOutfitNames.Size = new System.Drawing.Size(195, 22);
            this.tsmiExportOutfitNames.Text = "Export Outfit Names";
            this.tsmiExportOutfitNames.Click += new System.EventHandler(this.TsmiExportOutfitNames_Click);
            // 
            // tsmiExportItemNames
            // 
            this.tsmiExportItemNames.Name = "tsmiExportItemNames";
            this.tsmiExportItemNames.Size = new System.Drawing.Size(195, 22);
            this.tsmiExportItemNames.Text = "Export Item Names";
            this.tsmiExportItemNames.Click += new System.EventHandler(this.TsmiExportItemNames_Click);
            // 
            // tsmiExportWeaponNames
            // 
            this.tsmiExportWeaponNames.Name = "tsmiExportWeaponNames";
            this.tsmiExportWeaponNames.Size = new System.Drawing.Size(195, 22);
            this.tsmiExportWeaponNames.Text = "Export Weapon Names";
            this.tsmiExportWeaponNames.Click += new System.EventHandler(this.TsmiExportWeaponNames_Click);
            // 
            // btnSelectExportPath
            // 
            this.btnSelectExportPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectExportPath.Location = new System.Drawing.Point(776, 108);
            this.btnSelectExportPath.Name = "btnSelectExportPath";
            this.btnSelectExportPath.Size = new System.Drawing.Size(123, 39);
            this.btnSelectExportPath.TabIndex = 24;
            this.btnSelectExportPath.Text = "Select Path";
            this.btnSelectExportPath.UseVisualStyleBackColor = true;
            this.btnSelectExportPath.Click += new System.EventHandler(this.BtnSelectExportPath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 23;
            this.label4.Text = "Export path:";
            // 
            // txtExportPath
            // 
            this.txtExportPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExportPath.Location = new System.Drawing.Point(16, 112);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.Size = new System.Drawing.Size(754, 29);
            this.txtExportPath.TabIndex = 22;
            // 
            // btnDisplayResourcesInfo
            // 
            this.btnDisplayResourcesInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplayResourcesInfo.Location = new System.Drawing.Point(997, 456);
            this.btnDisplayResourcesInfo.Name = "btnDisplayResourcesInfo";
            this.btnDisplayResourcesInfo.Size = new System.Drawing.Size(225, 39);
            this.btnDisplayResourcesInfo.TabIndex = 25;
            this.btnDisplayResourcesInfo.Text = "Display Resources Info";
            this.btnDisplayResourcesInfo.UseVisualStyleBackColor = true;
            this.btnDisplayResourcesInfo.Click += new System.EventHandler(this.BtnDisplayResourcesInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 738);
            this.Controls.Add(this.btnDisplayResourcesInfo);
            this.Controls.Add(this.btnSelectExportPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtExportPath);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblWorkingDirectory);
            this.Controls.Add(this.lblVideoMemoryRequirement);
            this.Controls.Add(this.lblSystemMemoryRequirement);
            this.Controls.Add(this.lblDataSize);
            this.Controls.Add(this.lblStatesChunkSize);
            this.Controls.Add(this.lblReferencesChunkSize);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblHeaderInfo);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.lvHeaderlibs);
            this.Controls.Add(this.btnSelectGamePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGamePath);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGamePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectGamePath;
        private System.Windows.Forms.ListView lvHeaderlibs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportAllFilesInSelectedFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportFile;
        private System.Windows.Forms.Label lblHeaderInfo;
        private System.Windows.Forms.Label lblVideoMemoryRequirement;
        private System.Windows.Forms.Label lblSystemMemoryRequirement;
        private System.Windows.Forms.Label lblDataSize;
        private System.Windows.Forms.Label lblStatesChunkSize;
        private System.Windows.Forms.Label lblReferencesChunkSize;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblWorkingDirectory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportOutfitNames;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportItemNames;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportWeaponNames;
        private System.Windows.Forms.Button btnSelectExportPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Button btnDisplayResourcesInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportFilesFromFromAllFoldersToolStripMenuItem;
    }
}

