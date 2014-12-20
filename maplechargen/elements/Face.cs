using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maplewookie.elements {
	public class Face {
		public readonly int id;
		public readonly int dx, dy;
		public readonly Image image;

		public Face(int id) {
			this.id = id;

			string path = Character.Gdpath + "/Face/" + id.ToString("D8") + ".img/";
			image = Image.FromFile(path + "default.face.png");
			dynamic xml = new DynamicXml(File.ReadAllText(path + "coord.xml"));
			dx = Int32.Parse(xml._face.x.Value);
			dy = Int32.Parse(xml._face.y.Value);
		}

		public void Render(Graphics g, int x, int y) {
			g.DrawImage(image, x + dx + 15, y + dy + 12);
		}
	}
}
