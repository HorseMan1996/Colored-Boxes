using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{
    [SerializeField] GameObject[] platforms;

    private void Awake()
    {
        CreatePlatforms();
    }
    public void CreatePlatforms()
    {
        for (int i = 0; i < 15 * CreateCubes.episode; i++)
        {
            Instantiate(platforms[0], new Vector3(i * 10, 0f, 0f), Quaternion.identity);
        }
        
    }
   /* // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
