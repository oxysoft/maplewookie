using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maplewookie.elements {
	public class Coat {
		public readonly int id;
		public readonly Image body, arm;
		public readonly int bodydx, bodydy, armdx, armdy;
		public readonly bool hasArms;

		public Coat(int id) {
			this.id = id;

			string path = Character.Gdpath + "/Coat/" + id.ToString("D8") + ".img/";
			body = Image.FromFile(path + "stand1.0.mail.png");
			dynamic xml = new DynamicXml(File.ReadAllText(path + "coord.xml"));
			bodydx = Int32.Parse(xml._mail.stand1.x.Value);
			bodydy = Int32.Parse(xml._mail.stand1.y.Value);

			if (File.Exists(path + "stand1.0.mailArm.png")) {
				hasArms = true;
				arm = Image.FromFile(path + "stand1.0.mailArm.png");

				armdx = Int32.Parse(xml._mailArm.stand1.x.Value);
				armdy = Int32.Parse(xml._mailArm.stand1.y.Value);
			}
		}

		public void RenderBody(Graphics g, int x, int y) {
			g.DrawImage(body, x + bodydx + 15, y + bodydy + 43);
		}

		public void RenderArm(Graphics g, int x, int y) {
			if (hasArms) {
				g.DrawImage(arm, x + armdx + 15, y + armdy + 43);
			}
		}
	}
}
