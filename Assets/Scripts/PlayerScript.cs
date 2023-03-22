using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    //declare variables
    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    private int scoreValue;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public Text lives;
    private int livesValue;

    public AudioClip musicSourceOne;
    public AudioClip musicSourceTwo;
    public AudioSource musicSource;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Gets the component of the rigid body
        rd2d = GetComponent<Rigidbody2D>();
        //initialize the score
        score.text = scoreValue.ToString();
        //set lives to 3
        livesValue = 3;
        //initialize the lives
        lives.text = livesValue.ToString();
        

        //win message is off to start
        winTextObject.SetActive(false);
        //lose message is off to start
        loseTextObject.SetActive(false);

        //music starts once game starts
        musicSource.clip = musicSourceOne;
        musicSource.loop = true;
        musicSource.Play();

    }

    // Update is called once per frame
    // Use this update fuction for physics
    void FixedUpdate()
    {
        //Taken from default for project settings
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        //Applies the force
        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));
    }



    //Collision method
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.collider.tag == "Coin")
        {
            //adds one to the score when player collides with coin
            scoreValue += 1;
            score.text = "Score " + scoreValue.ToString();
            //displays win message
            if(scoreValue == 4)
            {
                transform.position = new Vector2(50.0f, 0.5f);
                
                livesValue = 3;
                lives.text = "Lives: " + livesValue.ToString();
            }

            if(scoreValue == 8)
            {
                winTextObject.SetActive(true);
                speed = 0;
                musicSource.Stop();

                musicSource.clip = musicSourceTwo;
                musicSource.loop = true;
                musicSource.Play();
            }
            //destroys the coin when player collides with it
            Destroy(collision.collider.gameObject);
        }

        if(collision.collider.tag == "Enemy")
        {
            //takes away one life
            livesValue -= 1;
            lives.text = "Lives: " + livesValue.ToString();
            //displays lose message
            if(livesValue == 0)
            {
                loseTextObject.SetActive(true);
                speed = 0;
            }
            //destroys UFO when player collides with it
            Destroy(collision.collider.gameObject);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground") 
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }

    
}
