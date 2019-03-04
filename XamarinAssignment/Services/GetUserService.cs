using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinAssignment.Constants;
using XamarinAssignment.Models;

namespace XamarinAssignment.Services
{
    public class GetUserService
    {

        public async Task<List<Contact>> GetUserList()
        {
            try
            {
                var uri = new Uri(Constant.BaseUrl);

                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    var contents = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        if (!string.IsNullOrEmpty(contents))
                        {
                            User userList = JsonConvert.DeserializeObject<User>(contents);


                            return userList.contacts;
                        }
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

    }
}
