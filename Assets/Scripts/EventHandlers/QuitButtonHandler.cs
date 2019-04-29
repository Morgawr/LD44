using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LD44 {
public class QuitButtonHandler : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData data) {
        if(data.button == PointerEventData.InputButton.Left) {
            Application.Quit();
        }
    }
}
}