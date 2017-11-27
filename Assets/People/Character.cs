﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour {

    public CharacterBrain brain;

    [HideInInspector] public CharacterController charCon;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Transform trans;

    private int brainHash;

    void Awake(){
        charCon = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
        trans = transform;
    }

    // Use this for initialization
    void Start () {
        SetupBrain();
    }
	
	// Update is called once per frame
	void Update () {
        if(brain.GetHashCode() != brainHash)
            SetupBrain();

        if(brain)
            brain.Tick(this);
    }

    void SetupBrain(){
        if (brain != null)
            brain.Setup(this);
        brainHash = brain?brain.GetHashCode():0;
    }
}
