using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    [SerializeField] private int Healt;
    [SerializeField] private Animator Anim;

    public int GetHealt()
    {
        return Healt;
    }

    public void Damage(int damage)
    {
        Healt -= damage;
        if (DeadControl())
            Dead();
    }

    private bool DeadControl()
    {
        if (Healt < 1)
        {
            return true;
        }
        return false;
    }

    private void Dead()
    {
        
        Destroy(gameObject);
    }
}
