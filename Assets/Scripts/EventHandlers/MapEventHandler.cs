using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace LD44 {
public class MapEventHandler : MonoBehaviour, IPointerClickHandler {

    public void OnPointerClick(PointerEventData data) {
        if(data.button == PointerEventData.InputButton.Left) {
            SceneManager.UnloadSceneAsync("IdleScene");
            SceneManager.LoadSceneAsync("MapScene", LoadSceneMode.Additive);
        }
    }
}
}