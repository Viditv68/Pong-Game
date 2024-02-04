using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        float[] horizontal = new float[2] { -5f, 5f };
        float[] vertical = new float[2] { -1.5f, 1.5f };
        rb.velocity = new Vector3(horizontal[Random.Range(0, 2)], 0f, vertical[Random.Range(0, 2)]);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        rb.velocity = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal) * speed;
    }
}

