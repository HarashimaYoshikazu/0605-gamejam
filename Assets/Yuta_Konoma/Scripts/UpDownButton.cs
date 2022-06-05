using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDownButton : MonoBehaviour
{
    public RawImage Card1;
    public RawImage Card2;
    public Image Inside;

    private AudioSource audioSE;
    public AudioClip sound02;

    public void Start()
    {
        audioSE = gameObject.AddComponent<AudioSource>();
    }
    public void OnUpButton()
    {
        audioSE.PlayOneShot(sound02);
        var tex = Card1.texture;
        var tex2 = Card2.texture;
        Debug.Log("テクスチャは" + tex);
        Debug.Log("2のテクスチャは" + tex2);
        Inside.enabled = false;
    }

    public void OnDownButton()
    {
        audioSE.PlayOneShot(sound02);
        var tex = Card1.texture;
        var tex2 = Card2.texture;
        Debug.Log("テクスチャは" + tex);
        Debug.Log("2のテクスチャは" + tex2);
        Inside.enabled = false;
    }
}
