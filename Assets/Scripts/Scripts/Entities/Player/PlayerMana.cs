using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public Slider manaSlider;
    public float mana;
    public int manaCost;

    private void Update()
    {
        manaSlider.GetComponent<Slider>().value = mana;
    }
}
