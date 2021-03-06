﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USVG {
	public class SVGLoader : MonoBehaviour {
		public TextAsset svgAsset;
		public Material baseMaterial;

		SVGParser parser;
		List<SVGElement> elms;

		// Use this for initialization
		void Start()
		{
			parser = new SVGParser(svgAsset.text);
			elms = new List<SVGElement>();
			parser.GetElementList(elms);
			foreach (SVGElement ele in elms) {
				Debug.Log(ele.ToString());
				ele.Render(null, baseMaterial);
			}
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}
