using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float amtToMove = ProjectileSpeed*Time.deltaTime;
        transform.Translate(Vector3.up * amtToMove);

        if(transform.position.y > 6.4f)
            Destroy(gameObject);
	}
}
