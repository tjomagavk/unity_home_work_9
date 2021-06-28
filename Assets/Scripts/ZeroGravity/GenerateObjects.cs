using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{
    [SerializeField] private PhysicMaterial[] materials;
    [SerializeField] private float boomPower;
    [SerializeField] private int boomRadius;
    private List<GameObject> _objects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        foreach (GameObject o in _objects)
        {
            Destroy(o);
        }

        _objects.Clear();

        for (int i = 0; i < 5; i++)
        {
            _objects.Add(CreateGameObject(PrimitiveType.Cube));
            _objects.Add(CreateGameObject(PrimitiveType.Capsule));
            _objects.Add(CreateGameObject(PrimitiveType.Cylinder));
            _objects.Add(CreateGameObject(PrimitiveType.Sphere));
        }
    }

    public void Boom()
    {
        foreach (GameObject o in _objects)
        {
            var distance = Vector3.Distance(gameObject.transform.position, o.transform.position);
            if (distance < boomRadius)
            {
                var currentPower = (boomRadius - distance) * boomPower;
                o.GetComponent<Rigidbody>().AddForce(Vector3.up * currentPower, ForceMode.Impulse);
                // Destroy(o);
            }
        }
    }

    private GameObject CreateGameObject(PrimitiveType type)
    {
        GameObject newObject = GameObject.CreatePrimitive(type);
        newObject.transform.localScale = new Vector3(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10));
        newObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        Vector3 position = new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5));
        newObject.transform.position = position;
        newObject.AddComponent<Rigidbody>().useGravity = true;
        newObject.GetComponent<Rigidbody>().mass = Random.Range(.5f, 5f);
        newObject.GetComponent<Collider>().material = materials[Random.Range(0, materials.Length)];
        return newObject;
    }
}