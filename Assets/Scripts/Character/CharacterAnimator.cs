using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private CharacterHP state;

    private float speedAnim = 0.5f;
    public float smoothToggleAnim = 0.2f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        state = FindObjectOfType<CharacterHP>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && state.isHasWeapon)
        {
            ReadyForBattleAnim(state.isHasWeapon);
        }
        if (Input.GetMouseButton(1) && state.isHasWeapon)
        {
            ReadyForBattleAnim(false);
            AimingAnim(true);
            Debug.Log("RightMouseButtonDown");
        }
        else if (Input.GetMouseButtonUp(1) && state.isHasWeapon)
        {
            AimingAnim(false);
            ReadyForBattleAnim(true);
        }
        
    }
    public void JumpAnim(bool isKeyDownJump)
    {
        if (isKeyDownJump)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        } 
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
    public void CharacterCrouchAnim()
    {
        animator.SetTrigger("CrouchTrigger");
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
    private void ReadyForBattleAnim(bool IsReadyForBattle)
    {
        animator.SetBool("IsReadyForBattle", IsReadyForBattle);
        Debug.Log("Battle" + IsReadyForBattle); 
    }
    public void AimingAnim(bool isAim)
    {
        animator.SetBool("IsAiming", isAim);
        Debug.Log("Aiming  " + isAim);
    }
}
