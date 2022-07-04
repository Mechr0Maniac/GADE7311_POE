using System.Collections;
using System.Collections.Generic;

public class QLearn
{
    private double[][] reward = new double[16][]
    {//              { 0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15 }
 /* 0*/ new double[] { -1, 0, -1, -1, -1,  0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
 /* 1*/ new double[] { -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
 /* 2*/ new double[] { -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1,  0, -1, -1, -1, -1 },
 /* 3*/ new double[] { -1, -1, -1, -1, 0, -1,  0, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
 /* 4*/ new double[] { -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
 /* 5*/ new double[] {  0, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
 /* 6*/ new double[] { -1, -1, -1,  0, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1, -1, -1 },
 /* 7*/ new double[] { -1, -1, -1, -1, -1, -1, -1, -1, 0, -1,  0,  0, -1, -1, -1, -1 },
 /* 8*/ new double[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1, -1 },
 /* 9*/ new double[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, -1, -1 },
 /*10*/ new double[] { -1, -1, -1, -1, -1, -1, -1,  0, -1, -1, -1, 0, -1, -1, -1, -1 },
 /*11*/ new double[] { -1, -1,  0, -1, -1, -1, -1,  0, -1, -1, -1, -1, 0, -1,  0, -1 },
 /*12*/ new double[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1 },
 /*13*/ new double[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1 },
 /*14*/ new double[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1, -1, -1, 100 },
 /*15*/ new double[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, -1 }
    };

    public int numOfStates = 16, numOfActions = 16;

    public double GetRewardValues(int state, int action)
    {
        return reward[state][action];
    }

    public int[] GetLegalActions(int state)
    {
        List<int> actions = new List<int>();
        for (int i = 0; i < reward[state].Length; i++)
        {
            if (reward[state][i] != -1)
                actions.Add(i);
        }
        return actions.ToArray();
    }
    public bool Goals(int current)
    {
        return current == 15;
    }
}
