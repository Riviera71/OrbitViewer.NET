using OrbitViewer.Applet;
using System.Windows.Forms;

namespace OrbitViewer.Application
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.scrollHorz = new System.Windows.Forms.HScrollBar();
            this.scrollVert = new System.Windows.Forms.VScrollBar();
            this.scrollZoom = new System.Windows.Forms.HScrollBar();
            this.btnRevPlay = new System.Windows.Forms.Button();
            this.btnRevStep = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnForStep = new System.Windows.Forms.Button();
            this.btnForPlay = new System.Windows.Forms.Button();
            this.cboTimestep = new System.Windows.Forms.ComboBox();
            this.cboCenter = new System.Windows.Forms.ComboBox();
            this.cboOrbits = new System.Windows.Forms.ComboBox();
            this.cbxDate = new System.Windows.Forms.CheckBox();
            this.cbxPlanet = new System.Windows.Forms.CheckBox();
            this.cbxDistance = new System.Windows.Forms.CheckBox();
            this.cbxObject = new System.Windows.Forms.CheckBox();
            this.lblCenter = new System.Windows.Forms.Label();
            this.lblOrbits = new System.Windows.Forms.Label();
            this.lblZoom = new System.Windows.Forms.Label();
            this.cboObject = new System.Windows.Forms.ComboBox();
            this.lblObject = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboObjectType = new System.Windows.Forms.ComboBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.lblObjectType = new System.Windows.Forms.Label();
            this.btnDate = new System.Windows.Forms.Button();
            this.orbitPanel = new OrbitViewer.Applet.OrbitPanel();
            this.cbxAxis = new System.Windows.Forms.CheckBox();
            this.cbxGrid = new System.Windows.Forms.CheckBox();
            this.cbxInfoObject = new System.Windows.Forms.CheckBox();
            this.cbxAntialiasing = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrollHorz
            // 
            this.scrollHorz.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scrollHorz.LargeChange = 1;
            this.scrollHorz.Location = new System.Drawing.Point(0, 494);
            this.scrollHorz.Maximum = 360;
            this.scrollHorz.Name = "scrollHorz";
            this.scrollHorz.Size = new System.Drawing.Size(704, 17);
            this.scrollHorz.TabIndex = 2;
            this.scrollHorz.Value = 255;
            this.scrollHorz.ValueChanged += new System.EventHandler(this.scrollHorz_ValueChanged);
            // 
            // scrollVert
            // 
            this.scrollVert.Dock = System.Windows.Forms.DockStyle.Right;
            this.scrollVert.LargeChange = 1;
            this.scrollVert.Location = new System.Drawing.Point(687, 0);
            this.scrollVert.Maximum = 180;
            this.scrollVert.Name = "scrollVert";
            this.scrollVert.Size = new System.Drawing.Size(17, 494);
            this.scrollVert.TabIndex = 1;
            this.scrollVert.Value = 130;
            this.scrollVert.ValueChanged += new System.EventHandler(this.scrollVert_ValueChanged);
            // 
            // scrollZoom
            // 
            this.scrollZoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scrollZoom.Location = new System.Drawing.Point(353, 118);
            this.scrollZoom.Maximum = 1000;
            this.scrollZoom.Minimum = 5;
            this.scrollZoom.Name = "scrollZoom";
            this.scrollZoom.Size = new System.Drawing.Size(250, 17);
            this.scrollZoom.TabIndex = 17;
            this.scrollZoom.Value = 67;
            this.scrollZoom.ValueChanged += new System.EventHandler(this.scrollZoom_ValueChanged);
            // 
            // btnRevPlay
            // 
            this.btnRevPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRevPlay.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRevPlay.Location = new System.Drawing.Point(174, 36);
            this.btnRevPlay.Name = "btnRevPlay";
            this.btnRevPlay.Size = new System.Drawing.Size(31, 23);
            this.btnRevPlay.TabIndex = 2;
            this.btnRevPlay.Text = "<<";
            this.btnRevPlay.UseVisualStyleBackColor = true;
            this.btnRevPlay.Click += new System.EventHandler(this.btnRevPlay_Click);
            // 
            // btnRevStep
            // 
            this.btnRevStep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRevStep.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRevStep.Location = new System.Drawing.Point(207, 36);
            this.btnRevStep.Name = "btnRevStep";
            this.btnRevStep.Size = new System.Drawing.Size(31, 23);
            this.btnRevStep.TabIndex = 3;
            this.btnRevStep.Text = "|<";
            this.btnRevStep.UseVisualStyleBackColor = true;
            this.btnRevStep.Click += new System.EventHandler(this.btnRevStep_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStop.Location = new System.Drawing.Point(240, 36);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(31, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "||";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnForStep
            // 
            this.btnForStep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnForStep.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnForStep.Location = new System.Drawing.Point(273, 36);
            this.btnForStep.Name = "btnForStep";
            this.btnForStep.Size = new System.Drawing.Size(31, 23);
            this.btnForStep.TabIndex = 5;
            this.btnForStep.Text = ">|";
            this.btnForStep.UseVisualStyleBackColor = true;
            this.btnForStep.Click += new System.EventHandler(this.btnForStep_Click);
            // 
            // btnForPlay
            // 
            this.btnForPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnForPlay.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnForPlay.Location = new System.Drawing.Point(306, 36);
            this.btnForPlay.Name = "btnForPlay";
            this.btnForPlay.Size = new System.Drawing.Size(31, 23);
            this.btnForPlay.TabIndex = 6;
            this.btnForPlay.Text = ">>";
            this.btnForPlay.UseVisualStyleBackColor = true;
            this.btnForPlay.Click += new System.EventHandler(this.btnForPlay_Click);
            // 
            // cboTimestep
            // 
            this.cboTimestep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboTimestep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimestep.FormattingEnabled = true;
            this.cboTimestep.Location = new System.Drawing.Point(175, 62);
            this.cboTimestep.Name = "cboTimestep";
            this.cboTimestep.Size = new System.Drawing.Size(161, 21);
            this.cboTimestep.TabIndex = 7;
            this.cboTimestep.SelectedIndexChanged += new System.EventHandler(this.cboTimestep_SelectedIndexChanged);
            // 
            // cboCenter
            // 
            this.cboCenter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCenter.FormattingEnabled = true;
            this.cboCenter.Location = new System.Drawing.Point(175, 89);
            this.cboCenter.Name = "cboCenter";
            this.cboCenter.Size = new System.Drawing.Size(161, 21);
            this.cboCenter.TabIndex = 9;
            this.cboCenter.SelectedIndexChanged += new System.EventHandler(this.cboCenter_SelectedIndexChanged);
            // 
            // cboOrbits
            // 
            this.cboOrbits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboOrbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrbits.FormattingEnabled = true;
            this.cboOrbits.Location = new System.Drawing.Point(175, 116);
            this.cboOrbits.Name = "cboOrbits";
            this.cboOrbits.Size = new System.Drawing.Size(161, 21);
            this.cboOrbits.TabIndex = 11;
            this.cboOrbits.SelectedIndexChanged += new System.EventHandler(this.cboOrbits_SelectedIndexChanged);
            // 
            // cbxDate
            // 
            this.cbxDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDate.AutoSize = true;
            this.cbxDate.Checked = true;
            this.cbxDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDate.Location = new System.Drawing.Point(353, 39);
            this.cbxDate.Name = "cbxDate";
            this.cbxDate.Size = new System.Drawing.Size(77, 17);
            this.cbxDate.TabIndex = 12;
            this.cbxDate.Text = "Date Label";
            this.cbxDate.UseVisualStyleBackColor = true;
            this.cbxDate.CheckedChanged += new System.EventHandler(this.cbxDate_CheckedChanged);
            // 
            // cbxPlanet
            // 
            this.cbxPlanet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxPlanet.AutoSize = true;
            this.cbxPlanet.Checked = true;
            this.cbxPlanet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPlanet.Location = new System.Drawing.Point(456, 39);
            this.cbxPlanet.Name = "cbxPlanet";
            this.cbxPlanet.Size = new System.Drawing.Size(89, 17);
            this.cbxPlanet.TabIndex = 13;
            this.cbxPlanet.Text = "Planet Labels";
            this.cbxPlanet.UseVisualStyleBackColor = true;
            this.cbxPlanet.CheckedChanged += new System.EventHandler(this.cbxPlanet_CheckedChanged);
            // 
            // cbxDistance
            // 
            this.cbxDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxDistance.AutoSize = true;
            this.cbxDistance.Checked = true;
            this.cbxDistance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDistance.Location = new System.Drawing.Point(353, 64);
            this.cbxDistance.Name = "cbxDistance";
            this.cbxDistance.Size = new System.Drawing.Size(67, 17);
            this.cbxDistance.TabIndex = 14;
            this.cbxDistance.Text = "Distance";
            this.cbxDistance.UseVisualStyleBackColor = true;
            this.cbxDistance.CheckedChanged += new System.EventHandler(this.cbxDistance_CheckedChanged);
            // 
            // cbxObject
            // 
            this.cbxObject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxObject.AutoSize = true;
            this.cbxObject.Checked = true;
            this.cbxObject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxObject.Location = new System.Drawing.Point(456, 64);
            this.cbxObject.Name = "cbxObject";
            this.cbxObject.Size = new System.Drawing.Size(86, 17);
            this.cbxObject.TabIndex = 15;
            this.cbxObject.Text = "Object Label";
            this.cbxObject.UseVisualStyleBackColor = true;
            this.cbxObject.CheckedChanged += new System.EventHandler(this.cbxObject_CheckedChanged);
            // 
            // lblCenter
            // 
            this.lblCenter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCenter.AutoSize = true;
            this.lblCenter.Location = new System.Drawing.Point(110, 92);
            this.lblCenter.Name = "lblCenter";
            this.lblCenter.Size = new System.Drawing.Size(44, 13);
            this.lblCenter.TabIndex = 8;
            this.lblCenter.Text = "Center:";
            // 
            // lblOrbits
            // 
            this.lblOrbits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrbits.AutoSize = true;
            this.lblOrbits.Location = new System.Drawing.Point(110, 119);
            this.lblOrbits.Name = "lblOrbits";
            this.lblOrbits.Size = new System.Drawing.Size(40, 13);
            this.lblOrbits.TabIndex = 10;
            this.lblOrbits.Text = "Orbits:";
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(350, 92);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(37, 13);
            this.lblZoom.TabIndex = 16;
            this.lblZoom.Text = "Zoom:";
            // 
            // cboObject
            // 
            this.cboObject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObject.FormattingEnabled = true;
            this.cboObject.IntegralHeight = false;
            this.cboObject.Location = new System.Drawing.Point(399, 3);
            this.cboObject.MaxDropDownItems = 15;
            this.cboObject.Name = "cboObject";
            this.cboObject.Size = new System.Drawing.Size(161, 21);
            this.cboObject.TabIndex = 3;
            this.cboObject.SelectedIndexChanged += new System.EventHandler(this.cboObject_SelectedIndexChanged);
            // 
            // lblObject
            // 
            this.lblObject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblObject.AutoSize = true;
            this.lblObject.Location = new System.Drawing.Point(350, 6);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(43, 13);
            this.lblObject.TabIndex = 2;
            this.lblObject.Text = "Object:";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.cbxAntialiasing);
            this.pnlBottom.Controls.Add(this.cbxInfoObject);
            this.pnlBottom.Controls.Add(this.cbxGrid);
            this.pnlBottom.Controls.Add(this.cbxAxis);
            this.pnlBottom.Controls.Add(this.panel1);
            this.pnlBottom.Controls.Add(this.btnDate);
            this.pnlBottom.Controls.Add(this.lblCenter);
            this.pnlBottom.Controls.Add(this.scrollZoom);
            this.pnlBottom.Controls.Add(this.lblOrbits);
            this.pnlBottom.Controls.Add(this.btnRevPlay);
            this.pnlBottom.Controls.Add(this.cboOrbits);
            this.pnlBottom.Controls.Add(this.btnRevStep);
            this.pnlBottom.Controls.Add(this.cboCenter);
            this.pnlBottom.Controls.Add(this.btnStop);
            this.pnlBottom.Controls.Add(this.btnForStep);
            this.pnlBottom.Controls.Add(this.btnForPlay);
            this.pnlBottom.Controls.Add(this.cboTimestep);
            this.pnlBottom.Controls.Add(this.cbxDate);
            this.pnlBottom.Controls.Add(this.cbxPlanet);
            this.pnlBottom.Controls.Add(this.lblZoom);
            this.pnlBottom.Controls.Add(this.cbxDistance);
            this.pnlBottom.Controls.Add(this.cbxObject);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 511);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(704, 150);
            this.pnlBottom.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.cboObject);
            this.panel1.Controls.Add(this.lblObject);
            this.panel1.Controls.Add(this.cboObjectType);
            this.panel1.Controls.Add(this.btnAbout);
            this.panel1.Controls.Add(this.lblObjectType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 27);
            this.panel1.TabIndex = 0;
            // 
            // cboObjectType
            // 
            this.cboObjectType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboObjectType.FormattingEnabled = true;
            this.cboObjectType.IntegralHeight = false;
            this.cboObjectType.Location = new System.Drawing.Point(175, 3);
            this.cboObjectType.MaxDropDownItems = 15;
            this.cboObjectType.Name = "cboObjectType";
            this.cboObjectType.Size = new System.Drawing.Size(161, 21);
            this.cboObjectType.TabIndex = 1;
            this.cboObjectType.SelectedIndexChanged += new System.EventHandler(this.cboObjectType_SelectedIndexChanged);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAbout.Location = new System.Drawing.Point(679, 2);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(23, 23);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.Text = "?";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // lblObjectType
            // 
            this.lblObjectType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.Location = new System.Drawing.Point(110, 6);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(43, 13);
            this.lblObjectType.TabIndex = 0;
            this.lblObjectType.Text = "Object:";
            // 
            // btnDate
            // 
            this.btnDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDate.Location = new System.Drawing.Point(110, 36);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(60, 48);
            this.btnDate.TabIndex = 1;
            this.btnDate.Text = "Date";
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // orbitPanel
            // 
            this.orbitPanel.BackColor = System.Drawing.Color.Black;
            this.orbitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orbitPanel.Location = new System.Drawing.Point(0, 0);
            this.orbitPanel.MinimumSize = new System.Drawing.Size(687, 472);
            this.orbitPanel.Name = "orbitPanel";
            this.orbitPanel.Size = new System.Drawing.Size(687, 494);
            this.orbitPanel.TabIndex = 0;
            this.orbitPanel.SizeChanged += new System.EventHandler(this.orbitPanel_SizeChanged);
            // 
            // cbxAxis
            // 
            this.cbxAxis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxAxis.AutoSize = true;
            this.cbxAxis.Checked = true;
            this.cbxAxis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAxis.Location = new System.Drawing.Point(551, 39);
            this.cbxAxis.Name = "cbxAxis";
            this.cbxAxis.Size = new System.Drawing.Size(46, 17);
            this.cbxAxis.TabIndex = 18;
            this.cbxAxis.Text = "Axis";
            this.cbxAxis.UseVisualStyleBackColor = true;
            this.cbxAxis.CheckedChanged += new System.EventHandler(this.cbxAxis_CheckedChanged);
            // 
            // cbxGrid
            // 
            this.cbxGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxGrid.AutoSize = true;
            this.cbxGrid.Checked = true;
            this.cbxGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxGrid.Location = new System.Drawing.Point(551, 64);
            this.cbxGrid.Name = "cbxGrid";
            this.cbxGrid.Size = new System.Drawing.Size(45, 17);
            this.cbxGrid.TabIndex = 19;
            this.cbxGrid.Text = "Grid";
            this.cbxGrid.UseVisualStyleBackColor = true;
            this.cbxGrid.CheckedChanged += new System.EventHandler(this.cbxGrid_CheckedChanged);
            // 
            // cbxInfoObject
            // 
            this.cbxInfoObject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxInfoObject.AutoSize = true;
            this.cbxInfoObject.Checked = true;
            this.cbxInfoObject.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxInfoObject.Location = new System.Drawing.Point(603, 41);
            this.cbxInfoObject.Name = "cbxInfoObject";
            this.cbxInfoObject.Size = new System.Drawing.Size(81, 17);
            this.cbxInfoObject.TabIndex = 20;
            this.cbxInfoObject.Text = "Info Object";
            this.cbxInfoObject.UseVisualStyleBackColor = true;
            this.cbxInfoObject.CheckedChanged += new System.EventHandler(this.cbxInfoObject_CheckedChanged);
            // 
            // cbxAntialiasing
            // 
            this.cbxAntialiasing.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxAntialiasing.AutoSize = true;
            this.cbxAntialiasing.Checked = true;
            this.cbxAntialiasing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAntialiasing.Location = new System.Drawing.Point(603, 64);
            this.cbxAntialiasing.Name = "cbxAntialiasing";
            this.cbxAntialiasing.Size = new System.Drawing.Size(80, 17);
            this.cbxAntialiasing.TabIndex = 21;
            this.cbxAntialiasing.Text = "Antialiasing";
            this.cbxAntialiasing.UseVisualStyleBackColor = true;
            this.cbxAntialiasing.CheckedChanged += new System.EventHandler(this.cbxAntialiasing_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 661);
            this.Controls.Add(this.orbitPanel);
            this.Controls.Add(this.scrollVert);
            this.Controls.Add(this.scrollHorz);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(720, 700);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrbitViewer.NET";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.HScrollBar scrollHorz;
		private System.Windows.Forms.VScrollBar scrollVert;
		private System.Windows.Forms.HScrollBar scrollZoom;
		private System.Windows.Forms.Button btnRevPlay;
		private System.Windows.Forms.Button btnRevStep;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnForStep;
		private System.Windows.Forms.Button btnForPlay;
		private System.Windows.Forms.ComboBox cboTimestep;
		private System.Windows.Forms.ComboBox cboCenter;
		private System.Windows.Forms.ComboBox cboOrbits;
		private System.Windows.Forms.CheckBox cbxDate;
		private System.Windows.Forms.CheckBox cbxPlanet;
		private System.Windows.Forms.CheckBox cbxDistance;
		private System.Windows.Forms.CheckBox cbxObject;
		private System.Windows.Forms.Label lblCenter;
		private System.Windows.Forms.Label lblOrbits;
		private System.Windows.Forms.Label lblZoom;
		private OrbitViewer.Applet.OrbitPanel orbitPanel;
		private ComboBox cboObject;
		private Label lblObject;
		private Panel pnlBottom;
		private Label lblObjectType;
		private ComboBox cboObjectType;
		private Button btnAbout;
		private Button btnDate;
		private Panel panel1;
        private CheckBox cbxAntialiasing;
        private CheckBox cbxInfoObject;
        private CheckBox cbxGrid;
        private CheckBox cbxAxis;
    }
}

