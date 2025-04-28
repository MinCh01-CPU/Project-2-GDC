using UnityEngine;

public class Aware_Bee : MonoBehaviour
{
    public bool AwareOfPlayer{get;private set;}
    public Vector2 DirectToPlayer{get; private set;}
    [SerializeField] private float RangeAware;
    private Transform _player;

    private void Awake()
    {
        _player=GameObject.Find("Player").transform;
    }
    void Update()
    {
        Vector2 DirectionToPlayer=_player.position-transform.position;
        DirectToPlayer=DirectionToPlayer.normalized;
        if(DirectionToPlayer.magnitude<=RangeAware){
            AwareOfPlayer=true;
        }
        else{
            AwareOfPlayer=false;
        }
    }
}
