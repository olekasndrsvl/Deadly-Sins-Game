using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
public class PlayerAttack : MonoBehaviour
{
    public float timeBetweenAttacks;
    public float startTimeBetweenAttacks;

    public int health;
    public Transform attackpos;
    public LayerMask enemy;
    public float attackrange;
    public Animator PlayerAnimator;
    public GameObject attackbutton;
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
        if (timeBetweenAttacks <= 0)
        {
            attackbutton.GetComponent<Image>().color=Color.white;
        }
    }

    public void TakeDamage(int damage)
    {
        var rand = new Random();
        health -= damage+ rand.Next(-5,5);
    }
    
    public void OnAttackButtonClicked()
    {
        attackbutton.GetComponent<Image>().color = Color.gray;
        if(timeBetweenAttacks<=0)
        {
            PlayerAnimator.SetTrigger("Fight");
        }    
    }

    public void AttackEnded()
    {
        enemies = Physics2D.OverlapCircleAll(attackpos.position, attackrange,enemy);
        
        if(enemies.Length>0)
            enemies.First().GetComponent<Enemy>().TakeDamage(damageAmount);
        timeBetweenAttacks = startTimeBetweenAttacks;
    }
}
