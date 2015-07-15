using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour
{

    //Static field accessible from anywhere
    public static bool goalMet;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            print("success");
            goalMet = true;

            Color c = this.GetComponent<Renderer>().material.color;
            c.a += 0.5f;
            GetComponent<Renderer>().material.color = c;
        }
    }
}

