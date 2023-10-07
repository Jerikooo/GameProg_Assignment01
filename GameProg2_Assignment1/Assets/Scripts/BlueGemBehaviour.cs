using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGemBehaviour : MonoBehaviour
{
    public GameObject particleSystemToSpawn;
    public GameObject player;

    private Animator animator;

    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other != null) {
            gameObject.SetActive(false);
            GameObject particleSystem = Instantiate(particleSystemToSpawn, transform.position, transform.rotation);
            Destroy(particleSystem, 3);
            animator.SetBool("CanDoubleJump", true);
            Invoke("SpawnBlueGem", 30.0f);
        }
    }
    private void SpawnBlueGem() {
        gameObject.SetActive(true);
    }
}
