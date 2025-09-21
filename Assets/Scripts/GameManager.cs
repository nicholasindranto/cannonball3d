using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // singleton
    public static GameManager instance;

    // array prefab wallofbricknya
    public GameObject[] wallGroupPrefabs;

    // jumlah brick yg jatuh sama 
    // jumlah brick yang dibutuhkan buat gamenya selesai
    public int fallenBrickAmount, fallenBrickNeed;

    // event pub sub buat set ammo nya sesuai level
    public event Action setAmmo;

    // level berapa sekarang
    public TextMeshProUGUI levelText;
    // angka levelnya
    // kenapa static? biar pas restart level, angkanya gak ganti
    public static int level = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpawnWallGroup(UnityEngine.Random.Range(0, wallGroupPrefabs.Length));
        /*
        alur spawn wall of bricks :
        1. dia spawn dulu mau yang mana dari array prefab wallgroup nya, 
           0 untuk level 1, 1 untuk level 2, 2 untuk level 3
        2. setelah spawn, kan muncul nih wall of bricks nya yang jadi 
           child dari wall group
        3. pas muncul, maka otomatis kode di script WallGroupSetter.cs jalan
        4. maka dia langsung dijumlahin seluruh wall of bricks ke dalam 
           wallFallenNeed
        */

        levelText.text = $"Level : {level}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // kalau pencet esc maka restart game
            RestartGame();
        }
    }

    private void SpawnWallGroup(int index)
    {
        Instantiate(wallGroupPrefabs[index], Vector3.zero, Quaternion.identity);
    }

    public void BrickFall()
    {
        fallenBrickAmount++;
        if (fallenBrickAmount >= fallenBrickNeed)
        {
            // ketika menang, levelnya nambah, dan gamenya restart
            level++;
            RestartGame();
            Debug.Log("you win");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetAmmo()
    {
        // kalau ada yang subscribe maka jalanin kodenya
        setAmmo?.Invoke();
        /*
        alur pub sub disini adalah :
        1. ketika wallgroup nya spawn (wall of bricksnya spawn), maka
           panggil fungsi ini alias ke ngepanggil semua function yang subscribe
           ke pubsub ini
        */
    }
}
