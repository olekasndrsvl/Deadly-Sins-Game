using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks;
    public float startTimeBetweenAttacks;

    public int health;
    public Transform attackpos;
    public LayerMask enemy;
    public float attackrange;
    public Animator PlayerAnimator;
    public int damageAmount;
    public GameObject deathEffect;
    bool isAttacking=false;
    private Collider2D[] enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenAttacks -= Time.deltaTime;
    }

    public void OnAttackButtonClicked()
    {
        if(!isAttacking)
        {
            PlayerAnimator.SetBool("IsFighting",false);
            PlayerAnimator.SetBool("IsFighting", true);
            isAttacking = true;
        }
        
    }

    public void AttackEnded()
    {
        enemies = Physics2D.OverlapCircleAll(attackpos.position, attackrange,enemy);
        PlayerAnimator.SetBool("IsFighting",false);
        if(enemies.Length>0)
            enemies.First().GetComponent<Enemy>().TakeDamage(damageAmount);
        isAttacking = false;
        timeBetweenAttacks = startTimeBetweenAttacks;
    }
}
