using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Camera : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    public float smoothness;
    public Vector3 Offset;
    public bool dead = true;
    private bool disapear = false;
    public Text count;
    void Start()
    {
        StartCoroutine(counting(4));
        transform.position = new Vector3(transform.position.x + Offset.x, transform.position.y + Offset.y, transform.position.z + Offset.z); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (disapear)
        {
            Color originalColor = count.color;
            count.color = Color.Lerp(originalColor, Color.clear, Time.deltaTime);
            if(count.color.a < 0.1f)
            {
                Debug.Log("ya");
                count.transform.parent.gameObject.SetActive(false);
            }
        }
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        if (!dead)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 6 * Time.deltaTime);
        }
        //transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, target.transform.position.z - Offset.z, Time.deltaTime * smoothness));
        Vector3 actualPos = target.transform.position + Offset;
        transform.position = Vector3.Lerp(transform.position, actualPos, Time.deltaTime * smoothness);
    }

    public void move(Vector3 offsets){
        // transform.position = new Vector3(transform.position.x + offsets.x, transform.position.y + offsets.y, transform.position.z + offsets.z);
        Offset = offsets;
    }
    IEnumerator counting(int x)
    {
        yield return new WaitForSeconds(1);
        if (x > 1)
        {
            x--;
            count.text = x.ToString();
            StartCoroutine(counting(x));
        }
        else
        {
            count.text = "GOOOO!";
            dead = false;
            disapear = true;
        }

    }

}
