using Identity.ModelsLibrary;

namespace Identity.ApiLibrary
{
    public abstract class BaseApi
    {
        protected readonly AppUserInfo AppUserInfo;
        protected BaseApi(AppUserInfo appUserInfo)
        {
            AppUserInfo = appUserInfo;
        }
    }
}
