using NUnit.Framework;

// Nombre de la clase: SistemaQuePruebo + Tests
[TestFixture]
public class ShieldSystemTests {

    [Test]
    // Estructura: Metodo_Escenario_ResultadoEsperado
    public void TakeDamage_WhenDamageExceedsShield_ShouldReduceHealthAndZeroShield() {
        // ARRANGE (Preparar)
        var system = new ShieldSystem(); // Salud: 100, Escudo: 50
        float damageAmount = 60f;

        // ACT (Actuar)
        system.TakeDamage(damageAmount);

        // ASSERT (Afirmar/Verificar)
        // El daño era 60. Absorbió 50 de escudo, restan 10 que van a salud.
        Assert.AreEqual(90f, system.Health, "La salud no se redujo correctamente tras agotar el escudo.");
        Assert.AreEqual(0f, system.Shield, "El escudo debería estar en 0 después de recibir daño excesivo.");
    }
}
