/*
 * Chris Smith
 * Assignment 6
 * Interface for objects that can take damage
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int amount);
}
