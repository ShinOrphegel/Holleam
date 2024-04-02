using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1_Tornado : MonoBehaviour
{
    Scene1_SwordMan s1sm;
    public float bulletMoveSpeed;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        s1sm = FindObjectOfType<Scene1_SwordMan>();
        direction = this.transform.position - s1sm.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= direction * Time.deltaTime * bulletMoveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}
