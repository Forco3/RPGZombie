using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private CharacterState state;
    private Animator animator;
    private InputActions action;
     
    private float speedAnim = 0.5f;
    public float smoothToggleAnim = 0.2f;

    private int equipWeaponLayer = 1;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        state = FindObjectOfType<CharacterState>();
        action = GetComponent<InputActions>();
        equipWeaponLayer = animator.GetLayerIndex("Weapon Equip");
    }
    private void OnEnable()
    {
        action.onEquipWeapon += WeaponEquipAnim;
    }
    private void OnDisable()
    {
        action.onEquipWeapon -= WeaponEquipAnim;
    }
    private void Update()
    {
        JumpAnim(state.isKeyDownJump);
    }
    private void FixedUpdate()
    {
        MoveAnim(state.inputAxis);
        ReadyForBattleAnim(state.isReadyForBattle);
        AimingAnim(state.isAiming);
        CharacterCrouchAnim(state.isCrouchimg);
    }
    public void JumpAnim(bool isKeyDownJump)
    {
        animator.SetBool("IsJumping", isKeyDownJump);
    }
    public void MoveAnim(Vector3 inputAxis) //inputAxis- ���������� � ����� ������ Vector3
    {
        speedAnim = Input.GetKey(KeyCode.LeftAlt) ? 0.5f : Input.GetKey(KeyCode.LeftShift) ? 1 : 0.8f;
        if (inputAxis.sqrMagnitude > 0.2f) //������ �������� ������ �� ���� �� ������ W A S D //sqrMagnitude- ����������� �������� ����� �� 0 �� 1
        {
            animator.SetFloat("Horizontal", inputAxis.x * speedAnim, smoothToggleAnim, Time.deltaTime); //��������� �������� �������� �� ��� x (������, �����)
            animator.SetFloat("Vertical", inputAxis.z * speedAnim, smoothToggleAnim, Time.deltaTime); //��������� �������� �������� �� ��� z (�����, �����) //������ �������� ����� ��� �������� ��������� �������� ����� ���������� (� ������ ������ 0.2f)
        } //"Horizontal" � "Vertical" c����� � ���������
        else
        { //��������� ��������
            animator.SetFloat("Horizontal", 0, smoothToggleAnim, Time.deltaTime);
            animator.SetFloat("Vertical", 0, smoothToggleAnim, Time.deltaTime);
        }
    }
    public void CharacterCrouchAnim(bool isCrouching)
    {
        if(isCrouching)
        animator.SetTrigger("CrouchTrigger");
    }
    
    private void ReadyForBattleAnim(bool IsReadyForBattle)
    {
        animator.SetBool("IsReadyForBattle", IsReadyForBattle); 
    }
    public void AimingAnim(bool isAim)
    {
        animator.SetBool("IsAiming", isAim); 
    }

    public void TurnAnimation(Vector3 mouseDelta)
    {
        if (Mathf.Abs(mouseDelta.x) > 0)
        {
            float deltaMouse = animator.GetFloat("MouseDelta");
            float smooth = Mathf.Lerp(deltaMouse, mouseDelta.x * 45, 0.1f);
            Debug.Log(deltaMouse);
            animator.SetFloat("MouseDelta", smooth, smoothToggleAnim, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("MouseDelta", 0, smoothToggleAnim, Time.deltaTime);
        }
    }
    private void WeaponEquipAnim(bool isEquip)
    {
        animator.SetLayerWeight(equipWeaponLayer, 1);
        if (isEquip)
        {
            animator.SetTrigger("WeaponEquipTrigger");
        }
        else animator.SetTrigger("WeaponUnEquipTrigger");
    }
}
