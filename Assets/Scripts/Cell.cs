using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool hasMine;
    public Sprite[] emptyTextures;
    public Sprite mineTexture;

    void Start()
    {
        this.hasMine = (Random.value < 0.15);
        // Obtener la columna;
        int x = (int)this.transform.position.x;
        //Obtenemos la fila que la tiene el padre;
        int y = (int)this.transform.parent.transform.position.y;

        GridHelper.cells[x, y] = this;
    }

    private void OnMouseUpAsButton()
    {
        if (this.hasMine)
        {
            GridHelper.UncoverAllTheMines();
        }
        else
        {
            int x = (int)this.transform.position.x;
            int y = (int)this.transform.parent.transform.position.y;
            this.loadTexture(GridHelper.CountAdjacentMines(x, y));
            GridHelper.FloodFillUncover(x, y, new bool[GridHelper.w, GridHelper.h]);
        }
    }

    public bool IsCovered()
    {
        return this.GetComponent<SpriteRenderer>().sprite.texture.name == "Panel";
    }

    public void loadTexture(int adjacentCount)
    {
        if (this.hasMine)
        {
            GetComponent<SpriteRenderer>().sprite = this.mineTexture;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = this.emptyTextures[adjacentCount];
        }
    }
}
