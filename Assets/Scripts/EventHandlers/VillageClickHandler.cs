using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace LD44 {
public class VillageClickHandler : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick(PointerEventData data) {
        if(data.button == PointerEventData.InputButton.Left) {
            SceneManager.UnloadSceneAsync("MapScene");
            SceneManager.LoadSceneAsync("VillageScene", LoadSceneMode.Additive);
        }
    }
}
}