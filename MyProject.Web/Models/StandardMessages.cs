namespace Identity.Web.Models
{
    public enum StandardMessages
    {
        Standard = 0,

        CustomMessageSuccess,
        CustomMessageInfo,
        CustomMessageWarning,
        CustomMessageError,

        ItemNochange,
        ItemAlreadyExists,
        ItemIsInUse,
        ItemNotFound,

        ItemCreated,
        ErrorCreating,

        ItemUpdated,
        ErrorUpdating,

        ItemDeleted,
        ErrorDeleting,

        ItemRestored,
        ErrorRestoring,

        ItemArchived,
        ErrorArchiving,

        ItemUnArchived,
        ErrorUnArchiving
    }
}