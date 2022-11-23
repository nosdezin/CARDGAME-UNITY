using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batalha : MonoBehaviour
{
    public int altura,largura;
    public GameObject batalhaTile;
    // public GameObject[] _tiles;
    // public List<GameObject> areaMinha = new List<GameObject>();

    void Start()
    {
        for(int x = 0;x < largura;x++){
            for(int y = 0;y < altura;y++){
                var spawnTitle = Instantiate(batalhaTile,new Vector2(x * 1.7f,y * 1.7f),Quaternion.identity,transform);
                spawnTitle.name = $"Tile {x} {y}";
            }
        }

        // _tiles = GameObject.FindGameObjectsWithTag("BatalhaTile");
        
        // for(int pxc = 0;pxc <= 15;pxc += 3){
        //     areaMinha.Add(_tiles[pxc]);
        // }

        transform.position = new Vector2(-4.2f,transform.position.y);
    }

    // private void Update() {
        
    // }
}
