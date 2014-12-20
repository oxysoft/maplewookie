using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace maplewookie {
	public class DynamicXml : DynamicObject, IEnumerable {
		private readonly List<XElement> elements;

		public DynamicXml(string text) {
			var doc = XDocument.Parse(text);
			elements = new List<XElement> { doc.Root };
		}

		protected DynamicXml(XElement element) {
			elements = new List<XElement> { element };
		}

		protected DynamicXml(IEnumerable<XElement> elements) {
			this.elements = new List<XElement>(elements);
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			result = null;
			if (binder.Name == "Value")
				result = elements[0].Value;
			else if (binder.Name == "Count")
				result = elements.Count;
			else {
				var attr = elements[0].Attribute(XName.Get(binder.Name));
				if (attr != null)
					result = attr;
				else {
					var items = elements.Descendants(XName.Get(binder.Name));
					if (items == null || !items.Any()) return false;
					result = new DynamicXml(items);
				}
			}
			return true;
		}

		public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) {
			int ndx = (int)indexes[0];
			result = new DynamicXml(elements[ndx]);
			return true;
		}

		public IEnumerator GetEnumerator() {
			return elements.Select(element => new DynamicXml(element)).GetEnumerator();
		}
	}
}
