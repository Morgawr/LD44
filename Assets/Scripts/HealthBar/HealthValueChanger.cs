using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class HealthValueChanger : MonoBehaviour {
    public Slider Slider;
    public Text Text;

    public void ChangeText() {
        Text.text = Slider.value + " / " + Slider.maxValue;
    }
}
}