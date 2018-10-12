using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

	// Use this for initialization
	public Transform pointPrefab;
	//resolution
	[Range (10,100)] public int resolution = 10;
	private Transform[] points = null;

	public GraphFunctionName function;

	void Awake()
	{
		bool conAnimacion = true;

		float step = 2f / resolution;
		Vector3 scale = Vector3.one * step; // 2/10 = 1/5 cada cubo mide 0.2 pero la posicion central va al medio
		Vector3 position; // coordanda x ya no porque es definida en el loop
						  //position.y = 0f;
		position.y = 0f;
		position.z = 0f;
		
		if (conAnimacion)
		{
			
			points = new Transform[resolution*resolution];
			for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
			{
				if (x == resolution) {
					x = 0;
					z += 1;
				} // cuando x es igual a resolution se vuelve a cero
				Transform point = Instantiate(pointPrefab);
				position.x = ((x + 0.5f) * step - 1f);
				position.z = ((z + 0.5f) * step - 1f);
				//position.y = position.x; // function y = f(x) => f(x) = x
				//position.y = position.x * position.x; // function y = f(x) => f(x) = x^2
				//position.y = position.x * position.x * position.x; // function y = f(x) => f(x) = x^3
				point.localPosition = position;
				point.localScale = scale;
				point.SetParent(transform, false);
				points[i] = point;
			}

		}
		else {

			for (int i = 0; i < resolution; i++)
			{
				Transform point = Instantiate(pointPrefab);
				position.x = ((i + 0.5f) * step - 1f);
				//position.y = position.x; // function y = f(x) => f(x) = x
				//position.y = position.x * position.x; // function y = f(x) => f(x) = x^2
				position.y = position.x * position.x * position.x; // function y = f(x) => f(x) = x^3
				point.localPosition = position;
				point.localScale = scale;
				point.SetParent(transform, false);
			}
		}


	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time;
		GraphFunction f = functionslist[(int)function];

		for(int i = 0 ; i < points.Length; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;
			//position.y = position.x * position.x;
			//position.y = SineFunction( position.x , t);
			position.y = f(position.x, position.z ,  t); // add the Z dimension
			point.localPosition = position;
		}
	}

	public static float SineFunction(float x, float z, float t) {
		return Mathf.Sin(Mathf.PI * (x + t));
	}

	public static float MultiSineFunction(float x, float z, float t)
	{
		float y = Mathf.Sin(Mathf.PI * (x + t));
		y += Mathf.Sin(2f * Mathf.PI * (x + t)) / 2f;
		y *= 2f / 3f; // I don't understand whyy but I think this's for the function range.
		return y;

	}

	//Array de delegados
	public static GraphFunction[] functionslist = { SineFunction, MultiSineFunction };

}
