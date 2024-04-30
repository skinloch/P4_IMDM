using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
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
