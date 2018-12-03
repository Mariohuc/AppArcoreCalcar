using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface MathematicalFunction
{
    string getFunctionName();
    Vector3 graph(float u, float v, float t);
    Parameter[] getParameters();
    Parameter getParameterByName(string name);
    void updateParameter(string parameter, float value);
}
