using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MetricBehaviour : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut() {
        for (float i = 1; i >=0; i -=Time.deltaTime) {
            _spriteRenderer.material.color = new Color(1,1,1,i);
            yield return null;
        }
    }
}
