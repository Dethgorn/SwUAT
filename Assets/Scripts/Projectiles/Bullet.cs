using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float moveSpeed;

    [SerializeField] private float lifespan = 2f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        // go
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        PlayerHealth otherHP = other.gameObject.GetComponent<PlayerHealth>();
        if (otherHP != null)
        {
            otherHP.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
