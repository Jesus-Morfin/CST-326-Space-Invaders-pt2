using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class PlayerProjectile : MonoBehaviour
{
    
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    public System.Action<PlayerProjectile> destroyed;
    private int score = 0;
    private int highScore;
    
    public AudioSource destroyedSound;
    public AudioClip explosion;
    
    private IEnumerator coroutine;



    public TextMeshProUGUI Score;
    public TextMeshProUGUI  HighScore;
    
    public Vector3 direction = Vector3.up;

    public System.Action projectileDestroyed;
    public float projectileSpeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.direction * (projectileSpeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Barricade"))
        {
            destroyedSound.PlayOneShot(explosion);
            Destroy(col.gameObject);
            this.projectileDestroyed.Invoke();
            Destroy(this.gameObject);
        }
        
        else if (col.CompareTag("Invader 1"))
        {
            destroyedSound.PlayOneShot(explosion);
            score += 10;
            totalScore();
            Destroy(col.gameObject);
            this.projectileDestroyed.Invoke();
            Destroy(this.gameObject);
        }
        else if (col.CompareTag("Invader 2"))
        {
            destroyedSound.PlayOneShot(explosion);
            score += 20;
            totalScore();
            Destroy(col.gameObject);
            this.projectileDestroyed.Invoke();
            Destroy(this.gameObject);
        }
        else if (col.CompareTag("Invader 3"))
        {
            destroyedSound.PlayOneShot(explosion);
            score += 30;
            totalScore();
            Destroy(col.gameObject);
            this.projectileDestroyed.Invoke();
            Destroy(this.gameObject);
        }
        else if (col.CompareTag("Mystery Ship"))
        {
            destroyedSound.PlayOneShot(explosion);
            int randomNumber = Random.Range(50, 300);
            score += randomNumber;
            totalScore();
            Destroy(col.gameObject);
            this.projectileDestroyed.Invoke();
            Destroy(this.gameObject);
        }
        else if(col.CompareTag("Player"))
        {
            destroyedSound.PlayOneShot(explosion);
            /*_animator.SetBool("Destroyed", true);
            coroutine = WaitTIME(2.0f);
            StartCoroutine(coroutine);
            Destroy(this.gameObject);*/
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
 
            
            
        }
        else if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            destroyedSound.PlayOneShot(explosion);
            _animator.SetBool("Destroyed", true);
            coroutine = WaitTIME(2.0f);
            StartCoroutine(coroutine);
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            destroyedSound.PlayOneShot(explosion);
            this.projectileDestroyed.Invoke();
            Destroy(this.gameObject);
        }
    }
    
     
    private void totalScore()
    {
        if (score < 100)
        {
            this.Score.text = "Score \n"+"00" + score.ToString();
            if (highScore < score)
            {
                highScore = score;
                if (highScore < 100)
                {
                    this.Score.text ="Hi-Score \n"+ "00" + highScore.ToString();
                }
                else if (highScore < 1000)
                {
                    this.Score.text ="Hi-Score \n"+ "0" + highScore.ToString();
                }
                else
                {
                    this.Score.text ="Hi-Score \n"+  highScore.ToString();
                }
            }
        }
        else if (score < 1000)
        {
            this.Score.text = "Score \n"+"0" + score.ToString();
        }
        else
        {
            this.Score.text ="Score \n"+  score.ToString();
        }
    }
    private void OnDestroy()
    {
        if (destroyed != null) {
            destroyed.Invoke(this);
        }
    }
    
    private IEnumerator WaitTIME(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }

}
