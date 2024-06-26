﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using music_store.Models;

namespace music_store.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = { };
            using (var db = new music_storeEntities4())
            {
                // Получаем пользователя
                var user = db.sellers.FirstOrDefault(u => u.log_in == username);
                if (user != null && user.role != null)
                    // получаем роль
                    roles = new[] { user.role };
                return roles;
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (var db = new music_storeEntities4())
            {
                // Получаем пользователя
                var user = db.sellers.Include(u => u.role).FirstOrDefault(u => u.log_in == username);

                if (user != null && user.role != null && user.role == roleName)
                    return true;
                return false;
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}