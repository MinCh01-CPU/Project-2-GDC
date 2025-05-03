using UnityEngine;

public class jungleChange : MonoBehaviour
{
    [SerializeField] private GameObject background_1, background_2;

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player"))
        {
            background_1.SetActive(false);
            background_2.SetActive(true);
        }
    }
}
