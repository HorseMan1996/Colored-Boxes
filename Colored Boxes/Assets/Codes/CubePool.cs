using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    public static GameObject cubeBlue;
    public static GameObject cubeRed;
    public static GameObject cubeGreen;

    public static GameObject cubeColor;
    public static Material cubeColorMaterial;
    // Start is called before the first frame update
    void Awake()
    {
        cubeBlue = GameObject.Find("GreenBtn");
        cubeRed = GameObject.Find("RedBtn");
        cubeGreen = GameObject.Find("BlueBtn");

        cubeColor = GameObject.Find("ColorBtn");
        cubeColorMaterial = cubeColor.GetComponent<Material>();
    }
}
