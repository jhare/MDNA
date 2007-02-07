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
	/// This class implements the ICommand interface in order to offer
	/// a "do all" command to the user that does all replacements and
	/// addition of notation that it knows how to do at that moment.
	/// </summary>
	public class DoAllCmd : ICommand
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

		public DoAllCmd()
		{
			m_app = null;
			m_enabled = false;
			
			// Leaving this out until I can make an attractive bitmap. This may
			// never happen, regardless of my skill, since ArcMap is very picky
			// about those bitmaps.
			/*
			m_bitmap = new System.Drawing.Bitmap(GetType().Assembly.GetManifestResourceStream("mdna.DoAllIcon.bmp"));
			if (m_bitmap != null)
			{
				m_bitmap.MakeTransparent(m_bitmap.GetPixel(0,0));
				m_hBitmap = m_bitmap.GetHbitmap();
			}
			*/
		}

		~DoAllCmd()
		{
			if (m_hBitmap.ToInt32() != 0)
				DeleteObject(m_hBitmap);
		}


		#region ICommand Members

		public void OnClick()
		{
			MessageBox.Show( "Not yet implemented." );
		}

		public string Message
		{
			get
			{
				return( "Perform all substitution operations." );
			}
		}

		public int Bitmap
		{
			get
			{
				return m_hBitmap.ToInt32();
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
				return( "Do All" );
			}
		}

		public string Tooltip
		{
			get
			{
				return( "This command replaces all replaceable elements in the map." );
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
				return( "DoAll" );
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
