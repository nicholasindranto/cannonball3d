using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    // reference ke cannonammo nya
    private CannonAmmo cannonAmmo;

    // reference ke prefab cannonballnya
    public GameObject cannonBallPrefab;

    // reference ke shootpoint nya
    public Transform shootPoint;

    // kecepatan tembakannya
    public float shootForce;

    private void Awake()
    {
        cannonAmmo = GetComponent<CannonAmmo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // klik kiri mouse
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // kalau ammo nya habis gak bisa nembak lagi, di return
        if (cannonAmmo.CurrentAmmo <= 0) return;

        // spawn cannonball nya
        GameObject cannonBall = Instantiate(cannonBallPrefab, shootPoint.position, shootPoint.rotation);

        // ambil rigidbodynya dan kasih kecepatan kaya peluru pakai 
        // forcemode.impulse
        cannonBall.GetComponent<Rigidbody>().AddForce(cannonBall.transform.forward * shootForce, ForceMode.Impulse);

        // pas nembak jumlah ammo nya ngurang 1
        cannonAmmo.CurrentAmmo--;
    }
}
