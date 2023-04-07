using Buoi1.Models;
using Newtonsoft.Json;

namespace Buoi1.Services
{
    public class SesssionService
    {
        public static List<Product> GetObjFromSession(ISession session, string key)
        {
            string jsonData = session.GetString(key); // lấy dữ liệu dạng string từ session
            if (jsonData == null)
            {
                return new List<Product>(); // Khởi tạo 1 list mới để chứa sp khi dữ liệu lấy ra null => Session chưa được tạo ra
            }
            else
            {
                // Nếu có dự liệu thì chuyển về dạng list
                var products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
                return products;
            }
        }
        public static void SetObjToSession(ISession session,string key, object data)
        {
            var jsonData = JsonConvert.SerializeObject(data); // Chuyển đổi dữ liệu về jsonData
            session.SetString(key, jsonData); // ghi đè vào session
        }
        public static bool CheckObjList(Guid id, List<Product> products)
        {
            return products.Any(x => x.Id == id);
        }
    }
}
