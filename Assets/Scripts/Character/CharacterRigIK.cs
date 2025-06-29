using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(StateCharacter))]
public class CharacterRigIK : MonoBehaviour
{
    private StateCharacter state;

    public Rig weaponSlotSpineWeight;
    public Rig weaponSlotReadyForBattle;
    public Rig weaponSlotAimWeight; 
   
    private void Awake()
    {
        state = GetComponentInChildren<StateCharacter>();
    }
    private void Update()
    { 
        WeaponSlotSpine(state.isHasWeapon);
        WeaponSlotReadyForBattle(state.isHasWeapon, state.isReadyForBattle);
        WeaponSlotAim(state.isHasWeapon, state.isReadyForBattle, state.isAiming);
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
        }   
    }
  
    private void WeaponSlotAim(bool isHasWeapon, bool isReadyForBattle, bool isAimWeapon)
    {
        if (isHasWeapon && isReadyForBattle)
        {
            weaponSlotAimWeight.weight = isAimWeapon ? 1 : 0;
        }
    }
}
