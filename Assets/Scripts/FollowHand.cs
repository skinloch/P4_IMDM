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
            Debug.Log("PINCH");
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
            rb.AddForce(100f, 0f, 0f, ForceMode.Impulse);
        }
    }
}
