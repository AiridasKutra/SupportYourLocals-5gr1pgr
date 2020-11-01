﻿namespace Common.Network
{
    enum PacketType
    {
        NONE,
        TEXT,
        DATA,
        EXECUTE_COMMAND,
        ADD_ENTRY_TABLENAME,
        ADD_ENTRY_DATA,
        EDIT_ENTRY_TABLENAME,
        EDIT_ENTRY_ROWNAME,
        EDIT_ENTRY_DATA,
        REMOVE_ENTRY_TABLENAME,
        REMOVE_ENTRY_ROWNAME,
        SEND_MESSAGE_TEXT,
        SEND_MESSAGE_EVENT_ID,
        OPEN_CHAT,

        SPLIT_PACKETS = 0x10000000,     // Specifies number of following packets to combine
        MULTIPLE_PACKETS = 0x10000001   // Specifies number of following packets to receive before pushing
    }
}