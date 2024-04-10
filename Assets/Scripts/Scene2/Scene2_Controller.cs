using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Scene2_Controller : MonoBehaviour
{
    public TextMeshProUGUI story;
    public string[] storyContent;
    public TextMeshProUGUI dialogCharacter;
    public string[] dialogCharacterName;
    public TextMeshProUGUI dialogTxt;
    public string[] dialogContent;
    public float showingSpeed;
    public GameObject bar;
    public GameObject mainImage;
    public GameObject windGodImage;
    public GameObject wolfImage;
    public GameObject forestBG;
    public GameObject darkBG;
    public GameObject ruinBG;

    public AudioSource ads;

    private int storyCount;
    private int sentenceIndex;
    private Coroutine ShowCo;
    // Start is called before the first frame update
    void Start()
    {
        ShowCo = StartCoroutine(ShowCox());
        storyCount = 0;
        sentenceIndex = 0;
/*        bar.SetActive(true);
        mainImage.SetActive(false);
        windGodImage.SetActive(false);
        wolfImage.SetActive(true);
        forestBG.SetActive(true);
        darkBG.SetActive(false);
        ruinBG.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            nextDialog();
        }
    }

    private IEnumerator ShowCox()
    {
        //play audio
        dialogCharacter.text = "";
        dialogTxt.text = "";
        story.text = "";
        if (dialogCharacterName[sentenceIndex] == "Knight")
        {
            bar.SetActive(true);
            mainImage.SetActive(true);
            windGodImage.SetActive(false);
            wolfImage.SetActive(false);
            forestBG.SetActive(false);
            darkBG.SetActive(false);
            ruinBG.SetActive(true);
        }
        else if (dialogCharacterName[sentenceIndex] == "Azelf")
        {
            bar.SetActive(true);
            mainImage.SetActive(false);
            windGodImage.SetActive(true);
            wolfImage.SetActive(false);
            forestBG.SetActive(false);
            darkBG.SetActive(false);
            ruinBG.SetActive(true);
        }
        else if (dialogCharacterName[sentenceIndex] == "King Wolf")
        {
            bar.SetActive(true);
            mainImage.SetActive(false);
            windGodImage.SetActive(false);
            wolfImage.SetActive(true);
            darkBG.SetActive(false);
            if (sentenceIndex <= 1)
            {
                forestBG.SetActive(true);
                ruinBG.SetActive(false);
            }
            else
            {
                forestBG.SetActive(false);
                ruinBG.SetActive(true);
            }
        }
        else
        {
            bar.SetActive(false);
            mainImage.SetActive(false);
            windGodImage.SetActive(false);
            wolfImage.SetActive(false);
            forestBG.SetActive(false);
            darkBG.SetActive(true);
            ruinBG.SetActive(false);
            foreach (char c in storyContent[storyCount].ToCharArray())
            {
                story.text += c;
                yield return new WaitForSeconds(showingSpeed);
            }
            storyCount++;
        }
        foreach (char c in dialogCharacterName[sentenceIndex].ToCharArray())
        {
            dialogCharacter.text += c;
        }
        
        foreach (char c in dialogContent[sentenceIndex].ToCharArray())
        {
            dialogTxt.text += c;
            yield return new WaitForSeconds(showingSpeed);
        }
    }

    public void nextDialog()
    {
        if (sentenceIndex < (dialogContent.Length - 1))
        {
            sentenceIndex++;
            if (ShowCo != null)
            {
                StopAllCoroutines();
            }
            //dialogTxt.text = "";

            ShowCo = StartCoroutine(ShowCox());

        }
        else
        {
            SceneManager.LoadScene("Scene1");
        }
    }
}
