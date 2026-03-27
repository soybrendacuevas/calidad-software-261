public class ShieldSystem {
    public float Health = 100;
    public float Shield = 50;

    public void TakeDamage(float damage) {
        // Lógica: Primero se agota el escudo, luego la salud.
        if (Shield > 0) {
            Shield -= damage; 
            // BUG 1: ¿Qué pasa si el daño es mayor al escudo? 
            // El remanente debería pasar a la salud, pero aquí se pierde.
        } else {
            Health -= damage;
        }

        // BUG 2: El escudo podría quedar en números negativos.
    }
}
