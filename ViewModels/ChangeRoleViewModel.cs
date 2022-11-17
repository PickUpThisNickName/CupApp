using CupApplication.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;


namespace CupApplication.Data.ViewModels
{
    public class ChangeRoleModel
    {
        public User? User { get; set; }
        public List<IdentityRole>? AllRoles { get; set; }
        public IList<string>? UserRoles { get; set; }
        public ChangeRoleModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
    public class ChangeRoleViewModel: IEnumerable
    {
        public List<ChangeRoleModel> ListUsers = new List<ChangeRoleModel>();
        public ChangeRoleModel this[int index]
        {
            get
            {
                return ListUsers[index];
            }
            set
            {
                ListUsers[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(ChangeRoleModel value)
        {
            this.ListUsers.Add(value);
        }

    }
}
