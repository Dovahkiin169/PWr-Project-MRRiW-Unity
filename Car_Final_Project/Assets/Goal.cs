using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Score score;

    void OnTriggerEnter(Collider other)
    {
        score.increaseScore(1);
    }

    void OnCollisionEnter(Collision collision)
    {
        score.increaseScore(1);
    }
}
