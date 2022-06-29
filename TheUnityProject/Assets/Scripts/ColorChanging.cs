using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorChanging : MonoBehaviour
{
    [SerializeField]Volume volume;
    ColorAdjustments CA;
    float h;

    void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out CA);
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeColor();
    }
    void ChangeColor()
    {
        h += 0.1f;
        if (h >= 180) h = -180;
        CA.hueShift.value = h;

    }
}
