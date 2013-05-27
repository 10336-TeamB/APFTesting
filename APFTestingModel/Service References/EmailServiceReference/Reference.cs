﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APFTestingModel.EmailServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmailDataContract", Namespace="http://schemas.datacontract.org/2004/07/EmailService")]
    [System.SerializableAttribute()]
    public partial class EmailDataContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BodyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.KeyValuePair<string, string>[] ExamField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid ExamIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ExamTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ExaminerNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RequiredPackerPacksField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ToAddressField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Body {
            get {
                return this.BodyField;
            }
            set {
                if ((object.ReferenceEquals(this.BodyField, value) != true)) {
                    this.BodyField = value;
                    this.RaisePropertyChanged("Body");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] Exam {
            get {
                return this.ExamField;
            }
            set {
                if ((object.ReferenceEquals(this.ExamField, value) != true)) {
                    this.ExamField = value;
                    this.RaisePropertyChanged("Exam");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid ExamId {
            get {
                return this.ExamIdField;
            }
            set {
                if ((this.ExamIdField.Equals(value) != true)) {
                    this.ExamIdField = value;
                    this.RaisePropertyChanged("ExamId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ExamType {
            get {
                return this.ExamTypeField;
            }
            set {
                if ((this.ExamTypeField.Equals(value) != true)) {
                    this.ExamTypeField = value;
                    this.RaisePropertyChanged("ExamType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ExaminerNumber {
            get {
                return this.ExaminerNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.ExaminerNumberField, value) != true)) {
                    this.ExaminerNumberField = value;
                    this.RaisePropertyChanged("ExaminerNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RequiredPackerPacks {
            get {
                return this.RequiredPackerPacksField;
            }
            set {
                if ((this.RequiredPackerPacksField.Equals(value) != true)) {
                    this.RequiredPackerPacksField = value;
                    this.RaisePropertyChanged("RequiredPackerPacks");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Subject {
            get {
                return this.SubjectField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectField, value) != true)) {
                    this.SubjectField = value;
                    this.RaisePropertyChanged("Subject");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ToAddress {
            get {
                return this.ToAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.ToAddressField, value) != true)) {
                    this.ToAddressField = value;
                    this.RaisePropertyChanged("ToAddress");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmailServiceReference.IEmailServiceOperation", CallbackContract=typeof(APFTestingModel.EmailServiceReference.IEmailServiceOperationCallback))]
    public interface IEmailServiceOperation {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IEmailServiceOperation/SendEmail")]
        void SendEmail(APFTestingModel.EmailServiceReference.EmailDataContract emailData);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IEmailServiceOperation/SendEmail")]
        System.Threading.Tasks.Task SendEmailAsync(APFTestingModel.EmailServiceReference.EmailDataContract emailData);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmailServiceOperationCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IEmailServiceOperation/EmailIsSent")]
        void EmailIsSent(System.Guid examId, bool success);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmailServiceOperationChannel : APFTestingModel.EmailServiceReference.IEmailServiceOperation, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmailServiceOperationClient : System.ServiceModel.DuplexClientBase<APFTestingModel.EmailServiceReference.IEmailServiceOperation>, APFTestingModel.EmailServiceReference.IEmailServiceOperation {
        
        public EmailServiceOperationClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public EmailServiceOperationClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public EmailServiceOperationClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public EmailServiceOperationClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public EmailServiceOperationClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SendEmail(APFTestingModel.EmailServiceReference.EmailDataContract emailData) {
            base.Channel.SendEmail(emailData);
        }
        
        public System.Threading.Tasks.Task SendEmailAsync(APFTestingModel.EmailServiceReference.EmailDataContract emailData) {
            return base.Channel.SendEmailAsync(emailData);
        }
    }
}
