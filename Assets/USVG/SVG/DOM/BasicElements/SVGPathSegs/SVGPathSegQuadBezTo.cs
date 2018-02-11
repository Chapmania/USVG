﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bezier cuadratic Segment
/// </summary>
/// param _x1, _y1 : Control Points 1
/// params _x, _y : Final Point
public class SVGPathSegQuadBezTo : SVGPathSeg {
	protected float _x1, _y1;
	protected float _x, _y;
	
	public SVGPathSegQuadBezTo(float x1, float y1, float x, float y, bool isRel, SVGPathSeg prevSeg) : base(isRel, prevSeg){
		_x1 = x1;
		_y1 = y1;
		_x = x;
		_y = y;
	}

	public float X1 {get {return _x1;}}
	public float Y1 {get {return _y1;}}

	public override Vector2 getCursor()
	{
		if (_coord_type == PathCoordType.SVG_PATH_ABSOLUTE)
			return new Vector2(_x, _y);
		else
			return new Vector2(_x + _prevSeg.getCursor().x, _y + _prevSeg.getCursor().y);
	}

	public override float GetLenght()
	{
		Vector2[] points = GetPoints(4);
		float lenght = 0;
		for(int i=0; i<points.Length-2; i++){
			lenght += Vector2.Distance(points[i], points[i + 1]);
		}
		return lenght;
	}

	public override Vector2[] GetPoints(int nSegments)
	{
		float dt;
		int i;
		List<Vector2> points = new List<Vector2>();

		dt = 1.0f / (nSegments - 1);

		for (i = 0; i < nSegments; i++)
			points.Add(PointOnCuadraticBezier( i * dt));

		return points.ToArray();

	}

	Vector2 PointOnCuadraticBezier(float t){
		float xx;
		float yy;
		Vector2 cursor = _prevSeg.getCursor();

		Vector2 p_final = new Vector2(_x, _y);
		if (_coord_type == PathCoordType.SVG_PATH_RELATIVE)
			p_final += cursor;

		xx = (1 - t) * (1 - t) * cursor.x + 2 * (1 - t) * t * _x1 + t * t * _x;
		yy = (1 - t) * (1 - t) * cursor.y + 2 * (1 - t) * t * _y1 + t * t * _y;

		return new Vector2(xx, yy);
	}


}

