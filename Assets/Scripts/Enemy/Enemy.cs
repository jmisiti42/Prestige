using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public Stat hp, damage, speed, attackDelay;

    public Enemy(float startHp, float startDamage, float startSpeed, float startAttackDelay)
    {
        hp = new Stat(startHp);
        damage = new Stat(startDamage);
        speed = new Stat(startSpeed);
        attackDelay = new Stat(startAttackDelay);
    }
}
