using TodoList.Data.Entities;

namespace TodoList.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public List<UserEntity> userList = new List<UserEntity>();

        public UserEntity createUser(UserEntity user)
        {
            this.userList.Add(user);
            return user;
        }

        public UserEntity findUserByEmail(string userEmail)
        {
            UserEntity user = this.userList.Find(user => user.email == userEmail);
            if(user == null)
                return null;
            return user;
        }

        public UserEntity findUserById(Guid userId)
        {
            UserEntity user = this.userList.Find(user=> user.Id == userId);
            if (user == null)
                return null;
            return user;
           }

        public UserEntity updateUser(UserEntity userUp)
        {
           var findIndex = this.userList.FindIndex(user => user.Id == userUp.Id);  
            if(findIndex > -1)
            {
                this.userList[findIndex] = userUp;
            }
            return userUp;
        }
    }
}
