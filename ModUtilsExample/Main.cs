using Steamworks;
using System;
using System.Collections.Generic;
using HMLLibrary;
using System.Runtime.CompilerServices;


namespace ModUtilsExample
{
    public class Main : Mod
    {
        public void Start()
        {
            UnityEngine.Debug.LogWarning("[ModUtils Example]: You shouldn't be trying to load this mod. It does nothing");
            modlistEntry.modinfo.unloadBtn.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        }

        // ---------------------- All the ModUtils related methods and fields are optional -----------------------------------------

        /*
         * ================================================
         * You can use one of these if you want to
         * move all the ModUtils methods to another class.
         * All fields and methods be static or non-static and
         * public or non-public if you want. Also the
         * ModUtils_Reciever field can use any class in place of
         * "MyReciever". Keep in mind, if you're using a custom
         * reciever then all the ModUtils related fields and
         * methods (aside from the reciever field itself) must
         * be in that class instead of your mod's class.
         * ================================================
         */
        ///static MyReciever ModUtils_Reciever; // if you don't set a value for the field, ModUtils will attempt to create a new instance of the class
        ///static MyReciever ModUtils_Reciever = new MyReciever(); // if you set a value to the field, ModUtils will use the existing instance
        ///static Type ModUtils_Reciever = typeof(MyReciever); // if you want to use a static class, you can set the value to a Type


        /*
         * ================================================
         * You can use one of these to preset one or more
         * network channels for your mod to listen to (instead
         * of calling the StartListeningToChannel function
         * during the Start method). This field can be of any
         * type that can be easily converted to NetworkChannel
         * or IEnumerable<NetworkChannel> such as int, int[], 
         * string, List<short>
         * ================================================
         */
        ///static NetworkChannel ModUtils_Channel = (NetworkChannel)1006;
        ///static NetworkChannel[] ModUtils_Channel = new[] { (NetworkChannel)1006, (NetworkChannel)1007, (NetworkChannel)28 };
        ///static short ModUtils_Channel = 1006;
        ///static long[] ModUtils_Channel = new long[] { 1006, 1007, 28 };


        // Occurs when a network message is recieved on one of the network channels your mod is set to listen to.
        // Return type can be void or bool. If the return type is null you can return true to indicate that your
        // mod handled the message, if the method is void or returns false then the message will continue to be
        // passed to other mods listening to the network channel.
        bool ModUtils_MessageRecieved(CSteamID steamID, NetworkChannel channel, Message message) 
        {
            return false;
        }

        // Occurs when a mod is loaded. Note: this is often called before the loaded mod's Start function.
        // Is also called for all mods loaded before your mod. Note: these calls will occur before your mod's Start function.
        void ModUtils_ModLoaded(Mod mod)
        {

        }

        // Occurs when a mod is unloaded
        void ModUtils_ModUnloaded(Mod mod)
        {

        }

        // The world save data is stored by mod slug so changing your mod's slug can cause the data to not be loaded.
        // If you include this field and set it to your mod's old slug then data saved while using the old slug should still be loaded.
        ///static string ModUtils_OldSlug = "old-mod-slug";

        // Occurs on the host when the world is saved. If a RGD is returned (not null), it will be saved to the world.
        RGD ModUtils_SaveLocalData()
        {
            return null;
        }

        // Occurs on the host when a world starts loading (only occurs if the save contains an RGD saved to
        // the world by the ModUtils_SaveLocalData method). The RGD given to this method will be the one this
        // mod saved to the world. Note: This will be run before any of the other world data is loaded.
        void ModUtils_LoadLocalData(RGD data)
        {
            
        }

        // Occurs on the host when a client joins. If a Message is returned (not null), it will be included the
        // world load messages sent to the client.
        Message ModUtils_SaveRemoteData()
        {
            return null;
        }

        // Occurs on the client when the host sends the world load data (only occurs if the sent data contains
        // a message provided by the ModUtils_SaveRemoteData method). The message given to this method will be
        // the one this mod sent with the world load data. Note: This will be run before any of the other world
        // data is recieved.
        void ModUtils_LoadRemoteData(Message message)
        {
            
        }

        // Occurs when the build menu is reloaded. the list of items returned will be added to the build menu. With each item
        // in the list, the first Item_Base is the item in the menu that it'll be inserted after, the second Item_Base is
        // your item that you want to add, if the bool is true then item will be added horizontally, if false then the item
        // will be added vertically.
        IEnumerable<(Item_Base,Item_Base,bool)> ModUtils_BuildMenuItems()
        {
            return null;
        }
        // This is another varient of the above method. This version behaves the same but all items are assumed to be inserted vertically
        /// IEnumerable<(Item_Base, Item_Base)> ModUtils_BuildMenuItems()

        /*
         * ================================================
         * The following methods will be automatically
         * replaced with calls to ModUtil's functions.
         * Because of some issues with how things are
         * handled, it's highly recommended, but not
         * required, to include the MethodImpl attribute
         * on these methods
         * ================================================
         */

