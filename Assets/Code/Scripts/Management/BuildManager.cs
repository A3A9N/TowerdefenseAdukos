using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower[] towers; 
    private int selectedBuild = 0;

    private void Awake()
    {
        main = this;
    }

    public Tower GetSelectedBuild()
    {

        return towers[selectedBuild];
    }

    public void SetSelectedBuild(int selectedBuildIndex)
    {
        selectedBuild = selectedBuildIndex;
    }
}
