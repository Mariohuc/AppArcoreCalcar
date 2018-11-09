using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorialSpace : MonoBehaviour {

	//private Vector3 origin;
	public GameObject graph;
	private Graph script_graph;
	public Dropdown functionsListDropdown;

	public GameObject vectorialSpace;

	private List<GameObject> graphsList = new List<GameObject>();

	//private int currentUpdated = 1;

	public bool active;
	private GameObject currentInstGraph = null;


	// Use this for initialization
	void Awake()
	{
		//origin = new Vector3(0f, 0f, 0f);
		functionsListDropdown.ClearOptions();
		active = false;
		//foreach (Renderer r in GetComponentsInChildren<Renderer>())
		//{
		//	r.enabled = false;
		//}
	}

	void Start()
	{
		
	}

	public bool Active //Get y set son accesores
	{
		get //Solo regresa valor
		{
			return active;
		}

		set //Setea valor
		{
			active = value;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (currentInstGraph != null)
			currentInstGraph.transform.position = vectorialSpace.transform.position;
	}

	public void addSurface()
	{
		currentInstGraph = Instantiate(graph, vectorialSpace.transform); // create a new instance where the parent is the vectorial space
		graphsList.Add(currentInstGraph); // add the new instance into of graphList
		//script_graph = currentInstGraph.GetComponent<Graph>();
		List<string> options = new List < string > {"Sine","Sine2D","MultiSine","MultiSine2D","Ripple","Cylinder","Sphere","Torus" };
		functionsListDropdown.AddOptions(options);

		functionsListDropdown.onValueChanged.AddListener(delegate {
			DropdownValueChanged(functionsListDropdown, currentInstGraph);
		});
	}

	//Ouput the new value of the Dropdown into Text
	void DropdownValueChanged(Dropdown change, GameObject currentInstGraph)
	{
		if(currentInstGraph != null )
		{
			FunctionName temp = FunctionName.Sine;
			switch (change.value) {
				case 0: temp = FunctionName.Sine;
					break;
				case 1:
					temp = FunctionName.Sine2D;
					break;
				case 2:
					temp = FunctionName.MultiSine;
					break;
				case 3:
					temp = FunctionName.MultiSine2D;
					break;
				case 4:
					temp = FunctionName.Ripple;
					break;
				case 5:
					temp = FunctionName.Cylinder;
					break;
				case 6:
					temp = FunctionName.Sphere;
					break;
				case 7:
					temp = FunctionName.Torus;
					break;
			}

			script_graph = currentInstGraph.GetComponent<Graph>();
			script_graph.setFunction(temp);
		}
	}
}
