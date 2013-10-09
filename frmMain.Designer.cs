namespace DnsResolver
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dgDnsEntries = new System.Windows.Forms.DataGridView();
            this.btnResolveAll = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnFlushDNS = new System.Windows.Forms.Button();
            this.Hostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrQueuePoll = new System.Windows.Forms.Timer(this.components);
            this.btnPasteFromClipboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDnsEntries)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDnsEntries
            // 
            this.dgDnsEntries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDnsEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDnsEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hostname,
            this.IPAddress});
            this.dgDnsEntries.Location = new System.Drawing.Point(12, 12);
            this.dgDnsEntries.Name = "dgDnsEntries";
            this.dgDnsEntries.Size = new System.Drawing.Size(669, 484);
            this.dgDnsEntries.TabIndex = 0;
            this.dgDnsEntries.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDnsEntries_CellValueChanged);
            // 
            // btnResolveAll
            // 
            this.btnResolveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResolveAll.Location = new System.Drawing.Point(606, 502);
            this.btnResolveAll.Name = "btnResolveAll";
            this.btnResolveAll.Size = new System.Drawing.Size(75, 23);
            this.btnResolveAll.TabIndex = 1;
            this.btnResolveAll.Text = "Resolve All";
            this.btnResolveAll.UseVisualStyleBackColor = true;
            this.btnResolveAll.Click += new System.EventHandler(this.btnResolveAll_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearList.Location = new System.Drawing.Point(444, 502);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 2;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnFlushDNS
            // 
            this.btnFlushDNS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFlushDNS.Location = new System.Drawing.Point(525, 502);
            this.btnFlushDNS.Name = "btnFlushDNS";
            this.btnFlushDNS.Size = new System.Drawing.Size(75, 23);
            this.btnFlushDNS.TabIndex = 3;
            this.btnFlushDNS.Text = "Flush DNS";
            this.btnFlushDNS.UseVisualStyleBackColor = true;
            this.btnFlushDNS.Click += new System.EventHandler(this.btnFlushDNS_Click);
            // 
            // Hostname
            // 
            this.Hostname.HeaderText = "Hostname";
            this.Hostname.Name = "Hostname";
            this.Hostname.Width = 400;
            // 
            // IPAddress
            // 
            this.IPAddress.HeaderText = "IP Address";
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.ReadOnly = true;
            this.IPAddress.Width = 200;
            // 
            // tmrQueuePoll
            // 
            this.tmrQueuePoll.Enabled = true;
            this.tmrQueuePoll.Interval = 500;
            this.tmrQueuePoll.Tick += new System.EventHandler(this.tmrQueuePoll_Tick);
            // 
            // btnPasteFromClipboard
            // 
            this.btnPasteFromClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPasteFromClipboard.Location = new System.Drawing.Point(309, 502);
            this.btnPasteFromClipboard.Name = "btnPasteFromClipboard";
            this.btnPasteFromClipboard.Size = new System.Drawing.Size(129, 23);
            this.btnPasteFromClipboard.TabIndex = 4;
            this.btnPasteFromClipboard.Text = "Paste from Clipboard";
            this.btnPasteFromClipboard.UseVisualStyleBackColor = true;
            this.btnPasteFromClipboard.Click += new System.EventHandler(this.btnPasteFromClipboard_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 537);
            this.Controls.Add(this.btnPasteFromClipboard);
            this.Controls.Add(this.btnFlushDNS);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.btnResolveAll);
            this.Controls.Add(this.dgDnsEntries);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "DNS Resolver";
            ((System.ComponentModel.ISupportInitialize)(this.dgDnsEntries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDnsEntries;
        private System.Windows.Forms.Button btnResolveAll;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnFlushDNS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.Timer tmrQueuePoll;
        private System.Windows.Forms.Button btnPasteFromClipboard;
    }
}

