using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    //Transforms to act as start and end markers for the journey
    public Transform startMarker;
    public Transform endMarker;
    //movement speed in units/sec
    public float speed = 1.0F;
    //time when the movement started
    private float startTime;
    //total distance between the markers
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        //keep note of the time the movement started
        startTime = Time.time;
        //calculate journey length
        journeyLength = Vector2.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        //distance moved = time * speed
        float distCovered = (Time.time - startTime) * speed;
        //fraction of journey completed  = current distance divided by total distance
        float fracJourney = distCovered / journeyLength;
        //set our position as a fraction of the distance between the markers and pingpong the movement
        transform.position = Vector2.Lerp(startMarker.position, endMarker.position, Mathf.PingPong (fracJourney, 1));
    }
}
