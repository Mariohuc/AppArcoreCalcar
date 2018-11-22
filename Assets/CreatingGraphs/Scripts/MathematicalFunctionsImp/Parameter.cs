using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter
{
    private string name;
    private float value;
    private float maxValue;
    private float minValue;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public float Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

    public float MinValue
    {
        get { return minValue; }
        set { minValue = value; }
    }
    public float MaxValue
    {
        get { return maxValue; }
        set { maxValue = value; }
    }
}
