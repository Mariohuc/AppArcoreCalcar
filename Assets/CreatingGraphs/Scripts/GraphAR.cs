using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatingGraphs
{
	public class GraphAR : MonoBehaviour
	{

		// Use this for initialization
		public Transform pointPrefab;
		//resolution
		//[Range(10, 100)] public int resolution = 10;
		public int resolution = 80;
		private Transform[] points = null;

		public GraphFunctionName function;

		void Awake()
		{

			float step = 2f / resolution;
			Vector3 scale = Vector3.one * step; // 2/10 = 1/5 cada cubo mide 0.2 pero la posicion central va al medio
			Vector3 position; // coordanda x ya no porque es definida en el loop
							  //position.y = 0f;
			position.y = 0f;
			position.z = 0f;


			points = new Transform[resolution * resolution];
			for (int i = 0, z = 0; z < resolution; z++) // para la coordenada Z , que hace de Y en un plano de calculo
			{
				position.z = ((z + 0.5f) * step - 1f);
				for (int x = 0; x < resolution; x++, i++) // para la coordenada X
				{

					Transform point = Instantiate(pointPrefab);
					position.x = ((x + 0.5f) * step - 1f);
					point.localPosition = position;
					point.localScale = scale;
					point.SetParent(transform, false);
					points[i] = point;
				}
			}

			foreach (Renderer r in GetComponentsInChildren<Renderer>())
			{
				r.enabled = false;
			}
		}

		void Start()
		{

		}

		// Update is called once per frame
		
		void Update() {
			float t = Time.time;
			//GraphFunction f = functionslist[(int)function];
			GraphFunction f = functionslist[3];
			for (int i = 0; i < points.Length; i++) {
				Transform point = points[i];
				Vector3 position = point.localPosition;
				position.y = f(position.x, position.z, t); // add the Z dimension
				point.localPosition = position;
			}
		}
		
		public Transform ShowSurface()
		{
			
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
			{
				r.enabled = true;
			}

			return this.transform;

		}


		public static float SineFunction(float x, float z, float t)
		{
			//return Mathf.Sin(Mathf.PI * (x + t)); // animado 
			return Mathf.Sin(Mathf.PI * (x)); // sin animacion
		}

		public static float MultiSineFunction(float x, float z, float t)
		{
			float y = Mathf.Sin(Mathf.PI * (x + t));
			y += Mathf.Sin(2f * Mathf.PI * (x + t)) / 2f;
			y *= 2f / 3f; // I don't understand whyy but I think this's for the function range.
			return y;

		}

		static float Sine2DFunction(float x, float z, float t)
		{
			const float pi = Mathf.PI;
			float y = Mathf.Sin(pi * (x + t));
			y += Mathf.Sin(pi * (z + t));
			y *= 0.5f;
			return y;
		}

		static float Cono(float x, float z, float t)
		{
			float y = Mathf.Sqrt(x * x + z * z);
			return y;
		}

		//Array de delegados
		public static GraphFunction[] functionslist = { SineFunction, Sine2DFunction, MultiSineFunction, Cono };

	}
}




