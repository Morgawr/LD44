using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class ResourceBuyer : MonoBehaviour {
    private Text buttonLabel;
    public string ButtonName;
    public int DisplayCost;
    public int PurchaseCost;
    public int MaxPurchases;

    public HashSet<string> UpgradeRequirements = new HashSet<string>();
    public List<string> InitUpgradeRequirements = new List<string>();

    private void Purchase() {
        var purchased = Singleton<GameState>.Instance.PurchasedUpgrades;
        int counter = 0;
        if(purchased.TryGetValue(ButtonName, out counter)) {
            purchased[ButtonName] = counter+1;
        } else {
            purchased.Add(ButtonName, 1);
        }
    }

    public void OnClick() {
        Purchase();
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<HealthCounter>().SpendHealth(PurchaseCost);
    }

    void Start() {
        buttonLabel = GetComponentInChildren<Text>();
        buttonLabel.text = $"{ButtonName} (-{PurchaseCost}HP)";
        UpgradeRequirements = new HashSet<string>(InitUpgradeRequirements);
    }

    void Update() {

    }
}
}
