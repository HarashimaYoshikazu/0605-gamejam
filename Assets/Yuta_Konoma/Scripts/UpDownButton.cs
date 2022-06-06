using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDownButton : MonoBehaviour
{
    public RawImage Card1;
    public RawImage Card2;
    public Image Inside;
    public AudioClip sound02;
    private AudioSource audioSE;
    public ParticleSystem StarParticle;
    public void Start()
    {
        audioSE = gameObject.AddComponent<AudioSource>();
    }
    public void OnUpButton()
    {
        audioSE.PlayOneShot(sound02);
        Debug.Log("カード1は" + NumberManager.Instance.currentCard);
        Debug.Log("カード2は" + NumberManager.Instance.nextCard);

        if (NumberManager.Instance.currentCard > NumberManager.Instance.nextCard)
        {        
            Debug.Log("WIN");
            GameManager.Instance.ChangeGold(20);
        }
        else if (NumberManager.Instance.currentCard == NumberManager.Instance.nextCard)
        {
            Debug.Log("DRAW");
            GameManager.Instance.ChangeGold(10);
        }
        else
        {
            Debug.Log("LOSE");
            GameManager.Instance.ChangeGold(0);
        }
        Inside.enabled = false;
    }

    public void OnDownButton()
    { 
        audioSE.PlayOneShot(sound02);
        Debug.Log("カード1は" + NumberManager.Instance.currentCard);
        Debug.Log("カード2は" + NumberManager.Instance.nextCard);
        if(NumberManager.Instance.currentCard < NumberManager.Instance.nextCard)
        {
            Debug.Log("WIN");
            GameManager.Instance.ChangeGold(20);
        }
        else if(NumberManager.Instance.currentCard == NumberManager.Instance.nextCard)
        {
            Debug.Log("DRAW");
            GameManager.Instance.ChangeGold(10);
        }
        else
        {
            Debug.Log("LOSE");
            GameManager.Instance.ChangeGold(0);
        }
        Inside.enabled = false;
    }


}
