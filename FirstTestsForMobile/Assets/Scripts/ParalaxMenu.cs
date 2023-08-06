using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParalaxMenu : MonoBehaviour
{
    [SerializeField] private RawImage imag;
    [SerializeField] private float y;

    void Update()
    {
        imag.uvRect = new Rect(imag.uvRect.position + new Vector2(imag.uvRect.x, y) * Time.deltaTime,imag.uvRect.size); 
    }
}
