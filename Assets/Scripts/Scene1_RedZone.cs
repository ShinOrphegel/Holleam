using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1_RedZone : MonoBehaviour
{
    float timex = 1;
    float xtime;
    // Start is called before the first frame update
    void Start()
    {
        xtime = timex;
    }

    // Update is called once per frame
    void Update()
    {
        xtime -= Time.deltaTime;
        if(xtime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
