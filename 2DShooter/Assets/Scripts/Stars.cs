using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour 
{
    public float Speed;

	
	// Update is called once per frame
	void Update () 
    {
        float amtToMove = Speed * Time.deltaTime;
        transform.Translate(Vector3.down * amtToMove, Space.World);

        if (transform.position.y < -10.75f)
        {
            transform.position = new Vector3(transform.position.x, 14f, transform.position.z);
        }
	}
}
