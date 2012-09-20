/*
 * Created by SharpDevelop.
 * Date: 9/13/2012
 * Time: 9:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace vlcPlugIn
{
	partial class SetupDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupDialog));
			this.btn_OK = new System.Windows.Forms.Button();
			this.cmb_Channel = new System.Windows.Forms.ComboBox();
			this.lbl_listenChannel = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btn_openPlaylist = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dataView1 = new System.Data.DataView();
			this.lbl_vlcHost = new System.Windows.Forms.Label();
			this.txt_vlcHost = new System.Windows.Forms.TextBox();
			this.lbl_vlcPort = new System.Windows.Forms.Label();
			this.txt_vlcPort = new System.Windows.Forms.TextBox();
			this.lbl_playlistStartID = new System.Windows.Forms.Label();
			this.txt_vlcStartID = new System.Windows.Forms.TextBox();
			this.lbl_findID = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_OK
			// 
			this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_OK.Location = new System.Drawing.Point(731, 324);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new System.Drawing.Size(75, 23);
			this.btn_OK.TabIndex = 0;
			this.btn_OK.Text = "OK";
			this.btn_OK.UseVisualStyleBackColor = true;
			this.btn_OK.Click += new System.EventHandler(this.Button1Click);
			// 
			// cmb_Channel
			// 
			this.cmb_Channel.FormattingEnabled = true;
			this.cmb_Channel.Location = new System.Drawing.Point(113, 304);
			this.cmb_Channel.Name = "cmb_Channel";
			this.cmb_Channel.Size = new System.Drawing.Size(167, 21);
			this.cmb_Channel.TabIndex = 1;
			this.cmb_Channel.SelectedIndexChanged += new System.EventHandler(this.Cmb_ChannelSelectedIndexChanged);
			// 
			// lbl_listenChannel
			// 
			this.lbl_listenChannel.Location = new System.Drawing.Point(26, 307);
			this.lbl_listenChannel.Name = "lbl_listenChannel";
			this.lbl_listenChannel.Size = new System.Drawing.Size(81, 23);
			this.lbl_listenChannel.TabIndex = 2;
			this.lbl_listenChannel.Text = "Video Channel:";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "*.xspf";
			// 
			// btn_openPlaylist
			// 
			this.btn_openPlaylist.Location = new System.Drawing.Point(11, 104);
			this.btn_openPlaylist.Name = "btn_openPlaylist";
			this.btn_openPlaylist.Size = new System.Drawing.Size(96, 23);
			this.btn_openPlaylist.TabIndex = 3;
			this.btn_openPlaylist.Text = "open playlist...";
			this.btn_openPlaylist.UseVisualStyleBackColor = true;
			this.btn_openPlaylist.Click += new System.EventHandler(this.Btn_openPlaylistClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dataGridView1.Location = new System.Drawing.Point(113, 104);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(693, 189);
			this.dataGridView1.TabIndex = 4;
			// 
			// dataView1
			// 
			this.dataView1.AllowDelete = false;
			this.dataView1.AllowNew = false;
			// 
			// lbl_vlcHost
			// 
			this.lbl_vlcHost.Location = new System.Drawing.Point(11, 13);
			this.lbl_vlcHost.Name = "lbl_vlcHost";
			this.lbl_vlcHost.Size = new System.Drawing.Size(100, 23);
			this.lbl_vlcHost.TabIndex = 5;
			this.lbl_vlcHost.Text = "VLC Host Address:";
			// 
			// txt_vlcHost
			// 
			this.txt_vlcHost.Location = new System.Drawing.Point(113, 10);
			this.txt_vlcHost.Name = "txt_vlcHost";
			this.txt_vlcHost.Size = new System.Drawing.Size(100, 20);
			this.txt_vlcHost.TabIndex = 6;
			// 
			// lbl_vlcPort
			// 
			this.lbl_vlcPort.Location = new System.Drawing.Point(53, 42);
			this.lbl_vlcPort.Name = "lbl_vlcPort";
			this.lbl_vlcPort.Size = new System.Drawing.Size(54, 23);
			this.lbl_vlcPort.TabIndex = 7;
			this.lbl_vlcPort.Text = "VLC Port:";
			// 
			// txt_vlcPort
			// 
			this.txt_vlcPort.Location = new System.Drawing.Point(113, 39);
			this.txt_vlcPort.Name = "txt_vlcPort";
			this.txt_vlcPort.Size = new System.Drawing.Size(100, 20);
			this.txt_vlcPort.TabIndex = 8;
			// 
			// lbl_playlistStartID
			// 
			this.lbl_playlistStartID.Location = new System.Drawing.Point(7, 71);
			this.lbl_playlistStartID.Name = "lbl_playlistStartID";
			this.lbl_playlistStartID.Size = new System.Drawing.Size(100, 23);
			this.lbl_playlistStartID.TabIndex = 9;
			this.lbl_playlistStartID.Text = "playlist.xml Start ID:";
			// 
			// txt_vlcStartID
			// 
			this.txt_vlcStartID.Location = new System.Drawing.Point(113, 68);
			this.txt_vlcStartID.Name = "txt_vlcStartID";
			this.txt_vlcStartID.Size = new System.Drawing.Size(100, 20);
			this.txt_vlcStartID.TabIndex = 10;
			this.txt_vlcStartID.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// lbl_findID
			// 
			this.lbl_findID.Location = new System.Drawing.Point(220, 71);
			this.lbl_findID.Name = "lbl_findID";
			this.lbl_findID.Size = new System.Drawing.Size(586, 23);
			this.lbl_findID.TabIndex = 11;
			this.lbl_findID.Text = "http://<host IP>:<host port>/requests/playist.xml (then look at the first leaf id" +
			" under the \"playlist\" node)";
			// 
			// SetupDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(831, 359);
			this.Controls.Add(this.lbl_findID);
			this.Controls.Add(this.txt_vlcStartID);
			this.Controls.Add(this.lbl_playlistStartID);
			this.Controls.Add(this.txt_vlcPort);
			this.Controls.Add(this.lbl_vlcPort);
			this.Controls.Add(this.txt_vlcHost);
			this.Controls.Add(this.lbl_vlcHost);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btn_openPlaylist);
			this.Controls.Add(this.lbl_listenChannel);
			this.Controls.Add(this.cmb_Channel);
			this.Controls.Add(this.btn_OK);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SetupDialog";
			this.Text = "VLC Plugin";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label lbl_findID;
		private System.Windows.Forms.TextBox txt_vlcStartID;
		private System.Windows.Forms.Label lbl_playlistStartID;
		private System.Windows.Forms.TextBox txt_vlcPort;
		private System.Windows.Forms.Label lbl_vlcPort;
		private System.Windows.Forms.TextBox txt_vlcHost;
		private System.Windows.Forms.Label lbl_vlcHost;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btn_openPlaylist;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label lbl_listenChannel;
		private System.Windows.Forms.ComboBox cmb_Channel;
		private System.Windows.Forms.Button btn_OK;
	}
}
