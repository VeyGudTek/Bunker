using System;
using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private const float BULLET_SPEED = 50f;

    [SerializeField]
    private Rigidbody BulletRigidbody;

    private readonly WaitForSeconds FIVE_SECONDS = new WaitForSeconds(5f);
    bool Released = false;
    private Action ReleaseFunction;

    public void Init(Transform startingTransform, Action release)
    {
        Released = false;
        ReleaseFunction = release;

        transform.position = startingTransform.position;
        transform.rotation = startingTransform.rotation;
        BulletRigidbody.linearVelocity = Vector3.zero;
        Physics.SyncTransforms();

        BulletRigidbody.AddRelativeForce(Vector3.forward * BULLET_SPEED, ForceMode.VelocityChange);

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
