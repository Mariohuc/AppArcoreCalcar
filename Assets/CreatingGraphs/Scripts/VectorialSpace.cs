using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorialSpace : MonoBehaviour {

	private Vector3 origin;

	public Graph graphs;
	public Dropdown functionsListDropdown;

	public GameObject vectorialSpace;

	private List<Graph> graphsList = new List<Graph>();

	private int currentUpdated = 1;

	private bool rendered_enable;
	private Graph currentInstantiate = null;

	// Use this for initialization
	void Awake()
	{
		origin = new Vector3(0f, 0f, 0f);
		functionsListDropdown.ClearOptions();
		rendered_enable = false;
		//foreach (Renderer r in GetComponentsInChildren<Renderer>())
		//{
		//	r.enabled = false;
		//}
		

	}

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void addSurface()
	{
		currentInstantiate = Instantiate(graphs, vectorialSpace.transform); // create a new instance where the parent is the vectorial space
		graphsList.Add(currentInstantiate); // add the new instance into of graphList
		currentInstantiate.showSurface(); // the new instance order render their childre component
		List<string> options = new List < string > {"Sine","Sine2D","MultiSine","MultiSine2D","Ripple","Cylinder","Sphere","Torus" };
		functionsListDropdown.AddOptions(options);

		functionsListDropdown.onValueChanged.AddListener(delegate {
			DropdownValueChanged(functionsListDropdown, currentInstantiate);
		});
	}

	public Transform showVectorialSpace() {
		//foreach (Renderer r in GetComponentsInChildren<Renderer>())
		//{
		//	r.enabled = true;
		//}
		rendered_enable = true;
		//addSurface(); // for default it will add a first surface into the vectorial space.
		return this.transform;
	}

	public bool isRendered() {
		return rendered_enable;
	}
	//Ouput the new value of the Dropdown into Text
	void DropdownValueChanged(Dropdown change, Graph currentInstantiate)
	{
		if(currentInstantiate != null )
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

			currentInstantiate.setFunction(temp);
		}
	}
}
