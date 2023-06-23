using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.FSM_SO_VERSION;
using _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel;
using _Main.Scripts.Steering_Behaviours;
using _Main.Scripts.Steering_Behaviours.Steering_Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : MonoBehaviour
{
    [SerializeField] StateData initState;
    [SerializeField] float sbPursuitTime;

    BossEnemyModel _model;
    private BossRouletteWheel _bossEnemyRoulette;
    FsmScript _bossFSM;
    Flee _sbFlee;

    public BossRouletteWheel BossEnemyRoulette { get => _bossEnemyRoulette; set => _bossEnemyRoulette = value; }
    public Flee SbFlee { get => _sbFlee; set => _sbFlee = value; }

    private void Awake()
    {
        _model = (BossEnemyModel)GetComponent<BossEnemyModel>().GetModel();
    }
    // Start is called before the first frame update
    void Start()
    {
        _sbFlee = new Flee(transform, _model.GetTarget().transform);
        _bossFSM = new FsmScript(_model, initState);
        _bossEnemyRoulette = new BossRouletteWheel(_model, this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
