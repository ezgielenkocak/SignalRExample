using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRServerExample.Hubs
{
    //Hub classından türeyen tüm classlar TCP protokolü üzerinden haberleşmemizi sağlayacak sorumluluğu üstlenir.
    //Clientların huba subscribe olması için hubta bir fonksiyon oluşturmam lazım. 
    //İilgili clientlar o fonksiyona subscribe olduğu için RPC sistemi sayesinde gerekli metotlar devreye girer.
    public class MyHub:Hub  
    {
        //Clientların subscribe olacağı fonksiyon bu. Bu metot tetiklendiğinde clienttaki belirli fonksiyonlar tetiklenir
        public async Task SendMessage(string message) //gelen mesahı hub'ın karşılayabilmesi için parametreyi kullandım.Clientin gönderdiği data parametreden gelecek
        {
            //hub' gönderdiğim mesajın huba bağlı olan diğer clientlara ulaşması
            await Clients.All.SendAsync("receiveMessage", message); //==> Clientta receiveMessage isimli fonksiyonu bekliyorum. O fonksiyonu tetikle ve tetiklerken data(message gönderen) clientın gönderdiği mesajı diğer clientlara gönder.

             
        }
    }
}

//SendMessage metoduyla hub'ı hazırladım
//Web SOcket protokolonü kullanacağımı bildirmem lazım            ==>Startup.cs
//Bu hubı hangi endpointte kullanacağımı da bildirmem lazım
