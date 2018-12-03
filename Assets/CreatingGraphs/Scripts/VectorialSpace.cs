using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class VectorialSpace : MonoBehaviour {

    private Vector3 origin;
    private GameObject axes;
	private List<GameObject> graphsList;
	//private int currentUpdated = 1;
	private GameObject currentSelectedtGraph;

	private bool active;
    private bool IsTheCurrentGraphPlaced = false;


    public void setAxesGameObject( GameObject a) {
		axes = a;
        axes.transform.localPosition = origin;
    }

	// Use this for initialization
	void Awake()
	{
        origin = new Vector3(0f, 3.5f, 0f);
        transform.localPosition = new Vector3(0f, 0f, 0f);// origin
		axes = null;
		currentSelectedtGraph = null;
		graphsList = new List<GameObject>();
		active = false;
		//foreach (Renderer r in GetComponentsInChildren<Renderer>())
		//{
		//	r.enabled = false;
		//}
	}

	void Start()
	{
		
	}

    public GameObject currentSelectedGraph {
        get { return currentSelectedtGraph; }
        set { currentSelectedtGraph = value;  }
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
        if (currentSelectedtGraph != null && IsTheCurrentGraphPlaced == false)
        {
            currentSelectedtGraph.transform.localPosition = origin; // this.transform.localPosition;
            IsTheCurrentGraphPlaced = true;
        }
	}

	public void addSurface(GameObject newsurface)
	{
		graphsList.Add(newsurface);
		currentSelectedtGraph = graphsList[graphsList.Count-1]; // create a new instance where the parent is the vectorial space 
    }

}
