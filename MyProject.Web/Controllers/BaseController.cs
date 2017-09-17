using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Identity.IdentityLibrary;
using Identity.ModelsLibrary;
using Identity.Web.Models;

namespace Identity.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public AppUserInfo AppUserInfo { get; protected set; }

        protected BaseController()
        {
            LoadCurrentUser();
        }

        protected void LoadCurrentUser()
        {
            AppUserInfo = CurrentUser.GetCurrentUserInfo();
        }

        protected void AddViewMessage(StandardMessages standardMessage, string message, string messageGroupName = null, bool autoHide = false, bool allowClose = true)
        {
            var messageGroup = !string.IsNullOrWhiteSpace(messageGroupName) ? messageGroupName : "Default";
            HandleAddViewMessage(standardMessage, new List<string>() { message }, messageGroup, autoHide, allowClose);
        }

        protected void AddViewMessage(StandardMessages standardMessage, List<string> messages, string messageGroupName = null, bool autoHide = false, bool allowClose = true)
        {
            var messageGroup = !string.IsNullOrWhiteSpace(messageGroupName) ? messageGroupName : "Default";
            HandleAddViewMessage(standardMessage, messages, messageGroup, autoHide, allowClose);
        }

        private void HandleAddViewMessage(StandardMessages standardMessage, List<string> messages, string messageGroupName, bool autoHide, bool allowClose)
        {
            var messageGroups = new List<ViewMessagesGroup>();
            if (TempData["ViewMessages"] != null)
            {
                messageGroups = (List<ViewMessagesGroup>)TempData["ViewMessages"];
            }

            var messageGroup = messageGroups.FirstOrDefault(m => m.MessageGroup.Equals(messageGroupName, StringComparison.CurrentCultureIgnoreCase));
            if (messageGroup == null)
            {
                messageGroup = new ViewMessagesGroup(standardMessage, messageGroupName, autoHide, allowClose);
                messageGroups.Add(messageGroup);
            }

            messageGroup.AddMessages(messages);
            TempData["ViewMessages"] = messageGroups;
        }
    }
}