using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelTimes {

	public static float[,,] medalTimes =
	{
		//world 1
		{
			//Level 1_1
			{13.80f,16.10f,19.00f,7},
			//Level 1_2
			{9.50f,11.30f,15.60f,8},
			//Level 1_3
			{13.00f,16.20f,20.60f,8},
			//Level 1_4
			{9.00f,13.50f,19.60f,10},
		},
		//world 2
		{
			//Level 2_1
			{27.60f,32.50f,40.80f,13},
			//Level 2_2
			{14.00f,19.00f,24.00f,16},
			//Level 2_3
			{14.20f,19.20f,24.00f,14},
			//Level 2_4
			{13.00f,18.20f,24.00f,17},
		}
	};

	public static Vector4 getLevelTimes (string currentLevel){

		string w = currentLevel [5].ToString();
		string l = currentLevel [7].ToString();

		int worldNumber = int.Parse(w);
		int levelNumber = int.Parse(l);
		worldNumber--;
		levelNumber--;

		Vector4 result = new Vector4 (medalTimes [worldNumber, levelNumber, 0], 
			               medalTimes [worldNumber, levelNumber, 1],
			               medalTimes [worldNumber, levelNumber, 2],
			               medalTimes [worldNumber, levelNumber, 3]);


		return result;
	}
}
