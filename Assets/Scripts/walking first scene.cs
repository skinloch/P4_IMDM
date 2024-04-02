using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingfirstscene : MonoBehaviour
{
    private float speed;
    public float start;
    public float stop;

    public TextMeshPro endText;

    private float pos;
    private bool gameOver = false;
    private float tree1 = -8.7f;
    private int part = 1;
    private bool space = false;

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
        
        if(curr >= tree1 && part == 1)
        {
            endText.text = "Press 'SPACE' to\n  jump over the log";
            if(Input.GetKeyDown(KeyCode.Space))
            {
                endText.text = "";
                transform.position = new Vector3(0f, 1f, -8.3f);
                startLocation = -8.3f;                    
                part=2;
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                endText.text = "";
                if(currPosition > startLocation){
                    transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
                }
            }
        }
    }
}
