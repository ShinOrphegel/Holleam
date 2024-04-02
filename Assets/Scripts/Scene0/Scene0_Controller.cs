using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Scene0_Controller : MonoBehaviour
{
    public TextMeshProUGUI dialogTxt;
    public string[] dialogContent;
    public TextMeshProUGUI dialogCharacter;
    public string[] dialogCharacterName;
    public float showingSpeed;
    public GameObject mainImage;
    public GameObject woodSpiritImage;
    public GameObject wolfImage;

    public AudioSource ads;

    private int sentenceIndex;
    private Coroutine ShowCo;
    // Start is called before the first frame update
    void Start()
    {
    //    dialogTxt = GetComponent<TextMeshProUGUI>();
        ShowCo = StartCoroutine(ShowCox());
        sentenceIndex = 0;
        mainImage.SetActive(true);
        woodSpiritImage.SetActive(false);
        wolfImage.SetActive(false);
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
        if(dialogCharacterName[sentenceIndex] == "Main")
        {
            mainImage.SetActive(true);
            woodSpiritImage.SetActive(false);
            wolfImage.SetActive(false);

        }else if (dialogCharacterName[sentenceIndex] == "Wood Spirit")
        {
            mainImage.SetActive(false);
            woodSpiritImage.SetActive(true);
            wolfImage.SetActive(false);
        }
        else if(dialogCharacterName[sentenceIndex] == "King Wolf")
        {
            mainImage.SetActive(false);
            woodSpiritImage.SetActive(false);
            wolfImage.SetActive(true);
        }
        else
        {
            mainImage.SetActive(false);
            woodSpiritImage.SetActive(false);
            wolfImage.SetActive(false);
        }
        foreach (char c in dialogCharacterName[sentenceIndex].ToCharArray())
        {
            dialogCharacter.text += c;
        }
        dialogTxt.text = "";
        foreach(char c in dialogContent[sentenceIndex].ToCharArray())
        {
            dialogTxt.text += c;
            yield return new WaitForSeconds(showingSpeed);
        }
    }

    public void nextDialog()
    {
        if(sentenceIndex < (dialogContent.Length - 1))
        {
            sentenceIndex++;
            if (ShowCo != null)
            {
                //StopCoroutine(ShowCox());
                StopAllCoroutines();
            }
            dialogTxt.text = "";

            ShowCo = StartCoroutine(ShowCox());

        }
        else
        {
            SceneManager.LoadScene("Scene1");
        }
    }
}
