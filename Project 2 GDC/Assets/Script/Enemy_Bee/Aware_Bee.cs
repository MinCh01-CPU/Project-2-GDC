using UnityEngine;

public class Aware_Bee : MonoBehaviour
{
    public bool AwareOfPlayer{get;private set;}
    public Vector2 DirectToPlayer{get; private set;}
    public Vector2 DirectToSpawn{get; private set;}
    [SerializeField] private float RangeAware;
    private Transform _player;
    public Vector2 _SpawnPoint{get;private set;}

    private void Awake()
    {
        _player=GameObject.Find("Player").transform;
        _SpawnPoint=transform.position;
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
        Vector2 DirectionToSpawn=_SpawnPoint-(Vector2)transform.position;
        DirectToSpawn=DirectionToSpawn.normalized;
    }
}
