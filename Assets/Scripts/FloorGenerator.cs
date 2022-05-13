using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    Floor previousFloor;
    Floor currentFloor;
    float floorSize = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Floor[] floors = FindObjectsOfType<Floor>();
        currentFloor = floors[0];
        foreach (Floor f in floors){
            if (Distance(f.gameObject, gameObject) < Distance(currentFloor.gameObject, gameObject)) {
                currentFloor = f;
            }
            if (Distance(f.gameObject, gameObject) > 3*floorSize) {
                Destroy(f.gameObject);
            }
        }
        if (currentFloor != previousFloor) {
            createFloorsAround(currentFloor);
            previousFloor = currentFloor;
        }
    }

    public float Distance(GameObject a, GameObject b) {
        return (a.transform.position - b.transform.position).magnitude;
    }

    public void createFloorsAround(Floor floor)
    {
        float distance = floorSize;
        //1
        Vector3 position = new Vector3(-distance, distance, 0) + floor.transform.position;
        Instantiate<Floor>(floor, position, Quaternion.identity);
        //2
        position = new Vector3(0, distance, 0) + floor.transform.position;
        Instantiate<Floor>(floor, position, Quaternion.identity);
        //3
        position = new Vector3(distance, distance, 0) + floor.transform.position;
        Instantiate<Floor>(floor, position, Quaternion.identity);
        //4 
        position = new Vector3(-distance, 0, 0) + floor.transform.position;
        Instantiate<Floor>(floor, position, Quaternion.identity);
        //6
        position = new Vector3(distance, 0, 0) + floor.transform.position;
        Instantiate<Floor>(floor, position, Quaternion.identity);
        //7
        position = new Vector3(-distance, -distance, 0) + floor.transform.position;
        Instantiate<Floor>(floor, position, Quaternion.identity);
        //8
        position = new Vector3(0, -distance, 0) + floor.transform.position;
        Instantiate<Floor>(floor, position, Quaternion.identity);
        //9
        position = new Vector3(distance, -distance, 0) + floor.transform.position;
        Instantiate<Floor>(floor, position, Quaternion.identity);
    }
}
