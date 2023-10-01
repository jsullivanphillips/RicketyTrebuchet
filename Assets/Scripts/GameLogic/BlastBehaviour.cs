using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBehaviour : MonoBehaviour
{
    [SerializeField] private float blast_distance = 5f;
    [SerializeField] private float blast_speed = 2.5f;
    [SerializeField] private Transform target;
    public Transform blast_transform;// = this.transform; // <-- I want to do this, to prevent possible nondeterminism...

    void Start()
    {
        //blast_transform = this.transform;
        /*Vector2 dirVector = Vector3.forward * 4;
        Debug.Log("forvard:" + transform.forward);
        target = transform.forward * blast_distance; //new Vector2(dirVector.x * blast_distance, dirVector.y * blast_distance);
        Debug.Log("Starting roation:" + transform.rotation);
        Debug.Log("Starting poz:" + transform.position);
        Debug.Log("Target:" + target);
        */

        //Vector2 dirVector = 

        //target = new Vector2(transform.position.x + blast_distance, transform.position.y);

        target.position = new Vector2(blast_distance, 0);
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

        //Vector2 curr_poz = transform.position;
        float step = blast_speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        /*if (curr_poz.x < target.x) {
            
        }
        else {
            transform.position = target;
        }*/
    }
}
