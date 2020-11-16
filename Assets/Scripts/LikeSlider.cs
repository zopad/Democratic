using System.Collections;
using System.Collections.Generic;
using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Slider = UnityEngine.UI.Slider;

public class LikeSlider : MonoBehaviour
{
    public IntEvent likeStatChanged;
    public Gradient gradient;
    public Image sliderFill;
    public Slider slider;
    void Start()
    {
        IntAction anyád = IntAction.CreateInstance<IntAction>();
        likeStatChanged.Register(OnEventRaised);
    }

    public void OnEventRaised(int newLike)
    {
        sliderFill.color = gradient.Evaluate(newLike/100f);
        slider.value = newLike;
    }
}
