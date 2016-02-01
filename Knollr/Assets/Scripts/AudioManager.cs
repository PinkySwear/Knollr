using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {
    
    public AudioSource[] aSources;
    public Shape[] shapes;

    bool wait;
    int next = 0;
    int extra = 0;
    int Gameclicker = 109;
    int Realclicker = 0;
    bool ASC = true;
    //float start = System.DateTime.Now.Ticks;

    // Use this for initialization
    void Start () {
        aSources = gameObject.GetComponents<AudioSource>();
        for (int i = 0; i < aSources.Length; i++)
        {
            aSources[i].mute = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(next);
        StartCoroutine(PlayEvery(1));
    }

    IEnumerator PlayEvery(float seconds)
    {
        if (wait) yield break;
        wait = true;
        yield return new WaitForSeconds(seconds);
        Gameclicker -= 1;
        Realclicker += 1;
        wait = false;
        if (((Gameclicker % 4) == 0) && ASC)
        {
            aSources[next].mute = false;
            next++;
            if (next == 0)
            {
                aSources[7].mute = true;
            }
        }
        else if (((Gameclicker % 4) == 0))
        {
            aSources[next].mute = true;
            next++;
            if (next == 7)
            {
                aSources[Random.Range(1, 5)].mute = false;
            }

            if (next == 8)
            {
                aSources[7].mute = false;
            }
        }
        if (next == 8)
        {
            next = 0;
            ASC = !ASC;
        }
    }

}
