public class InventorySystem
{
    // Usamos Tipado Fuerte <T> para asegurar que la lista 
    // SOLO contenga objetos de tipo 'Item', no scripts maliciosos.
    private System.Collections.Generic.List<Item> _secureItems = new();

    public void AddItem<T>(T newItem) where T : Item
    {
        // El constraint 'where T : Item' garantiza que el objeto
        // herede de Item y cumpla con la estructura de seguridad.
        _secureItems.Add(newItem);
    }
}
