using UnityEngine;
using UnityEngine.Tilemaps;

public class bossTrigger : MonoBehaviour
{
    [SerializeField] private Tilemap bossWall;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bossWall.transform.position=new Vector3(0.135f,0.075f,-2);
            bossWall.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
