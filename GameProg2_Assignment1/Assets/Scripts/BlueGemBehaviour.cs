using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemBehaviour : MonoBehaviour
{
    public GameObject particleSystemToSpawn;

    private void OnTriggerEnter(Collider other) 
    {
        if (other != null) {
            gameObject.SetActive(false);
            GameObject particleSystem = Instantiate(particleSystemToSpawn, transform.position, transform.rotation);
            Destroy(particleSystem, 3);
        }
    }
}
