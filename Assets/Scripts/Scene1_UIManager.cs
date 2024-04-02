using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scene1_UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject winPanel;
    Scene1_Controller ctl;

    float curHP;
    // Start is called before the first frame update
    void Start()
    {
        ctl = FindAnyObjectByType<Scene1_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ctl.getEnd() == 2)
        {
            gameOverPanel.SetActive(true);
        }else if(ctl.getEnd() == 1)
        {
            winPanel.SetActive(true);
        }else if(ctl.getEnd() == 0)
        {
            gameOverPanel.SetActive(false);
            winPanel.SetActive(false);
        }


    }

}
