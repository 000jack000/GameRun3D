using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonController : MonoBehaviour
{
    // Start is called before the first frame update
    public float offsetcycle, offset; //Leer comentario de shooterController

    void Start()
    {
        StartCoroutine(waitCycle());
    }

    IEnumerator waitCycle()
    {
        
        yield return new WaitForSeconds(offsetcycle);
        StartCoroutine(Fall());
        StartCoroutine(waitCycle());

    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(offset);
        this.GetComponent<Animator>().Play("PistonMove");
    }
}
