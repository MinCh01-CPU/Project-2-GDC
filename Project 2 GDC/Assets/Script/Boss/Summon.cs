using UnityEngine;

public class Summon : MonoBehaviour
{
    public GameObject Enemy_Prefab;
    public BoxCollider2D SummonArena;
    public int Max_Enemy;
    public void summon(){
        for(int i=0; i<Max_Enemy; i++){
            Vector2 spawnPos=GetRandom(SummonArena.bounds);
            Instantiate(Enemy_Prefab,spawnPos,Quaternion.identity);
        }
    }
    Vector2 GetRandom(Bounds bounds){
        return new Vector2(
            Random.Range(bounds.min.x,bounds.max.x),
            Random.Range(bounds.min.y,bounds.max.y)
        );
    }
}
