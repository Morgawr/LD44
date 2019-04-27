using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace LD44 {
public class MapLocationHighlighter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private Text Description; 

    void Start() {
        Description = GetComponentInChildren<Text>();
        Description.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData data) {
        Description.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData data) {
        Description.gameObject.SetActive(false);
    }

}
}