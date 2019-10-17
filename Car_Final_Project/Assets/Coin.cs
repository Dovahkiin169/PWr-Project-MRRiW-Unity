using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        score.increaseScore(1);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnCollisionEnter()
    {
        score.increaseScore(1);
        this.gameObject.SetActive(false);
    }
}
