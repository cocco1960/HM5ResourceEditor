
namespace HM5ResourceEditor
{
    partial class ResourcesInfo
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
            this.lbResourceIDs = new System.Windows.Forms.ListBox();
            this.lblVideoMemoryRequirement = new System.Windows.Forms.Label();
            this.lblSystemMemoryRequirement = new System.Windows.Forms.Label();
            this.lblDataSize = new System.Windows.Forms.Label();
            this.lblStatesChunkSize = new System.Windows.Forms.Label();
            this.lblReferencesChunkSize = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblResourceInfo = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lvExtensions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lbResourceIDs
            // 
            this.lbResourceIDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResourceIDs.FormattingEnabled = true;
            this.lbResourceIDs.HorizontalScrollbar = true;
            this.lbResourceIDs.ItemHeight = 24;
            this.lbResourceIDs.Location = new System.Drawing.Point(12, 12);
            this.lbResourceIDs.Name = "lbResourceIDs";
            this.lbResourceIDs.Size = new System.Drawing.Size(789, 436);
            this.lbResourceIDs.TabIndex = 0;
            this.lbResourceIDs.SelectedIndexChanged += new System.EventHandler(this.LbResourceIDs_SelectedIndexChanged);
            // 
            // lblVideoMemoryRequirement
            // 
            this.lblVideoMemoryRequirement.AutoSize = true;
            this.lblVideoMemoryRequirement.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoMemoryRequirement.Location = new System.Drawing.Point(36, 651);
            this.lblVideoMemoryRequirement.Name = "lblVideoMemoryRequirement";
            this.lblVideoMemoryRequirement.Size = new System.Drawing.Size(241, 24);
            this.lblVideoMemoryRequirement.TabIndex = 19;
            this.lblVideoMemoryRequirement.Text = "Video memory requirement";
            // 
            // lblSystemMemoryRequirement
            // 
            this.lblSystemMemoryRequirement.AutoSize = true;
            this.lblSystemMemoryRequirement.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemMemoryRequirement.Location = new System.Drawing.Point(36, 617);
            this.lblSystemMemoryRequirement.Name = "lblSystemMemoryRequirement";
            this.lblSystemMemoryRequirement.Size = new System.Drawing.Size(252, 24);
            this.lblSystemMemoryRequirement.TabIndex = 18;
            this.lblSystemMemoryRequirement.Text = "System memory requirement";
            // 
            // lblDataSize
            // 
            this.lblDataSize.AutoSize = true;
            this.lblDataSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataSize.Location = new System.Drawing.Point(36, 584);
            this.lblDataSize.Name = "lblDataSize";
            this.lblDataSize.Size = new System.Drawing.Size(85, 24);
            this.lblDataSize.TabIndex = 17;
            this.lblDataSize.Text = "Data size";
            // 
            // lblStatesChunkSize
            // 
            this.lblStatesChunkSize.AutoSize = true;
            this.lblStatesChunkSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatesChunkSize.Location = new System.Drawing.Point(36, 551);
            this.lblStatesChunkSize.Name = "lblStatesChunkSize";
            this.lblStatesChunkSize.Size = new System.Drawing.Size(155, 24);
            this.lblStatesChunkSize.TabIndex = 16;
            this.lblStatesChunkSize.Text = "States chunk size";
            // 
            // lblReferencesChunkSize
            // 
            this.lblReferencesChunkSize.AutoSize = true;
            this.lblReferencesChunkSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferencesChunkSize.Location = new System.Drawing.Point(36, 517);
            this.lblReferencesChunkSize.Name = "lblReferencesChunkSize";
            this.lblReferencesChunkSize.Size = new System.Drawing.Size(202, 24);
            this.lblReferencesChunkSize.TabIndex = 15;
            this.lblReferencesChunkSize.Text = "References chunk size";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(36, 484);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(53, 24);
            this.lblType.TabIndex = 14;
            this.lblType.Text = "Type";
            // 
            // lblResourceInfo
            // 
            this.lblResourceInfo.AutoSize = true;
            this.lblResourceInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResourceInfo.Location = new System.Drawing.Point(12, 451);
            this.lblResourceInfo.Name = "lblResourceInfo";
            this.lblResourceInfo.Size = new System.Drawing.Size(132, 24);
            this.lblResourceInfo.TabIndex = 13;
            this.lblResourceInfo.Text = "Resource Info:";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.Location = new System.Drawing.Point(36, 684);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(82, 24);
            this.lblFilePath.TabIndex = 20;
            this.lblFilePath.Text = "File path";
            // 
            // lvExtensions
            // 
            this.lvExtensions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvExtensions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvExtensions.HideSelection = false;
            this.lvExtensions.Location = new System.Drawing.Point(807, 12);
            this.lvExtensions.Name = "lvExtensions";
            this.lvExtensions.Size = new System.Drawing.Size(418, 436);
            this.lvExtensions.TabIndex = 21;
            this.lvExtensions.UseCompatibleStateImageBehavior = false;
            this.lvExtensions.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Extension";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Offset";
            this.columnHeader2.Width = 250;
            // 
            // ResourcesInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 715);
            this.Controls.Add(this.lvExtensions);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.lblVideoMemoryRequirement);
            this.Controls.Add(this.lblSystemMemoryRequirement);
            this.Controls.Add(this.lblDataSize);
            this.Controls.Add(this.lblStatesChunkSize);
            this.Controls.Add(this.lblReferencesChunkSize);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblResourceInfo);
            this.Controls.Add(this.lbResourceIDs);
            this.Name = "ResourcesInfo";
            this.Text = "ResourcesInfo";
            this.Load += new System.EventHandler(this.ResourcesInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbResourceIDs;
        private System.Windows.Forms.Label lblVideoMemoryRequirement;
        private System.Windows.Forms.Label lblSystemMemoryRequirement;
        private System.Windows.Forms.Label lblDataSize;
        private System.Windows.Forms.Label lblStatesChunkSize;
        private System.Windows.Forms.Label lblReferencesChunkSize;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblResourceInfo;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.ListView lvExtensions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}