using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace maplewookie {
	public partial class Form1 : Form {
		public Bitmap bmp;
		public Thread backgroundThread;

		public Form1() {
			InitializeComponent();

			bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
//			Generate();
		}

		private void onGenerateClicked(object sender, EventArgs e) {
			btnSave.Enabled = false;
			btnGenerate.Enabled = false;
			btnStop.Enabled = true;

			backgroundThread = new Thread(Generate);
			backgroundThread.Start();
		}

		public void Generate() {
			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.Transparent);

			int xo = pictureBox1.Width / 2 - 39/2;
			int yo = pictureBox1.Height / 2 - 64/2;

			progressBar1.BeginInvoke(new Action(() => {
				progressBar1.Value = 0;
				progressBar1.Maximum = (int) numericUpDown1.Value;
			}));


			for (int i = 0; i < numericUpDown1.Value; i++) {
				g.Clear(Color.Transparent);
				Character c = Character.Random(0);
				c.Render(g, xo, yo);
				if (cbAutoSave.Checked) Save(i.ToString());
				pictureBox1.Invoke(new Action(() => {
					pictureBox1.Image = bmp;
				}));
				int i1 = i;
				progressBar1.Invoke(new Action(() => {
					progressBar1.Value = i1 + 1;
				}));
			}

			numericUpDown1.BeginInvoke(new Action(() => {
				numericUpDown1.Enabled = true;
			}));

			btnGenerate.BeginInvoke(new Action(() => {
				btnGenerate.Enabled = true;
			}));

			btnSave.BeginInvoke(new Action(() => {
				btnSave.Enabled = true;
			}));

			btnStop.BeginInvoke(new Action(() => {
				btnStop.Enabled = false;
			}));
		}

		private void btnStop_Click(object sender, EventArgs e) {
			backgroundThread.Abort();
			progressBar1.Value = progressBar1.Maximum;
		}


		public void Save(string name) {
			TrimBitmap(bmp).Save(@"C:\output\" + name + ".png");
		}

		// google had this in store for me
		// god invented copy & paste for a reason
		static Bitmap TrimBitmap(Bitmap source) {
			Rectangle srcRect = default(Rectangle);
			BitmapData data = null;
			try {
				data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				byte[] buffer = new byte[data.Height * data.Stride];
				Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);

				int xMin = int.MaxValue,
					xMax = int.MinValue,
					yMin = int.MaxValue,
					yMax = int.MinValue;

				bool foundPixel = false;

				for (int x = 0; x < data.Width; x++) {
					bool stop = false;
					for (int y = 0; y < data.Height; y++) {
						byte alpha = buffer[y * data.Stride + 4 * x + 3];
						if (alpha != 0) {
							xMin = x;
							stop = true;
							foundPixel = true;
							break;
						}
					}
					if (stop)
						break;
				}

				if (!foundPixel)
					return null;

				for (int y = 0; y < data.Height; y++) {
					bool stop = false;
					for (int x = xMin; x < data.Width; x++) {
						byte alpha = buffer[y * data.Stride + 4 * x + 3];
						if (alpha != 0) {
							yMin = y;
							stop = true;
							break;
						}
					}
					if (stop)
						break;
				}

				for (int x = data.Width - 1; x >= xMin; x--) {
					bool stop = false;
					for (int y = yMin; y < data.Height; y++) {
						byte alpha = buffer[y * data.Stride + 4 * x + 3];
						if (alpha != 0) {
							xMax = x;
							stop = true;
							break;
						}
					}
					if (stop)
						break;
				}

				for (int y = data.Height - 1; y >= yMin; y--) {
					bool stop = false;
					for (int x = xMin; x <= xMax; x++) {
						byte alpha = buffer[y * data.Stride + 4 * x + 3];
						if (alpha != 0) {
							yMax = y;
							stop = true;
							break;
						}
					}
					if (stop)
						break;
				}

				srcRect = Rectangle.FromLTRB(xMin, yMin, xMax + 1, yMax + 1);
			} finally {
				if (data != null)
					source.UnlockBits(data);
			}

			Bitmap dest = new Bitmap(srcRect.Width, srcRect.Height);
			Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
			using (Graphics graphics = Graphics.FromImage(dest)) {
				graphics.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
			}
			return dest;
		}
	}
}
