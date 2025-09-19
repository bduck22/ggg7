using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gg_Enemy : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Attack"))
        {
            Debug.Log(other.GetComponentInChildren<gg_Attack>().Damage);
        }
    }
}
