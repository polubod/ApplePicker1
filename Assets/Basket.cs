using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // b
        //Get the ScoreCounter (Script) component of scoreGo
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition; 

        // The Camera's Z position set how far to push the mouse into 3D
        //If this line causes a NULLReferenceException, select the Main Camera
        //in the Hierarchy and set its tag to MainCamera in the inspector.
        mousePos2D.z = -Camera.main.transform.position.z; // b

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D ); // c

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

        
    }
    void OnCollisionEnter( Collision coll ) { // a
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject; // b
        if ( collidedWith.tag == "Apple" ) { // c
            Destroy( collidedWith );
            //Increase the score
            scoreCounter.score += 100;
            HighScore.Try_SET_HIGH_SCORE(scoreCounter.score);
        }
        if ( collidedWith.tag == "Dynamite" ) { // c
            Destroy( collidedWith );
            SceneManager.LoadScene("_Scene_0");
        }
    }

}
