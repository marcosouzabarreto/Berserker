using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Define componentes da barra
    public Slider slider;
    public Gradient gradient;
    [SerializeField] Image fill;
    // Define os valores máximos e cor inicial para vida
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    // Define o valor e as cores para vida durante a operação da barra
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.value);
    }
}
