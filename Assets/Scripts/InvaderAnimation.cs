using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadersAnimation : MonoBehaviour
{
    public Sprite[] animation;
    public float animationSpeed = 50f;
    

    
    public System.Action invaderDestroyed;
    private SpriteRenderer _spriteRenderer;

    private int frames;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        InvokeRepeating(nameof(SpriteAnimation), this.animationSpeed, this.animationSpeed);
    }

    private void SpriteAnimation()
    {
        frames++;

        if (frames >= this.animation.Length)
        {
            frames = 0;
        }

        _spriteRenderer.sprite = this.animation[frames];
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Invader 1"))
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Invader 2"))
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Invader 3"))
        {

            Destroy(this.gameObject);
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Mystery Ship"))
        {

            Destroy(this.gameObject);
        } 
        else
        {
            Destroy(this.gameObject);
        }
    }


}