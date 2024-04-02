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
    private float tree1 = -8.7f;
    private int part = 1;

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

            if(currPosition >= stopLocation){
                endText.text = "Press 'SPACE' to\n  enter the plane";
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    endText.text = "     You Win!";
                    gameOver = true;
                }
            }
            else if(currPosition >= tree1 && part == 1)
            {
                endText.text = "Press 'SPACE' to\n  jump the log";
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    endText.text = "";
                    transform.position = new Vector3(0f, 1f, -8.3f);
                    startLocation = -8.3f;
                    part=2;
                }
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                if(currPosition > startLocation){
                    transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
                }
            }
            else if(Input.GetKey(KeyCode.UpArrow))
            {
                if(currPosition < stopLocation){
                    transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
                }
            }

            else{
                endText.text = "";
            }
        }
    }
}
