using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkle_BH : MonoBehaviour
{

    [SerializeField] private float MaxLifetime;
    [SerializeField] private float CurLifetime;

    // Start is called before the first frame update
    void Start()
    {
        CurLifetime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurLifetime += Time.deltaTime;

        if (CurLifetime >= MaxLifetime)
        {
            Destroy(this.gameObject);
        }

    }
}
