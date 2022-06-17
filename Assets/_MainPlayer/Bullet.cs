using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float lifeTime = 6f;

    bool bulletHitted=false;



    private void OnEnable()
    {
        StartCoroutine(BulletLifeCor());
        bulletHitted = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        bulletHitted = true;
    }

    private IEnumerator BulletLifeCor()
    {
        yield return new WaitForSeconds(lifeTime);
        Deactivate();
    }
    private IEnumerator BulletFlyToDirCor(Vector3 dir)
    {
        while (bulletHitted || gameObject.activeInHierarchy)
        {
            this.gameObject.transform.Translate(Vector3.forward*Time.deltaTime*bulletSpeed);
         
            yield return null;
        }
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        //StopAllCoroutines();
    }

    public void SetDirectionAndShoot(Vector3 dir)
    {
        
       
        bulletHitted = false;
        this.gameObject.SetActive(true);
        this.gameObject.transform.rotation = Quaternion.LookRotation(dir);
        StartCoroutine(BulletFlyToDirCor(dir));
        


    }



}
