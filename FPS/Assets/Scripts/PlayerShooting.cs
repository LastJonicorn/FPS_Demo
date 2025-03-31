using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float range = 100f;
    public float damage = 25f;
    public Camera cam;

    public ParticleSystem muzzleFlash;
    public GameObject hitSparkPrefab;
    public LayerMask targetLayers;

    //public List<GameObject> trees;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, targetLayers))
        {
            Debug.Log("Hit " + hit.transform.name);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                Debug.Log("Enemy was hit");
                target.TakeDamage(damage);
            }

            if (hitSparkPrefab != null)
            {
                GameObject impactEffect = Instantiate(hitSparkPrefab, hit.point, Quaternion.LookRotation(hit.normal));

                Destroy(impactEffect, 2f);
            }
        }
    }
}
