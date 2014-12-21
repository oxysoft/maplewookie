using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maplewookie.elements {
	public class Gloves {
		public readonly int id;
		public readonly int leftdx, leftdy, rightdx, rightdy;
		public readonly Image lGlove, rGlove;
		public readonly bool hasLeftGlove, hasRightGlove;
		
		public Gloves(int id) {
			this.id = id;
			string path = Character.Gdpath + "/Glove/" + id.ToString("D8") + ".img/";
			dynamic xml = new DynamicXml(File.ReadAllText(path + "coord.xml"));

			if (File.Exists(path + "stand1.0.lGlove.png")) {
				hasLeftGlove = true;
				lGlove = Image.FromFile(path + "stand1.0.lGlove.png");

				leftdx = Int32.Parse(xml._lGlove.stand1.x.Value);
				leftdy = Int32.Parse(xml._lGlove.stand1.y.Value);
			}

			if (File.Exists(path + "stand1.0.rGlove.png")) {
				hasRightGlove = true;
				rGlove = Image.FromFile(path + "stand1.0.rGlove.png");

				rightdx = Int32.Parse(xml._rGlove.stand1.x.Value);
				rightdy = Int32.Parse(xml._rGlove.stand1.y.Value);
			}
		}

		public void RenderLeft(Graphics g, int x, int y) {
			if (hasLeftGlove) {
				g.DrawImage(lGlove, x + leftdx + 15, y + leftdy + 43);
			}
		}

		public void RenderRight(Graphics g, int x, int y) {
			if (hasRightGlove) {
				g.DrawImage(rGlove, x + rightdx + 15, y + rightdy + 43);
			}
		}
	}
}
