using Mediapipe.Unity.Holistic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FollowHand : MonoBehaviour
{
    public static Gesture gen; // singleton
    public Rigidbody rb;
    private Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private float getAbs(float value)
    {
        if(value < 0f){
            return value * -1f;
        }
        else{
            return value;
        }
    }

    public bool rightPointer(){
        if(Gesture.gen.righthandpos[4].magnitude == 0 && Gesture.gen.righthandpos[8].magnitude == 0)
        {
            return false;
        }
        else if(getAbs(Gesture.gen.righthandpos[4].magnitude - Gesture.gen.righthandpos[8].magnitude) < .02f)
        {
            Debug.Log("Rpoint");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool rightRing(){
        if(Gesture.gen.righthandpos[4].magnitude == 0 && Gesture.gen.righthandpos[12].magnitude == 0)
        {
            return false;
        }
        else if(getAbs(Gesture.gen.righthandpos[4].magnitude - Gesture.gen.righthandpos[12].magnitude) < .02f)
        {
            Debug.Log("Rring");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool leftPointer(){
        if(Gesture.gen.lefthandpos[4].magnitude == 0 && Gesture.gen.lefthandpos[8].magnitude == 0)
        {
            return false;
        }
        else if(getAbs(Gesture.gen.lefthandpos[4].magnitude - Gesture.gen.lefthandpos[8].magnitude) < .02f)
        {
            Debug.Log("Lpoint");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool leftRing(){
        if(Gesture.gen.lefthandpos[4].magnitude == 0 && Gesture.gen.lefthandpos[12].magnitude == 0)
        {
            return false;
        }
        else if(getAbs(Gesture.gen.lefthandpos[4].magnitude - Gesture.gen.lefthandpos[12].magnitude) < .02f)
        {
            Debug.Log("Lring");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool jump(){
        if(Gesture.gen.lefthandpos[8].magnitude == 0 && Gesture.gen.righthandpos[8].magnitude == 0)
        {
            return false;
        }
        else if(getAbs(Gesture.gen.lefthandpos[8].magnitude - Gesture.gen.righthandpos[8].magnitude) < .02f)
        {
            Debug.Log("Jump");
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rightPointer()){
            rb.AddForce(0f, 0f, 250f, ForceMode.Impulse);
        }
        if(rightRing()){
            rb.AddForce(250f, 0f, 0f, ForceMode.Impulse);
        }
        if(leftPointer()){
            rb.AddForce(0f, 0f, -250f, ForceMode.Impulse);
        }
        if(leftRing()){
            rb.AddForce(-250f, 0f, 0f, ForceMode.Impulse);
        }
        if(jump()){
            rb.AddForce(0f, 250f, 0f, ForceMode.Impulse);
        }
    }
}
