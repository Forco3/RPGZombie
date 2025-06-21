using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRaycast : MonoBehaviour
{
    private WeaponHan handler;
    private CharacterState state;
    private CameraCharacter myCamera;
    public Transform rayPoint;
    private Ray ray;
    private RaycastHit hit;
    public LayerMask layerMaskItem;
    public LayerMask layerMaskEnemy;
    private float rayDistance = 5;
    private float rayDistEnemyHit = 1000;
    public float damage = 20;
    private void Awake()
    {
        handler = FindObjectOfType<WeaponHan>();
        state = FindObjectOfType<CharacterState>();
        myCamera = GetComponent<CameraCharacter>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PickUpItem();
        }
        if (Input.GetMouseButtonDown(0) && handler.isPickUpWeapon)
        {
            HitEnemy();
        }
    }
    private void PickUpItem()
    {
        GetRay();
        if(Physics.Raycast(ray, out hit, rayDistance, layerMaskItem))
        {
            PickUpItem pickItem = hit.collider.GetComponent<PickUpItem>();
            if (pickItem.IsWeapon())
            {
              handler.isPickUpWeapon = handler.SetParent(hit.collider.gameObject);
                state.SetStateReadyForBattle(handler.isPickUpWeapon); 
            }
            else
            {
                pickItem.Interected();
            }
        }
    }
    private void GetRay()
    {
        ray = new Ray(rayPoint.position, rayPoint.forward);
    }
    private void HitEnemy()
    {
        GetRay();
        if (Physics.Raycast(ray, out hit, rayDistEnemyHit, layerMaskEnemy))
        {
            EnemyHP hpEnemy = hit.collider.GetComponent<EnemyHP>();
            hpEnemy?.TakeDamageEnemy(20);
        }
    }
}
