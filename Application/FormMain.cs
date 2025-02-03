using OrbitViewer.Applet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CenteredObjectEnum = OrbitViewer.Applet.OrbitPanel.CenteredObjectEnum;
using OrbitsEnum = OrbitViewer.Applet.OrbitPanel.OrbitsEnum;

namespace OrbitViewer.Application
{
	public partial class FormMain : Form
	{
		#region + Consts

		#region ObjectType

		private const string TypeComet = "Comet";
		private const string TypeAsteroid = "Asteroid";

		#endregion

		#region CenterObject

		readonly string[] CenterObjectItems = {
			"Sun",
			"Comet/Asteroid",
			"Mercury",
			"Venus",
			"Earth",
			"Mars",
			"Jupiter",
			"Saturn",
			"Uranus",
			"Neptune",
			"Pluto"
		};

		#endregion

		#region OrbitsDisplay

		readonly string[] OrbitsDisplayItems = {
			"Default Orbits",
			"All Orbits",
			"No Orbits",
			"------",
			"Comet/Asteroid",
			"Mercury",
			"Venus",
			"Earth",
			"Mars",
			"Jupiter",
			"Saturn",
			"Uranus",
			"Neptune",
			"Pluto"
		};


		#endregion

		#region TimeStep

		readonly string[] TimeStepItems = {
            "1 Second",
            "1 Minut",
			"1 Hour",
			"1 Day",
			"3 Days",
			"10 Days",
			"1 Month",
			"3 Months",
			"6 Months",
			"1 Year"
		};

		static ATimeSpan[] timeStepSpan = {
			new ATimeSpan(0, 0,  0, 0, 0, 1.0),
			new ATimeSpan(0, 0,  0, 0, 1, 0.0),
			new ATimeSpan(0, 0,  0, 1, 0, 0.0),
			new ATimeSpan(0, 0,  1, 0, 0, 0.0),
			new ATimeSpan(0, 0,  3, 0, 0, 0.0),
			new ATimeSpan(0, 0, 10, 0, 0, 0.0),
			new ATimeSpan(0, 1,  0, 0, 0, 0.0),
			new ATimeSpan(0, 3,  0, 0, 0, 0.0),
			new ATimeSpan(0, 6,  0, 0, 0, 0.0),
			new ATimeSpan(1, 0,  0, 0, 0, 0.0)
		};

		#endregion

		#region Default values

		const int InitialScrollVert = 180;
		const int InitialScrollHorz = 270;
		const int InitialScrollZoom = 200;

		//OrbitDisplayEnum
		bool[] OrbitDisplayDefault = { true, true, true, true, true, true, false, false, false, false };
		bool[] OrbitDisplay = { true, true, true, true, true, true, false, false, false, false };

		#endregion

		#endregion

		#region Properties

		private bool IsMouseWheelZoom { get; set; }
		private Point StartDrag { get; set; }

		private Timer Timer { get; set; }
		private ATimeSpan TimeStep { get; set; }
		private int SimulationDirection { get; set; }

		private List<Comet> Objects { get; set; }
		private Comet SelectedObject { get; set; }

		#endregion

		#region Constructor

		public FormMain()
		{
			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

			InitializeComponent();

			Timer = new Timer();
			Timer.Interval = 50;
			Timer.Tick += new System.EventHandler(this.timer_Tick);
		}

		#endregion

		#region + EventHandling

		#region Form

