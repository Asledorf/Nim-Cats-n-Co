using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Nim : MonoBehaviour
{
	#region Singleton Logic
	private Nim() { }
	public static Nim Instance { get { return Nested.instance; } }
	private class Nested
	{
		private static bool firstInit = true; //check to see if the class has been initialized already
		// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
		static Nested() { if (firstInit) { firstInit = false; /*Start Method Here*/} } 
		internal static readonly Nim instance = new Nim();
	}
	#endregion Singleton Logic

	//board state members
	public GameObject NimObject;

	//small and large board sizes
	public List<List<GameObject>> smallNim; 
	public List<List<GameObject>> bigNim;

	//logic members
	public StringData WinMessage;
	public bool isSmallNim;
	public bool isPlayerOneTurn;
	public bool isVsComputer;

	//populates the nim boards
	public void Start() { populateNims(); }

	//game turns are taken and alternates between players
	public void Turn()
	{
		isPlayerOneTurn = !isPlayerOneTurn;
		isWin();
		//if the player is facing an AI
		if (isVsComputer && !isPlayerOneTurn)
		{
			(int, int) ints = AI.ChoosePiece();
		}
		// else the player is facing another player.
		else
		{
		
		}
		int row = ints.Item1;
	}

	public void isWin()
	{
		bool win =
		isSmallNim 
		?
		//check if the SMALL nim board is empty
		: 
		//check if the BIG nim board is empty

		;
		//check board state for win

		WinMessage = "";

		if (/*board state is won*/)
		{
			//check win state
			if (isVsComputer)
			{
				WinMessage = "The AI won!";
			}
			if (isPlayerOneTurn)
			{
				WinMessage = "Player one won!";
			}
			else
			{
				WinMessage = "Player two won!";
			}
			throw new System.Exception("ILLEGAL TURN / BOARD STATE");
		}
	}
    #region Nim Board Populations
    public void populateNims ()
	{
		populateSmallNim();
		populateBigNim();
	}

	//populates the small nim board
	public void populateSmallNim()
	{
		smallNim = new List<List<GameObject>>
		{
			new List<GameObject> { Instance.NimObject }
		,	new List<GameObject> { Instance.NimObject, Instance.NimObject, Instance.NimObject }
		,	new List<GameObject> { Instance.NimObject, Instance.NimObject, Instance.NimObject, Instance.NimObject, Instance.NimObject }
		};
	}

	//populates the large nim board
	public void populateBigNim()
	{
		bigNim = new List<List<GameObject>>
		{
			new List<GameObject> { Instance.NimObject }
		,   new List<GameObject> { Instance.NimObject, Instance.NimObject, Instance.NimObject }
		,   new List<GameObject> { Instance.NimObject, Instance.NimObject, Instance.NimObject, Instance.NimObject, Instance.NimObject }
		,   new List<GameObject> { Instance.NimObject, Instance.NimObject, Instance.NimObject, Instance.NimObject, Instance.NimObject, Instance.NimObject, Instance.NimObject }
		};
	}
    #endregion Nim Board Populations
}
