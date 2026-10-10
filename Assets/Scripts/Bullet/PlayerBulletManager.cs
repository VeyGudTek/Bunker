using UnityEngine;
using UnityEngine.Pool;

public class PlayerBulletManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;
    ObjectPool<PlayerBullet> BulletPool;

    void Awake()
    {
        BulletPool = new ObjectPool<PlayerBullet>(
            createFunc: () => CreateFunction(),
            actionOnGet: bullet => bullet.gameObject.SetActive(true),
            actionOnRelease: bullet => bullet.gameObject.SetActive(false),
            actionOnDestroy: bullet => Destroy(bullet.gameObject),
            collectionCheck: true,
            defaultCapacity: 10,
            maxSize: 20
        );
    }

    PlayerBullet CreateFunction()
    {
        return Instantiate(BulletPrefab, transform).GetComponent<PlayerBullet>();
    }


    public void Shoot(Vector3 startingPosition)
    {
        PlayerBullet bullet = BulletPool.Get();
        bullet.Init(() => BulletPool.Release(bullet));
        bullet.transform.position = startingPosition;
    }
}
