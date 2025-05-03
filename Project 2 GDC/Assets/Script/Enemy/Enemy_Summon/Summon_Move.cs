using UnityEngine;
using System.Collections;
using UnityEngine.Timeline;
using System;

public class Summon_Move : MonoBehaviour
{
    [SerializeField] private float Enemy_spd;
    [SerializeField] private float Enemy_dmg;
    [SerializeField] private float Enemy_cd;
    [SerializeField] private float hurtDuration ;
    private float lastTime = 0f;
    private Rigidbody2D _rb;
    private Summon_Aware _aware;
    private bool directRight=false;
    private bool isChasing=false;
    private bool isTouch=false;
    private bool isHurt=false;
    private Vector2 StartPoint;
    private Vector2 knockbackDirection;
    public Transform _player;
    public Animator animator;

    private void Awake()
    {
        _rb=GetComponent<Rigidbody2D>();
        _aware=GetComponent<Summon_Aware>();
    }
    private void Start(){

        _player = FindFirstObjectByType<JoyStick>().transform;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            isTouch=true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            isTouch=false;
        }
    }
    void attack(){
            animator.SetBool("Attack",true);
            Health hp=_player.GetComponent<Health>();
            if(hp!=null){
                hp.TakeDamage(Enemy_dmg);
            }
    }
    void FixedUpdate()
    {
        if(_aware.AwareOfPlayer){
            if(!isChasing){
                isChasing=true;
                StopAllCoroutines();
            }
            Chase();
            if(!isHurt&&isTouch && Time.time-lastTime>=Enemy_cd){
                attack();
                lastTime=Time.time;
            }
            else{
                animator.SetBool("Attack",false);
            }
        }
        else{
            if(isChasing){
                isChasing=false;
            }
        }
        if (isHurt){
            animator.SetBool("Attack", false);
            return;
        }
    }
    

    private void Chase()
    {
        Vector2 targetDirection = _aware.DirectToPlayer;
        _rb.linearVelocity = targetDirection * Enemy_spd;

            if(_player.position.x>transform.position.x){
                if(!directRight){Flip();}
            }
            else{
                if(directRight){Flip();}   
            }

    }

    
    void Flip(){
        directRight=!directRight;
        Vector2 scale= transform.localScale;
        scale.x *=-1;
        transform.localScale=scale;
        StartPoint = transform.position;
    }
    void fly(){
        if(!directRight){
            _rb.linearVelocityX=-Enemy_spd;
        }
        else{
            _rb.linearVelocityX=Enemy_spd;
        }
    }
    public void TakeDamageReaction(){
        if (!isHurt){
            StartCoroutine(HurtRoutine());
        }
    }
    private IEnumerator HurtRoutine(){
        isHurt = true;
        _rb.linearVelocity = Vector2.zero;
        animator.SetTrigger("Get Hit"); // Animation bị đánh
        yield return new WaitForSeconds(hurtDuration); // khoảng choáng

        isHurt = false;
    }
    
}
