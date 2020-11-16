using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public class LineGraphManager : MonoBehaviour
{
    public GameObject linerenderer;
    public GameObject pointer;

    public GameObject pointerRed;
    public GameObject pointerBlue;

    public GameObject holderPrefab;

    public GameObject holder;
    public GameObject xLineNumber;

    public Material bluemat;
    public Material greenmat;

    public int animationSpeed = 10;
    public Text topValue;

    public List<float> graphData = new List<float>();

    private float highestValue = 56;

    public Transform origin;

    private float lrWidth = 0.1f;
    private int dataGap = 0;


    void Start()
    {
    }

    public void fillData(List<float> dataPoints)
    {
        dataGap = 0;
        graphData = dataPoints;
        highestValue = dataPoints.Max();
    }

    private void ShowData(List<float> gdlist, float gap)
    {
        // Adjusting value to fit in graph
        for (int i = 0; i < gdlist.Count; i++)
        {
            // since Y axis is from 0 to 7 we are dividing the marbles with the highestValue
            // so that we get a value less than or equals to 1 and than we can multiply that
            // number with Y axis range to fit in graph. 
            // e.g. marbles = 90, highest = 90 so 90/90 = 1 and than 1*7 = 7 so for 90, Y = 7
            gdlist[i] = (gdlist[i] / highestValue) * 7;
        }

        StartCoroutine(BarGraphBlue(gdlist, gap));
    }

    public void ShowGraph()
    {
        ClearGraph();

        if (graphData.Count >= 1)
        {
            holder = Instantiate(holderPrefab, Vector3.zero, Quaternion.identity);
            holder.name = "h2";
            ShowData(graphData, 1);
        }
    }

    public void ClearGraph()
    {
        if (holder)
            Destroy(holder);
    }


    IEnumerator BarGraphBlue(List<float> gd, float gap)
    {
        float xIncrement = gap;
        int dataCount = 0;
        bool flag = false;
        Vector3 originPosition = origin.position;
        Vector3 startpoint = new Vector3((originPosition.x + xIncrement), (originPosition.y + gd[dataCount]),
            (originPosition.z));

        while (dataCount < gd.Count)
        {
            Vector3 endpoint = new Vector3((originPosition.x + xIncrement), (originPosition.y + gd[dataCount]),
                (originPosition.z));
            startpoint = new Vector3(startpoint.x, startpoint.y, originPosition.z);
            // pointer is an empty gameObject, i made a prefab of it and attach it in the inspector
            GameObject p = Instantiate(pointer, new Vector3(startpoint.x, startpoint.y, originPosition.z),
                Quaternion.identity);
            p.transform.parent = holder.transform;

            GameObject lineNumber = Instantiate(xLineNumber,
                new Vector3(originPosition.x + xIncrement, originPosition.y - 0.18f, originPosition.z),
                Quaternion.identity);
            lineNumber.transform.parent = holder.transform;
            lineNumber.GetComponent<TextMesh>().text = (dataCount + 1).ToString();

            // linerenderer is an empty gameObject with Line Renderer Component Attach to it, 
            // i made a prefab of it and attach it in the inspector
            GameObject lineObj = Instantiate(linerenderer, startpoint, Quaternion.identity);
            lineObj.transform.parent = holder.transform;
            lineObj.name = dataCount.ToString();

            LineRenderer lineRenderer = lineObj.GetComponent<LineRenderer>();

            lineRenderer.material = bluemat;
            lineRenderer.SetWidth(lrWidth, lrWidth);
            lineRenderer.SetVertexCount(2);

            while (Vector3.Distance(p.transform.position, endpoint) > 0.2f)
            {
                float step = animationSpeed * Time.deltaTime;
                p.transform.position = Vector3.MoveTowards(p.transform.position, endpoint, step);
                lineRenderer.SetPosition(0, startpoint);
                lineRenderer.SetPosition(1, p.transform.position);

                yield return null;
            }

            lineRenderer.SetPosition(0, startpoint);
            lineRenderer.SetPosition(1, endpoint);
            
            p.transform.position = endpoint;
            GameObject pointered = Instantiate(pointerRed, endpoint, pointerRed.transform.rotation);
            pointered.transform.parent = holder.transform;
            startpoint = endpoint;

            dataCount += 1;

            xIncrement += gap;

            yield return null;
        }
    }
}