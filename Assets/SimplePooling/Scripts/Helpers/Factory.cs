using System.Collections;
using SimplePooling;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public SimplePoolData poolData;

    private ISimplePool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new SimpleArrayPool<Bullet>(poolData);
    }

    private IEnumerator Start()
    {
        while (true)
        {
            var bullet = bulletPool.Get();

            bullet.transform.position = transform.TransformPoint(transform.forward * 2f);

            StartCoroutine(ReleaseRoutine(bullet));

            yield return new WaitForSeconds(1f);

            yield return null;
        }
    }

    private IEnumerator ReleaseRoutine(Bullet bullet)
    {
        yield return new WaitForSeconds(3f);

        bulletPool.Release(bullet);
    }
}
