using System;
using System.Xml;
using System.IO;

namespace mdnaSettings
{
	/// <summary>
	/// The SettingsFile class deals with reading/writing the XML
	/// that stores MDNA settings and constants for the templates.
	/// </summary>
	public class SettingsFile
	{
		#region Data Members
		string m_fileName;
		#endregion

		#region Constructors
		public SettingsFile()
		{
			m_fileName = "";
		}

		public SettingsFile( string fileName)
		{
			// If the file isn't there, create it, otherwise just
			// set the name for internal reference.
			m_fileName = fileName;
			if( File.Exists( m_fileName ) == false )
			{
				XmlTextWriter xml = new XmlTextWriter( fileName, System.Text.Encoding.UTF8 );

				xml.Formatting = System.Xml.Formatting.Indented;

				xml.WriteStartDocument();

				xml.WriteStartElement( "mdna" );
				xml.WriteEndElement();

				xml.WriteEndDocument();

				xml.Close();
			}

		}
		#endregion

		#region Member Functions
		public bool Save( mdnaSettings.Settings settings )
		{
			// The hash table in the Settings class is set to "internal"
			// so that things within this assembly (dll) can access it easily.
			// This comes in handy at this point, where we need foreach capability
			// to save the settings, but don't want to grant it to the users of
			// the class. These users would be anything outside of the mdnaSettings
			// project, such as the Preferences form, etc, etc.
			//
			// This does NOT break the data-hiding paradigm this way, since we are
			// simply and explicitly granting selective access to a member and
			// denying it from others.

			
			return( false );
		}
		#endregion
	}
}
