using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    static int rndColor;
    float playerX;
    [SerializeField] GameObject frontCube;
    [SerializeField] Material frontCubeMaterial;
    // Start is called before the first frame update
    void Start()
    {
        rndColor = Random.Range(1, 4);
        if (rndColor == 1)
        {
            frontCubeMaterial.color = Color.red;
        }
        else if (rndColor == 2)
        {
            frontCubeMaterial.color = Color.blue;
        }
        else
        {
            frontCubeMaterial.color = Color.green;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerX = Input.GetAxis("Horizontal") / 10f;
        if (transform.position.z >= -2.50f && transform.position.z <= 2.50f)
        {
            transform.position = transform.position + new Vector3(0.2f, 0f, -playerX);
        }
        else
        {
            if (transform.position.z <= -2.50f)
            {
                transform.position = transform.position + new Vector3(0.2f, 0f, 0.01f);
            }
            else if (transform.position.z >= 2.50f)
            {
                transform.position = transform.position + new Vector3(0.2f, 0f, -0.01f);
            }
        }
        
    }

  
}
