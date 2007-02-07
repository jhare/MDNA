using System;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Utility.CATIDs;

namespace mdna
{
	/// <summary>
	/// Summary description for MDNAToolbar.
	/// </summary>
	public class MDNAToolbar : IToolBarDef
	{
		public MDNAToolbar()
		{
			
		}

		#region IToolBarDef Members

		public void GetItemInfo(int pos, IItemDef itemDef)
		{
			// For now we only have the "batch" command.

			switch( pos )
			{
				case 0:
					itemDef.ID = "mdna.DoAllCmd";
					itemDef.Group = false;
					break;
				case 1:
					itemDef.ID = "mdna.ShowPreferencesCmd";
					itemDef.Group = true;
					break;
			}
		}

		public string Caption
		{
			get
			{
				return( "MDNA Toolbar" );
			}
		}

		public string Name
		{
			get
			{
				return( "MDNA Toolbar" );
			}
		}

		public int ItemCount
		{
			get
			{
				return( 2 );
			}
		}

		#endregion

		#region "Component Category Registration"
		[ComRegisterFunction()]
		static void Reg(string regKey)
		{
				MxCommandBars.Register(regKey);
				string theGUID = regKey.Substring(regKey.LastIndexOf(@"\") + 1);
				string keyStr = @"Software\ESRI\ArcCatalog\Settings\PremierToolbars\";
				Microsoft.Win32.RegistryKey premierRegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyStr, true);
				if (premierRegKey == null)
				{
					premierRegKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(keyStr);
				}
				if (premierRegKey != null)
				{
					premierRegKey.CreateSubKey(theGUID);
					premierRegKey.Close();
				}
		}

		[ComUnregisterFunction()]
		static void Unreg(string regKey)
		{
				MxCommandBars.Unregister(regKey);
				string theGUID = regKey.Substring(regKey.LastIndexOf(@"\") + 1);
				string keyStr = @"Software\ESRI\ArcCatalog\Settings\PremierToolbars\";
				Microsoft.Win32.RegistryKey premierRegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyStr, true);
				if (premierRegKey != null)
				{
					premierRegKey.DeleteSubKey(theGUID);
					premierRegKey.Close();
				}
		}
		#endregion


	}
}