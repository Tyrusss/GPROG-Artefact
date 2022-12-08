using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceTracker
{

    private static int _gold;

    public static int Gold
    {
        get => _gold;
        
        set
        {
            _gold = value;
        }
    }

}
