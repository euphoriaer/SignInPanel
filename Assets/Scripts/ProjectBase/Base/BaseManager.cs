using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager<T> where T : new()
{
    private static T instate;
    public static T Getinstate()
    {
        if (instate == null)
        {
            instate = new T();
        }
        return instate;
    }
}
