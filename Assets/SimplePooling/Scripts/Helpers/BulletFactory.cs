using System.Collections;
using SimplePooling;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public SimplePoolData poolData;
    [Range(.1f, 1f)] public float shootDelay;

    private ISimplePool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new SimpleArrayPool<Bullet>(poolData);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);

        StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            var bullet = bulletPool.Get();

            bullet.transform.position = transform.TransformPoint(transform.forward * 2f);

            StartCoroutine(ReleaseRoutine(bullet));

            yield return new WaitForSeconds(shootDelay);

            yield return null;
        }
    }

    private IEnumerator ReleaseRoutine(Bullet bullet)
    {
        yield return new WaitForSeconds(3f);

        bulletPool.Release(bullet);
    }
}
