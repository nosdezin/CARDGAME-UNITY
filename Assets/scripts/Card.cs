using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Vector2 MousePos;
    private Collider2D thisCollider;
    // private CardHand sc;
    public Vector2 lugarInicial; 
    public List<GameObject> areaMinha = new List<GameObject>();
    private bool isCartaHold;
    public int meuId = 0;

    void Start() {
        isCartaHold = false;
        thisCollider = GetComponent<Collider2D>();
        lugarInicial = new Vector2(transform.position.x,transform.position.y);
        // sc = GameObject.Find("Area de Carta").GetComponent<CardHand>();
        GameObject[] tilesBatalha = GameObject.FindGameObjectsWithTag("BatalhaTile");

        for(int pxc = 0;pxc <= 15;pxc += 3){
            areaMinha.Add(tilesBatalha[pxc]);
        }

        string nmb = "";
        string nome = gameObject.name;
        foreach(char letra in nome){
            if(letra is int){
                Debug.Log(letra);
                // nmb += letra;
            }
        }

        // Debug.Log(nmb);
        // for(int v = 0;v <= nome.Length-1;v++){
        //     if(typeof(nome[v]) == typeof(0)){
        //         nbm += nome[v];
        //     }
        // }

        
        // char lastCharacter = nome[nome.Length-1];
        // Debug.Log(lastCharacter);
        // meuId = arr[-1];
        // Debug.Log(gameObject.name);
    }

    void Update() {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Collider2D col = Physics2D.OverlapPoint(MousePos);
        if(col == thisCollider){
            transform.localScale = new Vector2(1.2f,1.2f);
        }else{
            transform.localScale = new Vector2(1,1);
        }

        foreach(var area in areaMinha){
            Collider2D GOCO = area.GetComponent<Collider2D>();
            BatalhaTile scBT = area.GetComponent<BatalhaTile>();
            if(col == GOCO && isCartaHold && !scBT.isBusy){
                Destroy(gameObject);
                scBT.isBusy = true;
            }
        }

        if(Input.GetMouseButton(0) && col == thisCollider){
            transform.position = new Vector2(MousePos.x,MousePos.y);
            isCartaHold = true;
        }else{
            transform.position = lugarInicial;
            isCartaHold = false;
        }
    }
}
