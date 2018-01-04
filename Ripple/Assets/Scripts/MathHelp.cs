using UnityEngine;
using System.Collections;

public static class MathHelp
{

    public static float Map(float t, float minInput, float maxInput, float minOutput, float maxOutput)
    {
        return (t - minInput) * (maxOutput - minInput) / (maxInput - minInput) + minOutput;
    }
}
