using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene1_Controller : MonoBehaviour
{
    //Biến nhập từ bên unity
    public float changePhaseTime; //20
    public int miniphase; //0
    Scene1_SMHP player;
    Scene1_Wolf wolf;
    public AudioSource ads;
    public AudioClip win;
    public AudioClip lose;

    //Biến private
    float cpt; //change phase time
    int mnp; //miniphase
    int isEnd; //0 la dang dien ra, 1 la thang, 2 la thua

    // Start is called before the first frame update
    void Start()
    {
        cpt = changePhaseTime;
        mnp = miniphase;
        player = FindObjectOfType<Scene1_SMHP>();
        wolf = FindObjectOfType<Scene1_Wolf>();
        isEnd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnd == 0)
        {
            cpt -= Time.deltaTime;
            if (cpt <= 0)
            {
                mnp += 1;
                cpt = changePhaseTime;
                if (mnp == 2)
                {
                    mnp = 0;
                }
            }
            // kiem tra game da end chua
            if (wolf.getHP() <= 0)
            {
                isEnd = 1;
                ads.PlayOneShot(win);
            }else if(player.getHP() <= 0)
            {
                isEnd = 2;
                ads.PlayOneShot(lose);
            }
        }



    }

    public float getCPT()
    {
        return this.cpt;
    }

    public float getMNP()
    {
        return this.mnp;
    }

    public int getEnd()
    {
        return isEnd;
    }

    public void replay()
    {
        player.callStart();
        wolf.callStart();
        Start();
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
