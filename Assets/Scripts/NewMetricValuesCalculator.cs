using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class NewMetricValuesCalculator : MonoBehaviour
{
    public FloatValueList gdpHistory;    // in billion USD

    public FloatVariable gdpModifier; // current modifier value which may be positive or negative

    private float hack = -2.5f;

    public void calculateNextMonth()
    {
        float prev = gdpHistory.Get(gdpHistory.Count - 1);
    //    gdpHistory.RemoveAt(0); /* use if we want to only diplay last 12 months */
        float next = prev + (prev * hack / 100);
        gdpHistory.Add(next);
    }

   
}
