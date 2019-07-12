using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private GameObject character;
    private Transform trf;
    private Animator anim;
    public RectTransform handle;
    public RectTransform handleBg;

    public float speed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        character = this.gameObject;
        anim = character.GetComponent<Animator>();
        trf = character.GetComponent<Transform>();
    }

    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
    }

    void Update()
    {
        Vector3 headingLocal = handle.localPosition;
        Vector3 heading = handleBg.position;
        Vector2 dir = new Vector2(heading.x, heading.y);
        Vector2 dirLocal = new Vector2(headingLocal.x, headingLocal.y);
        if ((headingLocal.x >= 5 || headingLocal.x <= -5) || (headingLocal.y >= 5 || headingLocal.y <= -5))
        {
            float angle = AngleBetweenVector2(dir, dirLocal + dir);
            if (angle >= 45 && angle <= 135)
                anim.Play("Walk_Up");
            else if (angle > -45 && angle < 45)
                anim.Play("Walk_Right");
            else if (angle >= -135 && angle <= -45)
                anim.Play("Walk_Down");
            else if (angle > 135 || angle < -135)
                anim.Play("Walk_Left");
            Vector3 movement = headingLocal;
            movement *= Time.deltaTime * speed;
            trf.Translate(movement);
        } else
        {
            anim.Play("Idle");
        }
    }
}
