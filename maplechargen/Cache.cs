using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maplewookie.elements;

namespace maplewookie {
	public class Cache {
		private static Dictionary<int, Skin> skins = new Dictionary<int, Skin>();
		private static Dictionary<int, Face> faces = new Dictionary<int, Face>();
		private static Dictionary<int, Hair> hairs = new Dictionary<int, Hair>();
		private static Dictionary<int, Coat> coats = new Dictionary<int, Coat>();
		private static Dictionary<int, Pants> pants = new Dictionary<int, Pants>();
		private static Dictionary<int, Shoes> shoes = new Dictionary<int, Shoes>();
		private static Dictionary<int, Gloves> gloves = new Dictionary<int, Gloves>();
		private static Dictionary<int, AccFace> accsface = new Dictionary<int, AccFace>();
		private static Dictionary<int, AccEye> accseye = new Dictionary<int, AccEye>();

		public static int Count {
			get { return skins.Count + faces.Count + hairs.Count + coats.Count + pants.Count + shoes.Count + gloves.Count + accsface.Count + accseye.Count; }
		}

		public static Skin GetSkin(int id) {
			if (skins.ContainsKey(id))
				return skins[id];

			skins.Add(id, new Skin(id));
			return skins[id];
		}

		public static Face GetFace(int id) {
			if (faces.ContainsKey(id))
				return faces[id];

			faces.Add(id, new Face(id));
			return faces[id];
		}

		public static Hair GetHair(int id) {
			if (hairs.ContainsKey(id))
				return hairs[id];

			hairs.Add(id, new Hair(id));
			return hairs[id];
		}

		public static Coat GetCoat(int id) {
			if (coats.ContainsKey(id))
				return coats[id];

			coats.Add(id, new Coat(id));
			return coats[id];
		}

		public static Pants GetPants(int id) {
			if (pants.ContainsKey(id))
				return pants[id];

			pants.Add(id, new Pants(id));
			return pants[id];
		}

		public static Shoes GetShoes(int id) {
			if (shoes.ContainsKey(id))
				return shoes[id];

			shoes.Add(id, new Shoes(id));
			return shoes[id];
		}
		
		public static Gloves GetGloves(int id) {
			if (gloves.ContainsKey(id))
				return gloves[id];

			gloves.Add(id, new Gloves(id));
			return gloves[id];
		}

		public static AccFace GetAccFace(int id) {
			if (accsface.ContainsKey(id))
				return accsface[id];

			accsface.Add(id, new AccFace(id));
			return accsface[id];
		}

		public static AccEye GetAccEye(int id) {
			if (accseye.ContainsKey(id))
				return accseye[id];

			accseye.Add(id, new AccEye(id));
			return accseye[id];
		}
	}
}
