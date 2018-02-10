using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace USVG {
	public abstract class SVGElement {
		Dictionary<string, string> attrList;
		SVGTransformList transformlist;

		protected SVGElement(Dictionary<string, string> _attrList) {
			attrList = _attrList;

			foreach(KeyValuePair<string,string> attr in attrList){
				switch(attr.Key){
					case "transform":
						transformlist = new SVGTransformList();
						transformlist.ParseAttributes(attr.Value);
						break;
					default:
						Debug.Log("Attributo no implementado: " + attr.Key);
						break;
				}
			}

		}

		protected abstract void GenerateGameObject(Transform parent);
	}

}