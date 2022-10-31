namespace OrderNames;

public class Tort
{
    public List<string> cake_features;

    public Tort(List<string> _cake_features)
    {
        cake_features = _cake_features;
    }
    

    public void SaveOrderToFile(string filename, string order)
    {
        File.WriteAllTextAsync(filename, order);
    }
}//

