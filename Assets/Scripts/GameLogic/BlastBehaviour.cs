using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBehaviour : MonoBehaviour
{
    public float blast_distance = 5f;
    public float blast_speed = 2.5f;
    public GameObject self_reference; // will be passed a reference to self via the instantiator class.
    private Vector2 target;

    void Start()
    {
        target = transform.position + transform.right * blast_distance;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // could also use a Lerp instead:
        /*if (transform.position.x - startDist < blastDistance) {
            Debug.Log("moves");
            transform.position = new Vector2((transform.position.x + blastSpeed) * Time.deltaTime, transform.position.y);
        }*/

        // Later one, may want to export to a coroutine:
        /*if (timeElapsed < lerpDur) {
            valToLerp = Mathf.Lerp(startVal, endVal, timeElapsed / lerpDur);
            timeElapsed += Time.deltaTime;
        }
        else {
            valToLerp = endVal;
        }*/

        Vector2 curr_poz = transform.position;
        Vector2 distance = curr_poz - target;
        if (distance.magnitude > 0.5f) {
            Debug.Log(distance.magnitude);
            float step = blast_speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
        else { 
            Debug.Log("DESTROY");
            endBlast();
        }
    }

    private void endBlast() {
        Destroy(self_reference);
    }
}
