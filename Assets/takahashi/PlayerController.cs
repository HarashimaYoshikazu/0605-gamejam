using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float _speed = 5f;

    Rigidbody2D _rb = null;
    Animator _anim = null;
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
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(h,v).normalized*_speed;

        _anim.SetFloat("X",h);
        _anim.SetFloat("Y",v);
        if(_rb.velocity ==Vector2.zero)
        {
            _anim.SetBool("isMove",false);
        }
        else
        {
            _anim.SetBool("isMove", true);
        }
    }

    //ÉVÅ[ÉìÇÃêÿÇËë÷Ç¶
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("test"))
        {
            SceneManager.LoadScene("test", LoadSceneMode.Additive);
        }
        else if(collision.CompareTag("test2"))
        {
            SceneManager.LoadScene("test2", LoadSceneMode.Additive);
        }
        
    }
}
