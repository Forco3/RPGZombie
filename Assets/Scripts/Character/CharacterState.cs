using UnityEngine;
using System;

public class CharacterState : MonoBehaviour
{
    public event Action OnSetParentWeapon;
    public event Action OnResetParenWeapon;

    public bool isHasWeapon { get; private set; } //свойства должны быть публичными
    public bool isReadyForBattle { get; private set; }
    public bool isAiming { get; private set; }
    public bool isFire { get; private set; }
    public bool isCrouchimg { get; private set; }
    public bool isKeyDownJump { get; private set; }
    public bool isCollisitonTerrain { get; private set; } 
    public bool isEquipingWeaponAnimationState {  get; private set; }
    public bool isWeaponInHand {  get; private set; }
    public Vector3 inputAxis { get; private set; }

    public bool isRaycastHitEnemy { get; private set; }


    public void SetStateCrouch(bool isKeyPressed)
    {
        isCrouchimg = isKeyPressed;
    }
    public void SetMoveAxis(Vector3 inputAxis)
    {
        this.inputAxis = inputAxis;
    }
    public void SetRaycastHitWeaponState(bool isHasWeapon)
    {
        this.isHasWeapon = isHasWeapon;
    } 

    public void SetStateReadyForBattle()
    {
        if(isHasWeapon)
            isReadyForBattle = !isReadyForBattle;
    }
    public void SetStateAim(bool isAiming)
    {
        if (isReadyForBattle)
            this.isAiming = isAiming;
    }

    public void SetStateFire(bool isFire)
    {
        if(isAiming)
            this.isFire = isFire;
    }
    public void SetStateJump(bool isKeyDown)
    {
        if(isCollisitonTerrain)
            isKeyDownJump = isKeyDown;
    }
    public void SetStateCollisionTerrain(bool isCollision)
    {
        isCollisitonTerrain = isCollision;
    }
    public void SetRaycastHitEnemyState(bool isRaycastHit)
    {
        isRaycastHitEnemy = isRaycastHit;
    }
    public void SetEquipingWeaponAnimationState(bool isEquip)
    {
        isEquipingWeaponAnimationState = isEquip;
        if (isEquip) OnSetParentWeapon?.Invoke();
        else OnResetParenWeapon?.Invoke();
    }
    public void SetWeaponInHand(bool inHand)
    {
        isWeaponInHand = inHand;
    }
}
