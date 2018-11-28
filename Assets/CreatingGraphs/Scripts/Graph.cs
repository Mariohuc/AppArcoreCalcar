using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graph : MonoBehaviour {

	// Use this for initialization
	public Transform pointPrefab;
    private RectTransform modifierParentPanel;

    //resolution
    //[Range(10, 100)]
    private int resolution = 80;

	//public FunctionName function;

	private Transform[] points;

	private GraphFunction f;

    private MathFunctionUI mathFunctionUIManager;

    public Button parameterSelectButton; // public 

    private Image parameterListContainerGraph;
    private Image parameterUpdaterViewportGraph; //IT must have a Text , a InputField and a Slider



    public Image ParameterListContainerGraph  // it must asign in vectorial space
    {
        set { parameterListContainerGraph = value; }
        get { return parameterListContainerGraph; }
    }

    public Image ParameterUpdaterViewportGraph // it must asign in vectorial space
    {
        set { parameterUpdaterViewportGraph = value; }
        get { return parameterUpdaterViewportGraph; }
    }


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
        mathFunctionUIManager = new MathFunctionUI();
        mathFunctionUIManager.MathFunction = new Ellipsoid();
        //modifierParentPanel = GameObject.Find("ModifiersParentPanel").GetComponent<RectTransform>();

        //if (modifierParentPanel == null) Application.Quit();  

        //setFunction(FunctionName.Sine);

        //foreach (Renderer r in GetComponentsInChildren<Renderer>())
        //{
        //	r.enabled = false;
        //}
    }

    public void setGraphMathFunction() {
        if (ParameterListContainerGraph == null || ParameterUpdaterViewportGraph == null)
            return;
     
        mathFunctionUIManager.ParameterListContainer = ParameterListContainerGraph;
        mathFunctionUIManager.ParameterUpdaterViewport = ParameterUpdaterViewportGraph;
        mathFunctionUIManager.ParameterSelectButton = parameterSelectButton;
        //mathFunctionUIManager.MathFunction = VARIABLECONTAINER.getChosenFunction();
       
        mathFunctionUIManager.putParameterButtonInContainer();
    }

    private void Start()
    {
        
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
				points[i].localPosition = mathFunctionUIManager.graph(u, v, t);
                //points[i].localPosition = f(u, v, t);
            }
		}
	}

	public void setFunction(FunctionName function) {
        f = Functions.getFunction(function);
	}

    public MathematicalFunction getMathFunction() {
        return mathFunctionUIManager.MathFunction;
    }

    public Transform showSurface()
	{
		//foreach (Renderer r in GetComponentsInChildren<Renderer>())
		//{
		//	r.enabled = true;
		//}

		return this.transform;
	}
}
