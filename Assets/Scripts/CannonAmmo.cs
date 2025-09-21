using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CannonAmmo : MonoBehaviour
{
    // reference juga ammo text nya
    public TextMeshProUGUI ammoText;

    // berapa total ammo nya
    public int totalAmmo;

    // ammo sekarang berapa
    public int currentAmmo;

    // setter getter ammo
    public int CurrentAmmo
    {
        set
        {
            currentAmmo = value;
            ammoText.text = $"Ammo : {currentAmmo}/{totalAmmo}";
            Debug.Log($"current ammo = {currentAmmo}");
            if (currentAmmo <= 0 && (GameManager.instance.fallenBrickAmount < GameManager.instance.fallenBrickNeed))
            {
                // kalau ammonya habis dan jumlah bricknya masih ada
                // maka kalah. level balik ke 1, dan restart gamenya
                GameManager.level = 1;
                GameManager.instance.RestartGame();
                Debug.Log("you lose");
            }
        }
        get
        {
            return currentAmmo;
        }
    }

    private void OnEnable()
    {
        GameManager.instance.setAmmo += SetAmmo;
    }

    private void OnDisable()
    {
        GameManager.instance.setAmmo -= SetAmmo;
    }

    private void SetAmmo()
    {
        // set ammo dengan cara jumlah brick yang perlu dihancurkan / 3
        totalAmmo = GameManager.instance.fallenBrickNeed / 3;

        // set current ammo yang sekarang
        currentAmmo = totalAmmo;
        ammoText.text = $"Ammo : {currentAmmo}/{totalAmmo}";
    }
}
