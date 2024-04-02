using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1_WM : MonoBehaviour
{
    Scene1_SwordMan s1sm;
    Scene1_Wolf s1w;
    Vector3 startPoint;
    Vector3 endPoint;
    // Start is called before the first frame update
    void Start()
    {
        s1sm = FindAnyObjectByType<Scene1_SwordMan>();
        s1w = FindAnyObjectByType<Scene1_Wolf>();
        startPoint = s1w.transform.position;
        endPoint = s1sm.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (s1w.transform.position == endPoint)
        {
            Destroy(gameObject);
        }
        else
        {
            s1w.transform.position = Vector3.MoveTowards(startPoint, endPoint, 1);
        }
            
    }
}
