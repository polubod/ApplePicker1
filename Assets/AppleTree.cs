using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;

    public GameObject dynamitePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Rate at which Apples will be instantiated
    public float appleDropDelay = 1f;
    public float dynamiteDropDelay = 4.9f;

    void Start () {
        // Start dropping apples
        Invoke( "DropApple", 2f); // a
        Invoke( "DropDynamite", Random.value); // a
    }

    void DropApple() { // b
        GameObject apple = Instantiate<GameObject>( applePrefab ); // c
        apple.transform.position = transform.position; // d
        Invoke( "DropApple", appleDropDelay ); // e
    }
    void DropDynamite() { // b
        GameObject dynamite = Instantiate<GameObject>( dynamitePrefab ); // c
        dynamite.transform.position = transform.position; // d
        Invoke( "DropDynamite", dynamiteDropDelay ); // e
    }



    void Update () {
        // Basic Movement
        Vector3 pos = transform.position; // b
        pos.x += speed * Time.deltaTime; // c
        transform.position = pos; // d
        // Changing Direction
        if ( pos.x < -leftAndRightEdge ) { // a
            speed = Mathf.Abs(speed); // Move right // b
        } else if ( pos.x > leftAndRightEdge ) { // c
            speed = -Mathf.Abs(speed); // Move left // c
        }


    }
    void FixedUpdate() {//a
        // Random direction changes are now time-based due to FixedUpdate()
        if ( Random.value < changeDirChance ) { //b
            speed *= -1; // Change direction
        }
    }



}
