using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public enum State
	{
		Playing,
		Explosion,
		Invincible
	}
	
    public float PlayerSpeed;
    public GameObject ProjectilePrefab;
    public GameObject ExplosionPrefab;

    public static int Score = 0;
    public static int Lives = 3;
    public static int Missed = 0;

    private float ProjectileOffset = 0.8f;
	private State state = State.Playing;
	private float shipInvisibleTime = 1.5f;
	private float shipMoveOnToScreenSpeed = 5f;
	private float blinkRate = .1f;
	private int numberOfTimeToBlink = 10;
	private int blinkCount;

	// Update is called once per frame
	void Update () 
	{
		if(state != State.Explosion)
		{
	        //Amount to move
	        float amtToMoveHorizontal = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
			float amtToMoveVertical = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;
	        
	        //Move the player
	        transform.Translate(Vector3.right * amtToMoveHorizontal);
			transform.Translate(Vector2.up * amtToMoveVertical);
	
	        //Wrap player
	        if (transform.position.x <= -7.5f)
	            transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
	        else if(transform.position.x >= 7.5f)
	            transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);
			
			//Make player stay inside the screen - vertically
			if(transform.position.y < -4f)
				transform.position = new Vector3(transform.position.x, -3.95f, transform.position.z);
			else if(transform.position.y > 5f)
				transform.position = new Vector3(transform.position.x, 4.95f, transform.position.z);
				
	
	        //Fire projectile
		    if (Input.GetKeyDown("space"))
		    {
	            var projectilePosition = new Vector3(transform.position.x,
	                                                 transform.position.y + ProjectileOffset,
	                                                 transform.position.z);
	            Instantiate(ProjectilePrefab, new Vector3(projectilePosition.x - 0.2f, projectilePosition.y, projectilePosition.z), Quaternion.identity);
				Instantiate(ProjectilePrefab, new Vector3(projectilePosition.x + 0.2f, projectilePosition.y, projectilePosition.z), Quaternion.identity);
		    }
			
		}
		
		//Exit game
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();	
		}
	}

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Enemy" && state == State.Playing)
        {
            Player.Lives--;

            Enemy enemy = (Enemy)otherObject.gameObject.GetComponent("Enemy");
            enemy.SetPositionAndSpeed();

            StartCoroutine(DestroyShip());
        }
    }

    IEnumerator DestroyShip()
    {
		state = State.Explosion;
        var expPrefab = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(expPrefab, 2f);

        gameObject.renderer.enabled = false;
        transform.position = new Vector3(0f, -5.5f, transform.position.z);
        
		yield return new WaitForSeconds(shipInvisibleTime);

        if (Player.Lives > 0)
        {
            gameObject.renderer.enabled = true;
			while(transform.position.y < -3.2f)
			{
				float amtToMove = shipMoveOnToScreenSpeed * Time.deltaTime;
				transform.Translate(Vector3.up * amtToMove,Space.World);
				yield return 0;
			}
			state = State.Invincible;
			
			while(blinkCount < numberOfTimeToBlink)
			{
				gameObject.renderer.enabled = !gameObject.renderer.enabled;
				
				if(gameObject.renderer.enabled == true)
					blinkCount++;
				
				yield return new WaitForSeconds(blinkRate);
			}
			blinkCount = 0;
			state = State.Playing;
        }
        else
        {
            Application.LoadLevel("Lose");
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 120, 20), "Score: " + Player.Score.ToString());
        GUI.Label(new Rect(10, 30, 60, 20), "Lives: " + Player.Lives.ToString());
        GUI.Label(new Rect(10, 50, 60, 20), "Missed: " + Player.Missed.ToString());
    }
}
