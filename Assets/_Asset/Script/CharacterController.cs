using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Crouching crouchcomponents;
    [SerializeField] private Ditection diteccomponents;
    [SerializeField] private Iblast iblastcomponent;
    [SerializeField] private JugSkill skillcomponents;
    [SerializeField] private KickControl kickcomponents;
    [SerializeField] private NormalAttackControl natkcomponents;
    [SerializeField] private RollControl rollcomponents;
    [SerializeField] private Runcontrol runcomponents;
    [SerializeField] private Shoot shootcomponents;
    [SerializeField] private SpecialAttackControl satkcomponents;
    [SerializeField] private StrikeControll strikecomponents;
    [SerializeField] private HealthManager healthcomponent;
    [SerializeField] private MoveControl movecoponents;
    [SerializeField] private JumpControl jumpcoponents;
    [SerializeField] private GroundCheck groundcheckcom;

    [SerializeField] private List<MonoBehaviour> components;
    private bool isplay = false;

    // Start is called before the first frame update
    private void Awake()
    {
        GetReferen();
    }
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isplay)
        {
            return;
        }
        if(!healthcomponent.Alive)
        {
            StartCoroutine(StopGame());
        }
    }

    IEnumerator StopGame()
    {
        EndGame();

        yield return new WaitForSeconds(5);

        Time.timeScale = 0;
    }

    private void GetReferen()
    {
        components = new List<MonoBehaviour>();
        components.Add(crouchcomponents);
        components.Add(diteccomponents);
        components.Add(iblastcomponent);
        components.Add(skillcomponents);
        components.Add(kickcomponents);
        components.Add(natkcomponents);
        components.Add(rollcomponents);
        components.Add(runcomponents);
        components.Add(satkcomponents);
        components.Add(strikecomponents);
        components.Add(healthcomponent);
        components.Add(movecoponents);
        components.Add(jumpcoponents);
        components.Add(groundcheckcom);
    }

    //private void Init()
    //{
    //    GetReferen();
    //    DisableComponent();
    //}

    private void StartGame()
    {
        isplay = true;
        EnableComponents();
    }

    private void EndGame()
    {
        isplay = false;
        DisableComponent();
    }

    private void EnableComponents()
    {
        SetComponent(true);
    }

    private void DisableComponent()
    {
        SetComponent(false);
    }

    private void SetComponent(bool isactive)
    {
        foreach (var component in components)
        {
            if (component != null)
                component.enabled = isactive;
        }
    }
}
