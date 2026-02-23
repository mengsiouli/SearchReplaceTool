using System.Windows.Forms;

namespace SearchReplaceTool
{
	partial class FrmStrSearchReplace
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) ) {
				components.Dispose();
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
			this.m_txbSearch = new System.Windows.Forms.TextBox();
			this.m_txbReplace = new System.Windows.Forms.TextBox();
			this.m_txbDocumentInput = new System.Windows.Forms.TextBox();
			this.m_lblSearchInput = new System.Windows.Forms.Label();
			this.m_lblReplaceInput = new System.Windows.Forms.Label();
			this.m_btnSearch = new System.Windows.Forms.Button();
			this.m_btnReplace = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_txbSearch
			// 
			this.m_txbSearch.Font = new System.Drawing.Font( "Microsoft JhengHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.m_txbSearch.Location = new System.Drawing.Point( 214, 491 );
			this.m_txbSearch.Margin = new System.Windows.Forms.Padding( 5, 5, 5, 5 );
			this.m_txbSearch.Multiline = true;
			this.m_txbSearch.Name = "m_txbSearch";
			this.m_txbSearch.Size = new System.Drawing.Size( 303, 63 );
			this.m_txbSearch.TabIndex = 1;
			// 
			// m_txbReplace
			// 
			this.m_txbReplace.Font = new System.Drawing.Font( "Microsoft JhengHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.m_txbReplace.Location = new System.Drawing.Point( 214, 616 );
			this.m_txbReplace.Margin = new System.Windows.Forms.Padding( 5, 5, 5, 5 );
			this.m_txbReplace.Multiline = true;
			this.m_txbReplace.Name = "m_txbReplace";
			this.m_txbReplace.Size = new System.Drawing.Size( 303, 65 );
			this.m_txbReplace.TabIndex = 4;
			// 
			// m_txbDocumentInput
			// 
			this.m_txbDocumentInput.Font = new System.Drawing.Font( "Microsoft JhengHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.m_txbDocumentInput.Location = new System.Drawing.Point( 81, 51 );
			this.m_txbDocumentInput.Margin = new System.Windows.Forms.Padding( 5, 5, 5, 5 );
			this.m_txbDocumentInput.Multiline = true;
			this.m_txbDocumentInput.Name = "m_txbDocumentInput";
			this.m_txbDocumentInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txbDocumentInput.Size = new System.Drawing.Size( 622, 369 );
			this.m_txbDocumentInput.TabIndex = 0;
			this.m_txbDocumentInput.TextChanged += new System.EventHandler( this.m_txbDocumentInput_TextChanged );
			// 
			// m_lblSearchInput
			// 
			this.m_lblSearchInput.AutoSize = true;
			this.m_lblSearchInput.Font = new System.Drawing.Font( "Microsoft JhengHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.m_lblSearchInput.Location = new System.Drawing.Point( 72, 496 );
			this.m_lblSearchInput.Margin = new System.Windows.Forms.Padding( 5, 0, 5, 0 );
			this.m_lblSearchInput.Name = "m_lblSearchInput";
			this.m_lblSearchInput.Size = new System.Drawing.Size( 133, 55 );
			this.m_lblSearchInput.TabIndex = 3;
			this.m_lblSearchInput.Text = "搜尋 :";
			// 
			// m_lblReplaceInput
			// 
			this.m_lblReplaceInput.AutoSize = true;
			this.m_lblReplaceInput.Font = new System.Drawing.Font( "Microsoft JhengHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.m_lblReplaceInput.Location = new System.Drawing.Point( 72, 622 );
			this.m_lblReplaceInput.Margin = new System.Windows.Forms.Padding( 5, 0, 5, 0 );
			this.m_lblReplaceInput.Name = "m_lblReplaceInput";
			this.m_lblReplaceInput.Size = new System.Drawing.Size( 133, 55 );
			this.m_lblReplaceInput.TabIndex = 6;
			this.m_lblReplaceInput.Text = "取代 :";
			// 
			// m_btnSearch
			// 
			this.m_btnSearch.Font = new System.Drawing.Font( "Microsoft JhengHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.m_btnSearch.Location = new System.Drawing.Point( 556, 491 );
			this.m_btnSearch.Margin = new System.Windows.Forms.Padding( 5, 5, 5, 5 );
			this.m_btnSearch.Name = "m_btnSearch";
			this.m_btnSearch.Size = new System.Drawing.Size( 150, 66 );
			this.m_btnSearch.TabIndex = 2;
			this.m_btnSearch.Text = "搜尋";
			this.m_btnSearch.UseVisualStyleBackColor = true;
			this.m_btnSearch.Click += new System.EventHandler( this.m_btnSearch_Click );
			// 
			// m_btnReplace
			// 
			this.m_btnReplace.Font = new System.Drawing.Font( "Microsoft JhengHei", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 136 ) ) );
			this.m_btnReplace.Location = new System.Drawing.Point( 556, 616 );
			this.m_btnReplace.Margin = new System.Windows.Forms.Padding( 5, 5, 5, 5 );
			this.m_btnReplace.Name = "m_btnReplace";
			this.m_btnReplace.Size = new System.Drawing.Size( 150, 69 );
			this.m_btnReplace.TabIndex = 5;
			this.m_btnReplace.Text = "取代";
			this.m_btnReplace.UseVisualStyleBackColor = true;
			this.m_btnReplace.Click += new System.EventHandler( this.m_btnReplace_Click );
			// 
			// FrmStrSearchReplace
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 13F, 24F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 791, 763 );
			this.Controls.Add( this.m_btnReplace );
			this.Controls.Add( this.m_btnSearch );
			this.Controls.Add( this.m_lblReplaceInput );
			this.Controls.Add( this.m_lblSearchInput );
			this.Controls.Add( this.m_txbDocumentInput );
			this.Controls.Add( this.m_txbReplace );
			this.Controls.Add( this.m_txbSearch );
			this.Margin = new System.Windows.Forms.Padding( 5, 5, 5, 5 );
			this.Name = "FrmStrSearchReplace";
			this.Text = "TextSearchReplace";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox m_txbSearch;
		private System.Windows.Forms.TextBox m_txbReplace;
		private System.Windows.Forms.TextBox m_txbDocumentInput;
		private System.Windows.Forms.Label m_lblSearchInput;
		private System.Windows.Forms.Label m_lblReplaceInput;
		private System.Windows.Forms.Button m_btnSearch;
		private System.Windows.Forms.Button m_btnReplace;
	}
}

