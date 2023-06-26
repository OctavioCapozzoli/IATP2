using _Main.Scripts.Entities.Enemies;
using _Main.Scripts.FSM_SO_VERSION;
using _Main.Scripts.Roulette_Wheel.EntitiesRouletteWheel;
using _Main.Scripts.Steering_Behaviours;
using _Main.Scripts.Steering_Behaviours.Steering_Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossEnemyController : MonoBehaviour
{
    [SerializeField] StateData initState;
    [SerializeField] float sbPursuitTime;

    BossEnemyModel _model;
    private BossRouletteWheel _bossEnemyRoulette;
    FsmScript _bossFSM;
    Seek sbSeek;

    public BossRouletteWheel BossEnemyRoulette { get => _bossEnemyRoulette; set => _bossEnemyRoulette = value; }
    public Seek SbSeek { get => sbSeek; set => sbSeek = value; }

    private void Awake()
    {
        _model = (BossEnemyModel)GetComponent<BossEnemyModel>().GetModel();
    }
    // Start is called before the first frame update
    void Start()
    {
        _bossFSM = new FsmScript(_model, initState);
        _bossEnemyRoulette = new BossRouletteWheel(_model, this);
        sbSeek = new Seek(_model.transform, _model.GetTarget().transform);
    }

    // Update is called once per frame
    void Update()
    {
        _bossFSM.UpdateState();
    }
}
