using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private BoxCollider2D _boxCollider2D;

    private SpriteRenderer _compSpriteRenderer;

    public float speedX;

    public float speedY;

    private int xDirection;

    private int yDirection;

    void Awake(){
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.isTrigger = false;
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start(){
        speedX = 2;
        speedY = 2;
        xDirection = 1;
        yDirection = 1;
    }

    // Update is called once per frame
    void Update(){  
    }

    void FixedUpdate(){
        _rigidbody2D.position = new Vector2(_rigidbody2D.position.x + speedX * Time.deltaTime * xDirection, _rigidbody2D.position.y + speedY * Time.deltaTime * yDirection);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rectangulo Vertical")
        {
            if (xDirection == 1)
            {
                xDirection = -1;
                _compSpriteRenderer.flipX = true;
            }
            else if (xDirection == -1)
            {
                xDirection = 1;
                _compSpriteRenderer.flipX = false;
            }
        }
        if (collision.gameObject.tag == "Rectangulo Horizontal")
        {
            if (yDirection == 1)
            {
                yDirection = -1;
                _compSpriteRenderer.flipY = true;
            }
            else if (yDirection == -1)
            {
                yDirection = 1;
                _compSpriteRenderer.flipY = false;
            }
        }
    }
}
