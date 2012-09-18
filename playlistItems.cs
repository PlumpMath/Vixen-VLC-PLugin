/*
 * Created by SharpDevelop.
 * Date: 9/14/2012
 * Time: 9:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace vlcPlugIn
{
	public class PlaylistItems
	{
		//constructor
		public PlaylistItems()
		{
			
		}
		
		public PlaylistItems(int start, int stop, string fileName, int vlcID)
		{
			this._start = start;
			this._stop = stop;
			this._fileName = fileName;
			this._vlcID = vlcID;
		}
		private int _start;
		private int _stop;
		private string _fileName;
		private int _vlcID;
		
		public int trgStart{
			get{return _start;}
			set{_start = value;}
		}
	
		public int trgStop{
			get{return _stop;}
			set{_stop = value;}
		}
		
		public string FileName{
			get{return _fileName;}
			set{_fileName = value;}
		}
			
		public int vlcID{
			get{return _vlcID;}
			set{_vlcID = value;}
		}
		
	}
}
