using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private Stat hp;
    private Stat damage;

    void Start()
    {
        hp = new Stat(2f);
        damage = new Stat(3f);
    }
}
