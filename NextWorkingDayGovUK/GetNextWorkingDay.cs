using Tasks;
using Microsoft.Xrm.Sdk;
using System;
using System.ServiceModel;

namespace Actions
    {
    public class GetNextWorkingDay : IPlugin
        {
        #region Constructor/Configuration
        private string _secureConfig = null;
        private string _unsecureConfig = null;
        private ITracingService _tracing;
        private IPluginExecutionContext _context;
        public GetNextWorkingDay(string unsecure , string secureConfig)
           
            {
            _secureConfig = secureConfig;
            _unsecureConfig = unsecure;
            }
        #endregion

        public void Execute(IServiceProvider serviceProvider)
            {
            _tracing = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            _context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            try
                {
                _context.OutputParameters["Output"]  = ExecuteBusinessLogic();   
                }
            catch (FaultException<OrganizationServiceFault> fex)
                {
                throw new InvalidPluginExecutionException("Service Exception: " + fex.Message);
                }
            catch (Exception ex)
                {
                throw new InvalidPluginExecutionException("Generic Exception: " + ex.Message + "Extra bits: ");
                }

            }

        public DateTime ExecuteBusinessLogic()
            {
            var service = new NextWorkingDayService();                
            return service.GetNextWorkingDay(
                    service.RetrieveHolidays(_context.InputParameters["Region"] as string),
                    DateTime.Parse(_context.InputParameters["Date"].ToString()),
                    int.Parse(_context.InputParameters["WorkingDays"].ToString())
                );
            }
        }
    }
