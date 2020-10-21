using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController
{
    public static bool IsPaused { get { return Time.timeScale == 0; } }
}
