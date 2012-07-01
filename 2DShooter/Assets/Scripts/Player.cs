using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public float PlayerSpeed;
    public GameObject ProjectilePrefab;
	
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

        //Fire projectile
	    if (Input.GetKeyDown("space"))
	    {
            var projectilePosition = new Vector3(transform.position.x,
                                                 transform.position.y + (transform.localScale.y / 2),
                                                 transform.position.z);
            Instantiate(ProjectilePrefab, projectilePosition, Quaternion.identity);
	    }
	}
}
