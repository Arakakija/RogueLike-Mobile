using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public Animator animator => _animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimationByTrigger(string animationTrigger)
    {
        _animator.SetTrigger("Death");
    }


    public bool IsAnimationPlaying(string animationName)
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName(animationName);
    }
    
    
}
