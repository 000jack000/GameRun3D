using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutController : MonoBehaviour
{
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, vel, Space.Self);
    }
}
