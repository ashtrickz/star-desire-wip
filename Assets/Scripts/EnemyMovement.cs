using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform target;
    Rigidbody2D rb;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float nearDistance = 2f;
    Vector2 player;

    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 current = transform.position;
        var direction = player - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void FixedUpdate()
    {
        if (player.y < transform.position.y)
            if (Vector2.Distance(transform.position, player) < nearDistance)
                transform.position = Vector3.MoveTowards(transform.position, new Vector2(-player.x, player.y), speed * Time.deltaTime);
            else transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, player.y), speed * Time.deltaTime);
        else transform.position = Vector3.MoveTowards(transform.position, new Vector2(-target.position.x, target.position.y), speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, nearDistance);
    }
}
