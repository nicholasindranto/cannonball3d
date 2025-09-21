using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGroupSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ambil jumlah child dirinya sendiri alias brick nya
        GameManager.instance.fallenBrickNeed += transform.childCount;

        // panggil semua function yang subscribe ke setammo
        // untuk ngeset ammo nya
        GameManager.instance.SetAmmo();
    }
}
