using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Baccarat2 : MonoBehaviour
{
    public RawImage Card2;
    

    public List<Texture> img_list = new List<Texture>();
    public void Start()
    {
        Card2 = GameObject.Find("CardImage2").GetComponent<RawImage>();
        //1�`10�̉摜��ǂݍ���
        Read_img(0);
    }
    public void Read_img(int n)
    {
        Texture tmp;
        for (int i = 1; i < n + 1; i++)
        {
            tmp = Resources.Load("img/" + i) as Texture;
            img_list.Add(tmp);
        }
    }

    public void ChangeImage()
    {
        //�P�`�\������摜�̐��������_���ŎZ�o
        int random = Random.Range(1, img_list.Count);
        Card2.texture = img_list[random];

    }

}
