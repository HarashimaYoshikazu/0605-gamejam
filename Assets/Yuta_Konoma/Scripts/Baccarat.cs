using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Baccarat : MonoBehaviour
{
    public RawImage Card1;
    public RawImage Card2;
    public Image Inside;
    public GameObject DrawButton;
    public GameObject UpButton;
    public GameObject DownButton;

    private AudioSource audioSE;
    public AudioClip sound01;

    

    public List<Texture> texture_list = new List<Texture>();
    public void Start()
    {
        Card1.enabled = false; 
        Card2.enabled = false;
        Card2 = GameObject.Find("CardImage2").GetComponent<RawImage>();
        Inside.enabled = false;
        UpButton.SetActive(false);
        DownButton.SetActive(false);
        audioSE = gameObject.AddComponent<AudioSource>();
        Card1 = GameObject.Find("CardImage1").GetComponent<RawImage>();       
        Read_img(0);
    }
    public void Read_img(int n)
    {
        Texture tmp;
        for (int i = 1; i < n + 1; i++)
        {
            tmp = Resources.Load("img/" + i) as Texture;
            texture_list.Add(tmp);
        }
    }
    public void Participation()
    {
        Invoke(nameof(ChangeImage), 0.5f);
        GameManager.Instance.ChangeGold(-10);
    }
    public void ChangeImage()
    {
        audioSE.PlayOneShot(sound01);
        Card1.enabled = true;
        Card2.enabled = true;
        Inside.enabled = true;

        NumberManager.Instance.currentCard = Random.Range(0, texture_list.Count);
        NumberManager.Instance.nextCard = Random.Range(0, texture_list.Count);
        Card1.texture = texture_list[NumberManager.Instance.currentCard];
        Card2.texture = texture_list[NumberManager.Instance.nextCard];

        DrawButton.SetActive(false);
        UpButton.SetActive(true);
        DownButton.SetActive(true);
    }
}
