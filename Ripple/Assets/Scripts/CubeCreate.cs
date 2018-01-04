using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreate : MonoBehaviour {

    List<Oscillator> oscillators = new List<Oscillator>();

    float _angle = 0;
    float _maxD;

    public int Rows = 24;
    public int Cols = 24;

    public float Speed = 5f;

    public GameObject CubePrefab;

    /// <summary>
    /// Create the cubes that will grow and shrink.
    /// </summary>
    void Awake()
    {
        _maxD = Rows;
        for (int z = 0; z < Rows; z++)
        {
            for (int x = 0; x < Cols; x++)
            {
                var copy = Instantiate(CubePrefab, transform);
                var oscillator = copy.GetComponent<Oscillator>();

                copy.transform.position = new Vector3(x - Cols / 2, 0, z - Rows / 2);
                oscillators.Add(oscillator);
            }
        }
    }

    void Update()
    {
        int index = 0;

        for (int z = 0; z < Rows; z++)
        {
            for (int x = 0; x < Cols; x++)
            {
                var oscillator = oscillators[index];
                oscillator.UpdateAngle(_angle, _maxD);
                index++;
            }
        }

        _angle += Speed * Time.deltaTime;
    }


}
