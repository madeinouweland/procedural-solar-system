using System.Collections.Generic;
using UnityEngine;

public class Body
{
    public float OrbitRadius { get; }
    public float Radius { get; }
    public Color Color { get; }
    public List<Body> Children { get; } = new List<Body>();
    public float OrbitSpeed { get; }
    public float RotationSpeed { get; }
    public GameObject GameObject { get; set; }
    public string Name { get; }

    public Body(string name, Color color, float orbitRadius, float radius, float orbitSpeed, float rotationSpeed)
    {
        Name = name;
        OrbitRadius = orbitRadius;
        Radius = radius;
        Color = color;
        OrbitSpeed = orbitSpeed;
        RotationSpeed = rotationSpeed;
    }
}
