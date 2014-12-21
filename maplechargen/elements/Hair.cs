using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maplewookie.elements {
	public class Hair {
		public readonly int id;
		public readonly int frontdx, frontdy, fronthatdx, fronthatdy, backdx, backdy;
		public readonly Image back, front, frontHat;
		public readonly bool hasBack = false;
		public readonly bool hatChanges = false;

		public Hair(int id) {
			this.id = id;

			string path = Character.Gdpath + "/Hair/" + id.ToString("D8") + ".img/";
			dynamic xml = new DynamicXml(File.ReadAllText(path + "coord.xml"));

			if (File.Exists(Character.Gdpath + "/Hair/" + id.ToString("D8") + ".img/default.hairBelowBody.png")) {
				back = Image.FromFile(Character.Gdpath + "/Hair/" + id.ToString("D8") + ".img/default.hairBelowBody.png");
				backdx = Int32.Parse(xml._hairBelowBody.x.Value);
				backdy = Int32.Parse(xml._hairBelowBody.y.Value);
				hasBack = true;
			}

			hatChanges = File.Exists(path + "/default.hair.png") && File.Exists(path + "/default.hairOverHead.png");

			if (hatChanges) {
				frontHat = Image.FromFile(path + "default.hair.png");
				fronthatdx = Int32.Parse(xml._hair.x.Value);
				fronthatdy = Int32.Parse(xml._hair.y.Value);
			}

			if (File.Exists(path + "/default.hairOverHead.png")) {
				front = Image.FromFile(path + "default.hairOverHead.png");
				frontdx = Int32.Parse(xml._hairOverHead.x.Value);
				frontdy = Int32.Parse(xml._hairOverHead.y.Value);
			} else {
				front = Image.FromFile(path + "default.hair.png");
				frontdx = Int32.Parse(xml._hair.x.Value);
				frontdy = Int32.Parse(xml._hair.y.Value);
			}

		}

		public void RenderBack(Character chr, Graphics g, int x, int y) {
			if (hasBack) {
				g.DrawImage(back, x + backdx + 15, y + backdy + 12);
			}
		}

		public void RenderFront(Character chr, Graphics g, int x, int y) {
			if (chr.hat > 0 && hatChanges) {
				g.DrawImage(frontHat, x + fronthatdx + 15, y + fronthatdy + 12);
			} else {
				g.DrawImage(front, x + frontdx + 15, y + frontdy + 12);
			}
		}
	}
}
