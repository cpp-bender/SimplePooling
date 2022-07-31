using System.Collections;
using SimplePooling;
using UnityEngine;

public class ArrayFactory : MonoBehaviour
{
    public SimplePoolData poolData;

    public Bullet[] arr;

    private ISimplePool<Bullet> bulletPool;

    private void Start()
    {
        bulletPool = new SimpleArrayPool<Bullet>(poolData);
    }

    private IEnumerator Routine()
    {
        var bullet = bulletPool.Get();

        bullet.transform.position = transform.TransformPoint(transform.forward * 2f);

        yield return new WaitForSeconds(5f);

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
