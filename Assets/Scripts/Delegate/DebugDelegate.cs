using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public class DebugDelegate : MonoBehaviour
{
    // fonksiyonlar silsilesini bi tanimla
    public delegate void DelegateDebug();
    
    // Burda da objeyi oluştur. üstte tanimladigin fonksiyonun
    public DelegateDebug delegateDebug;
    
    
    
    void Start()
    {
         // fonksiyonları birbirine ekleyebiliyoruz.
       AddMethod(Debug1);
       AddMethod(Debug2);
        
        // null değilse çalışsın
        delegateDebug?.Invoke();
    }

    private void Debug1()
    {
        Debug.Log("debug 1");
    }

    private void Debug2()
    {
        Debug.Log("debug 2");    
    }

    public void AddMethod(DelegateDebug method)
    {
        delegateDebug += method;
    }

    public void RemoveMethod(DelegateDebug method)
    {
        delegateDebug -= method;
    }
}
