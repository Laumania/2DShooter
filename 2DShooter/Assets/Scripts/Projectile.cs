using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed;
    public GameObject ExplosionPrefab;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float amtToMove = ProjectileSpeed*Time.deltaTime;
        transform.Translate(Vector3.up * amtToMove, Space.World);

        if(transform.position.y > 6.4f)
            Destroy(gameObject);
	}

    void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.tag == "Enemy")
        {
            var enemy = (Enemy) otherObject.gameObject.GetComponent("Enemy");
            var expPrefab = Instantiate(ExplosionPrefab, enemy.transform.position, enemy.transform.rotation);
            
            enemy.SetPositionAndSpeed();
            Destroy(gameObject);
            Destroy(expPrefab, 2f);
            Player.Score += 100;
        }
    }
}
