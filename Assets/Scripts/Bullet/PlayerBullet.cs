using System;
using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private readonly WaitForSeconds FIVE_SECONDS = new WaitForSeconds(5f);
    bool Released = false;
    private Action ReleaseFunction;

    public void Init(Transform startingTransform, Action release)
    {
        Released = false;
        ReleaseFunction = release;
        transform.position = startingTransform.position;
        transform.rotation = startingTransform.rotation;

        StartCoroutine(LifeCycleTimer());
    }

    IEnumerator LifeCycleTimer()
    {
        yield return FIVE_SECONDS;
        Release();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyBase>(out var enemy))
        {
            enemy.TakeDamage(10f);
            Release();
        }
    }

   private void Release()
    {
        if (!Released)
        {
            Released = true;
            ReleaseFunction.Invoke();
        }
    }
}
