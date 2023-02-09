using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed =10;
    private Vector2 currSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis ("Horizontal"); 
        float verticalInput = Input.GetAxis ("Vertical");
        Vector2 nuSpeed = new Vector2 (0,0);
        nuSpeed.x=(horizontalInput*speed);
        nuSpeed.y=(verticalInput*speed);
        rb.velocity=nuSpeed;
    }


}
