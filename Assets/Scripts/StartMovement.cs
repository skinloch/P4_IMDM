using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartMovement : MonoBehaviour
{
    public float speed;
    public float startLocation;
    public float stopLocation;

    public TextMeshPro endText;

    private float currPosition;
    private bool gameOver = false;
    private float tree1 = -8.7f;
    private float tree2 = -7.2f;
    private float tree3 = -4.7f;
    private int part = 1;
    private bool tab = false;

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

            if(Input.GetKeyDown(KeyCode.E))
            {
                if(tab){
                    transform.position = new Vector3(0f, 1f, transform.position.z);
                    tab = false;
                }
                else{
                    transform.position = new Vector3(0f, 0.5f, transform.position.z);
                    tab = true;
                }
            }

            if(currPosition >= stopLocation){
                endText.text = "Press 'SPACE' to\nenter the temple";
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else if(Input.GetKey(KeyCode.DownArrow))
                {
                    endText.text = "";
                    if(currPosition > startLocation){
                        transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
                    }
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
                else if(Input.GetKey(KeyCode.DownArrow))
                {
                    endText.text = "";
                    if(currPosition > startLocation){
                        transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
                    }
                }
            }
            else if(currPosition >= tree2 && part == 2)
            {
                if(tab && Input.GetKey(KeyCode.UpArrow))
                {
                    endText.text = "";
                    transform.position = new Vector3(0f, 1f, -6.6f);
                    tab = false;
                    startLocation = -6.6f;
                    part=3;
                }
                else if(Input.GetKey(KeyCode.DownArrow))
                {
                    if(currPosition > startLocation){
                        transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
                    }
                }
            }
            else if(currPosition >= tree3 && part == 3)
            {
                if(tab && Input.GetKey(KeyCode.UpArrow))
                {
                    endText.text = "";
                    transform.position = new Vector3(0f, 1f, -4.1f);
                    tab = false;
                    startLocation = -4.1f;
                    part=4;
                }
                else if(Input.GetKey(KeyCode.DownArrow))
                {
                    if(currPosition > startLocation){
                        transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
                    }
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
