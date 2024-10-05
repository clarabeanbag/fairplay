using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumsController : MonoBehaviour
{
    enum Levels {Level1, Level2, Level3, Level4};

    enum BuildingTypes {Type1, Type2, type3, Type4};

    int PointsNeededPerLevel(Levels lvl){
        int pointsPerLevel = 0;
        if (lvl == Levels.Level1) pointsPerLevel = 50;
        else if (lvl == Levels.Level2) pointsPerLevel = 70;
        else if (lvl == Levels.Level3) pointsPerLevel = 90;
        else pointsPerLevel = 110;

        return pointsPerLevel;
    }
}
