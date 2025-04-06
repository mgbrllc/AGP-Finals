using UnityEngine;
using System.Collections;

public class BacteriaFade : MonoBehaviour
{
    private SpriteRenderer sr;

    void Start()
    {
        // Try to get from self
        sr = GetComponent<SpriteRenderer>();

        // If not found, look through all children recursively
        if (sr == null)
        {
            sr = GetComponentInChildren<SpriteRenderer>(true); // include inactive children
        }

        if (sr == null)
        {
            Debug.LogError("❌ No SpriteRenderer found anywhere on: " + gameObject.name);
        }
    }

    public void FadeAndDestroy()
    {
        Debug.Log("✔ FadeAndDestroy called on: " + gameObject.name);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        if (sr == null)
        {
            Debug.LogError("❌ SpriteRenderer is still null — aborting fade.");
            Destroy(gameObject); // fallback
            yield break;
        }

        float fadeDuration = 0.1f;
        float elapsed = 0f;
        Color originalColor = sr.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        Debug.Log("🧨 Destroying: " + gameObject.name);
        Destroy(gameObject);
    }
}
