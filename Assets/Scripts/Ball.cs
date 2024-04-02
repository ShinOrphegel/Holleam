using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  //  GameCotroller m_gc;


    // Start is called before the first frame update
    void Start()
    {
       // m_gc = FindObjectOfType<GameCotroller>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("c");
            Destroy(gameObject);
        }
    }
}
