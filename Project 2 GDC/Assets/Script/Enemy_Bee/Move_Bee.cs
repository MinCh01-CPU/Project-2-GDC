using UnityEngine;
using System.Collections;
using UnityEngine.Timeline;
using System;

public class Move_Bee : MonoBehaviour
{
    [SerializeField] private float Enemy_spd;
    [SerializeField] private float patrolRange;
    private Rigidbody2D _rb;
    private Aware_Bee _aware;
    private bool directRight=false;
    private bool isChasing=false;
    private Vector2 StartPoint;
    public Transform _player;
    public Animator animator;
    private void Awake()
    {
        _rb=GetComponent<Rigidbody2D>();
        _aware=GetComponent<Aware_Bee>();
        StartPoint=transform.position;
    }
    private void Start(){

        StartCoroutine(Patrol());
    }
    void FixedUpdate()
    {
        if(_aware.AwareOfPlayer){
            if(!isChasing){
                isChasing=true;
                StopAllCoroutines();
            }
            Chase();
        }
        else{
            if(isChasing){
                isChasing=false;
                StartCoroutine(Patrol());
            }
        }
    }
    
    private void GoSpawn(){
        Vector2 spawnDirection = _aware.DirectToSpawn;
        _rb.linearVelocity = spawnDirection * Enemy_spd;

        if (spawnDirection.x > 0 && !directRight){
        Flip();
        }
        else if (spawnDirection.x < 0 && directRight){
        Flip();
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

    private IEnumerator Patrol()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            while (Vector2.Distance(transform.position, _aware._SpawnPoint) > 0.01f)
        {
            GoSpawn();
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        _rb.linearVelocity = Vector2.zero;
            // Di chuyển đến khi vượt khỏi phạm vi tuần tra
            while (Mathf.Abs(transform.position.x - StartPoint.x) <= patrolRange)
            {
                fly();
                yield return null;
            }

            // Đã tới giới hạn → dừng và đợi
            yield return new WaitForSeconds(3f);

            // Quay đầu và lặp lại
            Flip();
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
}
