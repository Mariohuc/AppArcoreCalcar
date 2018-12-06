using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSheetedHyperboloid : MathematicalFunction {

    private const float pi = Mathf.PI;
    private Parameter a;
    private Parameter c;

    private string functionName = "Hiperboloide de una Hoja";

    public OneSheetedHyperboloid()
    {
        a = new Parameter();
        a.Name = "Radio de Falda [a]";
        a.Value = 1.5f;
        a.MinValue = 0.5f;
        a.MaxValue = 2.5f;

        c = new Parameter();
        c.Name = "Radio [c]";
        c.Value = 1f;
        c.MinValue = 0.5f;
        c.MaxValue = 2.5f;
    }

    public string getFunctionName()
    {
        return functionName;
    }

    public Vector3 graph(float u, float v, float t)
    {
        Vector3 p;
        //float a = 1.5f + Mathf.Sin(pi * (u + t)), c = 1f + Mathf.Sin(pi * (u + t));
        p.x = a.Value * Mathf.Sqrt(1 + u * u) * Mathf.Cos(pi * v);
        p.z = a.Value * Mathf.Sqrt(1 + u * u) * Mathf.Sin(pi * v);
        p.y = c.Value * u;

        return p;
    }
    public Parameter[] getParameters()
    {
        Parameter[] parameters = new Parameter[2];
        parameters[0] = a;
        parameters[1] = c;
        return parameters;
    }

    public void updateParameter(string parameterName, float value)
    {

        if (a.Name.Equals(parameterName))
        {
            a.Value = value;
            return;
        }
        if (c.Name.Equals(parameterName))
        {
            c.Value = value;
        }
    }

    public Parameter getParameterByName(string name)
    {
        Parameter a = null;
        foreach (Parameter temp in getParameters())
        {
            if (temp.Name.Equals(name))
                a = temp;
        }

        return a;
    }
}
