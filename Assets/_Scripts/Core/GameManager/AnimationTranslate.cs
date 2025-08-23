using _Scripts.DesignPattern.Singleton;
using UnityEngine;

public class AnimationTranslate : Singleton<AnimationTranslate>
{
    public void Translate(Transform target, Vector3 from, Vector3 to, float duration)
    {
        StartCoroutine(TranslateCoroutine(target, from, to, duration));
    }

    private System.Collections.IEnumerator TranslateCoroutine(Transform target, Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;
        target.localPosition = from;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            target.localPosition = Vector3.Lerp(from, to, elapsed / duration);
            yield return null;
        }

        target.localPosition = to;
    }
}
