using UnityEngine;

public class AimRaycast : MonoBehaviour
{
    private InputActions input;
    private WeaponHan weapon;  
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
        weapon = FindObjectOfType<WeaponHan>();
        input = FindObjectOfType<InputActions>();
    }
    private void OnEnable()
    {
        input.onRaycastHitPickUpItem += RaycastHitPickUpItem;
        input.onRaycastHitEnemy += RaycastHitEnemy;
    }
    private void OnDisable()
    {
        input.onRaycastHitPickUpItem -= RaycastHitPickUpItem;
        input.onRaycastHitEnemy -= RaycastHitEnemy;
    }
 
    private bool RaycastHitPickUpItem()
    {
        GetRay();
        if (Physics.Raycast(ray, out hit, rayDistance, layerMaskItem))
        {
            PickUpItem pickItem = hit.collider.GetComponent<PickUpItem>();
            if (pickItem.IsWeapon())
            {
                return weapon.SetParent(hit.collider.gameObject);
            }
            else
            {
                pickItem.Interected();
                return false;
            }
        }
        else return false;
    }
    
    private bool RaycastHitEnemy()
    {
        GetRay();
        if (Physics.Raycast(ray, out hit, rayDistEnemyHit, layerMaskEnemy))
        {
            EnemyHP hpEnemy = hit.collider?.GetComponent<EnemyHP>();
            hpEnemy?.TakeDamageEnemy(20);
            return true;
        }
        else return false;
    }
    private void GetRay()
    {
        ray = new Ray(rayPoint.position, rayPoint.forward);
    }
}
