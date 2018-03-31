using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public GameObject player;
    private PlayerMovement playerScript;

    public GameObject hpBar;
    private RectTransform hpBarRect;
    private Image hpBarImage;
    public Text playerText;

    private float defaultScale;

    private void Awake()
    {
        playerScript = player.GetComponent<PlayerMovement>();
    }

    // Use this for initialization
    void Start() {
       
        playerText.text = playerScript.name;

        hpBarRect = hpBar.GetComponent<RectTransform>();
        hpBarImage = hpBar.GetComponent<Image>();

        defaultScale = hpBarRect.localScale.x;
    }

    // Update is called once per frame
    void Update() {
        hpBarRect.localScale = new Vector3(defaultScale * (playerScript.healthCount / playerScript.maxHealth), hpBarRect.localScale.y);


        if (playerScript.healthCount < playerScript.maxHealth * 0.25f)
        {
            hpBarImage.color = Color.red;
        }
        else if(playerScript.healthCount < playerScript.maxHealth * 0.5f)
        {
            hpBarImage.color = Color.yellow;
        }else
        {
            hpBarImage.color = Color.green;
        }

    }
}