using UnityEngine;

public abstract class AnimBase : MonoBehaviour
{
    public AttackBase attack { get; private set; } 
    public Animator animator { get; private set; }
    public  MoveBase move { get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        move = GetComponent<MoveBase>();
        attack = GetComponent<AttackBase>();
    }

    public void MoveAnim(float moveSpeed)
    {
        animator.SetFloat("velocityY", Mathf.Abs(moveSpeed), 0.2f, Time.deltaTime);
    }
    public void ScrimerAnim()
    {
        animator.SetTrigger("ScreamTrigger");
    }
    public void JumpAnimAttack()
    {
        animator.SetTrigger("JumpAttackTrigger");
    }
    public  void PunchAnimAttack()
    {
        animator.SetTrigger("PunchAttackTrigger");
    }
    public void DefaultAttackAnim()
    {
        animator.SetTrigger("AttackTrigger");
    }
}
