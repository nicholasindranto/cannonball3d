using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    // apakah udah runtuh belum
    public bool isFallen;

    void OnTriggerEnter(Collider other)
    {
        // kalau udah jatoh maka jangan di jalankan kodenya, return
        if (isFallen) return;

        if (other.GetComponent<FallenWallDetector>())
        {
            // udah jatoh
            isFallen = true;
            // panggil brickfall nya untuk mendeteksi jumlah brick yg jatoh
            GameManager.instance.BrickFall();
        }
    }
}
