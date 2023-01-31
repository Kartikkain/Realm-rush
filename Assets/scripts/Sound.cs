using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] GameObject ambience;

    static bool hasSpawned = false;

    private void Awake()
    {
        // checking if the object is already spawned or not.
        if (hasSpawned) return;
        spawnambience(ambience);
        hasSpawned = true;
    }

    // instantiating the object 
    void spawnambience(GameObject presistenceobj)
    {
        GameObject presistence = Instantiate(presistenceobj);
        DontDestroyOnLoad(presistence);
    }


}
