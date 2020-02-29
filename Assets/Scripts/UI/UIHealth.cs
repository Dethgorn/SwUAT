using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{

    private PlayerHealth playerHealthComponent;
    [SerializeField]
    private Text playerHPText;
    

    // Start is called before the first frame update
    void Start()
    {
        playerHPText = this.GetComponent<Text>();
        playerHealthComponent = GameManager.instance.player.GetComponent<PlayerHealth>();
        // register UpdateHealthUI function with the Event in our health
        playerHealthComponent.OnHealthChange.AddListener(UpdateHealthUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthUI(float newHP)
    {
        playerHPText.text = newHP.ToString();
    }

}
