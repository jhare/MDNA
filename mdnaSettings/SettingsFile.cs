using System;
using System.Xml;
using System.Xml.XPath; // XPath pwns. Call your mom.
using System.IO;
using System.Collections;
using System.Windows.Forms;

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
			Create( fileName );	
		}
		#endregion

		#region Member Functions

		public void Create( string path )
		{
			XmlTextWriter xml;

			if( path == "" )
			{
				return;
			}

			m_fileName = path;
			
			if( File.Exists( m_fileName ) == false )
			{
				xml = new XmlTextWriter( m_fileName, System.Text.Encoding.UTF8 );

				xml.Formatting = System.Xml.Formatting.Indented;

				xml.WriteStartDocument();

				xml.WriteStartElement( "mdna" );
				xml.WriteEndElement();

				xml.WriteEndDocument();

				xml.Close();
			}							
		}


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

			// If the file's not there, start one
			if( File.Exists( m_fileName ) == false )
			{
				Create( m_fileName );
			}

			XmlTextReader reader = new XmlTextReader( m_fileName );
			XmlDocument doc = new XmlDocument();
			doc.Load( reader );
			reader.Close();

			foreach( DictionaryEntry de in settings.m_settings )
			{
				// Create a new XML element for the key/value pair.
				XmlElement newEntry = doc.CreateElement( settings.Category );
				newEntry.SetAttribute( "name", (string)de.Key );
				newEntry.SetAttribute( "value", (string)de.Value );

				// Get a reference to the exact same entry, if it exists.
				XmlNode existingEntry;
				//MessageBox.Show( "//" + settings.Category + "/[name='" + (string)de.Key + "']" );
				XmlElement root = doc.DocumentElement;
				existingEntry = root.SelectSingleNode( "//" + settings.Category + "[@name='" + (string)de.Key + "']" );

				
				// If it doesn't exist, just add it. Otherwise, replace it.
				if( existingEntry == null )
				{
					root.AppendChild( newEntry );
				}
				else
				{
					root.ReplaceChild( newEntry, existingEntry );
				}

				doc.Save( m_fileName );
			}
			
			return( true );
		}

		public mdnaSettings.Settings Load( string category )
		{
			mdnaSettings.Settings result = new mdnaSettings.Settings();

			XPathDocument doc = new XPathDocument( m_fileName );
			XPathNavigator nav = doc.CreateNavigator();

			// Get the expression compiled.
			// We want all of the nodes in the category regardless of position or their attributes.
			XPathExpression expr;
			expr = nav.Compile( "//"+category ); 
			XPathNodeIterator iter = nav.Select(expr);

			result.Category = category;

			try
			{
				while( iter.MoveNext() )
				{
					result.Add( iter.Current.GetAttribute( "name", "" ), iter.Current.GetAttribute( "value", "" ) );
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( "Exception Caught: " + ex.Message );
			}
            
			return( result );
		}


		#endregion
	}
}
