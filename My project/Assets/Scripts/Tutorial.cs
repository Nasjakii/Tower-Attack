using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject textfield;
    private int textfieldIndex;
    public TextMeshProUGUI text;
    public TextMeshProUGUI headline;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            textfieldIndex++;
        }
        switch (textfieldIndex)
        {
            case 0:
                text.SetText("aaaa");
                headline.SetText("Headline 0");
                break;
            case 1:
                text.SetText("bbbb");
                headline.SetText("Headline 1");
                break;
            default:
                gameObject.SetActive(false);
                break;
        }
    }
}
