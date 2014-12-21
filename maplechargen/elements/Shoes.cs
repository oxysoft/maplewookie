using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maplewookie.elements {
	public class Shoes {
		public readonly int id;
		public readonly int dx, dy;
		public readonly Image image;
		public readonly int z;

		public Shoes(int id) {
			this.id = id;

			string path = Character.Gdpath + "/Shoes/" + id.ToString("D8") + ".img/";
			dynamic xml = new DynamicXml(File.ReadAllText(path + "coord.xml"));

			image = Image.FromFile(path + "stand1.0.shoes.png");
			dx = Int32.Parse(xml._shoes.stand1.x.Value);
			dy = Int32.Parse(xml._shoes.stand1.y.Value);
			z = xml._info.z.value.Value == "shoesOverPants" ? 1 : 0;
		}

		public void Render(Graphics g, int x, int y) {
			g.DrawImage(image, x + dx + 15, y + dy + 43);
		}

	}
}
