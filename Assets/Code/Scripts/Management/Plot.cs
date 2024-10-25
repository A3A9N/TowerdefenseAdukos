using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject build;
    private Color startColor;

    private void Start()
    {
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        if (sr != null)
            sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        if (sr != null)
            sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (build != null)
        {
            Debug.Log("Er is al een build deze plot.");
            return;
        }

        Tower towerToBuild = BuildManager.main.GetSelectedBuild();

        if (towerToBuild.cost > LevelManager.main.currency)
        {
            Debug.Log("You Cant afford this");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        build = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
    }
}
