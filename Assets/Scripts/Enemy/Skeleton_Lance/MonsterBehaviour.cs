using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
	public Enemy character;
    public ProjectileBehaviour[] projectiles;
    private Transform position;
    private Animator anim;
    private float nextFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        position = gameObject.GetComponent<Transform>();
        character = new Enemy(10f, 1f, 1f, 1f);
    }

    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFire)
		{
			nextFire = Time.time + character.attackDelay.value;
            anim.Play("Attack_Left");
            ProjectileBehaviour proj = Instantiate(projectiles[0], position);
            //Vector2 heading = new Vector2(proj.enemy.transform.position.x, proj.transform.position.y);
            //Vector2 headingLocal = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            float angle = AngleBetweenVector2((Vector2)position.position, (Vector2)position.position + (Vector2)projectiles[0].enemy.transform.position);
            Debug.Log(angle);
            if (angle >= 45 && angle <= 135)
                anim.Play("Walk_Up");
            else if (angle > -45 && angle < 45)
                anim.Play("Attack_Right");
            else if (angle >= -135 && angle <= -45)
                anim.Play("Walk_Down");
            else if (angle > 135 || angle < -135)
                anim.Play("Attack_Left");
        }
    }
}
