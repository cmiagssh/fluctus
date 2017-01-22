using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPickInfoScript : MonoBehaviour {

    public int p1Pick;
    public int p2Pick;

    void Awake ()
    {
        DontDestroyOnLoad(gameObject);
    }
}
