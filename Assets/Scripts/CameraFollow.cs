using UnityEngine;
using System.Collections;
public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;
    private Vector3 originalPos;

    void Start()
    {
        offset = transform.position - target.position;
        originalPos = transform.position;
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
    public IEnumerator Shake()
{
    float duration = 0.3f;
    float magnitude = 0.2f;

    float elapsed = 0f;

    while (elapsed < duration)
    {
        float x =
            Random.Range(-1f, 1f) * magnitude;

        float y =
            Random.Range(-1f, 1f) * magnitude;

        transform.position =
            originalPos + new Vector3(x, y, 0);

        elapsed += Time.deltaTime;

        yield return null;
    }

    transform.position = originalPos;
}
}