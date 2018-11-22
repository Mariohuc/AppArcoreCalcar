using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ellipsoid : MathematicalFunction {

    private const float pi = Mathf.PI;
    private Parameter a;
    private Parameter b;
    private Parameter c;

    public Ellipsoid() {

        a = new Parameter();
        a.Name = "a";
        a.Value = 2f;
        a.MinValue = 0.5f;
        a.MaxValue = 2.5f;

        b = new Parameter();
        b.Name = "b";
        b.Value = 1.2f;
        b.MinValue = 0.5f;
        b.MaxValue = 2.5f;

        c = new Parameter();
        c.Name = "c";
        c.Value = 0.6f;
        c.MinValue = 0.5f;
        c.MaxValue = 2.5f;
    }


    public Vector3 graph(float u, float v, float t)
    {
        Vector3 p;
        p.x = a.Value * Mathf.Cos(pi * u) * Mathf.Sin(pi * v);
        p.z = b.Value * Mathf.Sin(pi * u) * Mathf.Sin(pi * v);
        p.y = c.Value * Mathf.Cos(pi * v);

        return p;
    }
    public Parameter [] getParameters( ) {

        Parameter[] parameters = new Parameter[3];
        parameters[0] = a;
        parameters[1] = b;
        parameters[2] = c;
        return parameters;
    }

    public void updateParameter(string parameterName, float value) {

        if (a.Name.Equals(parameterName)) {
            a.Value = value;
            return;
        }
        if (b.Name.Equals(parameterName))
        {
            b.Value = value;
            return;
        }
        if (c.Name.Equals(parameterName))
        {
            c.Value = value;
        }
    }

}
