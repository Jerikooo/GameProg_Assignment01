using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI gemText;

    void Start()
    {
        gemText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        gemText.text = GameManager.Instance.Score.ToString();
    }
}
