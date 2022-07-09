using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterMove : MonoBehaviour
{
    float speed = 0.15f;
    [SerializeField] TMP_Text episodeText;
    public static bool dead = false; 
    static int rndColor;
    float playerX;
    [SerializeField] Joystick joyStick;
    [SerializeField] GameObject frontCube;
    [SerializeField] Material frontCubeMaterial;
    private void Start()
    {
        episodeText.text = System.Convert.ToString(CreateCubes.episode);
    }
    // Start is called before the first frame update
    void Awake()
    {
        dead = false;
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
        playerX = joyStick.Horizontal / 10f;

            if (!dead)
            {
                if (transform.position.z >= -2.50f && transform.position.z <= 2.50f)
                {
                    transform.position = transform.position + new Vector3(speed, 0f, -playerX);
                }
                else
                {
                    if (transform.position.z <= -2.50f)
                    {
                        transform.position = transform.position + new Vector3(speed, 0f, 0.01f);
                    }
                    else if (transform.position.z >= 2.50f)
                    {
                        transform.position = transform.position + new Vector3(speed, 0f, -0.01f);
                    }
                }
            }
    }
    private void OnDisable()
    {
        PlayerPrefs.DeleteKey("levels");
    }

}
