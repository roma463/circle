using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionPartical : MonoBehaviour
{
    private controlmovesObj _control;
    private bool n;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _control = transform.parent.GetComponent<controlmovesObj>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "circle")
        {
            //_control.Anim();
        }
    }
}
