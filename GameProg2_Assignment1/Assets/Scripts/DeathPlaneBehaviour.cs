using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlaneBehaviour : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        // restart level when hit trigger
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.Instance.Score = GameManager.Instance.CurrentScore;
        }
    }
}
