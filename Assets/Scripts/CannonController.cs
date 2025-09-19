using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    // reference ke body cannon nya
    public Transform cannonBody;

    // kecepatan gerakannya
    public float rotationSpeed;

    // berapa derajat muternya
    public float xDegree, yDegree;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        // ambil input horiz dan verti pakai getaxis
        // kenapa getaxis? biar pergerakannya gak kaku, ada percepatannya
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // set ke derajatnya
        xDegree += horizontalMovement * rotationSpeed * Time.deltaTime;
        yDegree += verticalMovement * rotationSpeed * Time.deltaTime;

        // set maximum dan minimum rotationnya
        xDegree = Mathf.Clamp(xDegree, -43, 43);
        yDegree = Mathf.Clamp(yDegree, -8, 48);

        // set rotasi cannon bodynya
        // z = xDegree, kenapa?
        // karna kanan kiri itu = z
        cannonBody.localEulerAngles = new Vector3(0, yDegree, xDegree);
    }
}
