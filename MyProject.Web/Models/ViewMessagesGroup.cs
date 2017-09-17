using System.Collections.Generic;

namespace Identity.Web.Models
{
    public class ViewMessagesGroup
    {
        public StandardMessages MessageType { get; }
        public string MessageGroup { get; set; }
        public List<string> Messages { get; }
        public bool AutoHide { get; }
        public bool AllowClose { get; }

        public ViewMessagesGroup(StandardMessages messageType, string messageGroup, List<string> messages, bool autoHide, bool allowClose)
        {
            MessageType = messageType;
            MessageGroup = messageGroup;
            Messages = messages;
            AutoHide = autoHide;
            AllowClose = allowClose;
            if (messages == null) Messages = new List<string>();
        }

        public ViewMessagesGroup(StandardMessages messageType, string messageGroup, bool autoHide, bool allowClose)
        {
            MessageType = messageType;
            MessageGroup = messageGroup;
            AutoHide = autoHide;
            AllowClose = allowClose;
            Messages = new List<string>();
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        public void AddMessages(List<string> messages)
        {
            Messages.AddRange(messages);
        }
    }
}