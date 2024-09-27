using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f; // a
   

    // Update is called once per frame
    void Update(){
        if ( transform.position.y < bottomY ) {
            Destroy( this.gameObject ); // a
        
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); // b
            // Call the public AppleDestroyed() method of apScript
            apScript.AppleMissed(); // c
        }

    }
}
