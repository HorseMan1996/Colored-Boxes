using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    public static int episode = 1;
    float mapLength = 100;
    int rnd;
    private void Start()
    {
        if (PlayerPrefs.HasKey("levels"))
        {
            episode = PlayerPrefs.GetInt("levels");
        }
        Debug.Log("lan" + episode);
        for (int x = 20; x < mapLength * episode; x = x + 20)
        {
            rnd = Random.Range(1, 4);

            GameObject newColorBtn = Instantiate(CubePool.cubeColor, new Vector3(-0.35f + x - 7f, 0.49f, 0f), Quaternion.identity);
            MeshRenderer newColorBtnMesh = newColorBtn.GetComponent<MeshRenderer>();
            if (rnd == 1)
            {
                newColorBtnMesh.material.color = Color.red;
            }
            else if (rnd == 2)
            {
                newColorBtnMesh.material.color = Color.blue;
            }
            else
            {
                newColorBtnMesh.material.color = Color.green;
            }
            Debug.Log(x);
            for (int i = 0; i < mapLength / 10; i++)
            {
                if (rnd == 1)
                {
                    Instantiate(CubePool.cubeBlue, new Vector3(-0.35f + i + x, 0.5f, 1.5f), Quaternion.identity);
                    Instantiate(CubePool.cubeGreen, new Vector3(-0.35f + i + x, 0.5f, 0f), Quaternion.identity);
                    Instantiate(CubePool.cubeRed, new Vector3(-0.35f + i + x, 0.5f, -1.5f), Quaternion.identity);
                }
                else if (rnd == 2)
                {
                    Instantiate(CubePool.cubeGreen, new Vector3(-0.35f + i + x, 0.5f, 1.5f), Quaternion.identity);
                    Instantiate(CubePool.cubeBlue, new Vector3(-0.35f + i + x, 0.5f, 0f), Quaternion.identity);
                    Instantiate(CubePool.cubeRed, new Vector3(-0.35f + i + x, 0.5f, -1.5f), Quaternion.identity);
                }
                else
                {
                    Instantiate(CubePool.cubeRed, new Vector3(-0.35f + i + x, 0.5f, 1.5f), Quaternion.identity);
                    Instantiate(CubePool.cubeGreen, new Vector3(-0.35f + i + x, 0.5f, 0f), Quaternion.identity);
                    Instantiate(CubePool.cubeBlue, new Vector3(-0.35f + i + x, 0.5f, -1.5f), Quaternion.identity);
                }
            }
        }
        Instantiate(CubePool.cubeFinish, new Vector3(-0.35f + (mapLength * episode) - 7f, 0.49f, 0f), Quaternion.identity);
    }
}
