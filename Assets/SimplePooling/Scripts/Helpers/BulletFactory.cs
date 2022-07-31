using System.Collections;
using SimplePooling;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    public SimplePoolData poolData;

    private ISimplePool<Bullet> bulletPool;

    private void Start()
    {
        bulletPool = new SimplePool<Bullet>(poolData);
    }

    private IEnumerator Routine()
    {
        var bullet = bulletPool.Get();

        bullet.transform.position = transform.TransformPoint(transform.forward * 2f);

        yield return new WaitForSeconds(3f);

        bulletPool.Release(bullet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Routine());
        }
    }
}
