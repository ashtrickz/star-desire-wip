using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mousePos;
    Vector2 position = new Vector2(0f, 0f);
    public float speed = 0.1f;
    public bool allowFlight = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        position = Vector2.Lerp(transform.position, mousePos, speed);
    }

    private void FixedUpdate()
    {
        if (allowFlight)
            rb.MovePosition(position);
    }

    private void OnMouseDrag() => allowFlight = true;
    private void OnMouseUp() => StartCoroutine(flightCancel());

    IEnumerator flightCancel ()
    {
        yield return new WaitForSeconds(0.1f);
        allowFlight = false;
    }
}
