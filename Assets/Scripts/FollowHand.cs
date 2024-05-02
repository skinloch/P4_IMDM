using Mediapipe.Unity.Holistic;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class FollowHand : MonoBehaviour
{
    public static Gesture gen; // singleton
    void Start()
    {
        
    }

    /*public bool rightPoint(){
        if(Gesture.gen.righthandpos[4].x - Gesture.gen.righthandpos[8].x)
    }*/

    // Update is called once per frame
    void Update()
    {
        Debug.Log("4: " + Gesture.gen.righthandpos[4].x + ", 8: " + Gesture.gen.righthandpos[8].x);

    }
}
