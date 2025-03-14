using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors;
    public GameObject mmRoomPrefab;
    private Dungeon theDungeon;
    private List<Room> beenHere;
    private string prevDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Core.thePlayer = new Player("Mike");
        this.theDungeon = new Dungeon();
        this.beenHere = new List<Room>(); 
        this.setupRoom();
        beenHere.Add(Core.thePlayer.getCurrentRoom());
        //GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
    }

    //disable all doors
    private void resetRoom()
    {
        this.theDoors[0].SetActive(false);
        this.theDoors[1].SetActive(false);
        this.theDoors[2].SetActive(false);
        this.theDoors[3].SetActive(false);
    }
    private bool isARepeatRoom()
    {
        for (int i = beenHere.Count; i <= 0; i++)
        {
            if (Core.thePlayer.getCurrentRoom() == beenHere[i])
            {
                return true;
            }
        }
        return false; 
    }

    //show the doors appropriate to the current room
    private void setupRoom()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        this.theDoors[0].SetActive(currentRoom.hasExit("north"));
        this.theDoors[1].SetActive(currentRoom.hasExit("south"));
        this.theDoors[2].SetActive(currentRoom.hasExit("east"));
        this.theDoors[3].SetActive(currentRoom.hasExit("west"));
    }

    private void createMMRoom()
    {
        GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
        Vector3 currPos = newMMRoom.transform.position;
        Vector3 newPos;
        if (String.Equals(prevDirection, "east"))
        {
            newPos.x = currPos.x + 1.5f;
        }
        else if (String.Equals(prevDirection, "west"))
        {
            newPos.x = currPos.x - 1.5f;
        }
        else
        {
            newPos.x = currPos.x;
        }
        newPos.x = currPos.x;
        newPos.y = currPos.y;
        if(String.Equals(prevDirection, "north"))
        {
            newPos.z = currPos.z + 1.5f;
        }
        else if(String.Equals(prevDirection, "south"))
        {
            newPos.z = currPos.z - 1.5f;
        }
        else
        {
            newPos.z = currPos.z;
        }
        newMMRoom.transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        bool roomChange = false;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //try to goto the north
            roomChange = Core.thePlayer.getCurrentRoom().tryToTakeExit("north");
            prevDirection = "north";
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //try to goto the west
            roomChange = Core.thePlayer.getCurrentRoom().tryToTakeExit("west");
            prevDirection = "west";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //try to goto the east
            roomChange = Core.thePlayer.getCurrentRoom().tryToTakeExit("east");
            prevDirection = "east";
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //try to goto the south
            roomChange = Core.thePlayer.getCurrentRoom().tryToTakeExit("south");
            prevDirection = "south";
        }

        // did we change rooms?
        if(roomChange)
        {
            this.setupRoom();
            if (isARepeatRoom() == false)
            {
                createMMRoom();
                beenHere.Add(Core.thePlayer.getCurrentRoom());
            }
        }
    }
}
