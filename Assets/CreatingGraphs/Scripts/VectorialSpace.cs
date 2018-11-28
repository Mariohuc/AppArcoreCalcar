using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class VectorialSpace : MonoBehaviour {

    private Vector3 origin;
    private GameObject axes;
	private Graph _GRAPH_SCRIPT;
	private List<GameObject> graphsList;
	//private int currentUpdated = 1;
	private GameObject currentInstGraph;

	private bool active;
	public Dropdown functionsListDropdown;

    public Image parameterListContainerGraph;
    public Image parameterUpdaterViewportGraph; //IT must have a Text , a InputField and a Slider

    public void setAxesGameObject( GameObject a) {
		axes = a;
	}

	// Use this for initialization
	void Awake()
	{
        origin = new Vector3(0f, 3.5f, 0f);
        transform.localPosition = new Vector3(0f, 0f, 0f);// origin
		axes = null;
		currentInstGraph = null;
		graphsList = new List<GameObject>();
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
            currentInstGraph.transform.localPosition = origin; // this.transform.localPosition;

        if (axes != null)
            axes.transform.localPosition = origin; // this.transform.localPosition;
	}

	public void addSurface(GameObject newsurface)
	{
		graphsList.Add(newsurface);
		currentInstGraph = graphsList[graphsList.Count-1]; // create a new instance where the parent is the vectorial space
		_GRAPH_SCRIPT = currentInstGraph.GetComponent<Graph>();

        _GRAPH_SCRIPT.ParameterListContainerGraph = parameterListContainerGraph;
        _GRAPH_SCRIPT.ParameterUpdaterViewportGraph = parameterUpdaterViewportGraph;
        _GRAPH_SCRIPT.setGraphMathFunction();

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

			_GRAPH_SCRIPT = currentInstGraph.GetComponent<Graph>();
			_GRAPH_SCRIPT.setFunction(temp);
		}
	}
}
