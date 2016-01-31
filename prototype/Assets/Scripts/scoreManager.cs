using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour {

    public GameObject scoreBoard;
    public GameObject canvas;
    public Shape[] shapes;

    bool wait;
    public int Gameclicker = 128;

    // Use this for initialization
    void Start () {
    	if (Gameclicker % 60 > 9){
        	scoreBoard.GetComponent<Text>().text = (Gameclicker / 60) + ":" + (Gameclicker % 60);
        }
        else { 
			scoreBoard.GetComponent<Text>().text = (Gameclicker / 60) + ":0" + (Gameclicker % 60);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine(PlayEvery(1f));
    }

    IEnumerator PlayEvery(float seconds)
    {
        if (wait) yield break;
        wait = true;
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < shapes.Length; i++)
        {
            bodyDetector(shapes[i], i);
        }
        if (Gameclicker >0){
        	Gameclicker--;
        }
        else {
        	// EDIT THIS: When it reaches zero move to loser/lost level
        	Gameclicker = 0;
        }
		if (Gameclicker % 60 > 9){
        	scoreBoard.GetComponent<Text>().text = (Gameclicker / 60) + ":" + (Gameclicker % 60);
        }
        else { 
			scoreBoard.GetComponent<Text>().text = (Gameclicker / 60) + ":0" + (Gameclicker % 60);
        }
        wait = false;
    }

    void bodyDetector(Shape shape, int index)
    {
        if (!shape.hasExtra)
        {
            // Some way to find if touching shapes have same color
            for (int i = 0; i < shapes.Length; i++)
            {
                if (index != i)
                {
                    if (false)
                    {
                        shape.hasExtra = true;
                        Gameclicker += 2;
                    }
                }
            }
        }
    }
}
