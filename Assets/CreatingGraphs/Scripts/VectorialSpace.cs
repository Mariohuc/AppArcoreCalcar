using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorialSpace : MonoBehaviour {

	private Vector3 origin;

	public Graph graphs;
	public Dropdown FunctionsListDropdown;

	private List<Graph> graphsList = new List<Graph>();

	private int currentUpdated = 1;

	// Use this for initialization
	void Awake()
	{
		origin = new Vector3(0f, 0f, 0f);
	}

	void Start()
	{
		addSurface();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void addSurface()
	{
		var newGraph = Instantiate(graphs,this.transform);
		graphsList.Add(newGraph);


	}
}
