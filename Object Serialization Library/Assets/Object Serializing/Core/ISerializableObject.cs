public interface ISerializableObject
{
    object SaveData();
    void LoadData(object state);
}