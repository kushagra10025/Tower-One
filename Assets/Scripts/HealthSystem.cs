using System;

public class HealthSystem{

    private int health;
    private int healthMax;

    //OnHealthChanged event can be further broken down into two parts
    // 1. OnHealthIncrease
    // 2. OnHealthDecrease
    public event EventHandler OnHealthChanged;
    public event EventHandler OnDeath;
    
    public HealthSystem(int healthMax = 100){
        this.healthMax= healthMax;
        health = healthMax;
    }
    
    public int GetHealth() => health;
    public float GetHealthPercent() => (float) health / healthMax;

    public void ReduceHealth(int damageAmount){
        health -= damageAmount;
        if (health <= 0){
            health = 0;
            OnDeath?.Invoke(this,EventArgs.Empty);
        }
        OnHealthChanged?.Invoke(this,EventArgs.Empty);
    }

    public void IncreaseHealth(int healAmount){
        health += healAmount;
        if (health > healthMax) health = healthMax;
        OnHealthChanged?.Invoke(this,EventArgs.Empty);
    }
}