        // Sets the mod to start listening to a specific network channel
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)] // You don't need to have the "System.Runtime.CompilerServices." part if you add "using System.Runtime.CompilerServices" to the top of the file
        public static void ModUtils_StartListeningToChannel(NetworkChannel channel) { }

        // Sets the mod to start listening to a specific set of network channels
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ModUtils_StartListeningToChannels(IEnumerable<NetworkChannel> network) { }

        // Sets the mod to start listening to a specific network channel or channels. The parameter and or value
        // passed to it can be anything that can be parsed as a NetworkChannel or IEnumerable<NetworkChannel>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ModUtils_StartListeningToChannel(object network) { }

        // Sets the mod to stop listening to a specific network channel
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ModUtils_StopListeningToChannel(NetworkChannel channel) { }

        // Sets the mod to stop listening to a specific set of network channels
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ModUtils_StopListeningToChannels(IEnumerable<NetworkChannel> network) { }

        // Sets the mod to stop listening to a specific network channel or channels. The parameter and or value
        // passed to it can be anything that can be parsed as a NetworkChannel or IEnumerable<NetworkChannel>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ModUtils_StopListeningToChannel(object network) { }

        // Creates a generic message containing any set of values. Base supported types are most of the basic
        // value types but you can add support for additional types using the RegisterSerializer method
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Message ModUtils_CreateGenericMessage(Messages type, int subType, params object[] values) => null;

        // Gets the subType from a generic message. If the message is not a generic message, 0 is returned and
        // an error is logged in the console
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int ModUtils_GetGenericMessageId(Message message) => 0;

        // Gets the subType from a generic message. If the message is not a generic message, 0 is returned and
        // if logErrors is true, an error is logged in the console
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int ModUtils_GetGenericMessageId(Message message, bool logErrors) => 0;

        // Gets the subType from a generic message. If the message is not a generic message or an error occurs
        // while reading the message, null is returned and the error is logged in the console
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object[] ModUtils_GetGenericMessageValues(Message message) => null;

        // Gets the subType from a generic message. If the message is not a generic message or an error occurs
        // while reading the message, null is returned and if logErrors is true, the error is logged in the console
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object[] ModUtils_GetGenericMessageValues(Message message, bool logErrors) => null;


        /*
         * ================================================
         * Something to note with all serialization
         * methods: All IEnumerable classes will work as
         * long as their value's types are supported.
         * IEnerumable<T> will always become an array of
         * the generic type during deserialization. For
         * example, List<int> would become int[]. Any plain
         * IEnumerable or IEnerumable<object> classes will
         * become object[].
         * ================================================
         */


        // Converts an array of objects into an array of bytes. Keep in mind errors may occur while serializing if data is malformed. A try catch is recommended.
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ModUtils_Serialize(params object[] values) => null;

        // Converts an array of objects into a serialized string. Keep in mind errors may occur while serializing if data is malformed. A try catch is recommended.
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ModUtils_StringSerialize(params object[] values) => null;

        // Reverts an array of bytes into an array of objects. If an object fails to deserialize there will be a null
        // in its place in the array and the error is logged in the console. If an object fails to parse it may cause
        // following objects to also fail.
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object[] ModUtils_Deserialize(byte[] data) => null;

        // Reverts a serialized string into an array of objects. If an object fails to deserialize there will be a null
        // in its place in the array and the error is logged in the console. If an object fails to parse it may cause
        // following objects to also fail.
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object[] ModUtils_Deserialize(string data) => null;

        // Reverts an array of bytes into an array of objects. If an object fails to deserialize there will be a null
        // in its place in the array and if logErrors is true the error is logged in the console. If an object fails
        // to parse it may cause following objects to also fail.
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object[] ModUtils_Deserialize(byte[] data, bool logErrors) => null;

        // Reverts a serialized string into an array of objects. If an object fails to deserialize there will be a null
        // in its place in the array and if logErrors is true the error is logged in the console. If an object fails
        // to parse it may cause following objects to also fail.
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object[] ModUtils_Deserialize(string data, bool logErrors) => null;


        // When registering a type serializer it is recommended to use a fixed sized serializer where you can as
        // dynamic sized serializers can result in larger than expected messages. Larger messages require more processing

        // Registers a custom dynamic sized type serializer to your mod. If you want to use a normally unsupported type
        // in a generic message then you will need to use this.
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ModUtils_RegisterSerializer(Type type, Func<object, byte[]> toBytes, Func<byte[], object> fromBytes) { }

        // Registers a custom fixed sized type serializer to your mod. If you want to use a normally unsupported type in
        // a generic message then you will need to use this.
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ModUtils_RegisterSerializer(Type type, Func<object, byte[]> toBytes, Func<byte[], object> fromBytes, int byteCount) { }

        // Reloads the extra items in the build menu. Only needs to called after registering or unregistering items from the game
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ModUtils_ReloadBuildMenu() { }
    }
}