using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gg_UnitType
{
    Knight,
    Archer,
    Mage
}
public class gg_Unit : MonoBehaviour
{
    public float Damage;
    public float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            if(value > maxhp)
            {
                hp = value;
            }
            else if(value < 0)
            {
                hp = 0;
            }
            else
            {
                hp = value;
            }
        }
    }
    public float hp;
    public float maxhp;

    public float Mp
    {
        get
        {
            return mp;
        }
        set
        {
            if (value > maxmp)
            {
                mp = value;
            }
            else if (value < 0)
            {
                mp = 0;
            }
            else
            {
                mp = value;
            }
        }
    }
    public float mp;
    public float maxmp;

    public float Exp
    {
        get
        {
            return exp;
        }
        set
        {
            if(LevelExp <= value)
            {
                exp = value - LevelExp;
                Level++;
            }
            else
            {
                exp = value;
            }
        }
    }
    public float exp;
    public int Level;
    public float LevelExp;

    Vector3 dir;
    public float Speed;
    public float AttackSpeed;

    public float attacktime;

    public bool Played;

    public Rigidbody rb;
    public Animator animator;

    public gg_UnitType Type;

    public GameObject AttackPre;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(attacktime < 1)
        {
            attacktime += Time.deltaTime*AttackSpeed;
        }
        else
        {
            attacktime = 1;
        }

        if (Played)
        {
            dir = Vector3.zero;
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);

            if (Input.GetButton("Horizontal"))
            {
                dir += transform.right * Speed * Input.GetAxis("Horizontal");
            }
            if (Input.GetButton("Vertical"))
            {
                dir += transform.forward * Speed * Input.GetAxis("Vertical");
            }
            dir.y = rb.velocity.y;

            animator.SetBool("Walk", dir != Vector3.zero);

            rb.velocity = dir;

            if (Input.GetMouseButton(0)&&attacktime==1)
            {
                Attack();
            }
        }
    }
    public void Attack()
    {
        attacktime = 0;
        animator.SetTrigger("Attack");

        gg_Attack attack = Instantiate(AttackPre, transform.position, transform.rotation).GetComponentInChildren<gg_Attack>();
        Destroy(attack.gameObject, 0.5f);
        attack.Damage = Damage;
        attack.Weight = 1;
        attack.Targetnum = 10000;
    }

    private void OnTriggerEnter(Collider other)
    {
        //ÇÇ°Ý
    }
}
