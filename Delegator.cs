using System;
using ESRI.ArcGIS.Framework;

namespace mdna
{
	/// <summary>
	/// Delegator is responsible for the actual concert of operations that each
	/// of the commands intend to invoke. It may seem odd to take these out of
	/// the Cmd objects themselves, but there would be duplicate calls between
	/// the "DoAll" command and the seperate CollarReplace command and the
	/// AdjustGrid command.
	/// </summary>
	public class Delegator
	{
		public Delegator()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool AdjustGrid( IApplication hook )
		{
			return( false );
		}

		public bool CollarReplace( IApplication hook )
		{
			return( false );
		}
	}
}
