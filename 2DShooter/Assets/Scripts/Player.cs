using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public float PlayerSpeed;
    public GameObject ProjectilePrefab;
    public GameObject ExplosionPrefab;

    public static int Score = 0;
    public static int Lives = 3;
	
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

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Enemy")
        {
            Player.Lives--;

            Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
            enemy.SetPositionAndSpeed();

            Instantiate(ExplosionPrefab, transform.position, transform.rotation);

            //Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 120, 20), "Score: " + Player.Score.ToString());
        GUI.Label(new Rect(10, 30, 60, 20), "Lives: " + Player.Lives.ToString());
    }

    
}
