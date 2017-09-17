namespace Identity.ModelsLibrary.Records.Identities
{
    public class UserRecordIdentity : RecordIdentity
    {
        private string _profilePic;
        public string Username { get; set; }
        public string ProfilePic
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_profilePic))
                {
                    _profilePic = "/images/wireframe/square-image.png";
                }
                return _profilePic;
            }
            set
            {
                _profilePic = value;
            }
        }
    }
}
