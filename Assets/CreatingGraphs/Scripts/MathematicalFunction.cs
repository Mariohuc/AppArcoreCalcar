using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface MathematicalFunction {

    Vector3 graph(float u, float v, float t);
    Parameter [] getParameters( );
    void updateParameter(string parameter, float value);
}