		private void FormMain_Load(object sender, EventArgs ev)
		{
			scrollVert.Value = InitialScrollVert;
			scrollHorz.Value = InitialScrollHorz;
			scrollZoom.Value = InitialScrollZoom;

			orbitPanel.RotateVert = (double)(180 - scrollVert.Value);
			orbitPanel.RotateHorz = (double)(270 - scrollHorz.Value);
			orbitPanel.Zoom = (double)scrollZoom.Value;

			cboCenter.DataSource = CenterObjectItems;
			cboCenter.SelectedIndex = (int)CenteredObjectEnum.Sun;

			cboOrbits.DataSource = OrbitsDisplayItems;
			cboOrbits.SelectedIndex = (int)OrbitsEnum.AllOrbits;

			cboTimestep.DataSource = TimeStepItems;
			cboTimestep.SelectedIndex = 3;

			orbitPanel.ShowPlanetName = cbxPlanet.Checked;
			orbitPanel.ShowObjectName = cbxObject.Checked;
			orbitPanel.ShowDistanceLabel = cbxDistance.Checked;
			orbitPanel.ShowDateLabel = cbxDate.Checked;
            orbitPanel.ShowAxis = cbxAxis.Checked;
            orbitPanel.ShowGrid = cbxGrid.Checked;
            orbitPanel.ShowInfoObject = cbxInfoObject.Checked;
            orbitPanel.Antialiasing = cbxAntialiasing.Checked;

            cboObjectType.DataSource = new string[] { TypeComet, TypeAsteroid };
			SetObjectDataSource();

			orbitPanel.PaintEnabled = true;
			orbitPanel.LoadPanel(SelectedObject, new ATime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0.0));
			orbitPanel.Invalidate();
		}

		#endregion

		#region OrbitPanel

		private void orbitPanel_SizeChanged(object sender, EventArgs e)
		{
			orbitPanel.Offscreen = null;
			orbitPanel.Invalidate();
		}

		#endregion

		#region Button

		private void btnDate_Click(object sender, EventArgs e)
		{
			using (FormDate fd = new FormDate(orbitPanel.ATime))
			{
				if (fd.ShowDialog() == DialogResult.OK)
				{
					Timer.Stop();
					orbitPanel.ATime = fd.ATime;
					orbitPanel.Invalidate();
				}
			}
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			using (FormAbout fa = new FormAbout())
			{
				fa.ShowDialog();
			}
		}

		#endregion

		#region ScrollBars

		private void scrollVert_ValueChanged(object sender, EventArgs e)
		{
			orbitPanel.RotateVert = (double)(180 - scrollVert.Value);
			orbitPanel.Invalidate();
		}

		private void scrollHorz_ValueChanged(object sender, EventArgs e)
		{
			orbitPanel.RotateHorz = (double)(270 - scrollHorz.Value);
			orbitPanel.Invalidate();
		}

		private void scrollZoom_ValueChanged(object sender, EventArgs e)
		{
			orbitPanel.Zoom = (double)scrollZoom.Value;
			orbitPanel.Invalidate();
		}

		#endregion

		#region Simulation

		private void btnRevPlay_Click(object sender, EventArgs e)
		{
			SimulationDirection = ATime.TIME_DECREMENT;
			Timer.Start();
		}

		private void btnRevStep_Click(object sender, EventArgs e)
		{
			Timer.Stop();
			ATime atime = orbitPanel.ATime;
			atime.ChangeDate(TimeStep, ATime.TIME_DECREMENT);
			orbitPanel.ATime = atime;
			orbitPanel.Invalidate();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			Timer.Stop();
		}

		private void btnForStep_Click(object sender, EventArgs e)
		{
			Timer.Stop();
			ATime atime = orbitPanel.ATime;
			atime.ChangeDate(TimeStep, ATime.TIME_INCREMENT);
			orbitPanel.ATime = atime;
			orbitPanel.Invalidate();
		}

		private void btnForPlay_Click(object sender, EventArgs e)
		{
			SimulationDirection = ATime.TIME_INCREMENT;
			Timer.Start();
		}

		private void cboTimestep_SelectedIndexChanged(object sender, EventArgs e)
		{
			TimeStep = timeStepSpan[cboTimestep.SelectedIndex];
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			ATime atime = orbitPanel.ATime;
			atime.ChangeDate(TimeStep, SimulationDirection);
			orbitPanel.ATime = atime;
			orbitPanel.Invalidate();
		}

