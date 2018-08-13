using System;
using UnityEngine;

public class BodyRenderer
{
    private Func<GameObject> _create { get; }
    private float _time;

    public BodyRenderer(Func<GameObject> create)
    {
        _create = create;
    }

    public void Create(Body body)
    {
        body.GameObject = _create();
        body.GameObject.name = body.Name;
        body.GameObject.transform.localScale = new Vector3(body.Radius, body.Radius, body.Radius);
        body.GameObject.GetComponent<MeshRenderer>().material.color = body.Color;

        if (body.Radius < 1f  && body.Radius >= .1f) // only show planet orbits
        {
            var go = new GameObject { name = body.Name + " Orbit" };
            go.DrawCircle(body.OrbitRadius, .01f);
        }

        foreach (var item in body.Children)
        {
            Create(item);
        }
    }

    public void Update(Body info, Vector3 offset)
    {
        _time += Time.deltaTime;

        info.GameObject.transform.position = offset + OrbitRotate(info.OrbitRadius, _time * info.OrbitSpeed); // rotate around center orbit
        info.GameObject.transform.Rotate(new Vector3(0, Time.deltaTime * info.RotationSpeed * 10)); // rotate around axis

        foreach (var item in info.Children)
        {
            Update(item, info.GameObject.transform.position);
        }
    }

    private Vector3 OrbitRotate(float radius, float angle)
    {
        var x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
        var z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
        return new Vector3(x, 0, z);
    }
}
