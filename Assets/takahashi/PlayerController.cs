using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float _speed = 5f;

    Rigidbody2D _rb = null;   
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(h,v).normalized*_speed;
    }

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
