using System.Collections.Generic;
using UnityEngine;

public class ArenaShooter : MonoBehaviour
{
    // Range attribute makes it a slider in the inspector so I can't type in a weird number
    [Range(10, 100)]
    public int shotDamage = 34;

    // SerializeField attribute so this shows in the inspector but stays private
    [SerializeField]
    [Range(1, 5)]
    int targetCount = 3;

    // List<> is generic, this one only takes MovingTarget
    List<MovingTarget> targets = new List<MovingTarget>();

    void Start()
    {
        MovingTarget.score = 0;

        for (int i = 0; i < targetCount; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "Target " + (i + 1);
            cube.transform.position = new Vector3(0, i * 2 - 1, 0);

            MovingTarget target = cube.AddComponent<MovingTarget>();
            target.moveSpeed = 1.5f + i;
            targets.Add(target);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // out parameter: Raycast only returns true or false, so it uses out
            // to fill in hit with the cube I clicked on
            if (Physics.Raycast(ray, out hit))
            {
                MovingTarget target = hit.collider.GetComponent<MovingTarget>();
                if (target != null)
                {
                    target.TakeDamage(shotDamage);
                }
            }
        }
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 24;
        GUI.Label(new Rect(20, 20, 400, 40), "Score: " + MovingTarget.score);
        GUI.Label(new Rect(20, 55, 600, 40), "Click a cube to shoot it");
    }
}
