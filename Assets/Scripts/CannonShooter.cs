using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    // reference ke prefab cannonballnya
    public GameObject cannonBallPrefab;

    // reference ke shootpoint nya
    public Transform shootPoint;

    // kecepatan tembakannya
    public float shootForce;

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
        // spawn cannonball nya
        GameObject cannonBall = Instantiate(cannonBallPrefab, shootPoint.position, shootPoint.rotation);

        // ambil rigidbodynya dan kasih kecepatan kaya peluru pakai 
        // forcemode.impulse
        cannonBall.GetComponent<Rigidbody>().AddForce(cannonBall.transform.forward * shootForce, ForceMode.Impulse);
    }
}
