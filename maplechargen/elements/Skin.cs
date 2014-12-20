using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maplewookie.elements {
	public class Skin {
		public int id;
		public Image head, body, arm;

		public Skin(int id) {
			this.id = id;

			string path = Character.Gdpath + "/Skin/" + id.ToString("D8") + ".img/";
			head = Image.FromFile(path + "front.head.png");
			body = Image.FromFile(path + "stand1.0.body.png");
			arm = Image.FromFile(path + "stand1.0.arm.png");
		}

		public void RenderBody(Graphics g, int x, int y) {
			g.DrawImage(body, x + 7, y + head.Height - 2);
		}

		public void RenderHead(Graphics g, int x, int y) {
			g.DrawImage(head, x, y);
		}

		public void RenderArm(Graphics g, int x, int y) {
			g.DrawImage(arm, x + body.Width + 2, y + head.Height);
		}
	}
}
