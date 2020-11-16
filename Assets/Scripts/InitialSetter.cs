using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class InitialSetter : MonoBehaviour
{
    private static readonly List<float> startingGdpVals = new List<float>
    {
        157.6f, 158f, 158.1f, 158.2f, 158.2f, 158.3f,
        157.5f, 156f, 154f, 150f, 149f, 147f
    };
    public FloatValueList gdpHistory;
    // Start is called before the first frame update
    void Start()
    {
        gdpHistory.Clear();
        startingGdpVals.ForEach(val => gdpHistory.Add(val));
    }

    
}
