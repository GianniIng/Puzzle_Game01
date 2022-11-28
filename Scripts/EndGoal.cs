using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Endlevel")
        {
            SceneManager.LoadScene("Level01");
        }
    }
}
