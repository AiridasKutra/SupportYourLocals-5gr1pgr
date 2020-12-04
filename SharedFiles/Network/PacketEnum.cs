namespace Common.Network
{
    enum PacketType
    {
        NONE,
        TEXT,
        DATA,
        VFID,
        EXECUTE_COMMAND,
        ADD_ENTRY_TABLENAME,
        ADD_ENTRY_DATA,
        EDIT_ENTRY_TABLENAME,
        EDIT_ENTRY_ROWNAME,
        EDIT_ENTRY_DATA,
        REMOVE_ENTRY_TABLENAME,
        REMOVE_ENTRY_ROWNAME,

        SELECT_SPORTS,
        SELECT_EVENTS_BRIEF,
        SELECT_EVENTS_FULL,
        CREATE_EVENT,
        DELETE_EVENT,
        EDIT_EVENT,
        EDIT_EVENT_DATA,
        SET_EVENT_VISIBLE,
        SET_EVENT_INVISIBLE,
        CREATE_REPORT,
        SELECT_REPORTS_EVENT_ID,
        DELETE_REPORTS_EVENT_ID,
        DELETE_REPORT,

        SEND_MESSAGE_DATA,
        SEND_MESSAGE_EVENT_ID,
        OPEN_CHAT,
        DELETE_MESSAGE,
        SELECT_EVENT_COMMENTS,

        LOGIN_EMAIL,
        LOGIN_PASSWORD,
        LOGOUT,
        SET_ACCOUNT_USERNAME,
        SET_ACCOUNT_PASSWORD,
        CREATE_ACCOUNT_USERNAME,
        CREATE_ACCOUNT_EMAIL,
        CREATE_ACCOUNT_PASSWORD,
        SELECT_ACCOUNT_USERNAME,
        SELECT_ACCOUNT_EMAIL,
        SELECT_ACCOUNT_PERMISSIONS,
        SELECT_ACCOUNTS,
        GET_ACCOUNT_ID,

        MAKE_ADMINISTRATOR,
        MAKE_MODERATOR,
        MAKE_USER,
        BAN_ACCOUNT,
        BAN_ACCOUNT_DURATION,
        UNBAN_ACCOUNT,
        SILENCE_ACCOUNT,
        SILENCE_ACCOUNT_DURATION,
        UNSILENCE_ACCOUNT,
        DELETE_ACCOUNT,

        SPLIT_PACKETS = 0x10000000,     // Specifies number of following packets to combine
        MULTIPLE_PACKETS = 0x10000001   // Specifies number of following packets to receive before pushing
    }
}