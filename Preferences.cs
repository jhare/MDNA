using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdna
{
	/// <summary>
	/// Summary description for Preferences.
	/// </summary>
	public class Preferences : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Preferences()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmdOK
			// 
			this.cmdOK.Location = new System.Drawing.Point(120, 240);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 0;
			this.cmdOK.Text = "&OK";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Location = new System.Drawing.Point(208, 240);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 1;
			this.cmdCancel.Text = "&Cancel";
			// 
			// Preferences
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Name = "Preferences";
			this.Text = "Preferences";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
