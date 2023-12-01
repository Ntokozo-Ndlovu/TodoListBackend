using TodoList.Data.Entities;

namespace TodoList.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public List<UserEntity> userList = new List<UserEntity>();
        private TodoDbContext Context { get; set; }
        public UserRepository()
        {
            this.Context = new TodoDbContext();
        }
        public UserEntity createUser(UserEntity user)
        {
            var newUser = this.Context.User.Add(user);
            this.Context.SaveChanges();
            return newUser.Entity;
        }

        public UserEntity findUserByEmail(string userEmail)
        {
            var user = this.Context.User.FirstOrDefault(user => user.Email == userEmail);
            if(user == null)
            {
                throw new Exception("Not found");
            }
            return user;
        }

        public UserEntity findUserById(Guid userId)
        {
            var user = this.Context.User.FirstOrDefault(user => user.Id == userId);
            if (user == null)
                throw new Exception("Not Found");
            return user;
           }

        public UserEntity updateUser(UserEntity userUp)
        {
            Console.WriteLine($"User name: {userUp.Id} {userUp.Name} {userUp.Surname }{userUp.Email} {userUp.Username} ");
            var user = this.Context.User.Update(userUp);
            this.Context.SaveChanges();
            return userUp;
        }
    }
}
