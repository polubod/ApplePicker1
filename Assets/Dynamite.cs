using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    public static float bottomY = -20f; // a

    // Update is called once per frame
    void Update(){
        if ( transform.position.y < bottomY ) {
            Destroy( this.gameObject ); // b
        }

        
    }
}
