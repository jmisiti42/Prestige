using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private HP hp;

    void Start()
    {
        hp = new HP(2f);
        Debug.Log(hp.hp);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        hp.hp -= 0.5f; // Todo find a better name
        Debug.Log(hp.hp);
        Destroy(collision.gameObject);
    }
    void Update()
    {
    }
}
