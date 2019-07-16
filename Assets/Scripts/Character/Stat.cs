using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public float value;

    public Stat(float start)
    {
         value = start;
    }

    public void Add(float plus)
    {
        value += plus;
    }

    public void Remove(float minus)
    {
        value -= minus;
    }
}
