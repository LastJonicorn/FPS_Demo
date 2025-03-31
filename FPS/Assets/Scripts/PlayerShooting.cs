using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float range = 100f;
    public float damage = 25f;
    public Camera cam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log("Hit " + hit.transform.name);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                Debug.Log("Enemy was hit");
                target.TakeDamage(damage);
            }
        }
    }
}
