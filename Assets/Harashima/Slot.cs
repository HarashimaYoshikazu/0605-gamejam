using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    Sprite[] _slotImageArray;

    [SerializeField]
    Image[] _slotColumm = new Image[3];

    [SerializeField]
    int _rollValue = 10;


    void Start()
    {
        for (int i = 0; i < _slotColumm.Length; i++)
        {
            StartCoroutine(RollSlot(i));
        }
    }

    private void Update()
    {
    }
    IEnumerator RollSlot(int index)
    {
        int num = 0;
        while(true)
        {
            num++;

            yield return new WaitForSeconds(0.5f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                break;
            }
            _slotColumm[index].sprite =_slotImageArray[num%_slotImageArray.Length] ;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                break;
            }
        }


        yield return null;
    }

    bool IsSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;

        }
        return false;
    }
}
