﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace RadarFlight
{
    public partial class App : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        private global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMetaDataProvider __appProvider;
        private global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMetaDataProvider _AppProvider
        {
            get
            {
                if (__appProvider == null)
                {
                    __appProvider = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMetaDataProvider();
                }
                return __appProvider;
            }
        }

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            return _AppProvider.GetXamlType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            return _AppProvider.GetXamlType(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return _AppProvider.GetXmlnsDefinitions();
        }
    }
}

namespace RadarFlight.FlightsRadar_XamlTypeInfo
{
    /// <summary>
    /// Main class for providing metadata for the app or library
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public sealed class XamlMetaDataProvider : global::Windows.UI.Xaml.Markup.IXamlMetadataProvider
    {
        private global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlTypeInfoProvider _provider = null;

        private global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlTypeInfoProvider Provider
        {
            get
            {
                if (_provider == null)
                {
                    _provider = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlTypeInfoProvider();
                }
                return _provider;
            }
        }

        /// <summary>
        /// GetXamlType(Type)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(global::System.Type type)
        {
            return Provider.GetXamlTypeByType(type);
        }

        /// <summary>
        /// GetXamlType(String)
        /// </summary>
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlType(string fullName)
        {
            return Provider.GetXamlTypeByName(fullName);
        }

        /// <summary>
        /// GetXmlnsDefinitions()
        /// </summary>
        public global::Windows.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return new global::Windows.UI.Xaml.Markup.XmlnsDefinition[0];
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal partial class XamlTypeInfoProvider
    {
        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByType(global::System.Type type)
        {
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByType.TryGetValue(type, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByType(type);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlType GetXamlTypeByName(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlType xamlType;
            if (_xamlTypeCacheByName.TryGetValue(typeName, out xamlType))
            {
                return xamlType;
            }
            int typeIndex = LookupTypeIndexByName(typeName);
            if(typeIndex != -1)
            {
                xamlType = CreateXamlType(typeIndex);
            }
            if (xamlType != null)
            {
                _xamlTypeCacheByName.Add(xamlType.FullName, xamlType);
                _xamlTypeCacheByType.Add(xamlType.UnderlyingType, xamlType);
            }
            return xamlType;
        }

        public global::Windows.UI.Xaml.Markup.IXamlMember GetMemberByLongName(string longMemberName)
        {
            if (string.IsNullOrEmpty(longMemberName))
            {
                return null;
            }
            global::Windows.UI.Xaml.Markup.IXamlMember xamlMember;
            if (_xamlMembers.TryGetValue(longMemberName, out xamlMember))
            {
                return xamlMember;
            }
            xamlMember = CreateXamlMember(longMemberName);
            if (xamlMember != null)
            {
                _xamlMembers.Add(longMemberName, xamlMember);
            }
            return xamlMember;
        }

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByName = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>
                _xamlTypeCacheByType = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Windows.UI.Xaml.Markup.IXamlType>();

        global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>
                _xamlMembers = new global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.Markup.IXamlMember>();

        string[] _typeNameTable = null;
        global::System.Type[] _typeTable = null;

        private void InitTypeTables()
        {
            _typeNameTable = new string[12];
            _typeNameTable[0] = "Common.Models.FlightModel";
            _typeNameTable[1] = "Object";
            _typeNameTable[2] = "Int32";
            _typeNameTable[3] = "Boolean";
            _typeNameTable[4] = "String";
            _typeNameTable[5] = "System.DateTime";
            _typeNameTable[6] = "System.ValueType";
            _typeNameTable[7] = "Common.Models.PlainModel";
            _typeNameTable[8] = "RadarFlight.Converters.BoolToPlainPicSoure";
            _typeNameTable[9] = "RadarFlight.MainPage";
            _typeNameTable[10] = "Windows.UI.Xaml.Controls.Page";
            _typeNameTable[11] = "Windows.UI.Xaml.Controls.UserControl";

            _typeTable = new global::System.Type[12];
            _typeTable[0] = typeof(global::Common.Models.FlightModel);
            _typeTable[1] = typeof(global::System.Object);
            _typeTable[2] = typeof(global::System.Int32);
            _typeTable[3] = typeof(global::System.Boolean);
            _typeTable[4] = typeof(global::System.String);
            _typeTable[5] = typeof(global::System.DateTime);
            _typeTable[6] = typeof(global::System.ValueType);
            _typeTable[7] = typeof(global::Common.Models.PlainModel);
            _typeTable[8] = typeof(global::RadarFlight.Converters.BoolToPlainPicSoure);
            _typeTable[9] = typeof(global::RadarFlight.MainPage);
            _typeTable[10] = typeof(global::Windows.UI.Xaml.Controls.Page);
            _typeTable[11] = typeof(global::Windows.UI.Xaml.Controls.UserControl);
        }

        private int LookupTypeIndexByName(string typeName)
        {
            if (_typeNameTable == null)
            {
                InitTypeTables();
            }
            for (int i=0; i<_typeNameTable.Length; i++)
            {
                if(0 == string.CompareOrdinal(_typeNameTable[i], typeName))
                {
                    return i;
                }
            }
            return -1;
        }

        private int LookupTypeIndexByType(global::System.Type type)
        {
            if (_typeTable == null)
            {
                InitTypeTables();
            }
            for(int i=0; i<_typeTable.Length; i++)
            {
                if(type == _typeTable[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private object Activate_0_FlightModel() { return new global::Common.Models.FlightModel(); }
        private object Activate_7_PlainModel() { return new global::Common.Models.PlainModel(); }
        private object Activate_8_BoolToPlainPicSoure() { return new global::RadarFlight.Converters.BoolToPlainPicSoure(); }
        private object Activate_9_MainPage() { return new global::RadarFlight.MainPage(); }

        private global::Windows.UI.Xaml.Markup.IXamlType CreateXamlType(int typeIndex)
        {
            global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlSystemBaseType xamlType = null;
            global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType userType;
            string typeName = _typeNameTable[typeIndex];
            global::System.Type type = _typeTable[typeIndex];

            switch (typeIndex)
            {

            case 0:   //  Common.Models.FlightModel
                userType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_0_FlightModel;
                userType.AddMemberName("ID");
                userType.AddMemberName("PlainId");
                userType.AddMemberName("IsDeparture");
                userType.AddMemberName("IsFinish");
                userType.AddMemberName("FlightName");
                userType.AddMemberName("Time");
                userType.AddMemberName("Plain");
                xamlType = userType;
                break;

            case 1:   //  Object
                xamlType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 2:   //  Int32
                xamlType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 3:   //  Boolean
                xamlType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 4:   //  String
                xamlType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 5:   //  System.DateTime
                userType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("System.ValueType"));
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 6:   //  System.ValueType
                userType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                xamlType = userType;
                break;

            case 7:   //  Common.Models.PlainModel
                userType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.SetIsReturnTypeStub();
                xamlType = userType;
                break;

            case 8:   //  RadarFlight.Converters.BoolToPlainPicSoure
                userType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Object"));
                userType.Activator = Activate_8_BoolToPlainPicSoure;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 9:   //  RadarFlight.MainPage
                userType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType(this, typeName, type, GetXamlTypeByName("Windows.UI.Xaml.Controls.Page"));
                userType.Activator = Activate_9_MainPage;
                userType.SetIsLocalType();
                xamlType = userType;
                break;

            case 10:   //  Windows.UI.Xaml.Controls.Page
                xamlType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;

            case 11:   //  Windows.UI.Xaml.Controls.UserControl
                xamlType = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlSystemBaseType(typeName, type);
                break;
            }
            return xamlType;
        }


        private object get_0_FlightModel_ID(object instance)
        {
            var that = (global::Common.Models.FlightModel)instance;
            return that.ID;
        }
        private void set_0_FlightModel_ID(object instance, object Value)
        {
            var that = (global::Common.Models.FlightModel)instance;
            that.ID = (global::System.Int32)Value;
        }
        private object get_1_FlightModel_PlainId(object instance)
        {
            var that = (global::Common.Models.FlightModel)instance;
            return that.PlainId;
        }
        private void set_1_FlightModel_PlainId(object instance, object Value)
        {
            var that = (global::Common.Models.FlightModel)instance;
            that.PlainId = (global::System.Int32)Value;
        }
        private object get_2_FlightModel_IsDeparture(object instance)
        {
            var that = (global::Common.Models.FlightModel)instance;
            return that.IsDeparture;
        }
        private void set_2_FlightModel_IsDeparture(object instance, object Value)
        {
            var that = (global::Common.Models.FlightModel)instance;
            that.IsDeparture = (global::System.Boolean)Value;
        }
        private object get_3_FlightModel_IsFinish(object instance)
        {
            var that = (global::Common.Models.FlightModel)instance;
            return that.IsFinish;
        }
        private void set_3_FlightModel_IsFinish(object instance, object Value)
        {
            var that = (global::Common.Models.FlightModel)instance;
            that.IsFinish = (global::System.Boolean)Value;
        }
        private object get_4_FlightModel_FlightName(object instance)
        {
            var that = (global::Common.Models.FlightModel)instance;
            return that.FlightName;
        }
        private void set_4_FlightModel_FlightName(object instance, object Value)
        {
            var that = (global::Common.Models.FlightModel)instance;
            that.FlightName = (global::System.String)Value;
        }
        private object get_5_FlightModel_Time(object instance)
        {
            var that = (global::Common.Models.FlightModel)instance;
            return that.Time;
        }
        private void set_5_FlightModel_Time(object instance, object Value)
        {
            var that = (global::Common.Models.FlightModel)instance;
            that.Time = (global::System.DateTime)Value;
        }
        private object get_6_FlightModel_Plain(object instance)
        {
            var that = (global::Common.Models.FlightModel)instance;
            return that.Plain;
        }
        private void set_6_FlightModel_Plain(object instance, object Value)
        {
            var that = (global::Common.Models.FlightModel)instance;
            that.Plain = (global::Common.Models.PlainModel)Value;
        }

        private global::Windows.UI.Xaml.Markup.IXamlMember CreateXamlMember(string longMemberName)
        {
            global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMember xamlMember = null;
            global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType userType;

            switch (longMemberName)
            {
            case "Common.Models.FlightModel.ID":
                userType = (global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Common.Models.FlightModel");
                xamlMember = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMember(this, "ID", "Int32");
                xamlMember.Getter = get_0_FlightModel_ID;
                xamlMember.Setter = set_0_FlightModel_ID;
                break;
            case "Common.Models.FlightModel.PlainId":
                userType = (global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Common.Models.FlightModel");
                xamlMember = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMember(this, "PlainId", "Int32");
                xamlMember.Getter = get_1_FlightModel_PlainId;
                xamlMember.Setter = set_1_FlightModel_PlainId;
                break;
            case "Common.Models.FlightModel.IsDeparture":
                userType = (global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Common.Models.FlightModel");
                xamlMember = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMember(this, "IsDeparture", "Boolean");
                xamlMember.Getter = get_2_FlightModel_IsDeparture;
                xamlMember.Setter = set_2_FlightModel_IsDeparture;
                break;
            case "Common.Models.FlightModel.IsFinish":
                userType = (global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Common.Models.FlightModel");
                xamlMember = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMember(this, "IsFinish", "Boolean");
                xamlMember.Getter = get_3_FlightModel_IsFinish;
                xamlMember.Setter = set_3_FlightModel_IsFinish;
                break;
            case "Common.Models.FlightModel.FlightName":
                userType = (global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Common.Models.FlightModel");
                xamlMember = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMember(this, "FlightName", "String");
                xamlMember.Getter = get_4_FlightModel_FlightName;
                xamlMember.Setter = set_4_FlightModel_FlightName;
                break;
            case "Common.Models.FlightModel.Time":
                userType = (global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Common.Models.FlightModel");
                xamlMember = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMember(this, "Time", "System.DateTime");
                xamlMember.Getter = get_5_FlightModel_Time;
                xamlMember.Setter = set_5_FlightModel_Time;
                break;
            case "Common.Models.FlightModel.Plain":
                userType = (global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlUserType)GetXamlTypeByName("Common.Models.FlightModel");
                xamlMember = new global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlMember(this, "Plain", "Common.Models.PlainModel");
                xamlMember.Getter = get_6_FlightModel_Plain;
                xamlMember.Setter = set_6_FlightModel_Plain;
                break;
            }
            return xamlMember;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlSystemBaseType : global::Windows.UI.Xaml.Markup.IXamlType
    {
        string _fullName;
        global::System.Type _underlyingType;

        public XamlSystemBaseType(string fullName, global::System.Type underlyingType)
        {
            _fullName = fullName;
            _underlyingType = underlyingType;
        }

        public string FullName { get { return _fullName; } }

        public global::System.Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        virtual public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name) { throw new global::System.NotImplementedException(); }
        virtual public bool IsArray { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsCollection { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsConstructible { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsDictionary { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsMarkupExtension { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsBindable { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsReturnTypeStub { get { throw new global::System.NotImplementedException(); } }
        virtual public bool IsLocalType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType ItemType { get { throw new global::System.NotImplementedException(); } }
        virtual public global::Windows.UI.Xaml.Markup.IXamlType KeyType { get { throw new global::System.NotImplementedException(); } }
        virtual public object ActivateInstance() { throw new global::System.NotImplementedException(); }
        virtual public void AddToMap(object instance, object key, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void AddToVector(object instance, object item)  { throw new global::System.NotImplementedException(); }
        virtual public void RunInitializer()   { throw new global::System.NotImplementedException(); }
        virtual public object CreateFromString(string input)   { throw new global::System.NotImplementedException(); }
    }
    
    internal delegate object Activator();
    internal delegate void AddToCollection(object instance, object item);
    internal delegate void AddToDictionary(object instance, object key, object item);
    internal delegate object CreateFromStringMethod(string args);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlUserType : global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlSystemBaseType
    {
        global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlTypeInfoProvider _provider;
        global::Windows.UI.Xaml.Markup.IXamlType _baseType;
        bool _isArray;
        bool _isMarkupExtension;
        bool _isBindable;
        bool _isReturnTypeStub;
        bool _isLocalType;

        string _contentPropertyName;
        string _itemTypeName;
        string _keyTypeName;
        global::System.Collections.Generic.Dictionary<string, string> _memberNames;
        global::System.Collections.Generic.Dictionary<string, object> _enumValues;

        public XamlUserType(global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlTypeInfoProvider provider, string fullName, global::System.Type fullType, global::Windows.UI.Xaml.Markup.IXamlType baseType)
            :base(fullName, fullType)
        {
            _provider = provider;
            _baseType = baseType;
        }

        // --- Interface methods ----

        override public global::Windows.UI.Xaml.Markup.IXamlType BaseType { get { return _baseType; } }
        override public bool IsArray { get { return _isArray; } }
        override public bool IsCollection { get { return (CollectionAdd != null); } }
        override public bool IsConstructible { get { return (Activator != null); } }
        override public bool IsDictionary { get { return (DictionaryAdd != null); } }
        override public bool IsMarkupExtension { get { return _isMarkupExtension; } }
        override public bool IsBindable { get { return _isBindable; } }
        override public bool IsReturnTypeStub { get { return _isReturnTypeStub; } }
        override public bool IsLocalType { get { return _isLocalType; } }

        override public global::Windows.UI.Xaml.Markup.IXamlMember ContentProperty
        {
            get { return _provider.GetMemberByLongName(_contentPropertyName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType ItemType
        {
            get { return _provider.GetXamlTypeByName(_itemTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlType KeyType
        {
            get { return _provider.GetXamlTypeByName(_keyTypeName); }
        }

        override public global::Windows.UI.Xaml.Markup.IXamlMember GetMember(string name)
        {
            if (_memberNames == null)
            {
                return null;
            }
            string longName;
            if (_memberNames.TryGetValue(name, out longName))
            {
                return _provider.GetMemberByLongName(longName);
            }
            return null;
        }

        override public object ActivateInstance()
        {
            return Activator(); 
        }

        override public void AddToMap(object instance, object key, object item) 
        {
            DictionaryAdd(instance, key, item);
        }

        override public void AddToVector(object instance, object item)
        {
            CollectionAdd(instance, item);
        }

        override public void RunInitializer() 
        {
            global::System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(UnderlyingType.TypeHandle);
        }

        override public object CreateFromString(string input)
        {
            if (CreateFromStringMethod != null)
            {
                return this.CreateFromStringMethod(input);
            }
            else if (_enumValues != null)
            {
                int value = 0;

                string[] valueParts = input.Split(',');

                foreach (string valuePart in valueParts) 
                {
                    object partValue;
                    int enumFieldValue = 0;
                    try
                    {
                        if (_enumValues.TryGetValue(valuePart.Trim(), out partValue))
                        {
                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                        }
                        else
                        {
                            try
                            {
                                enumFieldValue = global::System.Convert.ToInt32(valuePart.Trim());
                            }
                            catch( global::System.FormatException )
                            {
                                foreach( string key in _enumValues.Keys )
                                {
                                    if( string.Compare(valuePart.Trim(), key, global::System.StringComparison.OrdinalIgnoreCase) == 0 )
                                    {
                                        if( _enumValues.TryGetValue(key.Trim(), out partValue) )
                                        {
                                            enumFieldValue = global::System.Convert.ToInt32(partValue);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        value |= enumFieldValue; 
                    }
                    catch( global::System.FormatException )
                    {
                        throw new global::System.ArgumentException(input, FullName);
                    }
                }

                return value; 
            }
            throw new global::System.ArgumentException(input, FullName);
        }

        // --- End of Interface methods

        public Activator Activator { get; set; }
        public AddToCollection CollectionAdd { get; set; }
        public AddToDictionary DictionaryAdd { get; set; }
        public CreateFromStringMethod CreateFromStringMethod {get; set; }

        public void SetContentPropertyName(string contentPropertyName)
        {
            _contentPropertyName = contentPropertyName;
        }

        public void SetIsArray()
        {
            _isArray = true; 
        }

        public void SetIsMarkupExtension()
        {
            _isMarkupExtension = true;
        }

        public void SetIsBindable()
        {
            _isBindable = true;
        }

        public void SetIsReturnTypeStub()
        {
            _isReturnTypeStub = true;
        }

        public void SetIsLocalType()
        {
            _isLocalType = true;
        }

        public void SetItemTypeName(string itemTypeName)
        {
            _itemTypeName = itemTypeName;
        }

        public void SetKeyTypeName(string keyTypeName)
        {
            _keyTypeName = keyTypeName;
        }

        public void AddMemberName(string shortName)
        {
            if(_memberNames == null)
            {
                _memberNames =  new global::System.Collections.Generic.Dictionary<string,string>();
            }
            _memberNames.Add(shortName, FullName + "." + shortName);
        }

        public void AddEnumValue(string name, object value)
        {
            if (_enumValues == null)
            {
                _enumValues = new global::System.Collections.Generic.Dictionary<string, object>();
            }
            _enumValues.Add(name, value);
        }
    }

    internal delegate object Getter(object instance);
    internal delegate void Setter(object instance, object value);

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.16.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    internal class XamlMember : global::Windows.UI.Xaml.Markup.IXamlMember
    {
        global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlTypeInfoProvider _provider;
        string _name;
        bool _isAttachable;
        bool _isDependencyProperty;
        bool _isReadOnly;

        string _typeName;
        string _targetTypeName;

        public XamlMember(global::RadarFlight.FlightsRadar_XamlTypeInfo.XamlTypeInfoProvider provider, string name, string typeName)
        {
            _name = name;
            _typeName = typeName;
            _provider = provider;
        }

        public string Name { get { return _name; } }

        public global::Windows.UI.Xaml.Markup.IXamlType Type
        {
            get { return _provider.GetXamlTypeByName(_typeName); }
        }

        public void SetTargetTypeName(string targetTypeName)
        {
            _targetTypeName = targetTypeName;
        }
        public global::Windows.UI.Xaml.Markup.IXamlType TargetType
        {
            get { return _provider.GetXamlTypeByName(_targetTypeName); }
        }

        public void SetIsAttachable() { _isAttachable = true; }
        public bool IsAttachable { get { return _isAttachable; } }

        public void SetIsDependencyProperty() { _isDependencyProperty = true; }
        public bool IsDependencyProperty { get { return _isDependencyProperty; } }

        public void SetIsReadOnly() { _isReadOnly = true; }
        public bool IsReadOnly { get { return _isReadOnly; } }

        public Getter Getter { get; set; }
        public object GetValue(object instance)
        {
            if (Getter != null)
                return Getter(instance);
            else
                throw new global::System.InvalidOperationException("GetValue");
        }

        public Setter Setter { get; set; }
        public void SetValue(object instance, object value)
        {
            if (Setter != null)
                Setter(instance, value);
            else
                throw new global::System.InvalidOperationException("SetValue");
        }
    }
}

