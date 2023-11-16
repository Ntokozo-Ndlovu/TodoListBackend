using TodoList.Data.Entities;

namespace TodoList.Data.Repository
{
    public interface IUserRepository
    {
        public UserEntity createUser(UserEntity user);
        public UserEntity findUserById(Guid userId);
        public UserEntity findUserByEmail(string userEmail);
        public UserEntity updateUser(UserEntity user);


    }
}
