using Example.Types;

namespace Example;

public static class UserDataLoader {
    [DataLoader]
    public static async Task<Dictionary<long, User>> GetUsersAsync(IReadOnlyList<long> ids, CancellationToken cancellationToken)
    {
        var users = UserRepository.GetUsers().Where(u => ids.Contains(u.Id)).ToDictionary(u => u.Id);

        return await Task.FromResult(users);
    }
}
