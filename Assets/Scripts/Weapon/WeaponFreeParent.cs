using UnityEngine;

public class WeaponFreeParent : MonoBehaviour
{
    private Transform newParent;
    private Transform weaponOriginParent;
    private Transform trWeapon; 
    private CharacterState state;
 
    private void Awake()
    {
        state = FindObjectOfType<CharacterState>(); 
        newParent = GetComponent<Transform>();
        weaponOriginParent = FindObjectOfType<WeaponHan>()?.transform;
    }
    private void OnEnable()
    {
        if (state != null)
        {
            state.OnSetParentWeapon += SetParentWeapon;
            
        }
    }
    private void OnDisable()
    {
        if (state != null)
        {
            state.OnSetParentWeapon -= SetParentWeapon; 
        }
    }
    private void SetParentWeapon()
    {
        state.OnResetParenWeapon += ResetParenWeapon;
        trWeapon = weaponOriginParent?.GetComponentInChildren<Weapon>()?.transform; 
        if (trWeapon != null)
        {
            trWeapon?.SetParent(newParent);
            trWeapon.localPosition = Vector3.zero;
            trWeapon.localRotation = Quaternion.identity;
        } 
    }
    private void ResetParenWeapon()
    { 
        if (trWeapon != null)
        {
            trWeapon?.SetParent(weaponOriginParent);
            trWeapon.localPosition = Vector3.zero;
            trWeapon.localRotation = Quaternion.identity;
        }
        if (!state.isEquipingWeaponAnimationState)
            state.OnResetParenWeapon -= ResetParenWeapon;
    }
}
