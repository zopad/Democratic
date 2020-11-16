using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MetricBehaviour : MonoBehaviour, IPointerEnterHandler
{
    public WMG_Axis_Graph graph;

    // TODO wrap this in a MetricHistory object with name, tooltip, etc 
    public FloatValueList history;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void fillGraphData()
    {
        WMG_Series series = graph.lineSeries[0].GetComponent<WMG_Series>();
        series.seriesName = "GDP"; // should come from obj
        graph.graphTitleString = "GDP";
        series.pointColor = Color.cyan;
        graph.yAxis.AxisMaxValue = history.Max() * 1.1f;
        graph.yAxis.AxisMinValue = history.Min() * 0.9f;
        graph.xAxis.AxisMaxValue = history.Count;
        graph.xAxis.AxisMinValue = 1;
        WMG_List<Vector2> pointValues = series.pointValues;
        pointValues.Clear();
        float x = 0;
        for (int i = 0; i < history.Count; i++)
        {
            pointValues.Add(new Vector2(x++, history.Get(i)));
        }
        graph.Refresh();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // unused maybe for hover?
    }
}
