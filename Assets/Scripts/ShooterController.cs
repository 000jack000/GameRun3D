using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{

    public GameObject Bullet;
    public bool oposite;
    public float vel, offset, offsetbullet; //controlar cada cuanto se repite el ciclo (offset) y cuanto espera cada shooter para disparar al inicio de ciclo (para hacer coreografias de balas guays)
    //Editable desde el editor asi vamos mas rapidos
    // Start is called before the first frame update
    private int dir = 1;
    void Start()
    {
        if (oposite) { dir = -1; } // direccion de disparo, editable desde editor
        StartCoroutine(waitshoot());
    }

    IEnumerator waitshoot()
    {
        yield return new WaitForSeconds(offset);
        StartCoroutine(shoot());
        StartCoroutine(waitshoot());
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(offsetbullet);
        GameObject aux = Instantiate(Bullet, transform.position, Quaternion.identity);
        aux.GetComponent<Rigidbody>().velocity = Vector3.right * vel * dir ;
    }
       
}
