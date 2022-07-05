using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCube : MonoBehaviour
{
    [SerializeField] AudioSource bing1;
    bool colorBtn = false;
    float a = 0;
    GameObject[] frontCubes;
    [SerializeField] Material frontCubeMaterial;
    [SerializeField] GameObject frontCube;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] frontCubes = GameObject.FindGameObjectsWithTag("frontcube");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "colorbtn")
        {
            MeshRenderer colorCube = other.GetComponent<MeshRenderer>();
            frontCubeMaterial.color = colorCube.material.color;
            colorBtn = true;
        }
        else if (!colorBtn)
        {
            if (frontCubeMaterial.color == Color.red)
            {
                if (other.gameObject.tag == "redbtn")
                {
                    Debug.Log("kırmızıya bastın");
                    Destroy(other.gameObject);
                    CreateFrontCube();
                }
                else
                {
                    DeleteFrontCube();
                }
            }
            else if (frontCubeMaterial.color == Color.blue)
            {
                if (other.gameObject.tag == "bluebtn")
                {
                    Debug.Log("kırmızıya bastın");
                    Destroy(other.gameObject);
                    CreateFrontCube();
                }
                else
                {
                    DeleteFrontCube();
                }
            }
            else if (frontCubeMaterial.color == Color.green)
            {
                if (other.gameObject.tag == "greenbtn")
                {
                    Debug.Log("kırmızıya bastın");
                    Destroy(other.gameObject);
                    CreateFrontCube();
                }
                else
                {
                    DeleteFrontCube();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "colorbtn")
        {
            colorBtn = false;
        }
    }

    void CreateFrontCube()
    {
        bing1.Play();
        a = a + 0.05f;
        Instantiate(frontCube, frontCube.transform.position + new Vector3(0f,a,0f), Quaternion.identity, player.transform);
      
    }

    void DeleteFrontCube()
    {
        a = a - 0.05f;
        GameObject[] frontCubes = GameObject.FindGameObjectsWithTag("frontcube");
        if (frontCubes.Length < 1)
        {
            Debug.Log("You Are Die");
        }
        Destroy(frontCubes[frontCubes.Length - 1]);
    }
}
