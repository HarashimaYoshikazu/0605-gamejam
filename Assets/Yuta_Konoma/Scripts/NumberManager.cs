using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberManager
{
    private static NumberManager number = new NumberManager();

    public static NumberManager Instance => number;

    public int currentCard;

    public int nextCard;
}
