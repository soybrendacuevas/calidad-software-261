public class PlayerControllerFinal : MonoBehaviour{

    //Base de estados
    public interface IPlayerState{
        void Enter(Player, player);
        void Exit(Player player);

        void HandelMovement(Player player,Vector3 dir);
        void HandleHealing(Player player, float amount);

    }


    public class AliveState : IPlayerState{
        public void Enter(Player player){
            Debug.Log("Player entro en el estado vivo");
        }
        public void Exit(Player player){}
        public void HandelMovement(Player player,Vector3 dir){
            //Movement Enable
            player.transfrom.Translate(dir * playerSpeed *Time.deltaTime);
        }
        public voidHandleHealing(Player player,float amount){
            player.AplyyHealing(amount);
        }
    }

    public class DeadState : IPlayerState{
           public void Enter(Player player){
            Debug.Log("Player entro en el estado muerto");
        }
        public void Exit(Player player){}
        public void HandelMovement(Player player,Vector3 dir){
            Debug.LogWarning("Movimiento bloqueado player muerto")
        }
        public voidHandleHealing(Player player,float amount){
            Debug.LogWarning("Healing bloqueado palyer muerto")
        }
    }

    public class Player : MonoBehaviour {
        
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public float moveSpeed = 5f;

    private IPlayerState currentState;

    private void Start()
    {
        TransitionToState(new AliveState());
    }


    public void TransitionToState(IPlayerState newState)
    {
        if (currentState != null)
            currentState.Exit(this);

        currentState = newState;

        currentState.Enter(this);
    }

    public void Move(Vector3 direction)
    {
        currentState.HandleMovement(this, direction);
    }


    public void Heal(float amount)
    {
        currentState.HandleHealing(this, amount);
    }


    public void ApplyHealing(float amount)
    {
        if (amount < 0f)
        {
            Debug.LogWarning("ApplyHealing recibió valor negativo.");
            return;
        }

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }

    public void Die()
    {
        TransitionToState(new DeadState());
    }
}