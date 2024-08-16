
using BRICS_API_Neo.Models;
using DataService.DBModels;
using System.Globalization;
using System.Security.Cryptography;

namespace BRICS_API_NEO
{
    public class StaticClass
    {
        private static IConfiguration _configuration;
        public StaticClass()
        {

        }

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static ConfigurationModel GetConfigCreadential()
        {
            //get static data
            ConfigurationModel configurationModel = new ConfigurationModel();
            var iciciCreadential = _configuration.GetSection("uatHardcodeData");
            var balanceInquiryCreadential = _configuration.GetSection("iciciCreadential");
            configurationModel.SecreatKey = balanceInquiryCreadential["secreatKey"];

            return configurationModel;
        }

        public static byte[] ExtractIV(string encryptData)
        {
            byte[] encryptedData = Convert.FromBase64String(encryptData);
            byte[] iv = new byte[16];
            Array.Copy(encryptedData, 0, iv, 0, iv.Length);
            return iv;
        }

        public static void Log(Icicilog log)
        {
            BricsrecosystemContext _dbContext = new BricsrecosystemContext();

            if (log != null)
            {
                var existingLog = _dbContext.Icicilogs.Where(x => x.RequestId == log.RequestId).FirstOrDefault();

                if (existingLog == null)
                {
                    _dbContext.Icicilogs.Add(log);
                }
                else
                {
                    existingLog.Requestbody = log.Requestbody;
                    existingLog.Encryptedrequest = log.Encryptedrequest;
                    existingLog.Iv = log.Iv;
                    existingLog.Response = log.Response;
                    existingLog.Encryptedresponse = log.Encryptedresponse;
                }
                _dbContext.SaveChanges();
            }
        }
    }
}
