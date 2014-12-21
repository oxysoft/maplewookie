using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maplewookie.elements {
	public class AccEye {
		public readonly int id;
		public readonly Image image;
		public readonly int dx, dy;

		public AccEye(int id) {
			this.id = id;

			string path = Character.Gdpath + "/Accessory/" + id.ToString("D8") + ".img/";
			dynamic xml = new DynamicXml(File.ReadAllText(path + "coord.xml"));

			image = Image.FromFile(path + "default.default.png");
			dx = Int32.Parse(xml._default.x.Value);
			dy = Int32.Parse(xml._default.y.Value);
		}

		private void RenderAccEye(Graphics g, int x, int y) {
			g.DrawImage(image, x + dx + 15, y + dy + 12);
		}


	}
}
