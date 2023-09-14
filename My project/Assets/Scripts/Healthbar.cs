using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healtbarSprite;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;

        string tag = transform.parent.gameObject.tag;
        GameObject background = gameObject.transform.GetChild(0).gameObject;
        GameObject foreground = background.transform.GetChild(0).gameObject;
        if (tag == "Troop")
        {
            foreground.GetComponent<Image>().color = Color.green;
        }
        if (tag == "Tower")
        {
            foreground.GetComponent<Image>().color = Color.red;
        }
    }

    public void UpdateHealtbar(float maxHealth, float currentHealth)
    {
        healtbarSprite.fillAmount = currentHealth / maxHealth;
    }

    private void Update()
    {

        if (gameObject.layer == 5) return;
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }


}
