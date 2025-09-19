using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallSelfDestroy : MonoBehaviour
{
    // berapa lama sebelum ngilang
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
