using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{

    int rnd;
    private void Start()
    {
        for (int x = 20; x < 100; x=x+20)
        {
            rnd = Random.Range(1, 4);

            GameObject newColorBtn = Instantiate(CubePool.cubeColor, new Vector3(-0.35f + x - 7f, 0.49f, 0f), Quaternion.identity);
            MeshRenderer newColorBtnMesh = newColorBtn.GetComponent<MeshRenderer>();
            if (rnd == 1)
            {
                newColorBtnMesh.material.color = Color.red;
            }
            else if (rnd == 1)
            {
                newColorBtnMesh.material.color = Color.blue;
            }
            else
            {
                newColorBtnMesh.material.color = Color.green;
            }
            Debug.Log(x);
            for (int i = 0; i < 10; i++)
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

    }
}
