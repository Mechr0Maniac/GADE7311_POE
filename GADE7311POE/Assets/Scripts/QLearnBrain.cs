using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

public class QLearnBrain
{
    private int rand;
    private double vals, initialss;
    private double[][] learnGrid;
    FileStream writer;
    private QLearn learner;
    string file = Application.dataPath + "/TrainingLogs.txt";
    public double Vals
    { 
        get { return vals; } 
    }
    public double[][] LearnGrid
    {
        get { return learnGrid; }
    }

    public QLearnBrain(double val)
    {
        if (File.Exists(file))
            File.Delete(file);
        writer = File.Create(file);
        byte[] title = new UTF8Encoding(true).GetBytes("Creation of Logs");
        writer.Write(title, 0, title.Length);
        learner = new QLearn();
        vals = val;
        initialss = val;
        learnGrid = new double[learner.numOfStates][];
        for (int i = 0; i < learner.numOfStates; i++)
            learnGrid[i] = new double[learner.numOfActions];
    }
    public QLearnerS Go(int initial)
    {
        QLearnerS info = new QLearnerS();
        info.Initial = initial;
        int states = initial;
        List<int> actionsTaken = new List<int>();
        while (true)
        {
            info.StepsTaken += 1;
            int actions = learnGrid[states].ToList().IndexOf(learnGrid[states].Max());
            states = actions;
            actionsTaken.Add(actions);
            if (learner.Goals(actions))
            {
                info.End = actions;
                break;
            }
        }
        info.ActionsDone = actionsTaken.ToArray();
        return info;
    }
    public void TrainAi(int numOfGenerations)
    {
        for (int i = 0; i < numOfGenerations; i++)
        {
            int initialS = SetInitial(learner.numOfStates);
            InitialiseSequence(initialS);
        }
        string temp = "";
        byte[] title = new UTF8Encoding(true).GetBytes("Training Complete");
        writer.Write(title, 0, title.Length);
        var stats = Go(0);
        temp = stats.ToString();
    }
    private void InitialiseSequence(int current)
    {
        while (true)
        {
            current = Actions(current);
            if (learner.Goals(current))
                break;
        }
    }
    private int Actions(int current)
    {
        int[] legalActions = learner.GetLegalActions(current);
        int randomAction = Random.Range(0, legalActions.Length);
        int actions = legalActions[randomAction];
        double rewardA = learner.GetRewardValues(current, actions);
        double rewardB = learnGrid[actions].Max();
        double thisState = rewardA + (vals * rewardB);
        learnGrid[current][actions] = thisState;
        int newStates = actions;
        byte[] title = new UTF8Encoding(true).GetBytes("Iteration: " + current.ToString() + " Current State: " + thisState.ToString());
        writer.Write(title, 0, title.Length);
        return newStates;
    }
    private int SetInitial(int numStates)
    {
        return Random.Range(0, numStates);
    }
}

public class QLearnerS
{
    public int Initial { get; set; }
    public int End { get; set; }
    public int StepsTaken { get; set; }
    public int[] ActionsDone { get; set; }
}
