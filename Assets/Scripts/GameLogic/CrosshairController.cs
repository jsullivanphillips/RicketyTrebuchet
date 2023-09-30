using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        
        Vector2 currMousePoz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = currMousePoz;
        //transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        Debug.Log(transform.position);
    }
}
