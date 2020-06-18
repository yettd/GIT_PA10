using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameover : MonoBehaviour
{
    public Text text;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetFloat("s");
        text.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reset()
    {
        SceneManager.LoadScene(0);
    }
}
