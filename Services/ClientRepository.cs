using wt_lab2_2oop_kleshchenok.Models;

namespace wt_lab2_2oop_kleshchenok.Services;

public class ClientRepository
{
    private readonly Dictionary<int, Client> _byId = new();

    public void Add(Client client) => _byId[client.Id] = client;

    /// <summary>
    /// 
    /// </summary>
    public bool TryFind(int id, out Client? client)
    {
        return _byId.TryGetValue(id, out client);
    }

    public IEnumerable<Client> All => _byId.Values;
}