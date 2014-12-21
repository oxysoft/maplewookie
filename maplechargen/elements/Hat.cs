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
		public readonly int topdx, topdy, backdx, backdy;
		public readonly Image top, back;
		public readonly bool hasBack;

		public Hat(int id) {
			this.id = id;

			string path = Character.Gdpath + "/Cap/" + id.ToString("D8") + ".img/";
			top = Image.FromFile(path + "default.default.png");
			dynamic xml = new DynamicXml(File.ReadAllText(path + "coord.xml"));

			if (File.Exists(path + "default.defaultAc.png")) {
				hasBack = true;
				back = Image.FromFile(path + "default.defaultAc.png");
				backdx = Int32.Parse(xml._defaultAc.x.Value);
				backdy = Int32.Parse(xml._defaultAc.y.Value);
			}

			topdx = Int32.Parse(xml._default.x.Value);
			topdy = Int32.Parse(xml._default.y.Value);
		}

		public void RenderTop(Graphics g, int x, int y) {
			g.DrawImage(top, x + topdx + 15, y + topdy + 12);
		}
		
		public void RenderBack(Graphics g, int x, int y) {
			if (hasBack) {
				g.DrawImage(back, x + backdx + 15, y + backdy + 12);
			}
		}
	}
}
