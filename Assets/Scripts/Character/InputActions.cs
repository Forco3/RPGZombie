using System;
using UnityEngine;

[RequireComponent(typeof(CharacterState))]
public class InputActions : MonoBehaviour
{
    private CharacterState state;
    public event Func<bool> onRaycastHitPickUpItem;
    public event Func<bool> onRaycastHitEnemy;
    public event Action<bool> onEquipWeapon;
    public void Awake()
    {
        state = GetComponent<CharacterState>();
    }

    private void Update()
    {
        InputAxis();
        JumpInput();
        PickUpItemFromRaycastHit();
        UpdateStateReadyForBattle();
        AimingInput();
        FireInput();
        CrouchInput();
    }
 
    void InputAxis()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        state.SetMoveAxis(new Vector3(x, 0, z));
    }

    void PickUpItemFromRaycastHit()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            bool isHasWeapon = onRaycastHitPickUpItem.Invoke();
            state.SetRaycastHitWeaponState(isHasWeapon); 
        } 
    }
    void UpdateStateReadyForBattle()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            state.SetWeaponInHand(!state.isWeaponInHand);
            onEquipWeapon?.Invoke(state.isWeaponInHand);
            state.SetStateReadyForBattle();
        }
    }
    void AimingInput()
    {
        bool isAiming = Input.GetMouseButton(1); 
        state.SetStateAim(isAiming);
    }
    void FireInput()
    {
        bool isFire = Input.GetMouseButton(0);
        bool isRaycastHitEnemy = onRaycastHitEnemy.Invoke(); 
        state.SetStateFire(isFire);
        state.SetRaycastHitEnemyState(isRaycastHitEnemy);
    }
    void JumpInput()
    {
        bool isKeyDownJump = Input.GetKeyDown(KeyCode.Space);
        state.SetStateJump(isKeyDownJump);
    } 
    void CrouchInput()
    {
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        state.SetStateCrouch(isCrouching);
    }
}
