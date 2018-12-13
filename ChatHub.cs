using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;


namespace SignalRChat
{
    public class ChatHub : Hub
    {
        static List<Users> ConnectedUsers = new List<Users>();
        static List<Messages> CurrentMessage = new List<Messages>();

        public void Connect(string userName)
        {
            var id = Context.ConnectionId;
            // HttpContext.Current.Session["UserId"] = id;
            // Подключение нового пользователя
            if (!ConnectedUsers.Any(x => x.ConnectionId == id))
            {
                string logintime = DateTime.Now.ToString();
                ConnectedUsers.Add(new Users { ConnectionId = id, UserName = userName, LoginTime = logintime });

                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName, logintime);
            }
        }

        public void SendMessageToAll(string userName, string message, string time)
        {
            // храним последние 100 сообщений в кэше
            AddMessageinCache(userName, message, time);

            if (userName != "bot")
            {
                Clients.All.messageReceived(userName, message, time);
            }
            else
            {
                BotSendMessage(userName, message, time);
            }
            

        }
        private static Random _rand = new Random();
        public void BotSendMessage(string userName, string message, string time)
        {
            string filePath = HttpContext.Current.Server.MapPath("\\facts.txt");
            string[] lines = File.ReadAllLines(filePath);
            Random rand = new Random();
            var randomLineNumber = rand.Next(0, lines.Length - 1);
            var message_to_send = message;
            try
            {
                message_to_send = lines[randomLineNumber];
            }
            catch
            {
                message_to_send = "fail";
            }

            // храним последние 100 сообщений в кэше
            AddMessageinCache(userName, message_to_send, time);

            // отправляем сообщение всем
            Clients.All.messageReceived(userName, message_to_send, time);

        }

        private void AddMessageinCache(string userName, string message, string time)
        {
            CurrentMessage.Add(new Messages { UserName = userName, Message = message, Time = time });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);

        }


        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }
            return base.OnDisconnected(stopCalled);
        }
    }
}