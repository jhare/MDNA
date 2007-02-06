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
	}
}
