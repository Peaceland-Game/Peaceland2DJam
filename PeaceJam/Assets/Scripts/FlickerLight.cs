using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    [SerializeField] Light pointLight; 
    [SerializeField] float flickerSpeed;
    [SerializeField] Vector2 intensityRange;
    [SerializeField] Vector2 lightRangeRange;

    // Update is called once per frame
    void Update()
    {
        float lerp = Mathf.PerlinNoise1D(Time.time * flickerSpeed);
        pointLight.intensity = Mathf.Lerp(lerp, intensityRange.x, intensityRange.y);
        pointLight.range = Mathf.Lerp(lerp, lightRangeRange.x, lightRangeRange.y);
    }
}