		#endregion

		#region ComboBoxes

		private void cboObjectType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetObjectDataSource();
		}

		private void cboObject_SelectedIndexChanged(object sender, EventArgs e)
		{
			Timer.Stop();

			SelectedObject = Objects.ElementAt(cboObject.SelectedIndex);
			orbitPanel.LoadPanel(SelectedObject, orbitPanel.ATime);
			orbitPanel.Invalidate();
		}

		private void cboCenter_SelectedIndexChanged(object sender, EventArgs e)
		{
			orbitPanel.CenterObjectSelected = cboCenter.SelectedIndex;
			orbitPanel.Invalidate();
		}

		private void cboOrbits_SelectedIndexChanged(object sender, EventArgs e)
		{
			int index = cboOrbits.SelectedIndex;

			if (index == (int)OrbitsEnum.Default)
			{
				for (int i = 0; i < OrbitDisplay.Length; i++)
					OrbitDisplay[i] = OrbitDisplayDefault[i];
			}
			else if (index == (int)OrbitsEnum.AllOrbits)
			{
				for (int i = 0; i < OrbitDisplay.Length; i++)
					OrbitDisplay[i] = true;
			}
			else if (index == (int)OrbitsEnum.NoOrbits)
			{
				for (int i = 0; i < OrbitDisplay.Length; i++)
					OrbitDisplay[i] = false;
			}
			else if (index == (int)OrbitsEnum.Separator)
			{
				return;
			}
			else if (index >= (int)OrbitsEnum.CometAsteroid)
			{
				OrbitDisplay[index - 4] = !OrbitDisplay[index - 4];
			}

			orbitPanel.SelectOrbits(OrbitDisplay);
			orbitPanel.Invalidate();
		}

		#endregion

		#region CheckBoxes

		private void cbxObject_CheckedChanged(object sender, EventArgs e)
		{
			orbitPanel.ShowObjectName = cbxObject.Checked;
			orbitPanel.Invalidate();
		}

		private void cbxPlanet_CheckedChanged(object sender, EventArgs e)
		{
			orbitPanel.ShowPlanetName = cbxPlanet.Checked;
			orbitPanel.Invalidate();
		}

		private void cbxDistance_CheckedChanged(object sender, EventArgs e)
		{
			orbitPanel.ShowDistanceLabel = cbxDistance.Checked;
			orbitPanel.Invalidate();
		}

		private void cbxDate_CheckedChanged(object sender, EventArgs e)
		{
			orbitPanel.ShowDateLabel = cbxDate.Checked;
			orbitPanel.Invalidate();
		}

		private void cbxAxis_CheckedChanged(object sender, EventArgs e)
		{
			orbitPanel.ShowAxis = cbxAxis.Checked;
			orbitPanel.Invalidate();
		}

		private void cbxGrid_CheckedChanged(object sender, EventArgs e)
		{
			orbitPanel.ShowGrid = cbxGrid.Checked;
			orbitPanel.Invalidate();
		}

		private void cbxInfoObject_CheckedChanged(object sender, EventArgs e)
		{
			orbitPanel.ShowInfoObject = cbxInfoObject.Checked;
			orbitPanel.Invalidate();
		}

		private void cbxAntialiasing_CheckedChanged(object sender, EventArgs e)
		{
			orbitPanel.Antialiasing = cbxAntialiasing.Checked;
			orbitPanel.Invalidate();
		}

		#endregion

		#endregion

		#region Methods

		private void SetObjectDataSource()
		{
			string type = cboObjectType.SelectedValue.ToString();

			switch (type)
			{
				case TypeComet:
					Objects = ImportUtil.ImportComets();
					break;
				case TypeAsteroid:
					Objects = ImportUtil.ImportAsteroids();
					break;
			}

			lblObject.Text = type + ":";
			cboObject.DisplayMember = "Name";
			cboObject.DataSource = Objects;
		}

		#endregion
	}
}