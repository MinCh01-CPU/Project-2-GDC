using System.Collections;
using UnityEngine;

public class darkBackgorund : MonoBehaviour
{
    [SerializeField] GameObject Background_1;
    private SpriteRenderer[] childBGs;
    private SpriteRenderer BG;
    private bool firtTimeEnter = true;

    void Start()
    {
        BG = GetComponent<SpriteRenderer>();
        childBGs = GetComponentsInChildren<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (!Background_1.activeInHierarchy) return;
            else if (firtTimeEnter)
            {
                StartCoroutine(FadeToDim(BG, 0, 8));
                foreach (SpriteRenderer childBG in childBGs)
                {
                    StartCoroutine(FadeToDim(childBG, 0, 8));
                }
                firtTimeEnter = false;
            }
            
        }
    }
    IEnumerator FadeToDim(SpriteRenderer spriteRenderer, float targetBrightness, float duration)
    {
        float time = 0;
        Color startColor = spriteRenderer.color;

        while (time < duration)
        {
            float t = time / duration;
            float b = Mathf.Lerp(1f, targetBrightness, t); // Lerp từ sáng tới tối
            spriteRenderer.color = new Color(
                startColor.r * b,
                startColor.g * b,
                startColor.b * b,
                startColor.a);  // Giữ nguyên alpha
            time += Time.deltaTime;
            yield return null;
        }
}

}

