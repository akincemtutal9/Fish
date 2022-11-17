using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTest : MonoBehaviour
{
    public delegate float MathFunctions(float x, float y);

    public MathFunctions mathFunctions;
    void Start()
    {
        AddMethod(AddTwoNumbers);
        AddMethod(SubtractTwoNumbers);
        AddMethod(MultiplyTwoNumbers);

        //mathFunctions(2.5f, 10f);

        var functions = mathFunctions.GetInvocationList();

        for (int i = 0; i < functions.Length; i++)
        {
            float result = ((MathFunctions)functions[i]).Invoke(2.5f, 10f);
            Debug.Log(result);
        }

    }
    

    public float AddTwoNumbers(float x, float y)
    {
        return x + y;
    }

    public float SubtractTwoNumbers(float x, float y)
    {
        return x - y;
    }

    public float MultiplyTwoNumbers(float x, float y)
    {
        return x * y;
    }
    
    
    public void AddMethod(MathFunctions function)
    {
        mathFunctions += function;
    }

    public void RemoveMethod(MathFunctions function)
    {
        mathFunctions -= function;
    }
}
