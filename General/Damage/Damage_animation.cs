using UnityEngine;
using System.Collections;

public class Damage_animation : MonoBehaviour
{
    public Life_count damage_taken;

    public bool isAnimation = false;

    public Spawning_Boxes spawner1;

    public boxSpawner2 spawner2;

    public float height = 2f;
    public float duration = 0.5f;

    private IEnumerator Damage_animation_coroutine()
    {
        isAnimation = true;

        float originalSpeed1 = spawner1.speed;
        float originalSpeed2 = spawner2.speed;
        spawner1.speed = 0f;
        spawner2.speed = 0f;

        GameObject[] boxes1 = GameObject.FindGameObjectsWithTag("Box");
        GameObject[] boxes2 = GameObject.FindGameObjectsWithTag("Box2");

        foreach (var box in boxes1)
        {
            StartCoroutine(PushUp(box));
            StartCoroutine(CollisionDisapear(box));
        }

        foreach (var box in boxes2)
        {
            StartCoroutine(PushRight(box));
            StartCoroutine(CollisionDisapear(box));
        }

        yield return new WaitForSeconds(duration);
        while (spawner1.speed <= originalSpeed1 && spawner2.speed <= originalSpeed2)
        {
            spawner1.speed += 0.1f;
            spawner2.speed += 0.1f;
            yield return new WaitForSeconds(0.001f);
        }
        spawner1.speed = originalSpeed1;
        spawner2.speed = originalSpeed2;

        isAnimation = false;
    }
    
    private IEnumerator CollisionDisapear(GameObject collision)
    {
        BoxCollider2D boxCollider = collision.gameObject.GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            yield break;
        }
        boxCollider.enabled = false;
        yield return new WaitForSeconds(3f);
        if (collision != null && boxCollider != null)
            boxCollider.enabled = true;
    }

    private IEnumerator PushUp(GameObject box)
    {
        Vector3 originalPosition = box.transform.position;
        Vector3 targetPosition = originalPosition + Vector3.up * height;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            box.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime * 2;
            yield return null;
        }
    }

    private IEnumerator PushRight(GameObject box)
    {
        Vector3 originalPosition = box.transform.position;
        Vector3 targetPosition = originalPosition + Vector3.right * height * 2;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            box.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime * 2;
            yield return null;
        }
    }

    void Update()
    {
        if (damage_taken.damage_taken && !isAnimation)
        {
            StartCoroutine(Damage_animation_coroutine());
        }
    }
}
