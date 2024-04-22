using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private ChestAnimation chestAnimation;
    private Player player;

    public
    void Start()
    {

        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D touchedObject)
    {

        if (touchedObject.gameObject.tag == player.tag)
        {
            chestAnimation.openChest();
        }
    }

    private void OnCollisionExit2D(Collision2D touchedObject)
    {
        if (touchedObject.gameObject.tag == player.tag)
        {
            chestAnimation.closeChest();
        }
    }
}
