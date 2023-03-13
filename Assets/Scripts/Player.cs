using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 15f;
    
    public AudioSource playerSound;
    public AudioClip playerShot;

    public PlayerProjectile laserPrefab;

    private bool laserShot;
    
   
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerSound.PlayOneShot(playerShot);
            
            _animator.SetBool("Shot", true);
            Projectile();
        }
        else
        {
            _animator.SetBool("Shot", false);
        }




    }

    private void Projectile()
    {
        if (!laserShot)
        {
            PlayerProjectile playerProjectile =Instantiate(laserPrefab, this.transform.position, Quaternion.identity);
            playerProjectile.projectileDestroyed += ProjectileDestroyed;
            laserShot = true;
        }
    }

    private void ProjectileDestroyed()
    {
        laserShot = false;
    }



}


