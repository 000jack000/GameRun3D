using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    int x = 0;
    public bool color;
    public int vel;

    public  Material R,G,B;

    private Vector3 pos,posc;

 

    public GameObject End;
    // Start is called before the first frame update
    void Start()
    {

        pos = transform.position;
        posc = GameObject.Find("Main Camera").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        x = 0;
        //color mode
        if (color)
        {
            if (!GameObject.Find("Main Camera").GetComponent<Camera>().dead)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    x = vel;
                    this.GetComponent<MeshRenderer>().material = R;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    x = vel;
                    this.GetComponent<MeshRenderer>().material = G;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    x = vel;
                    this.GetComponent<MeshRenderer>().material = B;
                }
            }
           
        } else { 
        //Normal mode
            if (Input.GetKey(KeyCode.W) && !GameObject.Find("Main Camera").GetComponent<Camera>().dead)
            {
                x = vel;
            }
        }
        this.GetComponent<Rigidbody>().velocity = new Vector3 (0,0,Mathf.Lerp(this.GetComponent<Rigidbody>().velocity.z,x,Time.deltaTime*8));
    }
    void OnTriggerEnter(Collider col)
    {
       
        if (col.tag == "Enemy")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().dead = true;
            GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position,posc,Time.deltaTime);
            transform.position = pos;
            StartCoroutine(die());
           
        }

        if (col.tag == "EnemyR" && this.GetComponent<MeshRenderer>().materials[0].name != "Red (Instance)")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().dead = true;
            GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, posc, Time.deltaTime);
            transform.position = pos;
            StartCoroutine(die());
        }

        if (col.tag == "EnemyB" && this.GetComponent<MeshRenderer>().materials[0].name != "Blue (Instance)")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().dead = true;
            GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, posc, Time.deltaTime);
            transform.position = pos;
            StartCoroutine(die());
        }

        if (col.tag == "EnemyG" && this.GetComponent<MeshRenderer>().materials[0].name != "Green (Instance)")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().dead = true;
            GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, posc, Time.deltaTime);
            transform.position = pos;
            StartCoroutine(die());
        }

        if (col.tag == "Checkpoint")
        {
            pos = transform.position;
            GameObject.Find("Main Camera").GetComponent<Camera>().move(col.gameObject.GetComponent<Checkpoint>().CameraPos);
            posc = GameObject.Find("Main Camera").transform.position;
            col.gameObject.GetComponent<Collider>().enabled = false;  //Si quiero hacer multiplayer quizas he de cambiar esto!!
        }
        if (col.tag == "Finish")
        {
            col.gameObject.GetComponent<ParticleSystem>().Play();
            End.SetActive(true);
        }


    }
        IEnumerator die()
        {
        yield return new WaitForSeconds(0.5f);//penalizacion muerte
        GameObject.Find("Main Camera").GetComponent<Camera>().dead = false;
        }
}
