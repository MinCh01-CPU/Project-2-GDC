using UnityEngine;
using UnityEngine.Tilemaps;

public class hiveTriigger : MonoBehaviour
{
    [SerializeField] private Tilemap hiveWall;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hiveWall.transform.position=new Vector3(0.135f,0.075f,-2);
            hiveWall.GetComponent<Collider2D>().isTrigger =  false;
        }
    }
}
