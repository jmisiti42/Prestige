using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile
{
    public Stat velocity, damages;
    public Vector2 direction;

    public Projectile(float startVelocity, float startDamages, Vector2 startDirection)
    {
        velocity = new Stat(startVelocity);
        damages = new Stat(startDamages);
        direction = startDirection;
    }
}
