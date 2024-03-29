using System;
using System.Collections;

namespace mdnaSettings
{
	/// <summary>
	/// Summary description for Settings.
	/// </summary>
	public class Settings
	{
		#region Data Members
		internal Hashtable m_settings;
		string m_category;
		#endregion

		#region Constructors
		public Settings()
		{
			m_settings = new Hashtable();
			m_category = "";
		}

		public Settings( string category )
		{
			m_settings = new Hashtable();
			m_category = category;
		}

		#endregion

		#region Properties

		public string Category
		{
			get
			{
				return( m_category );
			}
			set
			{
				m_category = value;
			}
		}


		public int Count
		{
			get
			{
				return( m_settings.Count );
			}
		}


		#endregion

		#region Member Functions
		// This function is essentially what I want to hide from the
		// would-be user of the Hashtable. There are a few reasons:
		// 1) No one likes to see casts.
		// 2) The default Hashtable behavior of when referencing a non-existent
		//    key, it will create that key, is undesirable for us.
		// 3) The return of a non-existent key would then be something other than ""
		//    in certain cases which is unacceptable for our requirements.
		public string Get( string lookup )
		{
			if( m_settings.ContainsKey( (object)lookup ) == true )
			{
				return( (string)m_settings[(object)lookup] );
			}
			else
			{
				return( "" );
			}
		}


		public void Clear()
		{
            m_settings.Clear();		
		}


		public void Add(string key, string value)
		{
			m_settings.Add( key, value );
		}


		public void Remove( string key )
		{
			m_settings.Remove( key );
		}


		#endregion
		
	}
}
