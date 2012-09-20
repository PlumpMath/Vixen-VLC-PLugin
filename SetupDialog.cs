/*
 * Created by SharpDevelop.
 * Date: 9/13/2012
 * Time: 9:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using Vixen;

namespace vlcPlugIn
{
	/// <summary>
	/// Description of SetupDialog.
	/// </summary>
	public partial class SetupDialog : Form
	{
		private string _VLCPlaylistFile;
		private XmlNodeList _trackNodes;
		private int _firstRun;
		public SetupDialog(List<Channel> channels, int startChannel,string vlcHost, string vlcPort, string vlcPlaylistFile,XmlNode ctxNode,string vlcStartID)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			foreach(Channel ch in channels){
				//if(ch.OutputChannel >= startChannel){
					cmb_Channel.Items.Add(ch.Name);
				//}
			}
			
			_trackNodes = ctxNode.SelectNodes("Settings/Track");
						
			cmb_Channel.SelectedIndex = startChannel;
			if(vlcHost == ""){
				txt_vlcHost.Text="http://localhost";
			}else {
				txt_vlcHost.Text=vlcHost;
			}
			
			if(vlcPort ==""){
				txt_vlcPort.Text = "8080";
			}else{
				txt_vlcPort.Text=vlcPort;
			}
			
			if(vlcStartID ==""){
				txt_vlcStartID.Text = "5";
			}else{
				txt_vlcStartID.Text=vlcStartID;
			}
			
			if(vlcPlaylistFile!=""){
				string path = vlcPlaylistFile; // The Path to the .Xml file
				_VLCPlaylistFile = vlcPlaylistFile;
				_firstRun=0;
	    		PopulateGrid(path);
			}
			
		}
		
		public int SelectedChannel{
			get{return cmb_Channel.SelectedIndex;}
		}
		
		public string VLCHost{
			get{return txt_vlcHost.Text;}
		}
		
		public string VLCPort{
			get{return txt_vlcPort.Text;}
		}	

		public string VLCPlaylistFile{
			get{return _VLCPlaylistFile;}
		}
		
		public string VLCStartID{
			get{return txt_vlcStartID.Text;}
		}
		
		public List<PlaylistItems> playList{
			get{
				List<PlaylistItems> pItems = new List<PlaylistItems>();
				foreach (DataGridViewRow r in dataGridView1.Rows){
					int startTrg,stopTrg;
					/*using (StreamWriter sw = System.IO.File.AppendText(@"C:\trg.txt")){
						sw.WriteLine(r.Cells[0].FormattedValue.ToString()+"IN LOOP::cell value::");
	    				}
					*/
					//if the start value in the cell is null make it -1 so it never turns on
					//we still need it in our seq or profile so the vlc id does not get out of whack
					if(r.Cells[0].FormattedValue.ToString() == ""){
						startTrg = -1;
				   	}else{
						startTrg = Convert.ToInt16(r.Cells[0].Value.ToString());
				   	}
					   
					//if the stop value in the cell is null make it -1 so it never turns on
					//we still need it in our seq or profile so the vlc id does not get out of whack
					if(r.Cells[1].FormattedValue.ToString() == ""){
						stopTrg = -1;
				   	}else{
						stopTrg = Convert.ToInt16(r.Cells[1].Value.ToString());
				   	}
					pItems.Add(new PlaylistItems(startTrg,stopTrg,r.Cells[2].Value.ToString(),5));
					
					
				}
				return pItems;
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			
		}
		
		void Cmb_ChannelSelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void Btn_openPlaylistClick(object sender, EventArgs e)
		{
			// Show the dialog and get result.
	    	DialogResult result = openFileDialog1.ShowDialog();
	    	if (result == DialogResult.OK){
	    		string path = openFileDialog1.FileName; // The Path to the .Xml file
	    		_VLCPlaylistFile = path;
	    		_firstRun=1;
	    		PopulateGrid(path);
	    	}
	    	Console.WriteLine(result); // <-- For debugging use only.
		}
		
		void DataGrid1Navigate(object sender, NavigateEventArgs ne)
		{
			
		}
		
		private void PopulateGrid(string path){
				
	    		XmlDataDocument playlistXML = new XmlDataDocument();
	    		
	    		playlistXML.DataSet.ReadXml(path);
	    		
	    		
	    		//dataGridView1.AutoGenerateColumns = true;
	    		dataGridView1.ReadOnly = false;
	    		dataGridView1.Width=693;
	    		dataGridView1.DataSource = playlistXML.DataSet;
	    		
	    		DataGridViewColumn iTrg = new  DataGridViewTextBoxColumn();
	    		DataGridViewColumn iStpTrg = new  DataGridViewTextBoxColumn();
	    		DataGridViewColumn fName = new DataGridViewTextBoxColumn();
	    		DataGridViewColumn duration = new DataGridViewTextBoxColumn();
	    			    		
	    		iTrg.HeaderText = "Trigger(play)";
	    		iTrg.Name="startTrig";
	    		iTrg.Width=100;
	    		iTrg.SortMode = DataGridViewColumnSortMode.NotSortable;
	    		dataGridView1.Columns.Add(iTrg);
	    		
	    		//iStpTrg.DataPropertyName = "extension";
	    		iStpTrg.HeaderText = "Trigger(stop)";
	    		iStpTrg.Name="stopTrig";
	    		iStpTrg.Width=100;
	    		iStpTrg.SortMode = DataGridViewColumnSortMode.NotSortable;
	    		dataGridView1.Columns.Add(iStpTrg);
	    		
	    		fName.DataPropertyName = "location";
	    		fName.HeaderText = "File";
	    		fName.Name="location";
	    		fName.Width=350;
	    		fName.ReadOnly=true;
	    		fName.SortMode = DataGridViewColumnSortMode.NotSortable;
	    		dataGridView1.Columns.Add(fName);
	    		
	    		duration.DataPropertyName = "duration";
	    		duration.HeaderText = "Duration (ms)";
	    		duration.Name="duration";
	    		duration.Width=100;
	    		duration.ReadOnly=true;
	    		duration.SortMode = DataGridViewColumnSortMode.NotSortable;
	    		dataGridView1.Columns.Add(duration);
	    	
	    		
	    		
	    		
	    		dataGridView1.DataMember = "track";
	    		dataGridView1.DataBindingComplete += OnCellFormatting;
	    		
	    		
	    		
		}
		
		private void OnCellFormatting(object sender, DataGridViewBindingCompleteEventArgs e){
			int idx;
			/*using (StreamWriter sw = System.IO.File.AppendText(@"C:\trg.txt")){
		    				sw.WriteLine("AAARGH");
	    				}*/
		    if(_firstRun == 0){
	    			idx=0;
	    			foreach (XmlNode plTrack in _trackNodes){
	    				/*using (StreamWriter sw = System.IO.File.AppendText(@"C:\trg.txt")){
		    				sw.WriteLine("NODE::"+idx+"::"+plTrack.Attributes["StartIntensity"].Value+"::"+plTrack.Attributes["StopIntensity"].Value);
	    				}*/
	    				dataGridView1.Rows[idx].Cells[0].Value = plTrack.Attributes["StartIntensity"].Value=="-1"?"":plTrack.Attributes["StartIntensity"].Value;
	    				dataGridView1.Rows[idx].Cells[1].Value = plTrack.Attributes["StopIntensity"].Value=="-1"?"":plTrack.Attributes["StopIntensity"].Value;
	    				
						idx++;	    				
					}
	    			
	    		}
		}
		
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			
		}
	}
}
