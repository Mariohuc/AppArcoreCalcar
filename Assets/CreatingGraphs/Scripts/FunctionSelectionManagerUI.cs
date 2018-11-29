using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FunctionSelectionManagerUI : MonoBehaviour {

    public Image panelImage;
    // Use this for initialization
	void Start () {
        Button[] buttons = panelImage.GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => callGraphARViewer());
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void callGraphARViewer() {

        string FUNCTIONNAME = EventSystem.current.currentSelectedGameObject.name;

        if (FUNCTIONNAME.Equals("EButton"))
        {
            ContextFunctions.SelectedFunction = new Ellipsoid();
            SceneManager.LoadScene("GraphARViewer");
        }
            
        
    }
}
