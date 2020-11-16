using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class UseNewMetricValue : MonoBehaviour, IObserver<float>
{
    public Slider slider;

    public FloatValueList gdpHistory;
    // Start is called before the first frame update
    void Start()
    {
        gdpHistory.ObserveAdd().Subscribe(this);
    }

    private void setSlider(float newVal)
    {
        slider.value = newVal;
    }


    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(float value)
    {
        setSlider(value);
    }
}
