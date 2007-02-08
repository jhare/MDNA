using System;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Utility.CATIDs;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;

using System.Windows.Forms;

namespace mdna
{
	/// <summary>
	/// Summary description for AdjustGridCmd
	/// </summary>
	public class AdjustGridCmd : ICommand
	{

		// For the bitmap.
		[DllImport("gdi32.dll")]
		static extern bool DeleteObject(IntPtr hObject);

		#region Data Members
		private IApplication m_app;
		private bool m_enabled;
		private System.Drawing.Bitmap m_bitmap;
		private IntPtr m_hBitmap;
		#endregion


		public AdjustGridCmd()
		{
			m_app = null;
			m_enabled = false;

			/*
			m_bitmap = new System.Drawing.Bitmap(GetType().Assembly.GetManifestResourceStream("mdna.preferences.bmp"));
			if (m_bitmap != null)
			{
				m_bitmap.MakeTransparent(m_bitmap.GetPixel(0,0));
				m_hBitmap = m_bitmap.GetHbitmap();
			}
			*/
		}

		~AdjustGridCmd()
		{
			if (m_hBitmap.ToInt32() != 0)
				DeleteObject(m_hBitmap);
		}
		#region ICommand Members

		public void OnClick()
		{
			MessageBox.Show( "Not implemented yet." );
		}

		public string Message
		{
			get
			{
				return( "Adjusts the grid parameters and its formatting." );
			}
		}

		public int Bitmap
		{
			get
			{
				return( m_hBitmap.ToInt32() );
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
				return( "Adjust Grid" );
			}
		}

		public string Tooltip
		{
			get
			{
				return( "Adjusts the grid parameters and its formatting." );
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
				return( "Adjust Grid" );
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
