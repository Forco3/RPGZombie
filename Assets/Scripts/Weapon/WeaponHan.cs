using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHan : MonoBehaviour
{
    private Transform targetWeapon;
    public bool isPickUpWeapon { set; get; }
    private void Awake()
    {
        targetWeapon = GetComponent<Transform>();
    }
    public bool SetParent(GameObject gameObject)
    {
        
        if(gameObject != null)
        {
            gameObject.transform.SetParent(targetWeapon);
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.identity;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
