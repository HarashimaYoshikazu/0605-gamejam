using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    Sprite[] _slotImageArray;

    Sprite[] _array1;
    Sprite[] _array2;
    Sprite[] _array3;

    [SerializeField]
    Image[] _slotColumm = new Image[3];

    [SerializeField]
    int _rollValue = 10;
    float _timer = 0f;

    int[] _stacks = new int[3] {0,0,0};

    void Start()
    {
        _array1 = new Sprite[_slotImageArray.Length];
        for (int f = 0; f < _slotImageArray.Length; f++)
        {
            if (f == _slotImageArray.Length - 1)
            {
                _array1[f] = _slotImageArray[0];
            }
            else
            {
                _array1[f] = _slotImageArray[f + 1];
            }

        }
        _array2 = new Sprite[_slotImageArray.Length];
        for (int h = 0; h < _slotImageArray.Length; h++)
        {
            if (h == _slotImageArray.Length - 2)
            {
                _array2[h] = _slotImageArray[0];
            }
            else if (h == _slotImageArray.Length - 1)
            {
                _array2[h] = _slotImageArray[1];
            }
            else
            {
                _array2[h] = _slotImageArray[h + 2];
            }

        }
        _array3 = _slotImageArray;
    }

    private void Update()
    {
        
    }
}
