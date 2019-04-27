using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44 {
public class UpdateChecker : MonoBehaviour {

    private List<ResourceBuyer> Upgrades;
    public GameObject UpgradesPanel;

    private static bool MeetsRequirements(ResourceBuyer upgrade) {
        var purchasedUpgrades = Singleton<GameState>.Instance.PurchasedUpgrades;
        return upgrade.UpgradeRequirements.IsSubsetOf(purchasedUpgrades.Keys);
    }

    // Test if the player has enough health to enable some upgrades to purchase
    public void Check() {
        var health = Singleton<GameState>.Instance.Health;
        var purchasedUpgrades = Singleton<GameState>.Instance.PurchasedUpgrades;
        foreach(var upgrade in Upgrades) {
            int counter = 0;
            bool canPurchase = true;
            if(purchasedUpgrades.TryGetValue(upgrade.ButtonName, out counter)) {
                if(counter >= upgrade.MaxPurchases)
                    canPurchase = false;
            } 
            if(!canPurchase) {
                upgrade.gameObject.SetActive(false);
                continue;
            }

            if(health < upgrade.PurchaseCost) {
                upgrade.GetComponent<Button>().interactable = false;
            } else {
                upgrade.GetComponent<Button>().interactable = true;
            }

            if(health < upgrade.DisplayCost || !MeetsRequirements(upgrade)) {
                upgrade.gameObject.SetActive(false);
            } else {
                upgrade.gameObject.SetActive(true);
            }
        }
    }

    public void Start() {
        Upgrades = new List<ResourceBuyer>(UpgradesPanel.GetComponentsInChildren<ResourceBuyer>());
        Check();
    }

    public void LateUpdate() {
        Check();
    }
}
}