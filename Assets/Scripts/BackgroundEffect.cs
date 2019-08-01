using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundEffect : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private float speed;

    private void Update()
    {
        Color c1 = img.color;
        float H = 0;
        float S = 0;
        float V = 0;
        Color.RGBToHSV(c1, out H, out S, out V);
        H += speed;
        Color c2 = Color.HSVToRGB(H,S,V);
        img.color = c2;
    }
}
