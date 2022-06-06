using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackJack : MonoBehaviour
{
    [SerializeField]
    RawImage _cardPrefab;
    [SerializeField]
    GameObject _winObject;
    [SerializeField]
    GameObject _loseObject;
    [SerializeField]
    GameObject[] _buttons = new GameObject[2];

    [Header("Dealer")]
    [SerializeField]
    RawImage[] _dealerHands = null;
    [SerializeField]
    Text _dealerHandText;
    int _dealerCount = 0;
    
    [Header("Player")]
    [SerializeField]
    List<RawImage> _playerHandsImage = new List<RawImage>();

    [SerializeField]
    Transform _playerHandTransform;

    [SerializeField]
    Text _playerHandText;
    int _playerCount = 0;


    void Start()
    {
        DealerSet();
        CreatePlayerCard(false);
        CreatePlayerCard(false);
    }

    public void CreatePlayerCard(bool isActive)
    {
        int rand = Random.Range(2, 14);
        if(rand>=10)
        {
            _playerCount += 10;
        }
        else
        {
            _playerCount += rand;
        }
        _playerHandText.text = _playerCount.ToString();

        var go = Instantiate(_cardPrefab, _playerHandTransform);
        go.texture = Resources.Load(rand.ToString()) as Texture;
        go.GetComponent<Card>().ActivePanel(isActive);
        _playerHandsImage.Add(go);

    }

    void DealerSet()
    {
        int rand = Random.Range(1, 14);
        if (rand >= 10)
        {
            _dealerCount += 10;
        }
        else
        {
            _dealerCount += rand;
        }

        _dealerHandText.text = _dealerCount.ToString();
        _dealerHands[0].texture = Resources.Load(rand.ToString()) as Texture;
    }

    public void EndGame()
    {
        int rand = Random.Range(1, 14);
        if (rand >= 10)
        {
            _dealerCount += 10;
        }
        else
        {
            _dealerCount += rand;
        }
        _dealerHands[1].GetComponent<Card>().ActivePanel(false);
        _dealerHandText.text = _dealerCount.ToString();
        _dealerHands[1].texture = Resources.Load(rand.ToString()) as Texture;

        if (_dealerCount<_playerCount && _playerCount<22)
        {
            _winObject.SetActive(true);
        }
        else
        {
            _loseObject.SetActive(true);
        }

        foreach(var i in _buttons)
        {
            i.SetActive(false);
        }
    }
}
