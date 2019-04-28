using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace LD44 {
public class SoundClickHandler : MonoBehaviour, IPointerClickHandler {

    public SoundToggler toggler;

    public void OnPointerClick(PointerEventData data) {
        if(data.button == PointerEventData.InputButton.Left) {
            toggler.Toggle();
        }
    }

}
}