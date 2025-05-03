using UnityEngine;

public class backgroundController : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxValue;
    private float startPos, length;

    void Start()
    {
        startPos = cam.transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxValue;
        float movement = cam.transform.position.x * (1 - parallaxValue);

        transform.position = new Vector3(startPos + distance, cam.transform.position.y, 0);

        if (movement > startPos + length)
            startPos += length;
        else if (movement < startPos - length)
            startPos -= length;
    }

}
