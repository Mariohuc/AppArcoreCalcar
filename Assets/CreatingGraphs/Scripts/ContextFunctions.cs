using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextFunctions : MonoBehaviour {

    // Use this for initialization
    private static MathematicalFunction selectedFunction = null;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public static MathematicalFunction SelectedFunction{
        set { selectedFunction = value; }
        get { return selectedFunction; }
    }
}
