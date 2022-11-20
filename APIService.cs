using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project1
{
    internal class QuestionModel

    {

        public string questionText { get; set; }

        public int questionNumber { get; set; }

        public string optionOne { get; set; }

        public string optionTwo { get; set; }

        public string optionThree { get; set; }

        public string correctOptionValue { get; set; }

    }
    internal class APIService
    {
        HttpClient _client;

        JsonSerializerOptions _serializerOptions;

        static string apiUrl = "http://ec2-3-6-127-17.ap-south-1.compute.amazonaws.com:8080/sai/";

        public QuestionModel question { get; private set; }



        public APIService()

        {

            _client = new HttpClient();

            _serializerOptions = new JsonSerializerOptions

            {

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

                WriteIndented = true

            };

        }



        public async Task<QuestionModel> getAnswerJSON(int questionNumber)

        {
            question = new QuestionModel();
            Uri uri = new Uri(string.Format($"{apiUrl}{questionNumber}", string.Empty));

            try

            {
               
                HttpResponseMessage response = await _client.GetAsync(uri);

                if (!response.IsSuccessStatusCode)

                {
                    return null;
                }
                string content = await response.Content.ReadAsStringAsync();

                question = JsonSerializer.Deserialize<QuestionModel>(content, _serializerOptions);

            }

            catch (Exception ex)

            {
                Console.WriteLine(ex);
            }
            return question;
        }
    }
}
