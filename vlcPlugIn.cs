/*
 * Created by SharpDevelop.
 * Date: 9/13/2012
 * Time: 8:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using Vixen;
using System.Windows.Forms;
using System.Xml;

namespace vlcPlugIn
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class vlcOutputPlugIn:IEventDrivenOutputPlugIn
	{
		private SetupData m_SetupData;
		private XmlNode m_SetupNode;
		private List<Channel> m_Channels;
		private int m_SelectedIndex;
		private string m_vlcHost;
		private string m_vlcPort;
		private string m_playlistFile;
		private List<PlaylistItems> pList = new List<PlaylistItems>();
		
		public HardwareMap[] HardwareMap {
			get {
				return new HardwareMap[0];
			}
		}
		
		public string Name {
			get {
				return "VLC Output Plugin";
			}
		}
		
		public string Author {
			get {
				return "slothman";
			}
		}
		
		public string Description {
			get {
				return "Allows you to control VLC based on event";
			}
		}
		
		//first used when clicking use in outplput plugin
		//called when clicking play
		public void Initialize(IExecutable executableObject, SetupData setupData, XmlNode setupNode)
		{
			this.m_SetupData = setupData;
			this.m_SetupNode = setupNode;
			this.m_Channels = executableObject.Channels;
			if(this.m_SetupNode.SelectSingleNode("Settings") == null){
				
				Xml.GetNodeAlways(this.m_SetupNode,"Settings");
				
				this.m_SelectedIndex = 0;
				this.m_vlcHost="";//set to nothing to use default
				this.m_vlcPort="";//set to nothing to use default
				this.m_playlistFile="";
			} else {
				XmlNode chNode = this.m_SetupNode.SelectSingleNode("Settings/ChannelIndex");
				XmlNode vlcHostNode = this.m_SetupNode.SelectSingleNode("Settings/VLCHost");
				XmlNode vlcPortNode = this.m_SetupNode.SelectSingleNode("Settings/VLCPort");
				XmlNode vlcPlaylistNode = this.m_SetupNode.SelectSingleNode("Settings/VLCPlaylist");
				XmlNodeList trackNodes;
				
				this.m_SelectedIndex = Convert.ToInt16(chNode.InnerText);
				this.m_vlcHost = Convert.ToString(vlcHostNode.InnerText);
				this.m_vlcPort = Convert.ToString(vlcPortNode.InnerText);
				this.m_playlistFile = Convert.ToString(vlcPlaylistNode.InnerText);
				trackNodes = this.m_SetupNode.SelectNodes("Settings/Track");
				foreach (XmlNode plTrack in trackNodes){
					this.pList.Add(
						new PlaylistItems(Convert.ToInt16(plTrack.Attributes["StartIntensity"].Value),
						                  Convert.ToInt16(plTrack.Attributes["StopIntensity"].Value),
						                  plTrack.Attributes["FileName"].Value.ToString(),
						                  Convert.ToInt16(plTrack.InnerText)
						                 )
					);
				}
			}
		}
		
		//for every change in timeslot during playback event is called
		public void Event(byte[] channelValues)
		{
			VLCHttpControl vlcHttp = new VLCHttpControl();
			//if(channelValues[m_SelectedIndex].ToString()=="1"){
			   
			//}
			this.pList.ForEach(delegate(PlaylistItems pli){
			            //for debugging
			            
			            /*using (StreamWriter sw = System.IO.File.AppendText(@"C:\start.txt")){
			                	sw.WriteLine(channelValues[m_SelectedIndex].ToString()+"|||"+
			                   		             Math.Round(
			                   		             	(
			                   		             		((double)pli.trgStart/100.0)
			                   		             			*255.0), 0, MidpointRounding.AwayFromZero).ToString());
			                   		//sw.WriteLine("|||"+      		             ((double)pli.trgStart).ToString());
			                   		
	        				}*/
			            if(channelValues[m_SelectedIndex].ToString() == 
			                   	   Math.Round((double)(((float)pli.trgStart/100)*255.0), 0, MidpointRounding.AwayFromZero).ToString()){
			            	
		              		vlcHttp.VLCHost = this.m_vlcHost;
		              		vlcHttp.VLCPort = this.m_vlcPort;
		              		vlcHttp.VLCId = pli.vlcID;
		              		vlcHttp.PL_Play();
			            } else if (channelValues[m_SelectedIndex].ToString() == 
			                   	           Math.Round((double)(((float)pli.trgStop/100)*255.0), 0, MidpointRounding.AwayFromZero).ToString()){
	                   		vlcHttp.VLCHost = this.m_vlcHost;
		              		vlcHttp.VLCPort = this.m_vlcPort;
		              		vlcHttp.VLCId = pli.vlcID;
		              		vlcHttp.PL_Stop();
	                   	}
			});
		}
		
		//called when clicking play
		public List<Form> Startup()
		{
			return new List<Form>();
		}
		
		//called when clicking stop
		public void Shutdown()
		{
			//stop any videos that are running
		}
		
		//called when clicking plugin setup
		public void Setup()
		{
			int startChannel;
			int startVLCID = 5;
			
			
			startChannel = this.m_SelectedIndex;
			
			SetupDialog dialog = new SetupDialog(this.m_Channels,startChannel,this.m_vlcHost,this.m_vlcPort,this.m_playlistFile,this.m_SetupNode);
			
			if(dialog.ShowDialog() == DialogResult.OK){
				int selection = dialog.SelectedChannel;
				string t_vlcHost = dialog.VLCHost;
				string t_vlcPort = dialog.VLCPort;
				string t_vlcPlaylistFile = dialog.VLCPlaylistFile;
				pList = dialog.playList;
				
				//get the node of where settings is
				XmlNode contextNode = this.m_SetupNode.SelectSingleNode("Settings");
				contextNode.RemoveAll(); //remove children of settings
				
				//create a new node under settings node and set the innerText
				XmlNode x_channelNode = Xml.SetNewValue(contextNode,"ChannelIndex",selection.ToString());
				XmlNode x_vlcHostNode = Xml.SetNewValue(contextNode,"VLCHost",t_vlcHost.ToString());
				XmlNode x_vlcPortNode = Xml.SetNewValue(contextNode,"VLCPort",t_vlcPort.ToString());
				XmlNode x_vlcPlaylistFileNode = Xml.SetNewValue(contextNode,"VLCPlaylist",t_vlcPlaylistFile.ToString());
				
				//as far as I can tell the http interface of VLC starts tracks on 5
				//so we will set a variable to 5 and then increment to get the vlc id
				pList.ForEach(delegate(PlaylistItems pli){
			    	XmlNode x_plaListNode = Xml.SetNewValue(contextNode,"Track",startVLCID.ToString());
					Xml.SetAttribute(x_plaListNode,"StartIntensity",pli.trgStart.ToString()); //create an attribute of the child node
					Xml.SetAttribute(x_plaListNode,"StopIntensity",pli.trgStop.ToString()); //create an attribute of the child node
					Xml.SetAttribute(x_plaListNode,"FileName",pli.FileName.ToString()); //create an attribute of the child node
			    
					startVLCID++;
				});
				//Xml.SetAttribute(newNode,"Attribute","somehing"); //create an attribute of the child node
			}
			dialog.Close();
		}
		public override string ToString()
		{
			return this.Name;
		}
		
		public byte VixenEvent{
			set{//value.toString
			}
		}

	}
}