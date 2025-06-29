using UnityEngine;

public class WeaponHan : MonoBehaviour
{
    private Transform targetWeapon; 
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
