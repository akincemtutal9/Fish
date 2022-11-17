using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestingValueRefTypes : MonoBehaviour
{
    private MyClass first;
    private MyClass second;

    private MyStruct firstS;
    private MyStruct secondS;
    
    private int a = 7;
    private int b;
    
    private void Start()
    {
        b = a;
        b = 5;
        Debug.Log("int -> "+a);


        firstS = new MyStruct(7);
        secondS = firstS;
        secondS.value = 5;
        Debug.Log("struct -> " + firstS.value);
        
        
        first = new MyClass(7);
        second = first;
        second.value = 5;
        Debug.Log("class -> "+first.value);

        
        
    }

}

    
    



