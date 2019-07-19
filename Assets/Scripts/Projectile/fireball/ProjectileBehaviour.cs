using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Projectile projectile;
    private Vector2 direction;
    private Vector2 target;
    private GameObject enemy;
    private Transform position;

    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Player").gameObject;
        position = gameObject.GetComponent<Transform>();
        target = enemy.GetComponent<Transform>().position;
        direction = target - (Vector2)gameObject.GetComponent<Transform>().position;
        projectile = new Projectile(1f, 1, direction);
    }

    // Update is called once per frame
    void Update()
    {
        direction = target - (Vector2)gameObject.GetComponent<Transform>().position;
        Vector3 movement = direction;
        movement *= Time.deltaTime * projectile.velocity.value;
        position.Translate(movement);
    }
}
