using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tpScript : MonoBehaviour
{
    public GameObject player;
    public LayerMask playerlayer;
    public static List<Scene> worlds;
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer != playerlayer)
        {
            return;
        }
        else
        {
            int index = Random.Range(2, worlds.Count);
            SceneManager.LoadScene(index);
        }
    }
}
