using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class AnimalWithDeath : Animal
{
    [SerializeField] private float lifeMaxBeforeDeath;
    [SerializeField] private float lifeMinBeforeDeath;
    private bool death = false;
    private float lifeToDeath;
    [SerializeField] private ParticleSystem deathParticles;

    // POLYMORPHISM
    void Start()
    {
        animalAnim = GetComponent<Animator>();
        life = lifeMax;
        StartCoroutine(RandomMovement());// ABSTRACTION
        lifeToDeath = Random.Range(lifeMinBeforeDeath, lifeMaxBeforeDeath);
        StartCoroutine(CountdownDeath());
    }

    private void LateUpdate()
    {
        if (death)
        {
            //Instantiate the death particle systems
            Instantiate(deathParticles, transform.position, deathParticles.transform.rotation);
            Destroy(gameObject);//WHen finished, destroy the object (Simulation of death)
        }   
    }

    private IEnumerator CountdownDeath()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            lifeToDeath -= 1;

            if (lifeToDeath <= 0)
                death = true;
        }
    }
}
