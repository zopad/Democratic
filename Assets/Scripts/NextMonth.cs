using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class NextMonth : MonoBehaviour
{

    public IntVariable currentMonth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementMonth()
    {
        currentMonth.SetValue(currentMonth.Value + 1);
    }
}
