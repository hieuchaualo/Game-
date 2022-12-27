using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class StartPoint : MonoBehaviour
{
   // Player player;
   // public GameObject camera;
//    public Image img;
//    public Sprite level1 ;

    public string pointName;

    void Start() {
        // img.sprite = level1 ;
       var player = GameManager.Instance.player;
        Debug.Log(player.transform.position.x + "," + player.transform.position.y + "," + player.transform.position.z);
        // if (player.startPoint == pointName) {
        player.transform.position = transform.position;
        Debug.Log("2-- " + player.transform.position.x + "," + player.transform.position.y + "," + player.transform.position.z);

            // camera = FindObjectOfType<Camera>();
       //camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        // }
    }
}