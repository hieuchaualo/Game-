using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] GameObject player;
    // private static bool retainCamera ;
    // Start is called before the first frame update

    void Start()
    {
        // DontDestroyOnLoad(transform.gameObject);
        // if (!retainCamera)
        // {
        //     retainCamera = true;
        //     DontDestroyOnLoad(transform.gameObject);
        //     Debug.Log("Camera Loaded");
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
    }
    void LateUpdate()
    {
        transform.position = new Vector3(GameManager.Instance.player.transform.position.x - 1 , transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
