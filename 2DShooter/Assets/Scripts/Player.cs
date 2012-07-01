using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float PlayerSpeed;
	
	// Update is called once per frame
	void Update () 
	{
        //Amount to move
        float amtToMove = Input.GetAxisRaw("Horizontal") * PlayerSpeed * Time.deltaTime;
        
        //Move the player
        transform.Translate(Vector3.right * amtToMove);

        //Wrap player
        if (transform.position.x <= -7.5f)
            transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
        else if(transform.position.x >= 7.5f)
            transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);
	}
}
