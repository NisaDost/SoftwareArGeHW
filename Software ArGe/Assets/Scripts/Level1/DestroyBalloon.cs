using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBalloon : MonoBehaviour
{
    //balon patlama animasyonu oynadığında event ile objeyi yok eder
    void Destroy()
    {
        Destroy(gameObject);
    }
}
