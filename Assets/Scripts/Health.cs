using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emtpyHeart;

    void Update(){
        ///prevent player health from exceeding max num of hearts
        if(health > numOfHearts){
            health = numOfHearts;
        }

        ///display proper number of empty and full health containers
        for (int i = 0; i < hearts.Length; i++){
            if (i < health){
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emtpyHeart;
            }

            if (i < numOfHearts){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

}
