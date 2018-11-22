using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorialSpace : MonoBehaviour {

    private Vector3 origin;
    private GameObject axes;
	private Graph script_graph;
	private List<GameObject> graphsList;
	//private int currentUpdated = 1;
	private GameObject currentInstGraph;

	private bool active;
	public Dropdown functionsListDropdown;
    public GameObject modifierContainer;

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
		//script_graph = currentInstGraph.GetComponent<Graph>();
		List<string> options = new List < string > {"Sine","Sine2D","MultiSine","MultiSine2D","Ripple","Cylinder","Sphere","Torus" };
		functionsListDropdown.AddOptions(options);

        updateParameterModifiers();

        functionsListDropdown.onValueChanged.AddListener(delegate {
			DropdownValueChanged(functionsListDropdown, currentInstGraph);
		});

        

    }


    void updateParameterModifiers() {
        // extract panels
        script_graph = currentInstGraph.GetComponent<Graph>();
        MathematicalFunction mathFunctionTemp = script_graph.getMathFunction(); // function
        Parameter[] parametersTemp = mathFunctionTemp.getParameters();
        RectTransform[] modifiers = modifierContainer.GetComponentsInChildren<RectTransform>();
        string[] parameter = { "a", "b", "c" };
        for (int i = 0; i < 3 ; i++)
        {
            if (modifiers[i].name.Equals("Text")) continue;
            InputField inputValue = modifiers[i].GetComponentInChildren<InputField>();
            Slider slider = modifiers[i].GetComponentInChildren<Slider>();      
            slider.minValue = parametersTemp[i].MinValue;
            slider.maxValue = parametersTemp[i].MaxValue;
            slider.value = parametersTemp[i].Value;
            slider.name = parameter[i];
            inputValue.text = parametersTemp[i].Value.ToString();

            slider.onValueChanged.AddListener(delegate {
      
                mathFunctionTemp.updateParameter(slider.name, slider.value);
                inputValue.text = slider.value.ToString();

            });
        }

        

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
