using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpDownButton : MonoBehaviour
{
    public RawImage Card1;
    public RawImage Card2;
    public void OnUpButton()
    {
        var tex = Card1.texture;
        var tex2 = Card2.texture;
        Debug.Log("�e�N�X�`����" + tex);
        Debug.Log("2�̃e�N�X�`����" + tex2);
    }

    public void OnDownButton()
    {
        var tex = Card1.texture;
        var tex2 = Card2.texture;
        Debug.Log("�e�N�X�`����" + tex);
        Debug.Log("2�̃e�N�X�`����" + tex2);
    }
}
