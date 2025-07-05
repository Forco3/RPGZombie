using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(CharacterState))]
public class CharacterRigIK : MonoBehaviour
{
    private CharacterState state;

    public Rig weaponSlotSpineWeight;
    public Rig weaponSlotReadyForBattle;
    public Rig weaponSlotAimWeight; 
    public Rig handsOnWeaponWeight;
    public Rig handsAimOnWeaponWeight;
    public Rig bodyLookTargetAimWeight; 
   
    private void Awake()
    {
        state = GetComponentInChildren<CharacterState>();
    }
    private void Update()
    { 
        WeaponSlotSpine(state.isHasWeapon);
        WeaponSlotReadyForBattle(state.isHasWeapon, state.isReadyForBattle);
        WeaponSlotAim(state.isHasWeapon, state.isReadyForBattle, state.isAiming);
        WeightIKWeapon(state.isEquipingWeaponAnimationState);
    }
    private void WeaponSlotSpine(bool isHasWeapon)
    {
        weaponSlotSpineWeight.weight = isHasWeapon ? 1 : 0;
    }

    private void WeaponSlotReadyForBattle(bool isHasWeapon, bool isReadyForBattle)
    {
        if (isHasWeapon)
        {
            weaponSlotReadyForBattle.weight = isReadyForBattle ? 1 : 0;
            handsOnWeaponWeight.weight = isReadyForBattle ? 1 : 0;
        }   
    }
  
    private void WeaponSlotAim(bool isHasWeapon, bool isReadyForBattle, bool isAimWeapon)
    {
        if (isHasWeapon && isReadyForBattle)
        {
            weaponSlotAimWeight.weight = isAimWeapon ? 1 : 0;
            bodyLookTargetAimWeight.weight = isAimWeapon ? 1 : 0;
            handsAimOnWeaponWeight.weight = isAimWeapon ? 1 : 0;
        }
    }
    public void WeightIKWeapon(bool isEquip)
    {
        if (isEquip)
        {
            weaponSlotSpineWeight.weight = 0;
            weaponSlotReadyForBattle.weight = 0;
            weaponSlotAimWeight.weight = 0;
            handsOnWeaponWeight.weight = 0;
            handsAimOnWeaponWeight.weight = 0;
            bodyLookTargetAimWeight.weight = 0;
        }
    }
}
