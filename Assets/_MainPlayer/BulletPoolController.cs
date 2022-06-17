using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolController : MonoBehaviour
{

    #region PoolFields&Methods

    [SerializeField] private List<Bullet> bullets;
    [SerializeField] private GameObject bulletPrefab;
    public Bullet CreateBullet(bool isActiveByDefault)
    {
        var newBullet = Instantiate(bulletPrefab, this.transform);
        bullets.Add(newBullet.GetComponent<Bullet>());

        return bullets[bullets.Count-1];
    }

    public bool HasFreeBullet(out Bullet b)
    {
        foreach (var blt in bullets)
        {
            if (!blt.gameObject.activeInHierarchy)
            {
                b = blt;
                return true;
            }

        }
        b = null;
        return false;
    }
    public Bullet GetFreeBullet()
    {
        if (this.HasFreeBullet(out var bullet))
            return bullet;

        return CreateBullet(false);
         

    }
    #endregion




}
