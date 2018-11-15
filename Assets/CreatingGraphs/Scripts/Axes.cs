using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axes : MonoBehaviour {

    // Use this for initialization
    public Transform pointPrefab;
    public Transform text3d;
    //resolution
    //[Range(10, 100)]
    private int resolution = 50;

    //public FunctionName function;

    private Transform[] points;

    void Awake()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        //Vector3 position;
        //position.y = 0f;
        //position.z = 0f;
        points = new Transform[(int)(6/step) * 3]; // It's 3 to be 3 axis
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    // Use this for initialization
    void Start () {
        float step = 2f / resolution;
        Vector3 p;
        int k = 0;
        for (int i = 0; i < (int)(6 / step); i++, k++)
        {
            float x = (i + 0.5f) * step - 3f;
            p.x = x;
            p.y = 0;
            p.z = 0;
            points[k].localPosition = p;
        }
        Transform temp = Instantiate(text3d, this.transform);
		temp.localPosition = new Vector3(3.5f, 0f, 0.5f); ;
        temp.localRotation *= Quaternion.Euler(0, 90f, 0);
        var textmesh = temp.GetComponent<TextMesh>();
        textmesh.text = "x";

        for (int i = 0; i < (int)(6 / step); i++,k++)
        {
            float y = (i + 0.5f) * step - 3f;
            p.x = 0;
            p.y = y;
            p.z = 0;
            points[k].localPosition = p;
        }
        temp = Instantiate(text3d, this.transform);
		temp.localPosition = new Vector3(0.5f, 4.4f, 0f); ;
        temp.localRotation *= Quaternion.Euler(0, 180f, 0);
        textmesh = temp.GetComponent<TextMesh>();      
        textmesh.text = "z";

        for (int i = 0; i < (int)(6 / step); i++,k++)
        {
            float z = (i + 0.5f) * step - 3f;
            p.x = 0;
            p.y = 0;
            p.z = z;
            points[k].localPosition = p;
        }
        temp = Instantiate(text3d, this.transform);
		temp.localPosition = new Vector3(0.5f, 0f, 3.5f); ;
        temp.localRotation *= Quaternion.Euler(0, 180f, 0);
        textmesh = temp.GetComponent<TextMesh>();
        textmesh.text = "y";
    }
	
	// Update is called once per frame
	void Update () {

        
    }


}
