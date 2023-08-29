using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PLayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateText(string text)
    {
        textMeshProUGUI.text = text;
    }
}
