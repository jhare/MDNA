using System;

namespace mdnaSettings
{
	/// <summary>
	/// Summary description for Settings.
	/// </summary>
	public class Settings
	{
		#region Data Members
		private int m_numSettings;
		private int m_numVars;
		#endregion

		public Settings()
		{
			m_numSettings = 0;
			m_numVars = 0;
		}

		public int GetNumSettings()
		{
			return( m_numSettings );
		}

		public int GetNumVars()
		{	
			return( m_numVars );
		}
	}
}
