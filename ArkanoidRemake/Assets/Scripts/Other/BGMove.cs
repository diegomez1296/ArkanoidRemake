﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMove : MonoBehaviour
{
    private RawImage rawImage;
    private float valueX, valueY;
    private float time = 0.01f;

    private void Start() => rawImage = GetComponent<RawImage>();
    private void OnEnable () => StartCoroutine(MoveBG(time));
    private void OnDisable () => StopCoroutine(MoveBG(time));

    IEnumerator MoveBG(float time)
    {
        yield return new WaitForSeconds(time);
        valueX = rawImage.uvRect.x;// - 0.001f;
        valueY = rawImage.uvRect.y + 0.0002f;

        rawImage.uvRect = new Rect(valueX, valueY, 1, 1);
        StartCoroutine(MoveBG(time));
    }
}
