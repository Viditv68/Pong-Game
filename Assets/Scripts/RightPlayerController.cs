using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayerController : MonoBehaviour
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
        if(Input.GetMouseButtonDown(0) && (!UIManager.manager.isInMainMenu || UIManager.manager.isGamePause))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                direction = new Vector3(0f, 0f, hit.point.z).normalized;
            }

        }
        else if(Input.GetMouseButtonUp(0))
        {
            direction = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
