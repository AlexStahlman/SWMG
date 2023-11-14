using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpellCaster : MonoBehaviour
{
    [SerializeField] private float MaxMP;
    [SerializeField] private float curMP;
    [SerializeField] private float rechargeMP;
    [SerializeField] private Transform castPoint;
    [SerializeField] public Spell curSpell;
    [Header("Cast Delay")]
    [SerializeField] public bool casting;
    [SerializeField] private float baseCastDelay;
    private float castDelay;
    [SerializeField] private float castDelayTimer;

    // Start is called before the first frame update
    private InputPasser input;
    void Start()
    {
        castDelay = baseCastDelay;
        input = GetComponent<InputPasser>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(castPoint.position, castPoint.forward * 10, Color.blue);
        if (casting)
        {
            castDelayTimer = castDelay;
            CastSpell();
            castDelayTimer -= Time.deltaTime;
            if (castDelayTimer <= 0)
            {
                casting = false;
                castDelayTimer = 0;
            }
        }
    }
    void CastSpell()
    {
        if (casting && curSpell.canCast == true)
        {
            curSpell.canCast = false;
            Instantiate(curSpell, castPoint.position, castPoint.rotation);
        }
    }
}
