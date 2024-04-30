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

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Gesture.gen.righthandpos[4]);
    }
}
