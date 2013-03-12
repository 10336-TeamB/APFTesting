using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APFTestingModel;
using Microsoft.Practices.Unity;

namespace APFTestingUI
{
    public class ControllerModule
    {
        IUnityContainer _iocContainer;

        public ControllerModule(IUnityContainer container) 
        {
            _iocContainer = container; 
        }
        
        public void Init()
        {
            //Add any logic here to look in a config file, check a property
            //or any other condition to decide which implementation is registered.
            //register the database logger to the ILogger interface
            _iocContainer.RegisterType(typeof(IFacade), typeof(Facade));
        }
    }
}