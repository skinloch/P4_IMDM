using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Walk : MonoBehaviour
{
    public float speed;
    public float startLocation;
    public float stopLocation;

    public TextMeshPro endText;

    private float currPosition;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        endText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            currPosition = transform.position.z;

            if(Input.GetKey(KeyCode.DownArrow))
            {
                if(currPosition > startLocation){
                    transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
                }
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                if(currPosition < stopLocation){
                    transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
                }
            }
            if(currPosition >= stopLocation){
                endText.text = "Press 'SPACE' to\n  enter the plane";
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    endText.text = "     You Win!";
                    gameOver = true;
                }
            }
            else{
                endText.text = "";
            }
        }
    }
}
