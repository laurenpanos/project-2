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
    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the component of the rigid body
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
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
            score.text = scoreValue.ToString();

            //destroys the coin when player collides with it
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
