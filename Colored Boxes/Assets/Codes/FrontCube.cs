using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class FrontCube : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera CameraFollow;
    [SerializeField] GameObject deadPanel;
    [SerializeField] GameObject nextLevelPanel;

    [SerializeField] GameObject particleSystem;
    [SerializeField] GameObject wrongParticleSystem;
    [SerializeField] AudioSource bing1;
    [SerializeField] AudioSource bing2;
    bool colorBtn = false;
    float a = 0;
    GameObject[] frontCubes;
    [SerializeField] Material frontCubeMaterial;
    [SerializeField] GameObject frontCube;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] frontCubes = GameObject.FindGameObjectsWithTag("frontcube");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Finish();
        }
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
                    GameObject effect = Instantiate(particleSystem, frontCube.transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
                    ParticleSystem particle = effect.GetComponent<ParticleSystem>();
                    particle.startColor = Color.red;
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
                    GameObject effect = Instantiate(particleSystem, frontCube.transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
                    ParticleSystem particle = effect.GetComponent<ParticleSystem>();
                    particle.startColor = Color.blue;
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
                    GameObject effect = Instantiate(particleSystem, frontCube.transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
                    ParticleSystem particle = effect.GetComponent<ParticleSystem>();
                    particle.startColor = Color.green;
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
        if (frontCubes.Length <= 1)
        {
            CharacterMove.dead = true;
            Invoke("DeadPanelOpen", 1f);
        }
        bing2.Play();
        Instantiate(wrongParticleSystem, frontCube.transform.position + new Vector3(1f, 0f, 0f), Quaternion.identity);
        Destroy(frontCubes[frontCubes.Length - 1]);
    }

    void Finish()
    {
        GameObject[] frontCubes = GameObject.FindGameObjectsWithTag("frontcube");
        foreach (GameObject item in frontCubes)
        {
            item.AddComponent<BoxCollider>();
            item.AddComponent<Rigidbody>();
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.right * 500f);
        }
        CreateCubes.episode++;
        PlayerPrefs.SetInt("levels", CreateCubes.episode);
        CharacterMove.dead = true;
        Invoke("NextPanelOpen", 1f);
    }

    void DeadPanelOpen()
    {
        deadPanel.SetActive(true);
    }

    void NextPanelOpen()
    {
        nextLevelPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
