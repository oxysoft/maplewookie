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
		public readonly bool isError;

		public Hat(int id) {
			this.id = id;

			string path = Character.Gdpath + "/Cap/" + id.ToString("D8") + ".img/";
			try {
				top = Image.FromFile(path + "default.default.png");
				dynamic xml = new DynamicXml(File.ReadAllText(path + "coord.xml"));

				if (File.Exists(path + "default.defaultAc.png")) {
					hasBack = true;
					back = Image.FromFile(path + "default.defaultAc.png");
					try {
						backdx = Int32.Parse(xml._defaultAc.x.Value);
						backdy = Int32.Parse(xml._defaultAc.y.Value);
					} catch (Exception e) {
						// some items is AC instead
						// silly nexon not being consistent
						backdx = Int32.Parse(xml._defaultAC.x.Value);
						backdy = Int32.Parse(xml._defaultAC.y.Value); 
					}
				}

				topdx = Int32.Parse(xml._default.x.Value);
				topdy = Int32.Parse(xml._default.y.Value);
			} catch (FileNotFoundException e) {
				isError = true;
				Console.WriteLine("File not found: " + e.FileName);
			}
		}

		public void RenderTop(Graphics g, int x, int y) {
			if (isError) return;

			g.DrawImage(top, x + topdx + 15, y + topdy + 12);
		}
		
		public void RenderBack(Graphics g, int x, int y) {
			if (isError) return;

			if (hasBack) {
				g.DrawImage(back, x + backdx + 15, y + backdy + 12);
			}
		}
	}
}
