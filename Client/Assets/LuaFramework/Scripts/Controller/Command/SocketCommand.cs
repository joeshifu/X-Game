using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaFramework;

public class SocketCommand : ControllerCommand
{

    public override void Execute(IMessage message)
    {
        object data = message.Body;
        if (data == null) return;
        KeyValuePair<int, ByteBuffer> buffer = (KeyValuePair<int, ByteBuffer>)data;
        switch (buffer.Key)
		{
			//把packet.header.header，packet.data 抛到lua里面去处理
            default: Util.CallMethod("Network", "OnSocket", buffer.Key, buffer.Value); break;
        }
    }
}
