namespace ChatClientLibrary.Chat.Collection
{
    using System;
    using System.Collections.Generic;
    using ChatClientLibrary.Chat.ChatUser;

    public class UserCollection : IDisposable
    {
        private IList<User> _collection = default(IList<User>);

        private static UserCollection _instance = default(UserCollection);
        private UserCollection() 
        {
            this._collection = new List<User>();
        }

        public static UserCollection InstanceContext
        {
            get { return _instance ?? (_instance = (new UserCollection())); }
        }

        public void Add(User user)
        {
            if (!this._collection.Contains(user))
                this._collection.Add(user);
        }

        public void Remove(User user)
        {
            if (this._collection.Contains(user))
                this._collection.Remove(user);
        }

        public User Get(string userUniqueID)
        {
            User user = default(User);
            foreach (User item in this._collection)
            {
                if (item.UserUnqiueID.Equals(userUniqueID, StringComparison.InvariantCultureIgnoreCase))
                {
                    user = item;
                    break;
                }
            }
            return  user;
        }

        public void Dispose()
        {

        }
    }
}
