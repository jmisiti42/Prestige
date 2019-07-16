using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
	public Enemy character;
    public ProjectileBehaviour[] projectiles;
    private Transform position;
	private float nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.GetComponent<Transform>();
		character = new Enemy(10f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFire)
		{
			nextFire = Time.time + character.attackDelay.value;
            Instantiate(projectiles[0], position);
		}
    }
}
