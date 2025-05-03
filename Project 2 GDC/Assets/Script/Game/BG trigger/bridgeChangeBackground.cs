using UnityEngine;

public class bridgeChangeBackground : MonoBehaviour
{
    [SerializeField] GameObject background_1, background_2;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            background_1.SetActive(true);
            background_2.SetActive(false);
        }
    }
}
