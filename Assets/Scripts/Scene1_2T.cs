using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1_2T : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("1");
        if (collision.gameObject.CompareTag("wall"))
        {
            Debug.Log("2");
            Destroy(gameObject);
        }
    }
}
