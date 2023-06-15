using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controls : MonoBehaviour
{

    public GameObject square;

    public void doSomething()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(square, new Vector2(i * 2 - 8.4f, 0), Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
