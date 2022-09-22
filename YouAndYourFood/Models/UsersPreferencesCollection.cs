using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;

namespace YouAndYourFood.Models
{
    public class UsersPreferencesCollection
    {
        [JsonProperty("usersPreferences")]
        public IList<UserPreferences> UsersPreferences { get; set; }

        public UserPreferences GetUserPreferences(string userName)
        {
            return UsersPreferences.SingleOrDefault(pref => pref.Username == userName);
        }

        public void AddNewUserPreference(UserPreferences userPreferences)
        {
            UsersPreferences.Add(userPreferences);
        }
    }

    public class UserPreferences
    {
        public UserPreferences(string username, IList<Preference> preferences)
        {
            Username = username;
            Preferences = preferences;
        }

        [JsonProperty("username")]
        public string Username { get; private set; }

        [JsonProperty("preferences")]
        public IList<Preference> Preferences { get; private set; }

        public bool IsPreferenceExists(Preference preference)
        {
            return Preferences.
            Any(prop => (prop.RestauranIid == preference.RestauranIid) && (prop.ItemId == preference.ItemId));
        }

        public void AddOrUpdatePreference(Preference preference)
        {
            var existingPreference = Preferences.
                SingleOrDefault(prop => (prop.RestauranIid == preference.RestauranIid) && (prop.ItemId == preference.ItemId));
            if (existingPreference != null)
            {
                existingPreference.Update(preference.Star, preference.Notes);
            }
            else
            {
                Preferences.Add(preference);
            }
        }
    }

    public class Preference
    {

        public Preference(string restauranIid, string itemId, string star, string notes)
        {
            RestauranIid = restauranIid;
            ItemId = itemId;
            Star = star;
            Notes = notes;
        }

        public Preference()
        {

        }

        [JsonProperty("restauranIid")]
        public string RestauranIid { get;private set; }

        [JsonProperty("itemId")]
        public string ItemId { get;private set; }

        [JsonProperty("star")]
        public string Star { get;private set; }

        [JsonProperty("notes")]
        public string Notes { get;private set; }

        public void Update(string star, string notes)
        {
            Star = star;
            Notes = notes;
        }
    }
}
