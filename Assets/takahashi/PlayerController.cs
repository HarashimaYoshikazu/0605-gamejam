using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    static private PlayerController _instance;
    static public PlayerController Instance => _instance;
    private PlayerController() { }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField]float _speed = 5f;

    Rigidbody2D _rb = null;
    Animator _anim = null;
    bool isMove = true;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
        //plaerÇÃëÄçÏ
    {
        if (isMove)
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            _rb.velocity = new Vector2(h, v).normalized * _speed;

            _anim.SetFloat("X", h);
            _anim.SetFloat("Y", v);
            if (_rb.velocity == Vector2.zero)
            {
                _anim.SetBool("isMove", false);
            }
            else
            {
                _anim.SetBool("isMove", true);
            }
        }

    }

    //ÉVÅ[ÉìÇÃêÿÇËë÷Ç¶
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BlackJack"))
        {
            SceneManager.LoadScene("BlackJack", LoadSceneMode.Additive);
            this.gameObject.SetActive(false);
            this.transform.position = Vector2.zero;
        }
        else if(collision.CompareTag("Bakara"))
        {
            SceneManager.LoadScene("BaccaratScene", LoadSceneMode.Additive);
            this.gameObject.SetActive(false);
            this.transform.position = Vector2.zero;
        }
        
    }

    public void ActivePlayer()
    {
        this.transform.position = Vector2.zero;
        this.gameObject.SetActive(true);
    }

    public void FalsePlayer()
    {
        this.transform.position = Vector2.zero;
        this.gameObject.SetActive(false);
    }

}
