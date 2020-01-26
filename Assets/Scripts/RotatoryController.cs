using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatoryController : MonoBehaviour
{

    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().speed = vel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
