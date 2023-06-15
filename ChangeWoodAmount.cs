using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeWoodAmount : MonoBehaviour
{
    public static TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = this.GetComponent<TextMeshProUGUI>();
    }
    public static void EditText(string newText)
    {
        // Update the text of the TextMeshProUGUI component
        textMeshPro.text = "Wood " + newText;
    }
}
