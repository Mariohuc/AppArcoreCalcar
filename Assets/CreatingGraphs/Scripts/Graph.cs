using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

	// Use this for initialization
	public Transform pointPrefab;

	void Awake()
	{
		for(int i=0;i<10;i++){
			Transform point = Instantiate(pointPrefab);
			point.localPosition = Vector3.right * i;
		}
		

	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
