using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;


//This class contains global events, as well as global pre-defined, or runtime-defined shared variables usable across the whole game.
public class Global
{
    #region GLOBAL_VARIABLES
    public Global() { }
    public static Global instance = new Global();
    public static float bounds = 60;   //maximum coords of the map
    public static string pilotName;     //name of our pilot

    public static int mapIndex; //which map are we on currently? (as INT index)
    public static bool isPvPAllowed = false;
    #endregion

    #region EVENTS
    public static ControllerBase localPlayer = null; //the player we play as
    public static event System.Action<bool> playerWasDestroyed; //param1: "is this a local player?"

    public static event System.Action<int> onMapBeginChange; //param1: "What is the index of map being loaded?"

    public static event System.Action<int> onItemWasBought; //param1: "What item was purchased?"

    public static event System.Action<string, Color, Material> onPlayerChangedDesígn; //param1: "What is the name of the ship?", param2: "Which color did we apply?", param3: "Which material was used?"

    public static event System.Action<ControllerBase> playerHasSpawned; //param1: "Player instance which was spawned"

    public static event System.Action<float, float> onTargeterUpdate; //param1 & 2: X & Y values of targeter


    //THIS IS MASTERPIECE! Took me hours to figure out, but... Here we raise STATIC events by name!
    public static void RaiseEvent(string methodName, object[] args)
    {
        foreach (var einfo in typeof(Global).GetEvents())
        {
            if (einfo.Name.Equals(methodName))
            {
                var eventDelegate = (System.MulticastDelegate)typeof(Global).GetField(methodName, BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);

                eventDelegate.DynamicInvoke(args);
            }
        }
    }



    #endregion
}
