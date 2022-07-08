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
    public static GameObject cubeFinish;
    // Start is called before the first frame update
    void Awake()
    {
        cubeFinish = GameObject.Find("Finish");
        cubeBlue = GameObject.Find("GreenBtn");
        cubeRed = GameObject.Find("RedBtn");
        cubeGreen = GameObject.Find("BlueBtn");

        cubeColor = GameObject.Find("ColorBtn");
        cubeColorMaterial = cubeColor.GetComponent<Material>();
    }
}
