using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maplewookie.elements {
	public class Pants {
		public readonly int id;
		public readonly int dx, dy;
		public Image image;

		public Pants(int id) {
			this.id = id;

			string path = Character.Gdpath + "/Pants/" + id.ToString("D8") + ".img/";
			image = Image.FromFile(path + "stand1.0.pants.png");
			dynamic xml = new DynamicXml(File.ReadAllText(path + "coord.xml"));

			dx = Int32.Parse(xml._pants.stand1.x.Value);
			dy = Int32.Parse(xml._pants.stand1.y.Value);
		}

		public void Render(Graphics g, int x, int y) {
			g.DrawImage(image, x + dx + 15, y + dy + 43);
		}
	}
}
