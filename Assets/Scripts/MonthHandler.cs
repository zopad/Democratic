using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Transition;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class MonthHandler : MonoBehaviour
{
    public int thisMonth;
    public IntEvent monthChangedEvent;
    public Image buttonCap;

    private readonly Color greyColor = new Color32(105, 121, 132, 255);
    private readonly Color greenColor = new Color32(5, 188, 41, 255);

    // Start is called before the first frame update
    void Start()
    {
        monthChangedEvent.Register(OnEventRaised);
    }

    public void OnEventRaised(int month)
    {
        if (month == thisMonth)
        {
            buttonCap.colorTransition(greenColor, 0.25f);
        }
        else if (thisMonth != 12 /* don't wanna change the gold color of DEC */)
        {
            buttonCap.colorTransition(greyColor, 0.25f);
        }
    }
}
