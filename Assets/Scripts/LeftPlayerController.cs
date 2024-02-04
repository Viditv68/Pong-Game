using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!UIManager.manager.isInMainMenu || UIManager.manager.isGamePause)
        {
            float vertical = Input.GetAxis("Vertical");
            direction = new Vector3(0, 0, vertical).normalized;
        }
 
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}

 
