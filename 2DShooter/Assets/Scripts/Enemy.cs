using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float MinSpeed;
    public float MaxSpeed;

    private float currentSpeed;
    private float x, y, z;

    // Use this for initialization
    private void Start()
    {
        currentSpeed = Random.Range(MinSpeed, MaxSpeed);

        x = Random.Range(-6f, 6f);
        y = 7.0f;
        z = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        float amtToMove = currentSpeed*Time.deltaTime;
        transform.Translate(Vector3.down * amtToMove);

        if(transform.position.y <= -5f)
        {
            currentSpeed = Random.Range(MinSpeed, MaxSpeed);
            x = Random.Range(-6f, 6f);
            transform.position = new Vector3(x, y, z);
        }
    }
}
