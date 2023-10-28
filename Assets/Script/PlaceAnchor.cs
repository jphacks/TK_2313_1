using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAnchor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT:: " + other.tag);
    }
}
