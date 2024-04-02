using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject worldBG;
    public GameObject windBG;
    public GameObject thunderBG;
    public GameObject iceBG;

    public GameObject GodOfWind;
    public GameObject GodOfThunder;
    public GameObject GodOfIce;

    public TextMeshProUGUI storyTXT;
    public TextMeshProUGUI windiceTXT;
    public TextMeshProUGUI thunderTXT;

    public float showSpeed;

    private Coroutine Show;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        worldBG.SetActive(true);
        windBG.SetActive(false);
        thunderBG.SetActive(false);
        iceBG.SetActive(false);

        GodOfWind.SetActive(false);
        GodOfThunder.SetActive(false);
        GodOfIce.SetActive(false);

        storyTXT.text = "";
        windiceTXT.text = "";
        thunderTXT.text = "";
        count = 0;
        Show = StartCoroutine(Showx());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Show != null)
            {
                StopCoroutine(Show);
            }
            Show = StartCoroutine(Showx());
        }
    }

    private IEnumerator Showx()
    {
        if(count == 0)
        {
            count = 1;
            string story0 = "Once upon a time, there was peaceful continent known as The Great World of Holleam.\n"
                + "It was ruled by being of almighty.\n"
                + "Azelf, the precense symbol for ideals.\n"
                + "Uxie, the precense symbol for the truth.\n"
                + "Mesprit, the precense  symbol for judgement.";
            //storyTXT.text = "";
            foreach (char c in story0.ToCharArray())
            {
                storyTXT.text += c;
                yield return new WaitForSeconds(showSpeed);
            }
        }else if(count == 1)
        {

            count = 2;
            worldBG.SetActive(false);
            windBG.SetActive(true);
            GodOfWind.SetActive(true);

            storyTXT.text = "";
            string story1 = "Azelf, the God of the Wind, immersing themself in the wind, travelling across the continent. " +
                "He brought the wind to blow through the villages, bringing life to all things. " +
                "Wind tells stories about brave heroes, teaching people to cultivate personal morality.";
            windiceTXT.text = "";
            foreach (char c in story1.ToCharArray())
            {
                windiceTXT.text += c;
                yield return new WaitForSeconds(showSpeed);
            }
        }else if(count == 2)
        {
            count = 3;
            windBG.SetActive(false);
            GodOfWind.SetActive(false);
            windiceTXT.text = "";
            thunderBG.SetActive(true);
            GodOfThunder.SetActive(true);
            string story2 = "Uxie, the God of Thunder, residing in the highest cloud of The Great World os Holleam. " +
                "Lightning is the eyes of The God, allowing them the most realistic view of all things in the world. " +
                "He devote all of his life to finding out: “ What is the truth of this world?”";
            foreach(char c in story2.ToCharArray())
            {
                thunderTXT.text += c;
                yield return new WaitForSeconds(showSpeed);
            }
        }else if(count == 3)
        {
            count = 4;
            thunderBG.SetActive(false);
            GodOfThunder.SetActive(false);
            thunderTXT.text = "";
            iceBG.SetActive(true);
            GodOfIce.SetActive(true);
            string story3 = "Mesprit, the God of Snow, who is the Chief Justice of The Great World of Holleam, judging whether human activities are right or not. " +
                "Every crime act has to pay the price, being punished by the calamity of snow. " +
                "Every guilty person will eventually spend the rest of their lives repenting in an eternal prison beneath the ice castle.";
            foreach (char c in story3.ToCharArray())
            {
                windiceTXT.text += c;
                yield return new WaitForSeconds(showSpeed);
            }
        }else if(count == 4)
        {
            count = 5;
            iceBG.SetActive(false);
            GodOfIce.SetActive(false);
            windiceTXT.text = "";
            worldBG.SetActive(true);
            string story4 = "However, coming with the flow of time, the order of the world is gradually established. " +
                "The god of snow became discordant to the other two. " +
                "For she felt their way of thinking were unsuitable for the meaning of “ruled”, and " +
                "she was the only ruler of this The Great World of Holleam.";
            foreach (char c in story4.ToCharArray())
            {
                storyTXT.text += c;
                yield return new WaitForSeconds(showSpeed);
            }
        }else
        {
            SceneManager.LoadScene("Scene0");
        }

    }

}
