using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    public GameObject carta;
    public GameObject localDaMao;
    public float pulos = 2f;
    float valorDoPulo = 0f;
    public List<GameObject> _cartas = new List<GameObject>();
    public Collider2D getCard;
    private Vector2 MousePos;

    private void Awake() {
        for(int quantidadeDeCarta = 0;quantidadeDeCarta < 6;quantidadeDeCarta++){
            var cartasTile = Instantiate(carta,new Vector3(localDaMao.transform.position.x + valorDoPulo,localDaMao.transform.position.y,0),Quaternion.identity,localDaMao.transform);
            cartasTile.name = $"carta {quantidadeDeCarta}";
            _cartas.Add(cartasTile);
            valorDoPulo += pulos;
        }

        getCard = GameObject.Find("PegarCarta").GetComponent<Collider2D>();
    }

    private void Update() {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Collider2D col = Physics2D.OverlapPoint(MousePos);

        if(col == getCard && Input.GetMouseButtonDown(0)){
            // CorrigirCartas();
            AdicionarCarta();
        }
    }

    private void AdicionarCarta(){
        int tamanho = _cartas.Count;
        var NovaCarta = Instantiate(carta,new Vector3(localDaMao.transform.position.x + pulos * tamanho,localDaMao.transform.position.y,0),Quaternion.identity,localDaMao.transform);
        NovaCarta.name = $"carta {tamanho}";
        _cartas.Add(NovaCarta);
    }

    // private void CorrigirCartas(){
    //     for(int index = 0;index <= _cartas.Count-1;index++){
    //         float posicao = index * pulos;
            
    //         if(_cartas[index] == null || _cartas[index].transform.position.x != posicao){
    //             _cartas[index+1].transform.position = new Vector2(posicao,transform.position.y);
    //         }
    //     }
    // }


}
