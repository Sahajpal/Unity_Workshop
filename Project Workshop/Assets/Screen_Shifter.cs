using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Screen_Shifter : MonoBehaviour
{
    public string MenuOrSplash;
    public Image splashimage;
    public GameObject extra;
    public string loadlevel;
    public int lagtime;
    public int waitTime;
    public string[] texts;
    public TMP_Text textbox;

    IEnumerator Start()
    {
        if (MenuOrSplash == "Menu")
        {
            splashimage.canvasRenderer.SetAlpha(0.0f);

            FadeIn();
            yield return new WaitForSeconds(1f);
            extra.SetActive(true);

            
            

        }

        else if(MenuOrSplash == "Splash")
        {
            splashimage.canvasRenderer.SetAlpha(0.0f);

            FadeIn();
            yield return new WaitForSeconds(1f);
            TextSetter();
            extra.SetActive(true);

            yield return new WaitForSeconds(lagtime);
            SceneManager.LoadScene(loadlevel);

        }

    }


    void TextSetter()
    {
        string randomString = texts[Random.Range(0, texts.Length)];
        textbox.SetText(randomString);
    }

    void FadeIn()
    {
        splashimage.CrossFadeAlpha(1.0f, 1.5f, false);

    }

    public void LoadScene(string sceneName)
    {
        //Animation
        StartCoroutine(WaitForSceneLoad(sceneName));
    }

    private IEnumerator WaitForSceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
}

