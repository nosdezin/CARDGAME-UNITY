using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatalhaTile : MonoBehaviour
{
    public bool isBusy;
    private Renderer rnd;
    // 1F306A

    private void Awake() {
        rnd = GetComponent<Renderer>();
        isBusy = false;
    }

    private void Update() {
        if(isBusy){
            rnd.material.color = Color.red;
        }else{
            rnd.material.color = new Color(0.2f, 0.4f, 0.6f);
        }
    }
}
