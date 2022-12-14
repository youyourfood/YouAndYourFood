using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using YouAndYourFood.Models;
using YouAndYourFood.Repository;
using YouAndYourFood.Services;

namespace YouAndYourFood.Services
{
    public class RestaurentService : IRestaurentService
    {

        private readonly IRestaurentRepository restaurentRepository;

        public RestaurentService(IRestaurentRepository restaurentRepository)
        {
            this.restaurentRepository = restaurentRepository;
        }

        public async Task<UsersPreferencesCollection> GetUsersPreferences()
        {
            return await restaurentRepository.GetUsersPreferences();
        }

        public async Task<UsersPreferencesCollection> AddPreference(Preference preference, string username)
        {
            UsersPreferencesCollection usersPreferencesCollection = await GetUsersPreferences();
            if (usersPreferencesCollection != null && usersPreferencesCollection.UsersPreferences != null 
                && usersPreferencesCollection.UsersPreferences.Any(user => user.Username == username))
            {
                UserPreferences userPreferences = usersPreferencesCollection.GetUserPreferences(username);
                if(userPreferences == null)
                {
                    UserPreferences newUserPrefernces = new UserPreferences(username, new List<Preference>() { preference });
                }
                else
                {
                    userPreferences.AddOrUpdatePreference(preference);
                }
            }
            else
            {

                UserPreferences userPreferences = new UserPreferences(username, new List<Preference>() { preference });

                usersPreferencesCollection.AddNewUserPreference(userPreferences);
            }

            return await restaurentRepository.SaveUserPreferences(usersPreferencesCollection);
        }

        public async Task<RestaurantsData> GetRestaurent()
        {
            return await restaurentRepository.GetRestaurent();
        }

        async Task<RestaurantsData> IRestaurentService.GetRestaurents()
        {
            return await restaurentRepository.GetRestaurents();
        }

        public async Task<UserPreferences> GetUserPreferences(string username)
        {
            return await restaurentRepository.GetUserPreferences(username);
        }
    }
}