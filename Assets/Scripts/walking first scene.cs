using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingfirstscene : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed=5f;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
        }
    }
}
