using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    static public (int i, int j) ChoosePiece(bool isEasy = true)
    {
        int x = 0, y = 0;

        if (isEasy)
        {
            System.Random rng = new System.Random((int)System.DateTime.Now.Ticks);
            if (Nim.Instance.isSmallNim)
            {
                //select random row
                int row = rng.Next(0,2);

                //storing the size for readibility
                int size = Nim.Instance.smallNim.Length - 1;

                //select random piece amount
                int amount =

            }
            else
            {
                //select random row

                //select random piece amount
            }
        }
        else
        {
            if (Nim.Instance.isSmallNim)
            {
                //select optimal row

                //select oandom piece amount
            }
            else
            {
                //select optimal row

                //select optimal piece amount
            }
        }

        return (x, y);
    }
}