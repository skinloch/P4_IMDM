using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed = 5.0f;
    private float currPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currPosition = transform.position.z;

        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(currPosition > -10){
                transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
            }
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
        }
    }
}
