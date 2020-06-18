using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Rigidbody rb;
    private float maxY=3.6f;
    private float minY = -5;
    private float y;
    private float score = 0;
    public Text t;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = transform.up * 250*Time.deltaTime;
            

        }
        if(transform.position.y<-4)
        {
            PlayerPrefs.SetFloat("s", score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void LateUpdate()
    {
        y = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="wall")
        {
            PlayerPrefs.SetFloat("s", score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "score")
        {
            score++;
            t.text = "SCORE : " + score;
        }
    }
}
