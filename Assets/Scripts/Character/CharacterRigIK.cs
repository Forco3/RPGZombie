using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterRigIK : MonoBehaviour
{
    private WeaponHan weaponHandler;

    public Rig weaponSlotSpineWeight;
    public Rig weaponSlotAimWeight;

    public bool isReadyForBattle = false;
    private void Awake()
    {
        weaponHandler = GetComponentInChildren<WeaponHan>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isReadyForBattle = !isReadyForBattle;
        }
        WeaponSlotSpine(weaponHandler.isPickUpWeapon, isReadyForBattle);
    }
    private void WeaponSlotSpine(bool isHasWeapon, bool isReadyForBattle)
    {
        if (isHasWeapon)
        {
            weaponSlotSpineWeight.weight = isReadyForBattle ? 1 : 0;
        }
        Debug.Log("IsHasWeapon = " + isHasWeapon);
        Debug.Log("IsReadyForBattle = " + isReadyForBattle);
    }
    private void WeaponSlotAim(bool isHasWeapon, bool isReadyForBattle, bool isAimWeapon)
    {
        if (isHasWeapon && isReadyForBattle)
        {
            weaponSlotAimWeight.weight = isAimWeapon ? 1 : 0;
        }
    }
}
