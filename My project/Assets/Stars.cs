using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
    public Sprite star_empty;
    public Sprite star_full;
    
    public void SetScore(int score)
    {
        Image star0 = transform.GetChild(0).gameObject.GetComponent<Image>();
        Image star1 = transform.GetChild(1).gameObject.GetComponent<Image>();
        Image star2 = transform.GetChild(2).gameObject.GetComponent<Image>();

        star0.sprite = star_empty;
        star1.sprite = star_empty;
        star2.sprite = star_empty;

        if (score >= 1)
        {
            star0.sprite = star_full;
        }
        if (score >= 2)
        {
            star1.sprite = star_full;
        }
        if (score >= 2)
        {
            star2.sprite = star_full;
        }
    }
}
