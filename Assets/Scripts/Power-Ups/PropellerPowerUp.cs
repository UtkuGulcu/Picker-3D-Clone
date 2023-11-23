using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerPowerUp : MonoBehaviour
{
    [SerializeField] private GameEventSO OnPropellerPowerUpPicked;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPropellerPowerUpPicked.Raise();
            Destroy(gameObject);
        }
    }
}
