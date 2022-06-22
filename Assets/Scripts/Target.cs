using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Vector2 player;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.x, -7), 10 * Time.deltaTime);
    }
}
