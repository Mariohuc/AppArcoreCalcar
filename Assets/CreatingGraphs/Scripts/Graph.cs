using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

	// Use this for initialization
	public Transform pointPrefab;
	//resolution
	[Range (10,100)] public int resolution = 10;

	void Awake()
	{
		float step = 2f / resolution;
		Vector3 scale = Vector3.one * step; // 2/10 = 1/5 cada cubo mide 0.2 pero la posicion central va al medio
		Vector3 position; // x ya no porque es definida en el loop
						  //position.y = 0f;
		position.z = 0f;
		for (int i=0;i < resolution; i++){
			Transform point = Instantiate(pointPrefab);
			position.x = ((i + 0.5f) * step - 1f);
			//position.y = position.x; // function y = f(x) => f(x) = x
			position.y = position.x * position.x; // function y = f(x) => f(x) = x^2
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent(transform,false);
		}
		

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
