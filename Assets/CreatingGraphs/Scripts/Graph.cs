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
    private int resolution = 100;

	//public FunctionName function;

	private Transform[] points;

    private MathematicalFunction mathFunction;



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
        
        setMathFunction( MathFunctionManagerUI.getSceneMathFunction() );
        //modifierParentPanel = GameObject.Find("ModifiersParentPanel").GetComponent<RectTransform>();

    }


    void Start()
    {}

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
				points[i].localPosition = mathFunction.graph(u, v, t);
                //points[i].localPosition = f(u, v, t);
            }
		}
	}

    public void setMathFunction(MathematicalFunction m)
    {
        mathFunction = m;
    }

    public MathematicalFunction getMathFunction() {
        return mathFunction;
    }

    public Transform showSurface()
	{
		return this.transform;
	}
}
