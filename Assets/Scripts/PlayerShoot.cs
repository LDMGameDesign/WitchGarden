using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform projSpawn;
    public GameObject playerProj;
    public Camera playerCam;

    public float projForce = 10f;

    Vector3 mousePos;

    void Update()
    {
        mousePos = playerCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz - 90);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(playerProj, projSpawn.position, projSpawn.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(projSpawn.up * projForce, ForceMode2D.Impulse);
    }
}
