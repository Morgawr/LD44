using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD44 {
public class QuitEnabler : MonoBehaviour {

    public GameObject QuitChild;

    public void EnableChild() {
        QuitChild.SetActive(true);
    }
}
}