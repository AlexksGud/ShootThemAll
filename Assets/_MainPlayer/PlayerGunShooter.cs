using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerGunShooter : MonoBehaviour
{
    [SerializeField] private Transform shootFirePoint;
    [SerializeField] private Camera mainCamera;

    [SerializeField] private float shootCoolDown = 0.4f;
                     private bool isReload = false;
    [SerializeField] private float cameraDistanceForAim = 12f;

    [SerializeField] private BulletPoolController bulletPool;

                     private PlayerMovement playerMovements;
    void Start()
    {
        playerMovements = GetComponent<PlayerMovement>();
       
    }

  
    void Update()
    {
        if (isReload) return;

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ReloadingCor());

            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);     
          

            gameObject.transform.
                DOLookAt(ray.GetPoint(cameraDistanceForAim), 0.4f).
                OnComplete(() =>
                {
                    Shoot(ray);
                });

            
        }
    }

    private IEnumerator ReloadingCor()
    {
        isReload = true;
        yield return new WaitForSecondsRealtime(shootCoolDown);
        isReload = false;
    }

    private void Shoot(Ray r)
    {
        playerMovements.ShootAnimation();
        var bullet = bulletPool.GetFreeBullet();


        bullet.transform.position = shootFirePoint.position;

        var ra = mainCamera.gameObject.transform.position*10f;
        bullet.SetDirectionAndShoot(ra);

       
    }
}
