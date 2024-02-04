using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private AudioClip hitSfx;
    [SerializeField] private AudioSource audioSource;
    //[SerializeField] private ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveBallRandomly());
    }

    // Update is called once per frame
    IEnumerator MoveBallRandomly()
    {
        yield return new WaitForSeconds(1.5f);
        float[] horizontal = new float[2] { -5f, 5f };
        float[] vertical = new float[2] { -1.5f, 1.5f };
        rb.velocity = new Vector3(horizontal[Random.Range(0, 2)], 0f, vertical[Random.Range(0, 2)]);
    }
    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    public void resetSpherePosition()
    {
        transform.position = new Vector3(0f,1f,0f);
        MoveBallRandomly();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        audioSource.PlayOneShot(hitSfx);
        rb.velocity = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal) * speed;

        if(collision.gameObject.name == "LeftWall")
        {
            UIManager.manager.IncrementPlayerTwoScore();
        }
        else if(collision.gameObject.name == "RightWall")
        {
            UIManager.manager.IncrementPlayerOneScore();
        }
    }
}

