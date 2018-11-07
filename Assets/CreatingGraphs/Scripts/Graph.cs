using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

	// Use this for initialization
	public Transform pointPrefab;
	//resolution
	//[Range(10, 100)]
	private int resolution = 80;

	//public FunctionName function;

	private Transform[] points;

	private GraphFunction f;

	void Awake()
	{
		float step = 2f / resolution;
		Vector3 scale = Vector3.one * step;
		//Vector3 position;
		//position.y = 0f;
		//position.z = 0f;
		points = new Transform[resolution * resolution];
		for (int i = 0; i < points.Length; i++)
		{
			Transform point = Instantiate(pointPrefab);
			point.localScale = scale;
			point.SetParent(transform, false);
			points[i] = point;
		}
		setFunction(FunctionName.Sine); // for default this graph start with SINE

		foreach (Renderer r in GetComponentsInChildren<Renderer>())
		{
			r.enabled = false;
		}
	}


	// Update is called once per frame
	void Update() {
		float t = Time.time;
		//f = Functions.getFunction(function);
		float step = 2f / resolution;
		for (int i = 0, z = 0; z < resolution; z++)
		{
			float v = (z + 0.5f) * step - 1f;
			for (int x = 0; x < resolution; x++, i++)
			{
				float u = (x + 0.5f) * step - 1f;
				points[i].localPosition = f(u, v, t);
			}
		}
	}

	public void setFunction( FunctionName function) {
		f = Functions.getFunction(function);
	}

	public Transform showSurface()
	{
		foreach (Renderer r in GetComponentsInChildren<Renderer>())
		{
			r.enabled = true;
		}

		return this.transform;
	}
}
