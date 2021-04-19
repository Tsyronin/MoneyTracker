using BLL.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class MonoHelper : IBankHelper
    {
        private HttpClient httpBankClient { get; set; }

        //TODO: Probably better to move to ctor.
        public void InitializeClient()
        {
            httpBankClient = new HttpClient();
            httpBankClient.BaseAddress = new Uri("https://api.monobank.ua/personal/statement/"); //TODO: move to config file
            httpBankClient.DefaultRequestHeaders.Accept.Clear();
            httpBankClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var XToken = "uRa6C5lcdnXr9aTH-ScSCGUEZVewjpK2a9tJ3QNPWmIg"; //TODO: move to config file
            httpBankClient.DefaultRequestHeaders.Add("X-Token", XToken);
        }

        /// <summary>
        /// Gets recent expenses made with specified account.
        /// </summary>
        /// <param name="account">Account name. Use '0' for default account</param>
        /// <param name="from">optional start date</param>
        /// <returns>List of most recent expences or null if account is invalid</returns>
        public async Task<IEnumerable<ExpenceDto>> GetRecentExpensesAsync(string account, DateTime? from)
        {
            DateTime monthAgo = from ?? DateTime.Now.AddMonths(-1);
            long unixTime = ((DateTimeOffset)monthAgo).ToUnixTimeSeconds();
            HttpResponseMessage response = await httpBankClient.GetAsync($"{account}/{unixTime}");
            IEnumerable<ExpenceDto> expences = new List<ExpenceDto>();

            if (response.IsSuccessStatusCode)
            {
                expences = await response.Content.ReadAsAsync<List<ExpenceDto>>();
                return expences;
            }
            return null;
        }
    }
}
