using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace OrbitViewer.Applet
{
	public class OrbitPanel : Panel
	{
		#region Enum

		public enum OrbitsEnum
		{
			Default = 0,
			AllOrbits,
			NoOrbits,
			Separator, //------
			CometAsteroid,
			Mercury,
			Venus,
			Earth,
			Mars,
			Jupiter,
			Saturn,
			Uranus,
			Neptune,
			Pluto
		}

		public enum OrbitDisplayEnum
		{
			CometAsteroid = 0,
			Mercury,
			Venus,
			Earth,
			Mars,
			Jupiter,
			Saturn,
			Uranus,
			Neptune,
			Pluto
		}

		public enum CenteredObjectEnum
		{
			Sun = 0,
			CometAsteroid,
			Mercury,
			Venus,
			Earth,
			Mars,
			Jupiter,
			Saturn,
			Uranus,
			Neptune,
			Pluto
		}

		#endregion

		#region Properties

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Comet Comet { get; set; }

		private ATime atime;
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ATime ATime
		{
			get
			{
				return this.atime;
			}
			set
			{
				this.atime = value;
				UpdatePositions(atime);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Image Offscreen { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool PaintEnabled { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int CenterObjectSelected { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowPlanetName { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowObjectName { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowDistanceLabel { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowDateLabel { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowAxis { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowGrid { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool ShowInfoObject { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Antialiasing { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double RotateHorz { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double RotateVert { get; set; }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Zoom { get; set; }

		private CometOrbit ObjectOrbit { get; set; }
		private PlanetOrbit[] PlanetOrbit { get; set; }
		private double EpochPlanetOrbit { get; set; }
		private Xyz ObjectPos { get; set; }
		private Xyz[] PlanetPos { get; set; }
		private bool[] OrbitDisplay { get; set; }
		private Matrix MtxToEcl { get; set; }
		private double EpochToEcl { get; set; }
		private Matrix MtxRotate { get; set; }
		private int X0 { get; set; }
		private int Y0 { get; set; }

		#endregion

		#region Colors

		protected Color ColorObjectOrbitUpper = Color.FromArgb(0x7F, 0x00, 0xF5, 0xFF);
		protected Color ColorObjectOrbitLower = Color.FromArgb(0x7F, 0x00, 0x00, 0xFF);
		protected Color ColorObject = Color.FromArgb(0x00, 0xFF, 0xFF);
		protected Color ColorObjectName = Color.FromArgb(0x00, 0xcc, 0xcc);
		protected Color ColorPlanetOrbitUpper = Color.FromArgb(0xFF, 0xFF, 0xFF);
		protected Color ColorPlanetOrbitLower = Color.FromArgb(0x80, 0x80, 0x80);

		protected Color ColorMercuryOrbitUpper = Color.FromArgb(0x0ff, 0x00, 0xBB);
		protected Color ColorMercuryOrbitLower = Color.FromArgb(0x99, 0x00, 0x70);
		protected Color ColorVenusOrbitUpper = Color.FromArgb(0xA0, 0x70, 0xD0);
		protected Color ColorVenusOrbitLower = Color.FromArgb(0x60, 0x43, 0x7D);
		protected Color ColorEarthOrbitUpper = Color.FromArgb(0x20, 0xC0, 0xFF);
		protected Color ColorEarthOrbitLower = Color.FromArgb(0x13, 0x73, 0x99);
		protected Color ColorMarsOrbitUpper = Color.FromArgb(0xFF, 0x40, 0x10);
		protected Color ColorMarsOrbitLower = Color.FromArgb(0x99, 0x26, 0x0A);
		protected Color ColorJupiterOrbitUpper = Color.FromArgb(0xFF, 0xA0, 0x20);
		protected Color ColorJupiterOrbitLower = Color.FromArgb(0x99, 0x60, 0x13);
		protected Color ColorSaturnOrbitUpper = Color.FromArgb(0xF0, 0xFF, 0x40);
		protected Color ColorSaturnOrbitLower = Color.FromArgb(0x90, 0x99, 0x26);
		protected Color ColorUranusOrbitUpper = Color.FromArgb(0x40, 0xFF, 0xA0);
		protected Color ColorUranusOrbitLower = Color.FromArgb(0x26, 0x99, 0x60);
		protected Color ColorNeptuneOrbitUpper = Color.FromArgb(0x90, 0xD0, 0xF0);
		protected Color ColorNeptuneOrbitLower = Color.FromArgb(0x56, 0x7D, 0x90);

		protected Color ColorPlanet = Color.FromArgb(0xFF, 0xFF, 0xFF);
		protected Color ColorPlanetName = Color.FromArgb(0x00, 0xaa, 0x00);
		protected Color ColorSun = Color.FromArgb(0xFF, 0xFF, 0x00);
		protected Color ColorAxisPlus = Color.FromArgb(0xC1, 0xB0, 0x15);
		protected Color ColorAxisMinus = Color.FromArgb(0x67, 0x5E, 0x0B);
		protected Color Colorplane = Color.FromArgb(0x15, 0x15, 0x15);
		protected Color ColorInformation = Color.FromArgb(0xFF, 0xFF, 0xFF);

		#endregion

		#region Fonts

		protected Font FontObjectName = new Font("Helvetica", 10, FontStyle.Regular);
		protected Font FontPlanetName = new Font("Helvetica", 10, FontStyle.Regular);
		protected Font FontInformation = new Font("Helvetica", 10, FontStyle.Bold);

		#endregion

		#region Consctructor

		public OrbitPanel()
		{
			this.DoubleBuffered = true;

			PlanetPos = new Xyz[9];
			OrbitDisplay = new bool[11];
			PlanetOrbit = new PlanetOrbit[9];

			Offscreen = null;
			PaintEnabled = false;
		}

		#endregion

		#region LoadPanel

		public void LoadPanel(Comet comet, ATime atime)
		{
			Comet = comet;
			ATime = atime;

			ObjectOrbit = new CometOrbit(Comet, 1000);

			UpdatePositions(atime);
			UpdatePlanetOrbit(atime);
			UpdateRotationMatrix(atime);
		}

		#endregion

		#region OnPaint

		protected override void OnPaint(PaintEventArgs e)
		{
			if (PaintEnabled)
			{
				if (Offscreen == null)
					Offscreen = new Bitmap(Size.Width, Size.Height);

				Update(e.Graphics);
			}
		}

		#endregion

		#region Update

		public void Update(Graphics g)
		{
			Point point3;
			Xyz xyz, xyz1;

			// Calculate Drawing Parameter
			Matrix mtxRotH = Matrix.RotateZ(RotateHorz * Math.PI / 180.0);
			Matrix mtxRotV = Matrix.RotateX(RotateVert * Math.PI / 180.0);
			MtxRotate = mtxRotV.Mul(mtxRotH);

			X0 = Size.Width / 2;
			Y0 = Size.Height / 2;

			if (Math.Abs(EpochToEcl - ATime.JD) > 365.2422 * 5)
			{
				UpdateRotationMatrix(ATime);
			}

			if (CenterObjectSelected == (int)CenteredObjectEnum.CometAsteroid)
			{
				xyz = ObjectPos.Rotate(MtxToEcl).Rotate(MtxRotate);
				point3 = GetDrawPoint(xyz);

				X0 = Size.Width - point3.X;
				Y0 = Size.Height - point3.Y;
			}
			else if (CenterObjectSelected >= (int)CenteredObjectEnum.Mercury)
			{
				xyz = PlanetPos[CenterObjectSelected - 2].Rotate(MtxRotate);
				point3 = GetDrawPoint(xyz);

				X0 = Size.Width - point3.X;
				Y0 = Size.Height - point3.Y;
			}

			using (Graphics graphics = Graphics.FromImage(Offscreen))
			{
				if (Antialiasing)
				{
					// Set the SmoothingMode property to smooth the line.
					graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

					// Set the TextRenderingHint prDrawingoperty.
					graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
				}

				Pen pen = new Pen(Color.White,3.0f);

				// Clear background
				SolidBrush sb = new SolidBrush(Color.Black);
				graphics.FillRectangle(sb, 0, 0, Size.Width, Size.Height);

				if (ShowGrid)
				{
					DrawEclipticGrid(graphics);
				}

				if (ShowAxis)
				{
					DrawEclipticAxis(graphics);
				}

				// Draw Sun
				sb.Color = ColorSun;
				graphics.FillPie(sb, X0 - 2, Y0 - 2, 5, 5, 0, 360);

				// Draw Orbit of Object
				xyz = ObjectOrbit.GetAt(0).Rotate(MtxToEcl).Rotate(MtxRotate);
				Point point1, point2;
				point1 = GetDrawPoint(xyz);

				if (OrbitDisplay[(int)OrbitDisplayEnum.CometAsteroid])
				{
					for (int i = 1; i <= ObjectOrbit.Division; i++)
					{
						xyz = ObjectOrbit.GetAt(i).Rotate(MtxToEcl);
						pen.Color = xyz.Z >= 0.0 ? ColorObjectOrbitUpper : ColorObjectOrbitLower;
						xyz = xyz.Rotate(MtxRotate);
						point2 = GetDrawPoint(xyz);
						graphics.DrawLine(pen, point1.X, point1.Y, point2.X, point2.Y);

						point1 = point2;
					}
				}

				// Draw Object Body
				sb.Color = ColorObject;
				xyz = ObjectPos.Rotate(MtxToEcl).Rotate(MtxRotate);
				point1 = GetDrawPoint(xyz);
				graphics.FillPie(sb, point1.X - 1, point1.Y - 1, 3, 3, 0, 360);

				if (ShowObjectName)
				{
					sb.Color = ColorObjectName;
					graphics.DrawString(Comet.Name, FontObjectName, sb, point1.X + 5, point1.Y);
				}

				//  Draw Orbit of Planets
				if (Math.Abs(EpochPlanetOrbit - ATime.JD) > 365.2422 * 5)
				{
					UpdatePlanetOrbit(ATime);
				}

				double zoom = 30.0;

				if (Zoom * 39.5 >= zoom)
				{
					if (OrbitDisplay[(int)OrbitDisplayEnum.Pluto])
						DrawPlanetOrbit(graphics, PlanetOrbit[Planet.PLUTO - 1], ColorPlanetOrbitUpper, ColorPlanetOrbitLower);

					DrawPlanetBody(graphics, FontPlanetName, PlanetPos[8], "Pluto", ColorPlanetOrbitUpper);
				}

				if (Zoom * 30.1 >= zoom)
				{
					if (OrbitDisplay[(int)OrbitDisplayEnum.Neptune])
						DrawPlanetOrbit(graphics, PlanetOrbit[Planet.NEPTUNE - 1], ColorNeptuneOrbitUpper, ColorNeptuneOrbitLower);

					DrawPlanetBody(graphics, FontPlanetName, PlanetPos[7], "Neptune", ColorNeptuneOrbitUpper);
				}

				if (Zoom * 19.2 >= zoom)
				{

					if (OrbitDisplay[(int)OrbitDisplayEnum.Uranus])
						DrawPlanetOrbit(graphics, PlanetOrbit[Planet.URANUS - 1], ColorUranusOrbitUpper, ColorUranusOrbitLower);

					DrawPlanetBody(graphics, FontPlanetName, PlanetPos[6], "Uranus", ColorUranusOrbitUpper);
				}

				if (Zoom * 9.58 >= zoom)
				{
					if (OrbitDisplay[(int)OrbitDisplayEnum.Saturn])
						DrawPlanetOrbit(graphics, PlanetOrbit[Planet.SATURN - 1], ColorSaturnOrbitUpper, ColorSaturnOrbitLower);

					DrawPlanetBody(graphics, FontPlanetName, PlanetPos[5], "Saturn", ColorSaturnOrbitUpper);
				}

				if (Zoom * 5.2 >= zoom)
				{
					if (OrbitDisplay[(int)OrbitDisplayEnum.Jupiter])
						DrawPlanetOrbit(graphics, PlanetOrbit[Planet.JUPITER - 1], ColorJupiterOrbitUpper, ColorJupiterOrbitLower);

					DrawPlanetBody(graphics, FontPlanetName, PlanetPos[4], "Jupiter", ColorJupiterOrbitUpper);
				}

				if (Zoom * 1.524 >= zoom)
				{
					if (OrbitDisplay[(int)OrbitDisplayEnum.Mars])
						DrawPlanetOrbit(graphics, PlanetOrbit[Planet.MARS - 1], ColorMarsOrbitUpper, ColorMarsOrbitLower);

					DrawPlanetBody(graphics, FontPlanetName, PlanetPos[3], "Mars", ColorMarsOrbitUpper);
				}

				if (Zoom * 1.0 >= zoom)
				{
					if (OrbitDisplay[(int)OrbitDisplayEnum.Earth])
						DrawPlanetOrbit(graphics, PlanetOrbit[Planet.EARTH - 1], ColorEarthOrbitUpper, ColorEarthOrbitUpper);

					DrawPlanetBody(graphics, FontPlanetName, PlanetPos[2], "Earth", ColorEarthOrbitUpper);
				}

				if (Zoom * 0.723 >= zoom)
				{
					if (OrbitDisplay[(int)OrbitDisplayEnum.Venus])
						DrawPlanetOrbit(graphics, PlanetOrbit[Planet.VENUS - 1], ColorVenusOrbitUpper, ColorVenusOrbitLower);

					DrawPlanetBody(graphics, FontPlanetName, PlanetPos[1], "Venus", ColorVenusOrbitUpper);
				}

				if (Zoom * 0.387 >= zoom)
				{
					if (OrbitDisplay[(int)OrbitDisplayEnum.Mercury])
						DrawPlanetOrbit(graphics, PlanetOrbit[Planet.MERCURY - 1], ColorMercuryOrbitUpper, ColorMercuryOrbitLower);

					DrawPlanetBody(graphics, FontPlanetName, PlanetPos[0], "Mercury", ColorMercuryOrbitUpper);
				}

				// Information
				sb.Color = ColorInformation;

				// Object Name string
				int labelMargin = 8;
				double fontSize = (double)FontInformation.Size;

				point1.X = labelMargin;
				point1.Y = labelMargin;

				if (ShowInfoObject)
				{
					xyz = ObjectPos.Rotate(MtxToEcl);
					///xyz = ObjectOrbit.GetAt(0).Rotate(MtxToEcl); // Perihelie
					graphics.DrawString(Comet.Name, FontInformation, sb, point1.X, point1.Y);
					point1.Y = labelMargin + (int)(fontSize * 2);
					graphics.DrawString(string.Format("X: {0:#0.00000000}", xyz.X), FontInformation, sb, point1.X, point1.Y);
					point1.Y = labelMargin + (int)(fontSize * 4);
					graphics.DrawString(string.Format("Y: {0:#0.00000000}", xyz.Y), FontInformation, sb, point1.X, point1.Y);
					point1.Y = labelMargin + (int)(fontSize * 6);
					graphics.DrawString(string.Format("Z: {0:#0.00000000}", xyz.Z), FontInformation, sb, point1.X, point1.Y);
				}

				if (ShowDistanceLabel)
				{
					// Earth & Sun Distance
					double edistance, sdistance;
					double xdiff, ydiff, zdiff;
					string dstr, rstr;

					xyz = ObjectPos.Rotate(MtxToEcl).Rotate(MtxRotate);
					xyz1 = PlanetPos[2].Rotate(MtxRotate);
					sdistance = Math.Sqrt((xyz.X * xyz.X) + (xyz.Y * xyz.Y) + (xyz.Z * xyz.Z)) + .0005;
					xdiff = xyz.X - xyz1.X;
					ydiff = xyz.Y - xyz1.Y;
					zdiff = xyz.Z - xyz1.Z;
					edistance = Math.Sqrt((xdiff * xdiff) + (ydiff * ydiff) + (zdiff * zdiff)) + .0005;

					dstr = String.Format("Earth Distance: {0:#0.00000000} AU = {1:### ### ### ###} km", edistance, edistance * 149597870.700);
					rstr = String.Format("Sun Distance:   {0:#0.00000000} AU = {1:### ### ### ###} km", sdistance, sdistance * 149597870.700);

					point1.Y = Size.Height - labelMargin - (int)(fontSize * 3.5);
					graphics.DrawString(dstr, FontInformation, sb, point1.X, point1.Y);

					point1.Y = Size.Height - labelMargin - (int)(fontSize * 2.0);
					graphics.DrawString(rstr, FontInformation, sb, point1.X, point1.Y);
				}

				if (ShowDateLabel)
				{
					// Date string
					string strDate = String.Format("{0} {1:00} {2:00} {3:00}h{4:00}min{5:00}s UTC", ATime.Year, ATime.MonthAbbr(ATime.Month), ATime.Day, ATime.Hour, ATime.Minute, ATime.Second);
					point1.X = Size.Width - (int)graphics.MeasureString(strDate, FontInformation).Width - labelMargin;
					point1.Y = Size.Height - labelMargin - (int)(fontSize * 2.0);
					graphics.DrawString(strDate, FontInformation, sb, point1.X, point1.Y);
					string strJD = String.Format("Julian Day: {0:#0.000000}", atime.JD);
					point1.X = Size.Width - (int)graphics.MeasureString(strJD, FontInformation).Width - labelMargin;
					point1.Y = Size.Height - labelMargin - (int)(fontSize * 3.5);
					graphics.DrawString(strJD, FontInformation, sb, point1.X, point1.Y);

				}
			}

			g.DrawImage(Offscreen, 0, 0);
		}

		#endregion

		#region + Methods

		#region UpdatePositions

		private void UpdatePositions(ATime atime)
		{
			if (PaintEnabled)
			{
				ObjectPos = Comet.GetPos(atime.JD);

				for (int i = 0; i < 9; i++)
				{
					PlanetPos[i] = Planet.GetPos(Planet.MERCURY + i, atime);
				}
			}
		}

		#endregion

		#region UpdatePlanetOrbit

		private void UpdatePlanetOrbit(ATime atime)
		{
			if (PaintEnabled)
			{
				int nDivision = 300;

				for (int i = Planet.MERCURY; i <= Planet.PLUTO; i++)
				{
					PlanetOrbit[i - Planet.MERCURY] = new PlanetOrbit(i, atime, nDivision);
				}

				EpochPlanetOrbit = atime.JD;
			}
		}

		#endregion

		#region UpdateRotationMatrix

		private void UpdateRotationMatrix(ATime atime)
		{
			if (PaintEnabled)
			{
				Matrix mtxPrec = Matrix.PrecMatrix(Astro.JD2000, atime.JD);
				Matrix mtxEqt2Ecl = Matrix.RotateX(ATime.GetEp(atime.JD));
				MtxToEcl = mtxEqt2Ecl.Mul(mtxPrec);
				EpochToEcl = atime.JD;
			}
		}

		#endregion

		#region GetDrawPoint

		private Point GetDrawPoint(Xyz xyz)
		{
			double mul = (Zoom * (double)MinimumSize.Width) / (1500.0 * (1.0 + xyz.Z / 625.0));
			int X = X0 + (int)Math.Round(xyz.X * mul);
			int Y = Y0 - (int)Math.Round(xyz.Y * mul);
			return new Point(X, Y);
		}

		#endregion

		#region DrawPlanetOrbit

		private void DrawPlanetOrbit(Graphics graphics, PlanetOrbit planetOrbit, Color colorUpper, Color colorLower)
		{
			Pen pen = new Pen(colorUpper,3.0f);
			Point point1, point2;
			Xyz xyz = planetOrbit.GetAt(0).Rotate(MtxToEcl).Rotate(MtxRotate);

			point1 = GetDrawPoint(xyz);

			for (int i = 1; i <= planetOrbit.Division; i++)
			{
				xyz = planetOrbit.GetAt(i).Rotate(MtxToEcl);

				pen.Color = xyz.Z >= 0.0 ? colorUpper : colorLower;

				xyz = xyz.Rotate(MtxRotate);
				point2 = GetDrawPoint(xyz);
				graphics.DrawLine(pen, point1.X, point1.Y, point2.X, point2.Y);
				point1 = point2;
			}
		}

		#endregion

		#region DrawPlanetBody

		private void DrawPlanetBody(Graphics graphics, Font font, Xyz planetPos, string name, Color ColorPlanetName)
		{
			Xyz xyz = planetPos.Rotate(MtxRotate);
			Point point = GetDrawPoint(xyz);
			SolidBrush sb = new SolidBrush(ColorPlanet);
			graphics.FillPie(sb, point.X - 1, point.Y - 1, 3, 3, 0, 360);

			if (ShowPlanetName)
			{
				sb.Color = ColorPlanetName;
				graphics.DrawString(name, font, sb, point.X + 5, point.Y);
			}
		}

		#endregion

		#region DrawEclipticAxis

		private void DrawEclipticAxis(Graphics graphics)
		{
			Pen pen = new Pen(ColorAxisMinus);
			Xyz xyz;
			Point point;
			double sizeAU = 50.0;

			// -X
			xyz = new Xyz(-sizeAU, 0.0, 0.0).Rotate(MtxRotate);
			point = GetDrawPoint(xyz);
			graphics.DrawLine(pen, X0, Y0, point.X, point.Y);

			// -Z
			xyz = new Xyz(0.0, 0.0, -sizeAU).Rotate(MtxRotate);
			point = GetDrawPoint(xyz);
			graphics.DrawLine(pen, X0, Y0, point.X, point.Y);

			pen.Color = ColorAxisPlus;

			// +X
			xyz = new Xyz(sizeAU, 0.0, 0.0).Rotate(MtxRotate);
			point = GetDrawPoint(xyz);
			graphics.DrawLine(pen, X0, Y0, point.X, point.Y);
			// +Z
			xyz = new Xyz(0.0, 0.0, sizeAU).Rotate(MtxRotate);
			point = GetDrawPoint(xyz);
			graphics.DrawLine(pen, X0, Y0, point.X, point.Y);
		}

		#endregion

		#region DrawEclipticGrid

		private void DrawEclipticGrid(Graphics graphics)
		{
			Pen pen = new Pen(Colorplane);
			///pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
			Xyz xyz;
			Point point1, point2;
			double sizeAU = 50.0;

			for (int y = 50; y > -51; y--)
			{
				xyz = new Xyz(-sizeAU, y, 0.0).Rotate(MtxRotate);
				point1 = GetDrawPoint(xyz);
				xyz = new Xyz(sizeAU, y, 0.0).Rotate(MtxRotate);
				point2 = GetDrawPoint(xyz);
				graphics.DrawLine(pen, point1.X, point1.Y, point2.X, point2.Y);
			}


			for (int x = -50; x < 51; x++)
			{
				xyz = new Xyz(x, sizeAU, 0.0).Rotate(MtxRotate);
				point1 = GetDrawPoint(xyz);
				xyz = new Xyz(x, -sizeAU, 0.0).Rotate(MtxRotate);
				point2 = GetDrawPoint(xyz);
				graphics.DrawLine(pen, point1.X, point1.Y, point2.X, point2.Y);
			}
		}

		#endregion

		#region SelectOrbits

		public void SelectOrbits(bool[] orbitDisplay)
		{
			for (int i = 0; i < orbitDisplay.Length; i++)
			{
				OrbitDisplay[i] = orbitDisplay[i];
			}
		}

		#endregion

		#endregion
	}
}