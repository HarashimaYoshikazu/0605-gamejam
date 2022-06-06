using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleButton : MonoBehaviour
{
   
    public void StartButton()
    {
        SceneManager.LoadScene("takahasi");
    }
 
    public void ExplanationButton()
    {
        SceneManager.LoadScene("ExplanationScene",LoadSceneMode.Additive);
    }
    public void StartScene()
    {
        SceneManager.LoadScene("Title");
    }
}
