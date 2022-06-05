using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Baccarat : MonoBehaviour
{
    public RawImage Card1;
    public GameObject DrawButton;
    public GameObject UpButton;
    public GameObject DownButton;

    int Gold =10;

    public List<Texture> texture_list = new List<Texture>();
    public void Start()
    {
        UpButton.SetActive(false);
        DownButton.SetActive(false);
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
    public void ChangeImage()
    {
        int random = Random.Range(1, texture_list.Count);        
        Card1.texture = texture_list[random];

        DrawButton.SetActive(false);
        UpButton.SetActive(true);
        DownButton.SetActive(true);
    }

    public void EndGame()
    {
        //ˆø”‚ð“ü‚ê‚é
        GameManager.Instance.ChangeGold(Gold);
        Debug.Log(1);
    }
}
