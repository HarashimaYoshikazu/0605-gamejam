using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UpDownButton : MonoBehaviour
{
    public Button Up;
    public Button Down;
    public RawImage Card1;
    public RawImage Card2;
    public Image Inside;
    public AudioClip sound02;
    private AudioSource audioSE;
    [SerializeField]
    GameObject _win = null;
    [SerializeField]
    GameObject _lose = null;
    public void Start()
    {
        audioSE = gameObject.AddComponent<AudioSource>();
    }
    public void OnUpButton()
    {
        audioSE.PlayOneShot(sound02);
        Debug.Log("カード1は" + NumberManager.Instance.currentCard);
        Debug.Log("カード2は" + NumberManager.Instance.nextCard);

        if (NumberManager.Instance.currentCard < NumberManager.Instance.nextCard)
        {
            Debug.Log("WIN");
            Up.enabled = false;
            Down.enabled = false;
            GameManager.Instance.ChangeGold(20);
            var go = Instantiate(_win);
            LifeCycle.Instance.StartFiever();
            DOVirtual.DelayedCall(5f, () =>
            {
                PlayerController.Instance.ActivePlayer();
                SceneManager.UnloadScene("BaccaratScene");
                Up.enabled = false;
                Down.enabled = false;
                Destroy(go);
            });
        }
        else if (NumberManager.Instance.currentCard == NumberManager.Instance.nextCard)
        {
            PlayerController.Instance.ActivePlayer();
            Debug.Log("DRAW");
            Up.enabled = false;
            Down.enabled = false;
            GameManager.Instance.ChangeGold(10);
            DOVirtual.DelayedCall(3f, () =>
            {
                PlayerController.Instance.ActivePlayer();
                SceneManager.UnloadScene("BaccaratScene");
                Up.enabled = false;
                Down.enabled = false;
            });
        }
        else
        {
            Debug.Log("LOSE");
            Up.enabled = false;
            Down.enabled = false;
            GameManager.Instance.ChangeGold(-10);
            var go = Instantiate(_lose);
            DOVirtual.DelayedCall(2f, () =>
            {
                PlayerController.Instance.ActivePlayer();
                SceneManager.UnloadScene("BaccaratScene");
                Destroy(go);
                Up.enabled = false;
                Down.enabled = false;
            });
        }
        Inside.enabled = false;
    }

    public void OnDownButton()
    { 
        audioSE.PlayOneShot(sound02);
        Debug.Log("カード1は" + NumberManager.Instance.currentCard);
        Debug.Log("カード2は" + NumberManager.Instance.nextCard);
        if(NumberManager.Instance.currentCard > NumberManager.Instance.nextCard)
        {
            Debug.Log("WIN");
            GameManager.Instance.ChangeGold(20);
            LifeCycle.Instance.StartFiever();
            var go = Instantiate(_win);
            Up.enabled = false;
            Down.enabled = false;
            DOVirtual.DelayedCall(5f, () =>
            {
                PlayerController.Instance.ActivePlayer();
                SceneManager.UnloadScene("BaccaratScene");
                Destroy(go);
                Up.enabled = false;
                Down.enabled = false;
            });
        }
        else if(NumberManager.Instance.currentCard == NumberManager.Instance.nextCard)
        {
            
            Debug.Log("DRAW");
            Up.enabled = false;
            Down.enabled = false;
            GameManager.Instance.ChangeGold(10);
            DOVirtual.DelayedCall(3f, () =>
            {
                PlayerController.Instance.ActivePlayer();
                SceneManager.UnloadScene("BaccaratScene");
                Up.enabled = false;
                Down.enabled = false;
            });
        }
        else
        {
            GameManager.Instance.ChangeGold(-10);
            Debug.Log("LOSE");
            Up.enabled = false;
            Down.enabled = false;
            var go = Instantiate(_lose);
            DOVirtual.DelayedCall(2f, () =>
            {
                PlayerController.Instance.ActivePlayer();
                SceneManager.UnloadScene("BaccaratScene");
                Destroy(go);
                Up.enabled = false;
                Down.enabled = false;
            });
        }
        Inside.enabled = false;        
    }


}
