using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.Utility.CATIDs;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;

namespace mdna
{
	/// <summary>
	/// Summary description for ShowPreferencesCmd.
	/// </summary>
	public class ShowPreferencesCmd : ICommand
	{
		#region Data Members
		private IApplication m_app;
		private bool m_enabled;
		#endregion

		public ShowPreferencesCmd()
		{
			m_app = null;
			m_enabled = false;
		}

		#region ICommand Members

		public void OnClick()
		{
			mdna.Preferences preferencesWindow = new mdna.Preferences();
			preferencesWindow.Show();
		}

		public string Message
		{
			get
			{
				return( "Display the preferences dialog." );
			}
		}

		public int Bitmap
		{
			get
			{
				return 0;
			}
		}

		public void OnCreate(object hook)
		{
			if( hook != null && hook is IMxApplication )
			{
				m_app = (IApplication)hook;
				m_enabled = true;
			}
			else
			{
				m_enabled = false;
			}
		}

		public string Caption
		{
			get
			{
				return( "Preferences" );
			}
		}

		public string Tooltip
		{
			get
			{
				return( "Display the preferences dialog." );
			}
		}

		public int HelpContextID
		{
			get
			{
				return 0;
			}
		}

		public string Name
		{
			get
			{
				return( "Preferences" );
			}
		}

		public bool Checked
		{
			get
			{
				return false;
			}
		}

		public bool Enabled
		{
			get
			{
				return( m_enabled );
			}
		}

		public string HelpFile
		{
			get
			{
				return null;
			}
		}

		public string Category
		{
			get
			{
				return( "MDNA" );
			}
		}

		#endregion

		#region "Component Category Registration"
		[ComRegisterFunction()]
		static void Reg(string regKey)
		{
				MxCommands.Register(regKey);
		}

		[ComUnregisterFunction()]
		static void Unreg(string regKey)
		{
				MxCommands.Unregister(regKey);
		}
		#endregion

	}
}
