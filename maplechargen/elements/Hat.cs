using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maplewookie.elements {
	public class Hat {
		public readonly int id;
		public readonly int dx, dy;
		public readonly Image image;

		public Hat(int id) {
			this.id = id;

			string path = Character.Gdpath + "/Cap/" + id.ToString("D8") + ".img/";
			image = Image.FromFile(path + "default.default.png");
			dynamic xml = new DynamicXml(File.ReadAllText(path + "coord.xml"));

			dx = Int32.Parse(xml._default.x.Value);
			dy = Int32.Parse(xml._default.y.Value);
		}

		public void Render(Graphics g, int x, int y) {
			g.DrawImage(image, x + dx + 15, y + dy + 12);
		}
	}
}
