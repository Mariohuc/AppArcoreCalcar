using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ellipsoid : MathematicalFunction {

    private const float pi = Mathf.PI;
    private string[] parameters = { "A", "B" };
    public Ellipsoid() { }


    public Vector3 graph(float u, float v, float t)
    {
        Vector3 p;

        float a = 2.5f, b = 1.6f, c = 1f;
        p.x = a * Mathf.Cos(pi * u) * Mathf.Sin(pi * v);
        p.z = b * Mathf.Sin(pi * u) * Mathf.Sin(pi * v);
        p.y = c * Mathf.Cos(pi * v);

        return p;
    }
    public string [] showParameterModifiers( ) {


        //var tempModifierPanel = Instantiate(setModifierPanel, parentPanel.transform);
        //Text[] text = setModifierPanel.GetComponentsInChildren<Text>();

        return null;
    }
    public void updateParameter(string parameter, float value) { }
}
