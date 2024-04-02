using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1_SMHP : MonoBehaviour
{
    public Image HPBar;

    float maxHP = 100;
    float curHP;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = curHP / maxHP;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wolf"))
        {
            curHP -= 20;
            Debug.Log(curHP);
        }
        if (collision.gameObject.CompareTag("Tornado"))
        {
            curHP -= 10;
            Debug.Log(curHP);
        }
        if (collision.gameObject.CompareTag("Icicle"))
        {
            curHP -= 15;
            Debug.Log(curHP);
        }

    }

    public float getHP()
    {
        return curHP;
    }

    public void callStart()
    {
        Start();
    }
}
