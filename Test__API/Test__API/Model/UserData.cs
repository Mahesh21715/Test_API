using System;
using System.Collections.Generic;
using System.Text;

namespace Test_API
{
    public class UserData
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        public static implicit operator UserData(List<UserData> v)
        {
            throw new NotImplementedException();
        }
    }
}
