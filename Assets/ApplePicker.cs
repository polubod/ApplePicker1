using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")] // a
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;


    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>(); // c
        for (int i=0; i<numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + ( basketSpacingY * i );
            tBasketGO.transform.position = pos;
            basketList.Add( tBasketGO ); // d
        }

        
    }
    public void AppleMissed() { // a
        // Destroy all of the falling apples
        GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");// b
        foreach ( GameObject tempGO in appleArray ) {
            Destroy( tempGO );
        }
        // Destroy one of the baskets // e
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count-1;
        // Get a reference to that Basket GameObject
        GameObject tbasketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt( basketIndex );
        Destroy( tbasketGO );
        if(basketList.Count == 0){
            SceneManager.LoadScene("_Scene_0");
        }
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
